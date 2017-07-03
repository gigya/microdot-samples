using System;
using System.Threading.Tasks;
using Gigya.Common.Contracts.HttpService;
using Gigya.Common.Contracts.Attributes;

namespace GpuService.Interface
{

    [HttpService(basePort: 10000)]
    public interface IGpuService
    {
        [Cached]
        Task<byte[]> Hash(string algorithm, int rounds, byte[] input);
        Task<Tuple<byte[], byte[]>> Encrypt(string algorithm, byte[] key, byte[] input);
        // ...
    }

}
