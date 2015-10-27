using MonkeyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyApp.ViewModel
{
    public class MonkeyViewModel
    {
        public Monkey Monkey { get; set; }
        public MonkeyViewModel(Monkey monkey)
        {
            Monkey = monkey;
        }
    }
}
