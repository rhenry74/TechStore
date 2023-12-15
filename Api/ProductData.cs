using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.Azure.Cosmos;

namespace Api;

public interface IProductData
{
    Task<Product> AddProductAsync(Product product);
    Task<bool> DeleteProductAsync(string id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> UpdateProductAsync(Product product);
}

public class ProductData : IProductData
{
    private Microsoft.Azure.Cosmos.Container _Container;
    public ProductData()
    {
        var url = System.Environment.GetEnvironmentVariable("CosmosClientUrl");
        var auth = System.Environment.GetEnvironmentVariable("CosmosAuth");
        CosmosClient client = new CosmosClient(url,auth);
        var dbResult = client.CreateDatabaseIfNotExistsAsync("TechStore").GetAwaiter().GetResult();
        Database database = dbResult.Database;
        var containterResult = database.CreateContainerIfNotExistsAsync(
            "Products",
            "/partitionKeyPath",
            400).GetAwaiter().GetResult();
        _Container = containterResult.Container;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        try
        {
            product.id = Guid.NewGuid().ToString();
            var response = await _Container.CreateItemAsync(product);
            return product;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw ex;
        }
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var response = await _Container.UpsertItemAsync(product);
        return product;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        string partitionKeyPath = "US";
        var response = await _Container.DeleteItemAsync<Product>(id, new PartitionKey(partitionKeyPath));
        return response.StatusCode == System.Net.HttpStatusCode.OK;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        using (FeedIterator<Product> feedIterator = _Container.GetItemQueryIterator<Product>(
            "select * from Products"))
        {
            List<Product> products = new List<Product>();
            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Product> response = await feedIterator.ReadNextAsync();
                foreach (var item in response)
                {
                    products.Add(item);
                }
            }
            return products.AsEnumerable();
        }
    }
}
