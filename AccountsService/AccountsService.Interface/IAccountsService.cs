using Gigya.Common.Contracts.HttpService;
using System.Threading.Tasks;

namespace AccountsService.Interface
{


    [HttpService(basePort: 30000)]
    public interface IAccountsService
    {
        [PublicEndpoint("acc.saveAccount")]
        Task SaveAccount(Account account);

        [PublicEndpoint("acc.getAccount")]
        Task<Account> GetAccount(string email);

        [PublicEndpoint("acc.checkPassword")]
        Task<bool> CheckPassword(string email, string password);
    }


    public class Account
    {
        public string Email;
        public string Password;
        // ...
    }
}
