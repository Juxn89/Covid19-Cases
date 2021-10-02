using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Covid19_Cases.Repositories
{
    public class Coviv19Repository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Coviv19Repository()
        {

        }

        #region Public methods
        public void GetRegion(string region = null) {
            throw new NotImplementedException();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Do a requesto to API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> DoRequest(string url) {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-19-statistics.p.rapidapi.com/reports?region_name=US"),
                Headers = {
                    { "x-rapidapi-host", "covid-19-statistics.p.rapidapi.com" },
                    { "x-rapidapi-key", "a4338f828cmsh813df6acc28d67ap1cd557jsn55ecf735a144" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
        }
        #endregion
    }
}