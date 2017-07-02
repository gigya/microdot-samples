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

                IGpuService gpuService = kernel.Get<IGpuService>();
                var random = new Random();

                while (true)
                {
                    byte[] toHash = Encoding.ASCII.GetBytes(random.Next(100).ToString());
                    byte[] hashed = gpuService.Hash("SHA256", 3, toHash).Result;
                    CountAndPrint();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }


        static DateTime stats = DateTime.Now;
        static long calls = 0;

        static void CountAndPrint()
        {
            ++calls;
            if ((DateTime.Now - stats).TotalSeconds >= 5)
            {
                Console.WriteLine($"Rate: {calls / (DateTime.Now - stats).TotalSeconds:0} requests/sec");
                stats = DateTime.Now;
                calls = 0;
            }
        }
    }
}
