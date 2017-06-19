using System;
using Gigya.Common.Contracts.Exceptions;
using InventoryService.Interface;
using Orleans;
using System.Threading.Tasks;

namespace InventoryService.Grains
{
    public interface IProductGrain : IGrainWithGuidKey
    {
        Task<int> GetCurrentStock();
        Task ModifyStock(int quantity);
    }

    public class ProductGrain : Grain, IProductGrain
    {
        protected readonly Func<InventoryConfig> GetConfig;

        public ProductGrain(Func<InventoryConfig> getConfig)
        {
            GetConfig = getConfig;
        }

        private int CurrentStock { get; set; }

        public Task<int> GetCurrentStock()
        {
            return Task.FromResult(CurrentStock);
        }

        public Task ModifyStock(int quantity)
        {
            var config = GetConfig();

            var updatedStock = CurrentStock + quantity;

            if (updatedStock < 0)
                throw new OutOfStockException($"Not enough stock to complete the operation. Only {CurrentStock} items in stock.");

            if (updatedStock > config.MaxItemsInStock)
                throw new RequestException($"Cannot add stock - operation will cause the stock to exceed maximum of {config.MaxItemsInStock} by {config.MaxItemsInStock - 1000}.");

            CurrentStock = updatedStock;

            if (updatedStock < config.LowStockWarning)
            {
                // TODO: Send low stock warning -or- order more stock.
            }

            return Task.CompletedTask;
        }
    }
}