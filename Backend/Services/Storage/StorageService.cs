using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Backend.Services.Storage
{
    public class StorageService: IStorageService
    {
        public StorageService(IConfiguration configuration)
        {
            var key = configuration.GetValue<string>("AzureStorage");
            CloudStorageAccount storage = CloudStorageAccount.Parse(key);
            var tableClient = storage.CreateCloudTableClient();
            var table = tableClient.GetTableReference("data");
            Task.Run(async()=> await table.CreateIfNotExistsAsync());
            
            var queueClient = storage.CreateCloudQueueClient();
                        

        }
    }
}