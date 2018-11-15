using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MonkeyFinder.Model;
using MonkeyFinder.Services;
using Xamarin.Forms;

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
    }
}
