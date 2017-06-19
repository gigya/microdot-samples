using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigya.Microdot.Interfaces.Configuration;

namespace InventoryService.Grains
{
    [ConfigurationRoot("Inventory", RootStrategy.ReplaceClassNameWithPath)]
    public class InventoryConfig: IConfigObject
    {
        /// <summary>
        /// Max number of items which can be stored on Stock
        /// </summary>
        public uint MaxItemsInStock { get; set; }

        /// <summary>
        /// Send warning if stock is lower than this quantity
        /// </summary>
        public uint LowStockWarning { get; set; }
    }
}
