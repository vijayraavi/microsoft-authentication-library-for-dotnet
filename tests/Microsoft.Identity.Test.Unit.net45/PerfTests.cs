// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;
using Microsoft.Identity.Test.Common;
using Microsoft.Identity.Test.Common.Core.Helpers;
using Microsoft.Identity.Test.LabInfrastructure;
using Microsoft.Identity.Test.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Identity.Test.Integration.HeadlessTests
{
    [TestClass]
    public class PerfTests : TestBase
    {

        private static readonly string[] s_scopes = { "User.Read" };

        [TestMethod]
        [DeploymentItem(@"Resources\MultiCloudTokenCache.json")]
        public async Task PerfAsync()
        {
            using (var harness = CreateTestHarness())
            {
                var pca = PublicClientApplicationBuilder
                           .Create(MsalTestConstants.ClientId)
                           .WithHttpManager(harness.HttpManager)
                           .WithAuthority(MsalTestConstants.AuthorityCommonTenant)
                           .BuildConcrete();

                var initialCache = pca.InitializeTokenCacheFromFile(
                    ResourceHelper.GetTestResourceRelativePath("MultiCloudTokenCache.json"),
                    updateATExpiry: true);

                string path = Path.GetTempFileName();
                pca.ConfigureFileTokenCache(path, initialCache);

                var acc = await pca.GetAccountsAsync().ConfigureAwait(false);
            }




            //IAccount account = null;
            //using (var validator = new PerformanceValidator(1000, "GetAccounts"))
            //{
            //    Trace.WriteLine("GetAccounts started");
            //    Stopwatch st = new Stopwatch();
            //    st.Start();

            //    var accounts = await pca.GetAccountsAsync().ConfigureAwait(false);
            //    st.Stop();
            //    account = accounts.Single();

            //    Debug.WriteLine($"GetAccounts finished in {st.ElapsedMilliseconds} ms");
            //}

            //using (var validator = new PerformanceValidator(2000, "AcquireTokenSilent"))
            //{
            //    Trace.WriteLine("AcquireTokenSilent started");

            //    var st = new Stopwatch();
            //    st.Start();

            //    var res = await pca.AcquireTokenSilent(s_scopes, account)
            //        .ExecuteAsync()
            //        .ConfigureAwait(false);
            //    st.Stop();

            //    Debug.WriteLine($"AcquireTokenSilent finished in {st.ElapsedMilliseconds} ms");

            //}

        }

    }
}
