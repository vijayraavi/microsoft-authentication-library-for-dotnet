// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Identity.Client.Cache.Items;
using Microsoft.Identity.Client.Internal;
using Microsoft.Identity.Client.OAuth2;
using Microsoft.Identity.Client.Utils;
using Microsoft.Identity.Json.Linq;

namespace Microsoft.Identity.Client.PoP
{
    internal class PoPAuthenticationScheme : IAuthenticationScheme
    {
        private static readonly DateTime s_jwtBaselineTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly HttpRequestMessage _httpRequestMessage;
        private readonly IPoPCryptoProvider _popCryptoProvider;

        /// <summary>
        /// Creates POP tokens, i.e. tokens that are bound to an HTTP request and are digitally signed.
        /// </summary>
        public PoPAuthenticationScheme(HttpRequestMessage httpRequestMessage, IPoPCryptoProvider popCryptoProvider)
        {
            _httpRequestMessage = httpRequestMessage;
            _popCryptoProvider = popCryptoProvider ??
                throw new ArgumentNullException(nameof(popCryptoProvider));
        }

        public string AuthorizationHeaderPrefix => "PoP";

        public string KeyId => _popCryptoProvider.KeyId;

        public IDictionary<string, string> GetTokenRequestParams()
        {
            return new Dictionary<string, string>() {
                { OAuth2Parameter.TokenType, PoPRequestParameters.PoPTokenType},
                { PoPRequestParameters.RequestConfirmation, _popCryptoProvider.GetPublicKeyJwk()}
            };
        }

        public string FormatAccessToken(MsalAccessTokenCacheItem atItem)
        {
            var header = new JObject
            {
                { JsonWebTokenConstants.ReservedHeaderParameters.Algorithm, _popCryptoProvider.Algorithm },
                { JsonWebTokenConstants.ReservedHeaderParameters.KeyId, _popCryptoProvider.KeyId },
                { JsonWebTokenConstants.ReservedHeaderParameters.Type, JsonWebTokenConstants.JWTHeaderType}
            };

            var payload = new JObject
                {
                    { PoPClaimTypes.At, atItem.Secret},
                    { PoPClaimTypes.Ts, (long)(DateTime.UtcNow - s_jwtBaselineTime).TotalSeconds },
                    { PoPClaimTypes.HttpMethod,  _httpRequestMessage.Method.Method}, 
                    { PoPClaimTypes.Host, _httpRequestMessage.RequestUri.Host},
                    { PoPClaimTypes.Path, _httpRequestMessage.RequestUri.AbsolutePath }
                    // TODO: add query q support
                };

            return CreateJWS(payload.ToString(Json.Formatting.None), header.ToString(Json.Formatting.None));
        }

        /// <summary>
        /// Creates a JWS (json web signature) as per: https://tools.ietf.org/html/rfc7515
        /// Format: header.payload.signed_payload
        /// </summary>
        private string CreateJWS(string payload, string header)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Base64UrlHelpers.Encode(Encoding.UTF8.GetBytes(header)));
            sb.Append(".");
            sb.Append(Base64UrlHelpers.Encode(payload));
            string headerAndPayload = sb.ToString();

            sb.Append(".");
            sb.Append(Base64UrlHelpers.Encode(_popCryptoProvider.Sign(Encoding.UTF8.GetBytes(headerAndPayload))));

            return sb.ToString();
        }
    }
}
