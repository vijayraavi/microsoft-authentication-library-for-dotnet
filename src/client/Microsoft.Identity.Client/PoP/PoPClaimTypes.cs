// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Identity.Client.PoP
{
    internal static class PoPClaimTypes
    {
        #region JSON keys for Http request

        /// <summary>
        /// Access token with response cnf
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string At = "at";

        /// <summary>
        /// Http method (GET or POST)
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string HttpMethod = "m";

        /// <summary>
        /// Timestamp
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string Ts = "ts";

        /// <summary>
        /// Uri host
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string Host = "u";

        /// <summary>
        /// Uri path
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string Path = "p";


        /// <summary>
        /// Uri path
        /// https://tools.ietf.org/html/draft-ietf-oauth-signed-http-request-03#section-3
        /// </summary>
        public const string Query = "q";

        #endregion
    }

    internal static class PoPRequestParameters
    {
        public const string PoPTokenType = "pop";
        public const string RequestConfirmation = "req_cnf";
    }
}
