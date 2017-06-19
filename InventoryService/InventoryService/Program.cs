using System;
using System.IO;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Environment variables can be set either by EnvironmentVariables file, or manually, by code.
            // In current sample project, we use both ways.
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", Path.Combine(Environment.CurrentDirectory, "config", GetEnvVarsFile()));

            // The following two rows set variables manually, but actually it is not needed, 
            // because variables which were not set before, will be set anyway by EnvironmentVarialbes file
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Path.Combine(Environment.CurrentDirectory, "config"));
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "./config/loadPaths.json");
            
            new InventoryServiceHost().Run();
        }

        private static string GetEnvVarsFile()
        {
#if DEBUG
            return "environmentVariables_dev.json";
#else
            return "environmentVariables_prod.json";
#endif
        }
    }
}