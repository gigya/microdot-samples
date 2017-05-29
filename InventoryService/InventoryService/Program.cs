using System;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);
            new InventoryServiceHost().Run();
        }
    }
}