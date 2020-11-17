using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EBTimeLogCreator
{
    public class TimeEntryRestService : IRestService
    {
        readonly HttpClient client;

        public TimeEntryRestService()
        {
            client = new HttpClient();
        }

        public async Task<HttpResponseMessage> SaveTimeLogAsync(TimeEntry item, string auth_string)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = uri,
                    Headers =
                    {
                        { HttpRequestHeader.Authorization.ToString(), auth_string},
                        { HttpRequestHeader.Accept.ToString(), "application/json" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json;charset=UTF-8" }
                    },
                    Content = content,
                };

                return await client.SendAsync(httpRequestMessage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
                return null;
            }
        }
    }
}
