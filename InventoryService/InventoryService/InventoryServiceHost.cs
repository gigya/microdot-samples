using Gigya.Microdot.Orleans.Ninject.Host;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Logging.NLog;
using Orleans;
using System.Threading.Tasks;

namespace InventoryService
{
    public class InventoryServiceHost : MicrodotOrleansServiceHost
    {
        public override ILoggingModule GetLoggingModule() => new NLogModule();

        protected override Task AfterOrleansStartup(IGrainFactory grainFactory)
        {
            return base.AfterOrleansStartup(grainFactory);
        }
    }
}