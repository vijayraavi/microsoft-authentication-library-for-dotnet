﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Cache;
using Microsoft.Identity.Client.Internal;
using Microsoft.Identity.Client.OAuth2;
using Microsoft.Identity.Client.Utils;
using Microsoft.Identity.Test.Common.Core.Mocks;

namespace Microsoft.Identity.Test.Unit
{
    internal static class TestConstants
    {
        public static SortedSet<string> s_scope
        {
            get
            {
                return new SortedSet<string>(new[] { "r1/scope1", "r1/scope2" });
            }
        }

        public const string ScopeStr = "r1/scope1 r1/scope2";
        public static readonly string[] s_graphScopes = new[] { "user.read" };
        public const uint JwtToAadLifetimeInSeconds = 60 * 10; // Ten minutes
        public const string ClientCredentialAudience = "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/v2.0";
        public const string AutomationTestThumbprint = "79fbcbeb5cd28994e50daff8035bacf764b14306";
        public const string RSATestCertThumbprint = "9498C1B91CA4F2CFFEA10C53DCC8301F9A8D4BDE";

        public static readonly SortedSet<string> s_scopeForAnotherResource = new SortedSet<string>(new[] { "r2/scope1", "r2/scope2" });
        public static readonly SortedSet<string> s_cacheMissScope = new SortedSet<string>(new[] { "r3/scope1", "r3/scope2" });
        public const string ScopeForAnotherResourceStr = "r2/scope1 r2/scope2";
        public const string Uid = "my-uid";
        public const string Utid = "my-utid";
        public const string Utid2 = "my-utid2";
        public const string Common = "common";
        public const string TenantId = "751a212b-4003-416e-b600-e1f48e40db9f";
        public const string AadAuthorityWithTestTenantId = "https://login.microsoftonline.com/751a212b-4003-416e-b600-e1f48e40db9f/";
        public static readonly IDictionary<string, string> s_clientAssertionClaims = new Dictionary<string, string> { { "client_ip", "some_ip" }, { "aud", "some_audience" } };
        public const string RTSecret = "someRT";
        public const string ATSecret = "some-access-token";

        public const string HomeAccountId = Uid + "." + Utid;

        public const string ProductionPrefNetworkEnvironment = "login.microsoftonline.com";
        public const string ProductionPrefCacheEnvironment = "login.windows.net";
        public const string ProductionNotPrefEnvironmentAlias = "sts.windows.net";

        public const string AuthorityNotKnownCommon = "https://sts.access.edu/common/";
        public const string AuthorityNotKnownTenanted = "https://sts.access.edu/" + Utid + "/";

        public const string SovereignNetworkEnvironment = "login.microsoftonline.de";
        public const string AuthorityHomeTenant = "https://" + ProductionPrefNetworkEnvironment + "/home/";
        public const string AuthorityUtidTenant = "https://" + ProductionPrefNetworkEnvironment + "/" + Utid + "/";
        public const string AuthorityUtid2Tenant = "https://" + ProductionPrefNetworkEnvironment + "/" + Utid2 + "/";
        public const string AuthorityGuestTenant = "https://" + ProductionPrefNetworkEnvironment + "/guest/";
        public const string AuthorityCommonTenant = "https://" + ProductionPrefNetworkEnvironment + "/common/";
        public const string AuthorityCommonTenantNotPrefAlias = "https://" + ProductionNotPrefEnvironmentAlias + "/common/";

        public const string PrefCacheAuthorityCommonTenant = "https://" + ProductionPrefCacheEnvironment + "/common/";
        public const string AuthorityOrganizationsTenant = "https://" + ProductionPrefNetworkEnvironment + "/organizations/";
        public const string AuthorityGuidTenant = "https://" + ProductionPrefNetworkEnvironment + "/12345679/";
        public const string AuthorityGuidTenant2 = "https://" + ProductionPrefNetworkEnvironment + "/987654321/";
        public const string AuthorityWindowsNet = "https://" + ProductionPrefCacheEnvironment + "/" + Utid + "/";
        public const string ADFSAuthority = "https://fs.msidlab8.com/adfs/";
        public const string B2CAuthority = "https://login.microsoftonline.in/tfp/tenant/policy/";
        public const string B2CLoginAuthority = "https://sometenantid.b2clogin.com/tfp/sometenantid/policy/";
        public const string B2CLoginAuthorityWrongHost = "https://anothertenantid.b2clogin.com/tfp/sometenantid/policy/";
        public const string B2CCustomDomain = "https://catsareamazing.com/tfp/catsareamazing/policy/";
        public const string B2CLoginAuthorityUsGov = "https://sometenantid.b2clogin.us/tfp/sometenantid/policy/";
        public const string B2CLoginAuthorityMoonCake = "https://sometenantid.b2clogin.cn/tfp/sometenantid/policy/";
        public const string B2CLoginAuthorityBlackforest = "https://sometenantid.b2clogin.de/tfp/sometenantid/policy/";
        public const string ClientId = "d3adb33f-c0de-ed0c-c0de-deadb33fc0d3";
        public const string ClientId2 = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
        public const string FamilyId = "1";
        public const string UniqueId = "unique_id";
        public const string IdentityProvider = "my-idp";
        public const string Name = "First Last";
        public const string Claims = "claim1claim2";
        public const string DisplayableId = "displayable@id.com";
        public const string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        public const string ClientSecret = "client_secret";
        public const string DefaultPassword = "password";
        public const string AuthorityTestTenant = "https://" + ProductionPrefNetworkEnvironment + "/" + Utid + "/";
        public const string DiscoveryEndPoint = "discovery/instance";
        public const string DefaultAuthorizationCode = "DefaultAuthorizationCode";
        public const string DefaultAccessToken = "DefaultAccessToken";
        public const string DefaultClientAssertion = "DefaultClientAssertion";
        public const string RawClientId = "eyJ1aWQiOiJteS11aWQiLCJ1dGlkIjoibXktdXRpZCJ9";
        public const string XClientSku = "x-client-SKU";
        public const string XClientVer = "x-client-Ver";
        public const TokenSubjectType TokenSubjectTypeUser = 0;
        public const string TestMessage = "test message";

        public const string LocalAccountId = "test_local_account_id";
        public const string GivenName = "Joe";
        public const string FamilyName = "Doe";
        public const string Username = "joe@localhost.com";

        //This value is only for testing purposes. It is for a certificate that is not used for anything other than running tests
        public const string _defaultx5cValue = @"MIIDHzCCAgegAwIBAgIQM6NFYNBJ9rdOiK+C91ZzFDANBgkqhkiG9w0BAQsFADAgMR4wHAYDVQQDExVBQ1MyQ2xpZW50Q2VydGlmaWNhdGUwHhcNMTIwNTIyMj
IxMTIyWhcNMzAwNTIyMDcwMDAwWjAgMR4wHAYDVQQDExVBQ1MyQ2xpZW50Q2VydGlmaWNhdGUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCh7HjK
YyVMDZDT64OgtcGKWxHmK2wqzi2LJb65KxGdNfObWGxh5HQtjzrgHDkACPsgyYseqxhGxHh8I/TR6wBKx/AAKuPHE8jB4hJ1W6FczPfb7FaMV9xP0qNQrbNGZU
YbCdy7U5zIw4XrGq22l6yTqpCAh59DLufd4d7x8fCgUDV3l1ZwrncF0QrBRzns/O9Ex9pXsi2DzMa1S1PKR81D9q5QSW7LZkCgSSqI6W0b5iodx/a3RBvW3l7d
noW2fPqkZ4iMcntGNqgsSGtbXPvUR3fFdjmg+xq9FfqWyNxShlZg4U+wE1v4+kzTJxd9sgD1V0PKgW57zyzdOmTyFPJFAgMBAAGjVTBTMFEGA1UdAQRKMEiAEM
9qihCt+12P5FrjVMAEYjShIjAgMR4wHAYDVQQDExVBQ1MyQ2xpZW50Q2VydGlmaWNhdGWCEDOjRWDQSfa3ToivgvdWcxQwDQYJKoZIhvcNAQELBQADggEBAIm6
gBOkSdYjXgOvcJGgE4FJkKAMQzAhkdYq5+stfUotG6vZNL3nVOOA6aELMq/ENhrJLC3rTwLOIgj4Cy+B7BxUS9GxTPphneuZCBzjvqhzP5DmLBs8l8qu10XAsh
y1NFZmB24rMoq8C+HPOpuVLzkwBr+qcCq7ry2326auogvVMGaxhHlwSLR4Q1OhRjKs8JctCk2+5Qs1NHfawa7jWHxdAK6cLm7Rv/c0ig2Jow7wRaI5ciAcEjX7
m1t9gRT1mNeeluL4cZa6WyVXqXc6U2wfR5DY6GOMUubN5Nr1n8Czew8TPfab4OG37BuEMNmBpqoRrRgFnDzVtItOnhuFTa0=";

        public static string Defaultx5cValue
        {
            get
            {
                return Regex.Replace(_defaultx5cValue, @"\r\n?|\n", string.Empty);
            }
        }

        public static readonly IDictionary<string, string> s_extraQueryParams
            = new Dictionary<string, string>()
            {
                {"extra", "qp" },
                {"key1", "value1%20with%20encoded%20space"},
                {"key2", "value2"}
            };

        public const string MsalCCAKeyVaultUri = "https://buildautomation.vault.azure.net/secrets/AzureADIdentityDivisionTestAgentSecret/e360740b3411452b887e6c3097cb1037";
        public const string MsalOBOKeyVaultUri = "https://buildautomation.vault.azure.net/secrets/IdentityDivisionDotNetOBOServiceSecret/243c858fe7b9411cbcf05a2a284d8a84";
        public const string FociApp1 = "https://buildautomation.vault.azure.net/secrets/automation-foci-app1/466ec9e219f2412b8664a92446a8f3bc";
        public const string FociApp2 = "https://buildautomation.vault.azure.net/secrets/automation-foci-app2/214a15bf554e41a7aef4e44707311cfb";

        public enum AuthorityType { B2C };
        public static string[] s_prodEnvAliases = new string[] {
                                "login.microsoftonline.com",
                                "login.windows.net",
                                "login.microsoft.com",
                                "sts.windows.net"};

        public static readonly string s_userIdentifier = CreateUserIdentifier();



        public static string CreateUserIdentifier()
        {
            // return CreateUserIdentifier(Uid, Utid);
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", Uid, Utid);
        }

        public static string CreateUserIdentifier(string uid, string utid)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", uid, utid);
        }

        public static MsalTokenResponse CreateMsalTokenResponse()
        {
            return new MsalTokenResponse
            {
                IdToken = MockHelpers.CreateIdToken(UniqueId, DisplayableId),
                AccessToken = "access-token",
                ClientInfo = MockHelpers.CreateClientInfo(),
                ExpiresIn = 3599,
                CorrelationId = "correlation-id",
                RefreshToken = "refresh-token",
                Scope = s_scope.AsSingleString(),
                TokenType = "Bearer"
            };
        }

        public static readonly Account s_user = new Account(s_userIdentifier, DisplayableId, ProductionPrefNetworkEnvironment);

        public const string OnPremiseAuthority = "https://fs.contoso.com/adfs/";
        public const string OnPremiseClientId = "on_premise_client_id";
        public const string OnPremiseUniqueId = "on_premise_unique_id";
        public const string OnPremiseDisplayableId = "displayable@contoso.com";
        public const string FabrikamDisplayableId = "displayable@fabrikam.com";
        public const string OnPremiseHomeObjectId = OnPremiseUniqueId;
        public const string OnPremisePolicy = "on_premise_policy";
        public const string OnPremiseRedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        public const string OnPremiseClientSecret = "on_premise_client_secret";
        public const string OnPremiseUid = "my-OnPremise-UID";
        public const string OnPremiseUtid = "my-OnPremise-UTID";

        public static readonly Account s_onPremiseUser = new Account(
            string.Format(CultureInfo.InvariantCulture, "{0}.{1}", OnPremiseUid, OnPremiseUtid), OnPremiseDisplayableId, null);

        public const string BrokerExtraQueryParameters = "extra=qp&key1=value1%20with%20encoded%20space&key2=value2";
        public const string BrokerClaims = "testClaims";

        public static readonly ClientCredentialWrapper s_onPremiseCredentialWithSecret = ClientCredentialWrapper.CreateWithSecret(ClientSecret);
        public static readonly ClientCredentialWrapper s_credentialWithSecret = ClientCredentialWrapper.CreateWithSecret(ClientSecret);

        public const string DiscoveryJsonResponse = @"{
                        ""tenant_discovery_endpoint"":""https://login.microsoftonline.com/tenant/.well-known/openid-configuration"",
                        ""api-version"":""1.1"",
                        ""metadata"":[
                            {
                            ""preferred_network"":""login.microsoftonline.com"",
                            ""preferred_cache"":""login.windows.net"",
                            ""aliases"":[
                                ""login.microsoftonline.com"", 
                                ""login.windows.net"",
                                ""login.microsoft.com"",
                                ""sts.windows.net""]},
                            {
                            ""preferred_network"":""login.partner.microsoftonline.cn"",
                            ""preferred_cache"":""login.partner.microsoftonline.cn"",
                            ""aliases"":[
                                ""login.partner.microsoftonline.cn"",
                                ""login.chinacloudapi.cn""]},
                            {
                            ""preferred_network"":""login.microsoftonline.de"",
                            ""preferred_cache"":""login.microsoftonline.de"",
                            ""aliases"":[
                                    ""login.microsoftonline.de""]},
                            {
                            ""preferred_network"":""login.microsoftonline.us"",
                            ""preferred_cache"":""login.microsoftonline.us"",
                            ""aliases"":[
                                ""login.microsoftonline.us"",
                                ""login.usgovcloudapi.net""]},
                            {
                            ""preferred_network"":""login-us.microsoftonline.com"",
                            ""preferred_cache"":""login-us.microsoftonline.com"",
                            ""aliases"":[
                                ""login-us.microsoftonline.com""]}
                        ]
                }";

        public const string TokenResponseJson =
            "{\"token_type\":\"Bearer\"," +
            "\"scope\":\"user_impersonation\"," +
            "\"expires_in\":\"3600\"," +
            "\"ext_expires_in\":\"3600\"," +
            "\"expires_on\":\"1566165638\"," +
            "\"not_before\":\"1566161738\"," +
            "\"resource\":\"user.read\"," +
            "\"access_token\":\"at_secret\"," +
            "\"refresh_token\":\"rt_secret\"," +
            "\"id_token\":\"idtoken.\"," +
            "\"client_info\":\"eyJ1aWQiOiI2ZWVkYTNhMS1jM2I5LTRlOTItYTk0ZC05NjVhNTBjMDZkZTciLCJ1dGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3In0\"}";

        public const string InteractiveRequestApiIdPlusCorrelationId = "1005,ad8c894a-557f-48c0-b045-c129590c344e,";
        public const string InteractiveRequestApiId = "1005";
    }

    internal static class Adfs2019LabConstants
    {
        public const string Authority = "https://fs.msidlab8.com/adfs";
        public const string AppId = "TestAppIdentifier";
        public const string PublicClientId = "PublicClientId";
        public const string ConfidentialClientId = "ConfidentialClientId";
        public const string ClientRedirectUri = "http://localhost:8080";
        public static readonly SortedSet<string> s_supportedScopes = new SortedSet<string>(new[] { "openid", "email", "profile" });
        public const string ADFS2019ClientSecretURL = "https://buildautomation.vault.azure.net/secrets/ADFS2019ClientCredSecret/";
    }
}
