using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infobip.Api.Model.Omni.Logs;
using System.Collections.Specialized;
using System.Web;
using InfobipClientLib.Infobip.Api.Helpers;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetOmniLogs
    {
        private static string path = "/omni/1/logs";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public GetOmniLogs(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<OmniLogsResponse> ExecuteAsync(GetOmniLogsExecuteContext context)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                NameValueCollection queryParameters = Helpers.ParseQueryString(string.Empty);
                SetQueryParamIfNotNull(queryParameters, "from", context.From);
                SetQueryParamIfNotNull(queryParameters, "to", context.To);
                SetQueryParamIfNotNull(queryParameters, "bulkId", context.BulkId);
                SetQueryParamIfNotNull(queryParameters, "messageId", context.MessageId);
                SetQueryParamIfNotNull(queryParameters, "generalStatus", context.GeneralStatus);
                SetQueryParamIfNotNull(queryParameters, "channel", context.Channel);
                SetQueryParamIfNotNull(queryParameters, "sentSince", context.SentSince);
                SetQueryParamIfNotNull(queryParameters, "sentUntil", context.SentUntil);
                SetQueryParamIfNotNull(queryParameters, "limit", context.Limit);
                SetQueryParamIfNotNull(queryParameters, "mcc", context.Mcc);
                SetQueryParamIfNotNull(queryParameters, "mnc", context.Mnc);

                string queryString = queryParameters.ToString();
                string endpoint = path + "?" + queryString;

                var response = await client.GetAsync(endpoint);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<OmniLogsResponse>(contents, Settings);
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