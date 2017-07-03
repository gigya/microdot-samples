using Gigya.Common.Contracts.HttpService;
using System.Threading.Tasks;

namespace AccountsService.Interface
{


    [HttpService(basePort: 30000)]
    public interface IAccountsService
    {
        Task SaveAccount(Account account);
        Task<Account> GetAccount(string email);
        Task<bool> CheckPassword(string email, string password);
    }


    public class Account
    {
        public string Email;
        public string Password;
        // ...
    }
}
