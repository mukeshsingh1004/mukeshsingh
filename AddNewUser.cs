using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace mukeshsingh
{
    public static class AddNewUser
    {
        [FunctionName("AddNewUser")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
        HttpRequestMessage req, 
        [Queue ("users")] IAsyncCollector<User> userQueue,
        TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            var body = await req.Content.ReadAsStringAsync();
            log.Info(body);
            var user = JsonConvert.DeserializeObject<User>(body);
            await userQueue.AddAsync(user);

            log.Info($"User {user.Name} Sucessfully added");

            return new OkObjectResult($"User {user.Name} sucessfully added");
        }
    }
}