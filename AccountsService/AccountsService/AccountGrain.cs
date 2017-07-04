using AccountsService.Interface;
using Orleans;
using System.Threading.Tasks;
using System;
using System.IO;
using Newtonsoft.Json;
using GpuService.Interface;
using System.Text;

namespace AccountsService
{

    public interface IAccountGrain : IGrainWithStringKey
    {
        Task SaveAccount(Account account);
        Task<Account> GetAccount();
        Task<bool> CheckPassword(string password);
    }


    public class AccountGrain : Grain, IAccountGrain
    {
        Account state;
        IGpuService gpuService;

        public AccountGrain(IGpuService gpuService)
        {
            this.gpuService = gpuService;
        }

        public async Task SaveAccount(Account account)
        {
            account.Password = await GetHash(account.Password);
            state = account;
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            using (var writer = File.CreateText("../../../" + account.Email))
                await writer.WriteLineAsync(json);
        }

        private async Task<string> GetHash(string text)
        {
            byte[] toHash = Encoding.ASCII.GetBytes(text);
            byte[] hashed = await gpuService.Hash("SHA256", 3, toHash);
            return Convert.ToBase64String(hashed);
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
