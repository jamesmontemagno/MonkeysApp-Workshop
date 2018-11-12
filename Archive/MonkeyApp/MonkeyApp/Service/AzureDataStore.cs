using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MonkeyApp.Interfaces;
using MonkeyApp.Model;
using MonkeyApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureDataStore))]
namespace MonkeyApp.Service
{
    public class AzureDataStore : IDataStore
    {
        public MobileServiceClient MobileService { get; set; }

        IMobileServiceSyncTable<Monkey> monkeyTable;
        bool initialized = false;

        public AzureDataStore()
        {
            // This is a sample read-only azure site for demo
            // Follow the readme.md in the GitHub repo on how to setup your own.
            MobileService = new MobileServiceClient(
            "https://monkeyapp5.azurewebsites.net",
            "",
            "");
        }

        public async Task Init()
        {
            initialized = true;
            const string path = "syncstore.db";
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Monkey>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            monkeyTable = MobileService.GetSyncTable<Monkey>();
        }


        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            if (!initialized)
                await Init();

            await monkeyTable.PullAsync("allMonkeys", monkeyTable.CreateQuery());

            return await monkeyTable.OrderBy(x=>x.Name).ToEnumerableAsync();
        }

        
        static readonly AzureDataStore instance = new AzureDataStore();
        /// <summary>
        /// Gets the instance of the Azure Web Service
        /// </summary>
        public static AzureDataStore Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
