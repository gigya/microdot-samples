using Gigya.Microdot.Logging.NLog;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Orleans.Ninject.Host;

namespace AccountsService
{

    class AccountsServiceHost : MicrodotOrleansServiceHost
    {
        public override ILoggingModule GetLoggingModule() => new NLogModule();

        static void Main(string[] args)
        {
            new AccountsServiceHost().Run();
        }

    }
}
