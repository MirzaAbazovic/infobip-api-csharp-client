using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infobip.Api.Model.Omni.Scenarios;
using System.Web;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class UpdateScenario
    {
        private static string path = "/omni/1/scenarios/{scenarioKey}";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public UpdateScenario(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Scenario> ExecuteAsync(string scenarioKey, Scenario bodyObject)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                string endpoint = path;
                endpoint = endpoint.Replace("{scenarioKey}", HttpUtility.UrlEncode(scenarioKey));

                string requestJson = JsonConvert.SerializeObject(bodyObject, Settings);
                HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endpoint, content);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Scenario>(contents, Settings);
                }
                else
                {
                    throw new InfobipApiException(
                        response.StatusCode,
                        JsonConvert.DeserializeObject<ApiErrorResponse>(contents, Settings)
                    );
                }
            }
        }

    }
}