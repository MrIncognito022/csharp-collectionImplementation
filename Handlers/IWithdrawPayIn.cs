using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers
{
    internal interface IWithdrawPayIn
    {
        public void Withdraw(string code,decimal amount);
    }
}
