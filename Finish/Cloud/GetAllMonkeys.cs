using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using MonkeyCloud.Model;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace MonkeyCloud
{
    public static class GetAllMonkeys
    {
        [FunctionName("GetAllMonkeys")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName:"monkey-db",
                collectionName:"monkey-coll",
                ConnectionStringSetting="CosmosConnectionString",
                SqlQuery="SELECT * FROM c"
            )]IEnumerable<Monkey> allMonkeys,
            ILogger log)
        {
            return new OkObjectResult(allMonkeys);
        }
    }
}
