using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListRentPeriodRepo
    {
        List<ListRentPeriodModel> Find();
        ListRentPeriodModel Find(int pRentPeriodId);
    }
}
