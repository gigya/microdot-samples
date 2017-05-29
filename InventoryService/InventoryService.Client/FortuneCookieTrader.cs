using Gigya.Microdot.Interfaces.Logging;
using InventoryService.Interface;
using System;
using System.Threading.Tasks;

namespace InventoryService.Client
{
    public class FortuneCookieTrader
    {
        private IInventoryService Inventory { get; }
        private ILog Log { get; }

        private Product Cookie { get; }

        public FortuneCookieTrader(IInventoryService inventory, ILog log)
        {
            Inventory = inventory;
            Log = log;

            var productId = Guid.NewGuid();
            var cookieNumber = BitConverter.ToUInt16(productId.ToByteArray(), 0);
            Cookie = new Product { Id = productId, Name = $"Fortune Cookie #{cookieNumber}" };
        }

        public async Task Start()
        {
            while (true)
            {
                try
                {
                    await Inventory.ShipItems(Cookie, 3);
                    Log.Info(_ => _("Shipped three fortune cookies.", unencryptedTags: new { Cookie.Name }));
                    await Task.Delay(1000);
                }
                catch (OutOfStockException)
                {
                    Log.Error("Out of stock! Restocking 10 items.");
                    await Inventory.RestockItems(Cookie, 10);
                    await Task.Delay(5000);
                }
            }
        }
    }
}
