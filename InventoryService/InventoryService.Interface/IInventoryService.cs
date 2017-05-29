using System;
using System.Threading.Tasks;
using Gigya.Common.Contracts.HttpService;

namespace InventoryService.Interface
{
    [HttpService(10000)]
    public interface IInventoryService
    {
        Task ShipItems(Product product, int quantity);
        Task RestockItems(Product product, int quantity);
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
