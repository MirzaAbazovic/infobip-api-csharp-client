using System;
using System.Collections.Specialized;

namespace InfobipClientLib.Infobip.Api.Helpers
{
    public static class Helpers
    {
        public static NameValueCollection ParseQueryString(string requestQueryString)
        {
            NameValueCollection rc = new NameValueCollection();
            string[] ar1 = requestQueryString.Split(new char[] { '&', '?' });
            foreach (string row in ar1)
            {
                if (string.IsNullOrEmpty(row)) continue;
                int index = row.IndexOf('=');
                if (index < 0) continue;
                rc.Add(Uri.UnescapeDataString(row.Substring(0, index)), Uri.UnescapeDataString(row.Substring(index + 1)));         
            }
            return rc;
        }

        internal static char UrlEncode(string messageId)
        {
            throw new NotImplementedException();
        }
    }
}
