using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Ninject.Host;
using Gigya.Microdot.SharedLogic;
using GpuService.Interface;
using Ninject;

namespace GpuService
{

    class GpuServiceHost: MicrodotServiceHost<IGpuService>
    {
        static void Main(string[] args)
        {
            new GpuServiceHost().Run();
        }

        protected override ILoggingModule GetLoggingModule() => new NLogModule();

        protected override void Configure(IKernel kernel, BaseCommonConfig commonConfig)
        {
            kernel.Bind<IGpuService>().To<GpuService>();
        }
    }

}
