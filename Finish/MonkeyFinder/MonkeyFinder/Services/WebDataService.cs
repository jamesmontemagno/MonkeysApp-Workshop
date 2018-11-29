using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MonkeyFinder.Model;
using MonkeyFinder.Services;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Text;
using System;

[assembly: Dependency(typeof(WebDataService))]
namespace MonkeyFinder.Services
{
    public class WebDataService : IDataService
    {
        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());
        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            //var json = await Client.GetStringAsync("https://montemagno.com/monkeys.json");
            var json = await Client.GetStringAsync("https://xam-workshop-twitch-func.azurewebsites.net/api/GetAllMonkeys");
            var all = Monkey.FromJson(json);
            return all;
        }

        public async Task UpdateDetails(string newDetails, string monkeyId)
        {

            var detailUpdate = new DetailUpdate { NewDetails = newDetails };
            var detailUpdateJson = JsonConvert.SerializeObject(detailUpdate);

            string updateUri = $"https://xam-workshop-twitch-func.azurewebsites.net/api/update/{monkeyId}";

            var req = new HttpRequestMessage(HttpMethod.Post, updateUri);

            req.Content = new StringContent(detailUpdateJson, Encoding.UTF8, "application/json");

            await Client.SendAsync(req);
        }
    }
}
