using MAD.API.Namely.Api;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MAD.API.Namely
{
    public class NamelyApiClient
    {
        public string ApiToken { get; }
        public string ApiClientName { get; }

        private readonly JsonSerializer jsonSerializer = new JsonSerializer();

        public NamelyApiClient(string apiToken, string apiClientName)
        {
            if (string.IsNullOrEmpty(apiToken))
                throw new ArgumentException("Must have a value.", nameof(apiToken));

            if (string.IsNullOrEmpty(apiClientName))
                throw new ArgumentException("Must have a value.", nameof(apiClientName));

            this.ApiToken = apiToken;
            this.ApiClientName = apiClientName;
        }

        public async Task<ReportResponse> GetReport(string reportGuid)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp($"https://{this.ApiClientName}.namely.com/api/v1/reports/{reportGuid}");
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {this.ApiToken}");
            request.Headers.Add(HttpRequestHeader.Accept, "application/json");

            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                return this.jsonSerializer.Deserialize<ReportResponse>(jr);
            }
        }
    }
}
