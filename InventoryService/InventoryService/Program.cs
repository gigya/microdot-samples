using System;
using System.IO;

namespace InventoryService
{
    static class Program
    {
        static void Main()
        {
            // Environment variables can be set either by code (like we do here), by the Operating System
            // or via a JSON file (see https://github.com/gigya/microdot/wiki/Environment-Variables).

            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Path.Combine(Environment.CurrentDirectory, "config"));
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "./config/configPaths.json");
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", Environment.CurrentDirectory);
            Environment.SetEnvironmentVariable("DC", "global");
            Environment.SetEnvironmentVariable("ENV", "dev"); // Changing the value to "prod" will cause the "prod" configuration to take effect

            new InventoryServiceHost().Run();
        }
    }
}