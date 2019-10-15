using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Identity.Test.LabInfrastructure;

namespace CommonCache.Test.Common
{
    public class TestInputData
    {
        public IEnumerable<LabResponse> LabUserDatas { get; set; }
        public string ResultsFilePath { get; set; }
        public CacheStorageType StorageType { get; set; }
    }
}
