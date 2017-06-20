using System;
using Gigya.Common.Contracts.Exceptions;
using InventoryService.Interface;
using Orleans;
using System.Threading.Tasks;
using Gigya.Microdot.Interfaces.Logging;

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
        private ILog Log { get; }

        public ProductGrain(Func<InventoryConfig> getConfig, ILog log)
        {
            GetConfig = getConfig;
            Log = log;
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

            if (updatedStock > config.MaxQuantityInStock)
                throw new RequestException($"Cannot add stock - operation will cause the stock to exceed maximum of {config.MaxQuantityInStock} by {updatedStock - config.MaxQuantityInStock}.");

            CurrentStock = updatedStock;

            if (updatedStock < config.LowStockWarningQuantity)
            {
                // TODO: Send low stock warning -or- order more stock.
            }

            Log.Info(_=>_($"Stock updated. Current quantity: {CurrentStock}. Maximum quantity allowed: {config.MaxQuantityInStock}."));
            return Task.CompletedTask;
        }
    }
}