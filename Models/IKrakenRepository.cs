using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.Models
{
    public interface IKrakenRepository
    {
        Task<string> GetTime(IOptions<DanAppSettings> settings);

    }
}
