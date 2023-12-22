using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Plugins.Services.Interfaces
{
    public  interface ICustomerService
    {
        Customer? SignIn(string username, string password);
    }
}
