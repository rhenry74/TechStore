using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Client.Shared;
using Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace Client
{
    public class AzureBlobPersistence : IPersistence
    {
        private HttpClient _apiClient;

        public AzureBlobPersistence(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<string> SaveAsync(ArtifactFileInfo fileInfo, Stream sourceStream)
        {
            try
            {
                PersistenceInfo blobStoreData = await _apiClient.GetFromJsonAsync<PersistenceInfo>("api/persistence");

                //var blobUri = new Uri("https://"
                //    + "23storage23" +
                //    ".blob.core.windows.net/" +
                //    "upload" + "/" + fileInfo.FileName);

                var blobUri = new Uri(blobStoreData.Url);

                AzureSasCredential credential = new AzureSasCredential(blobStoreData.Auth);
                BlobClient blobClient = new BlobClient(blobUri, credential, new BlobClientOptions());

                var res = await blobClient.UploadAsync((sourceStream), new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = fileInfo.FileType },
                    TransferOptions = new StorageTransferOptions
                    {
                        InitialTransferSize = 1024 * 1024,
                        MaximumConcurrency = 10
                    },
                    ProgressHandler = new Progress<long>((progress) =>
                    {
                        var progressNow = (100.0 * progress / fileInfo.FileSize).ToString("0");
                    })
                });

                return fileInfo.FileName;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

    }
}
