using AccountsService.Interface;
using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Newtonsoft.Json;
using Ninject;
using System;

namespace AccountsService.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", "./Configs/envVars.json");
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "./Configs/loadPaths.json");
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", "./Configs/");

            var kernel = new StandardKernel();
            kernel.Load<MicrodotModule>();
            kernel.Load<NLogModule>();

            try
            {
                var service = kernel.Get<IAccountsService>();
                switch (args[0])
                {
                    case "set":
                        service.SaveAccount(
                            new Account {
                                Email = args[1],
                                Password = args[2] }).Wait();
                        break;
                    case "get":
                        Console.WriteLine(
                            JsonConvert.SerializeObject(
                                service.GetAccount(args[1]).Result, Formatting.Indented));
                        break;
                    case "check":
                        Console.WriteLine(
                            service.CheckPassword(args[1], args[2]).Result);
                        break;
                    default:
                        Console.Error.WriteLine("Unknown command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
