using System;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "");
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", Environment.CurrentDirectory);

            new InventoryServiceHost().Run();
        }
    }
}