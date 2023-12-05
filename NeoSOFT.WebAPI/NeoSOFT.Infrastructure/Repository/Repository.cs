using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using NeoSOFT.Infrastructure.Context;
using NeoSOFT.Infrastructure.Contract;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeoSOFT.Infrastructure.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        
        public Repository(IDbContext DbContextSettings, CosmosClient cosmosClient)
        {
            var dbName=cosmosClient.GetDatabase(DbContextSettings.DatabaseName);
            _container=dbName.GetContainer(DbContextSettings.ContainerName);

        }

        public async Task<List<T>> GetAllAsync(string queryDefination)
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryDefination));
            var results = new List<T>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return  results.ToList();

        }

        public async Task<T> GetByIdAsync(string id)
        {
            var partitionKey = new PartitionKey(id);
            var response = await _container.ReadItemAsync<T>(id, partitionKey);
            return response.Resource;
            
        }

        public async Task<T> CreateAsync(T entity)
        {
            var response = await _container.CreateItemAsync(entity);
            return response.Resource;
            
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            var partitionKey = new PartitionKey(id);
            await _container.ReplaceItemAsync(entity, id, partitionKey);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var partitionKey = new PartitionKey(id);
            var response=await _container.DeleteItemAsync<T>(id, partitionKey);
            if(response.StatusCode!=null)
                return true;
            else return false;

        }
       
      
    }
}
