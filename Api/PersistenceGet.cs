using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using Data;

namespace Api;

public class PersistenceGet
{
    [FunctionName("PersistenceGet")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "persistence")] HttpRequest req)
    {
        PersistenceInfo info = new PersistenceInfo()
        {
            Url = System.Environment.GetEnvironmentVariable("AzureStorageClientUrl"),
            Auth = System.Environment.GetEnvironmentVariable("AzureStorageAuth")
        };
        var result = new OkObjectResult(info);
        return await Task.FromResult<IActionResult>(result);
    }
}
