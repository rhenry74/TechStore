using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api;

public class ProductsDelete
{
    private readonly IProductData productData;

    public ProductsDelete(IProductData productData)
    {
        this.productData = productData;
    }

    [FunctionName("ProductsDelete")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "products/{productId}")] HttpRequest req,
        string productId,
        ILogger log)
    {
        var result = await productData.DeleteProductAsync(productId);

        if (result)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
}
