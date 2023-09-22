using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Catalog.API.DBHelper
{
    public class DynamoDBTableCreator
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public DynamoDBTableCreator(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task CreateTableAsync<T>()
        {
            Type type = typeof(T);
            DynamoDBTableAttribute tableAttribute = type.GetCustomAttribute<DynamoDBTableAttribute>();
            if (tableAttribute == null)
            {
                throw new InvalidOperationException("The provided class does not have a dynamo db table attribute");
            }
            string tableName = tableAttribute.TableName;
            //check if table exist
            bool tableExist = await DoesTableExistAsync(tableName);
            if (tableExist)
            {
                Console.WriteLine($"Table '{tableName}' already exists. Skipping table creation.");
                return;
            }
            //create table if it does not exist
        }

        private async Task<bool> DoesTableExistAsync(string tableName)
        {
            var tables = await _dynamoDbClient.ListTablesAsync();
            return tables.TableNames.Contains(tableName);
        }
    }
}
