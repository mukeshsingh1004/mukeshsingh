using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;

namespace mukeshsingh
{
    //public static class GetAllUsers
    //{
    //    [FunctionName("GetAllUsers")]
    //    public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "User")]
    //    HttpRequestMessage req,
    //    [Table("user")] CloudTable usertable,
    //    TraceWriter log)
    //    {
    //        log.Info("Getting all users.");
                
    //        return new OkObjectResult();
    //    }
    //}
}
