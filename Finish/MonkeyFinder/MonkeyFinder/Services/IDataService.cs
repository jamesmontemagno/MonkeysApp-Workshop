using MonkeyFinder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyFinder.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();
    }
}
