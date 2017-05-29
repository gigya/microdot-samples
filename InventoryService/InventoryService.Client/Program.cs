using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Ninject;
using System;

namespace InventoryService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);

            var kernel = new StandardKernel();
            kernel.Load<MicrodotModule>();
            kernel.Load<NLogModule>();

            var trader = kernel.Get<FortuneCookieTrader>();
            trader.Start().Wait();
        }
    }
}
