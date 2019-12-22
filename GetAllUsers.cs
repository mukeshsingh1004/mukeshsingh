using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;

namespace mukeshsingh
{
    public static class GetAllUsers
    {
        [FunctionName("GetAllUsers")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
        HttpRequestMessage req,
        [Table("userstable")] CloudTable usertable,
        TraceWriter log)
        {
            log.Info("Getting all users.");
            TableQuery<User> rangeQuery = new TableQuery<User>();

            //foreach (User user
            //    in await usertable.ExecuteQuerySegmentedAsync(rangeQuery, null))
            //{
            //    log.Info($"{user.PartitionKey}\t{user.RowKey}\t{user.Timestamp}\t{user.Name}");
            //}

            return new OkObjectResult(await usertable.ExecuteQuerySegmentedAsync(rangeQuery, null));
        }
    }
}
