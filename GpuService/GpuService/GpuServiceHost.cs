using System;
using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Ninject.Host;
using Gigya.Microdot.SharedLogic;
using GpuService.Interface;
using Ninject;
using Gigya.Microdot.Interfaces.Logging;

namespace GpuService
{
    class GpuServiceHost: MicrodotServiceHost<IGpuService>
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);
            new GpuServiceHost().Run();
        }

        protected override ILoggingModule GetLoggingModule() => new NLogModule();

        protected override void Configure(IKernel kernel, BaseCommonConfig commonConfig)
        {
            kernel.Bind<IGpuService>().To<GpuService>();
            kernel.Get<ILog>().Error("tresint 123");
        }
    }

}
