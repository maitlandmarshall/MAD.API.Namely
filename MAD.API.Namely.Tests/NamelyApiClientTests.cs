using MAD.API.Namely;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MaitlandsInterfaceFramework.Namely.Tests
{
    [TestClass]
    public class NamelyApiClientTests
    {
        private string reportGuid;
        private NamelyApiClient client;

        [TestInitialize]
        public void Init()
        {
            Dictionary<string, string> apiKeys = 
                JsonConvert.DeserializeObject<Dictionary<string, string>>(
                    File.ReadAllText("NamelyApiKeys.txt")
                );

            this.reportGuid = apiKeys["NamelyReportGuid"];

            string apiToken = apiKeys["NamelyToken"];
            string clientName = apiKeys["NamelyClientName"];

            this.client = new NamelyApiClient(apiToken, clientName);
        }

        [TestMethod]
        public async Task GetReportTest()
        {
            MAD.API.Namely.Api.ReportResponse reportResult = await this.client.GetReport(this.reportGuid);
        }
    }
}
