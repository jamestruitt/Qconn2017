using System.IO;
using System.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using System;
using Newtonsoft.Json;

namespace LicensePlateFunctionDemo
{
    public static class FileUploadMonitor
    {
        private static string inputQueue = "licenseplateinput";
        private static string connectionString = Environment.GetEnvironmentVariable("licenseplatestoragepoc");
        private static CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

        [FunctionName("FileUploadMonitor")]
        public static void Run([BlobTrigger("uploadedtags/{name}", Connection = "licenseplatestoragepoc")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"Processing blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            var blobUri = GetBlobUri(name, log);

            WriteToQueue(name, blobUri, log);
        }

        private static string GetBlobUri(string name, TraceWriter log)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("uploadedtags");

            var currentBlob = container.GetBlobReference(name);
            log.Info($"Blob URI : {currentBlob.Uri}");

            return currentBlob.Uri.ToString();
        }

        private static void WriteToQueue(string fileName, string blobUri, TraceWriter log)
        {
            // Create the queue client.
            var queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue.
            var queue = queueClient.GetQueueReference(inputQueue);

            // Create the queue if it doesn't already exist.
            queue.CreateIfNotExists();

            queue.EncodeMessage = false;

            var uploadMessage = new UploadMessage
            {
                FileName = fileName,
                URL = blobUri,
                ReceivedDate = DateTime.Now
            };

            // Create a message and add it to the queue.
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(uploadMessage));
            
            queue.AddMessage(message);

            log.Info($"Message Written: {message.AsString}");
        }
    }
     
}
