using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Gigya.Common.Contracts.Exceptions;
using GpuService.Interface;

namespace GpuService
{

    class GpuService: IGpuService
    {
        public async Task<byte[]> Hash(string algorithm, int rounds, byte[] input)
        {
            switch (algorithm)
            {
                case "SHA256":
                    byte[] result = input;
                    while (rounds-- > 0)
                        result = SHA256.Create().ComputeHash(result);
                    return result;
                default: throw new RequestException("Unknown algorithm");
            }
        }

        public Task<Tuple<byte[], byte[]>> Encrypt(string algorithm, byte[] key, byte[] input)
        {
            throw new RequestException("Unknown algorithm");
        }

        // ...
    }
}
