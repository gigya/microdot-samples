using System;
using System.IO;
using System.Reflection;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Environment variables can be set either by code (like we do here), or by Operation System.
            // There exists another option of configuring environment variables using a Json file. See: https://github.com/gigya/microdot/wiki/Customization-by-Environment-Variables
            
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Path.Combine(Environment.CurrentDirectory, "config"));
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "./config/configPaths.json");
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", Environment.CurrentDirectory);

            Environment.SetEnvironmentVariable("ENV", "dev"); // Changing the value to "prod" will cause the "prod" configuration to take effect

            new InventoryServiceHost().Run();
        }

    }
}