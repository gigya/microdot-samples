using Gigya.Microdot.Orleans.Ninject.Host;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Logging.NLog;

namespace InventoryService
{
    public class InventoryServiceHost : MicrodotOrleansServiceHost
    {
        public override ILoggingModule GetLoggingModule() => new NLogModule();
    }
}