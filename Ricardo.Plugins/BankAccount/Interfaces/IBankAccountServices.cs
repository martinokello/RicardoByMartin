using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Plugins.BankAccount.Interfaces
{
    public interface IBankAccountServices
    {
        int Money { get; set; }
        bool CanWithdraw(int amount);
        void Withdraw(int amount);
    }
}
