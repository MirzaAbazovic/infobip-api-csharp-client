using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infobip.Api.Model.Sms.Mo.Reports;
using System.Collections.Specialized;
using InfobipClientLib.Infobip.Api.Helpers;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetReceivedMessages
    {
        private static string path = "/sms/1/inbox/reports";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public GetReceivedMessages(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<MOReportResponse> ExecuteAsync(GetReceivedMessagesExecuteContext context)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                NameValueCollection queryParameters = Helpers.ParseQueryString(string.Empty);
                SetQueryParamIfNotNull(queryParameters, "limit", context.Limit);

                string queryString = queryParameters.ToString();
                string endpoint = path + "?" + queryString;

                var response = await client.GetAsync(endpoint);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<MOReportResponse>(contents, Settings);
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

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object value)
        {
            if (value != null)
            {
                queryParameters[key] = value.ToString();
            }
        }

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object[] values)
        {
            if (values != null && values.Length > 0)
            {
                queryParameters[key] = string.Join(",", values);
            }
        }
    }
}