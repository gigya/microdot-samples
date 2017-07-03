using AccountsService.Interface;
using Orleans;
using System.Threading.Tasks;
using System;
using System.IO;
using Newtonsoft.Json;

namespace AccountsService
{

    interface IAccountGrain : IGrainWithStringKey
    {
        Task SaveAccount(Account account);
        Task<Account> GetAccount();
        Task<bool> CheckPassword(string password);
    }


    class AccountGrain : Grain, IAccountGrain
    {
        Account state;

        public async Task SaveAccount(Account account)
        {
            state = account;
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            using (var writer = File.CreateText("../../../" + account.Email))
                await writer.WriteLineAsync(json);
        }

        public override async Task OnActivateAsync()
        {
            string email = this.GetPrimaryKeyString();
            if (File.Exists("../../../" + email))
            {
                using (var reader = File.OpenText("../../../" + email))
                {
                    string json = await reader.ReadToEndAsync();
                    state = JsonConvert.DeserializeObject<Account>(json);
                }
            }
        }

        public Task<Account> GetAccount()
        {
            return Task.FromResult(state);
        }

        public Task<bool> CheckPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
