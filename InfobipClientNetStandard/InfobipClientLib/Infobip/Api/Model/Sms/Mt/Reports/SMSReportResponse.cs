using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Reports;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSReportResponse
    {
        [JsonProperty("results")]
        public IList<SMSReport> Results { get; set; }


    }
}