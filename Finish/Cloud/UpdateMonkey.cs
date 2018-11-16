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
using System.Net.Http;

namespace MonkeyCloud
{
    public static class UpdateMonkey
    {
        [FunctionName("UpdateMonkey")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "update/{monkeyId}")] HttpRequestMessage req,
            [CosmosDB(
                databaseName:"monkey-db",
                collectionName:"monkey-coll",
                ConnectionStringSetting="CosmosConnectionString",
                Id="{monkeyId}"
            )]Monkey monkey,
            [CosmosDB(
                databaseName:"monkey-db",
                collectionName:"monkey-coll",
                ConnectionStringSetting="CosmosConnectionString"
            )]out dynamic monkeyToWrite,
            ILogger log)
        {
            var updatedDetailTask = req.Content.ReadAsAsync<DetailUpdate>();

            Task.WhenAll(updatedDetailTask);

            var updatedDetail = updatedDetailTask.Result;

            monkey.Details = updatedDetail.NewDetails;

            monkeyToWrite = monkey;
            
            return new OkObjectResult(monkey);
        }
    }
}
