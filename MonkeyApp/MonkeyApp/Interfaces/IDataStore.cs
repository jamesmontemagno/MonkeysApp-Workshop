using MonkeyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyApp.Interfaces
{
    interface IDataStore
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();
    }
}
