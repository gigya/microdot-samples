using Gigya.Microdot.Interfaces.Logging;
using InventoryService.Interface;
using Orleans;
using Orleans.Concurrency;
using System;
using System.Threading.Tasks;

namespace InventoryService.Grains
{
    public interface IInventoryServiceGrain : IInventoryService, IGrainWithIntegerKey { }

    [Reentrant]
    [StatelessWorker]
    public class InventoryServiceGrain : Grain, IInventoryServiceGrain
    {
        private ILog Log { get; }

        public InventoryServiceGrain(ILog log)
        {
            Log = log;
        }

        public async Task RestockItems(Product product, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Restock quantity must be greater than 0.");

            var grain = GrainFactory.GetGrain<IProductGrain>(product.Id);
            await grain.ModifyStock(quantity);
            Log.Info(_ => _("Product successfully restocked", unencryptedTags: new { product.Name, product.Id, quantity }));
        }

        public async Task ShipItems(Product product, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Ship quantity must be greater than 0.");

            var grain = GrainFactory.GetGrain<IProductGrain>(product.Id);
            await grain.ModifyStock(-quantity);
            Log.Info(_ => _("Product successfully shipped", unencryptedTags: new { product.Name, product.Id, quantity }));

            // TODO: Send notification to customer that item has shipped
        }
    }
}