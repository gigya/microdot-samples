using System;
using System.Text;
using Gigya.Microdot.Logging.NLog;
using Ninject;
using Gigya.Microdot.Ninject;
using GpuService.Interface;
using Gigya.Microdot.SharedLogic;

namespace GpuService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT", Environment.CurrentDirectory);
            Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE", "envVars.json");

            try
            {
                var kernel = new StandardKernel();
                kernel.Load<MicrodotModule>();
                kernel.Load<NLogModule>();
                CurrentApplicationInfo.Init("GpuService.Client");

                IGpuService gpuService = kernel.Get<IGpuService>();
                byte[] hashed = gpuService.Hash("SHA256", 3, Encoding.ASCII.GetBytes("test")).Result;
                Console.Out.WriteLine(BitConverter.ToString(hashed));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
