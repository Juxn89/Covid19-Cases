using Covid19_Cases.DTO;
using Covid19_Cases.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using static Covid19_Cases.Emuns.Enums;

namespace Covid19_Cases.Repositories
{
    public class Covid19Repository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Covid19Repository()
        {

        }

        #region Public methods
        public async Task<List<SelectListItem>> GetRegionsAsync() {            
            var url = $"{Constans.Constans.REGION_ENDPOINT}";
            var json = await DoRequestAsync(url);
            var data = DeserializeJSON<RegionDto>(json);
            return data.data.ToList().ConvertoToSelectListItem();
        }

        public async Task<List<DataReportDto>> GetReportAsync(string regionFilter = null)
        {
            var url = $"{Constans.Constans.REPORT_ENDPOINT}";
            if (regionFilter != null && !string.IsNullOrEmpty(regionFilter))
                url = $"{url}?region_name={regionFilter}";

            var json = await DoRequestAsync(url);
            var data = DeserializeJSON<Covid19Dto>(json);

            return data.data.OrderByDescending(a => a.confirmed).Take(10).ToList();
        }

        public async Task<byte[]> GenerateFile(int type, string region = null) {
            var info = await GetReportAsync(region);

            switch (type)
            {
                case (int)ExportFile.CSV:
                    return GenerateCSV(info);
                case (int)ExportFile.XML:
                    return GenerateXML(info);
                default:
                    return GenerateJSON(info);
            }
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

        private byte[] GenerateJSON(List<DataReportDto> data) {
            string jsonData = new JavaScriptSerializer().Serialize(data);
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(jsonData);
            return byteArray;
        }

        private byte[] GenerateCSV(List<DataReportDto> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Region,Province,Confirmed,Deaths");
            foreach (var item in data)
            {
                sb.AppendLine($"{item.region.name},{item.region.province},{item.confirmed},{item.deaths}");
            }

            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
            return byteArray;
        }

        private byte[] GenerateXML(List<DataReportDto> data)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("Covid-19Cases");
            xml.AppendChild(root);

            foreach (var item in data)
            {
                XmlElement child = xml.CreateElement(item.region.iso);
                child.SetAttribute("Confirmed", item.confirmed.ToString());
                child.SetAttribute("Death", item.deaths.ToString());
                root.AppendChild(child);
            }

            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(xml.OuterXml.ToString());
            return byteArray;
        }
        #endregion
    }
}

