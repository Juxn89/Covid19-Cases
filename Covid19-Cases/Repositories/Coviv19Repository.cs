using Covid19_Cases.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Linq;

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
        public async Task<List<DataDto>> GetRegions() {            
            var url = $"{Constans.Constans.REGION_ENDPOINT}";
            var json = await DoRequestAsync(url);
            var data = DeserializeJSON<RegionDto>(json);
            return data.data.ToList();
        }

        public async Task<List<DataReportDto>> GetReport(string regionFilter = null)
        {
            var url = $"{Constans.Constans.REPORT_ENDPOINT}";
            if (regionFilter != null)
                url = $"{url}?region_name={regionFilter}";

            var json = await DoRequestAsync(url);
            var data = DeserializeJSON<Covid19Dto>(json);

            return data.data.OrderByDescending(a => a.confirmed).Take(10).ToList();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Do a requesto to API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> DoRequestAsync(string url) {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
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

        private T DeserializeJSON<T>(string json) {
           return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion
    }
}