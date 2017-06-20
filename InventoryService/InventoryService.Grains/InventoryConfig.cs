using Gigya.Microdot.Interfaces.Configuration;

namespace InventoryService.Grains
{    
    public class InventoryConfig: IConfigObject
    {
        /// <summary>
        /// Max number of items which can be stored on Stock
        /// </summary>
        public uint MaxQuantityInStock { get; set; }

        /// <summary>
        /// Send warning if stock is lower than this quantity
        /// </summary>
        public uint LowStockWarningQuantity { get; set; }
    }
}
