using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Ninject.Host;
using Gigya.Microdot.SharedLogic;
using GpuService.Interface;
using Ninject;
using System;

namespace GpuService
{

    class GpuServiceHost: MicrodotServiceHost<IGpuService>
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", "envVars.json");

            new GpuServiceHost().Run();
        }

        protected override ILoggingModule GetLoggingModule() => new NLogModule();

        protected override void Configure(IKernel kernel, BaseCommonConfig commonConfig)
        {
            kernel.Bind<IGpuService>().To<GpuService>();
        }
    }

}
