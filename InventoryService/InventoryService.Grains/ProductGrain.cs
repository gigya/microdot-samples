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
        private int CurrentStock { get; set; }

        public Task<int> GetCurrentStock()
        {
            return Task.FromResult(CurrentStock);
        }

        public Task ModifyStock(int quantity)
        {
            var updatedStock = CurrentStock + quantity;

            if (updatedStock < 0)
                throw new OutOfStockException($"Not enough stock to complete the operation. Only {CurrentStock} items in stock.");

            if (updatedStock > 1000)
                throw new RequestException($"Cannot add stock - operation will cause the stock to exceed maximum of 1000 by {updatedStock - 1000}.");

            CurrentStock = updatedStock;

            if (updatedStock < 5)
            {
                // TODO: Send low stock warning -or- order more stock.
            }

            return Task.CompletedTask;
        }
    }
}