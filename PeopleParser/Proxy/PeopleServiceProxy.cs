using Newtonsoft.Json;
using PeopleParser.BusinessEntitites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleParser.Proxy
{
    public class PeopleServiceProxy : IPeopleServiceProxy
    {
        public async Task<IEnumerable<People>> GetAll()
        {
            var client = new HttpClient();
            var url = ConfigurationManager.AppSettings["PeopleServiceUrl"].ToString();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var res = await client.GetAsync("people.json");
            res.EnsureSuccessStatusCode();
            var response = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<People>>(response);
        }
    }
}
