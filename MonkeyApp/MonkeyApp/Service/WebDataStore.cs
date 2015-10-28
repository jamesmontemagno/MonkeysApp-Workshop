using MonkeyApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyApp.Model;
using Xamarin.Forms;
using MonkeyApp.Service;
using System.Net.Http;
using Newtonsoft.Json;

//[assembly:Dependency(typeof(WebDataStore))]
namespace MonkeyApp.Service
{
    public class WebDataStore : IDataStore
    {
        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

            return JsonConvert.DeserializeObject<List<Monkey>>(json);

        }
    }
}
