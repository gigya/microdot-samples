using System;
using System.Text;
using Gigya.Microdot.Logging.NLog;
using Ninject;
using Gigya.Microdot.Ninject;
using GpuService.Interface;

namespace GpuService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var kernel = new StandardKernel();
                kernel.Load<MicrodotModule>();
                kernel.Load<NLogModule>();
                var gpuService = kernel.Get<IGpuService>();
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
