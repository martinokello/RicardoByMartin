using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Plugins.Inventory.Interfaces
{
    public interface IInventoryServices
    {
        IEnumerable<Item> AllStock();
    }
}
