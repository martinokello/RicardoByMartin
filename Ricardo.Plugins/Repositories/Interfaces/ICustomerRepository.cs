using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Plugins.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? FindCustomerByUsernameAndPassword(string username, string password);
    }
}
