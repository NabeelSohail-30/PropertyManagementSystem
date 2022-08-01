using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListSecurityDepositTypeRepo
    {
        ListSecurityDepositTypeModel Find(int pSecurityDepositTypeId);
        List<ListSecurityDepositTypeModel> Find();
    }
}
