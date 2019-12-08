using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace mukeshsingh
{
    public static class ProcessUsersQueue
    {
        [FunctionName("ProcessUsersQueue")]
        public static async Task Run([QueueTrigger("users", Connection = "AzureWebJobsStorage")]User user, 
            IBinder binder,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processing: {user}");

            var licenceblob = await binder.BindAsync<TextWriter>(
                new BlobAttribute($"licenses/{user.Id}.lic") { Connection = "AzureWebJobsStorage"});

            licenceblob.WriteLine($"Id: {user.Id}");
            licenceblob.WriteLine($"Name: {user.Name}");
            licenceblob.WriteLine($"Mobile: {user.Mobile}");
            licenceblob.WriteLine($"Email: {user.Email}");

            var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.Email + "secret"));

            licenceblob.WriteLine($"SecretCode: {BitConverter.ToString(hash).Replace("-","")}");

            log.Info($"C# Queue trigger function processed: {user}");

        }
    }
}
