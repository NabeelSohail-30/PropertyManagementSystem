using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListCurrencyRepo
    {
        ListCurrencyModel Find(int CurrencyId);
        List<ListCurrencyModel> Find();
    }
}
