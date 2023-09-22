using Amazon.DynamoDBv2;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Catalog.API.DatabaseSeeder
{
    public class SeedDatabase
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var dbScope = serviceProvider.CreateScope();
            var dynamoDb = dbScope.ServiceProvider.GetRequiredService<IAmazonDynamoDB>();
            var tableCreator = new DynamoDBTableCreator(dynamoDb);
        }
    }
}
