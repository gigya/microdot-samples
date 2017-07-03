using System;
using System.Text;
using Gigya.Microdot.Logging.NLog;
using Ninject;
using Gigya.Microdot.Ninject;
using GpuService.Interface;
using Gigya.Microdot.Interfaces.Configuration;

namespace GpuService.Client
{

    class HashingSettings : IConfigObject
    {
        public string Algorithm { get; set; }
        public int Rounds { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Environment.SetEnvironmentVariable("GIGYA_ENVVARS_FILE",      "./Configs/envVars.json");
                Environment.SetEnvironmentVariable("GIGYA_CONFIG_PATHS_FILE", "./Configs/loadPaths.json");
                Environment.SetEnvironmentVariable("GIGYA_CONFIG_ROOT",       "./Configs/");

                var kernel = new StandardKernel();
                kernel.Load<MicrodotModule>();
                kernel.Load<NLogModule>();
                var settings = kernel.Get<Func<HashingSettings>>();

                IGpuService gpuService = kernel.Get<IGpuService>();
                var random = new Random();

                while (true)
                {
                    byte[] toHash = Encoding.ASCII.GetBytes(random.Next(100).ToString());
                    byte[] hashed = gpuService.Hash(settings().Algorithm, settings().Rounds, toHash).Result;
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
