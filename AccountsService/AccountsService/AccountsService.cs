using System.Threading.Tasks;
using AccountsService.Interface;
using Orleans;
using Orleans.Concurrency;

namespace AccountsService
{
    public interface IAccountsServiceGrain : IAccountsService, IGrainWithIntegerKey { }


    [Reentrant]
    [StatelessWorker]
    public class AccountsService : Grain, IAccountsServiceGrain
    {
        public async Task SaveAccount(Account account)
        {
            await GrainFactory.GetGrain<IAccountGrain>(account.Email).SaveAccount(account);
        }

        public async Task<Account> GetAccount(string email)
        {
            return await GrainFactory.GetGrain<IAccountGrain>(email).GetAccount();
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            return await GrainFactory.GetGrain<IAccountGrain>(email).CheckPassword(password);
        }

    }
}
