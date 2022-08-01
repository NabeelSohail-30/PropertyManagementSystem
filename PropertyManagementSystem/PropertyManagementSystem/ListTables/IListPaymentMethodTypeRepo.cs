using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListPaymentMethodTypeRepo
    {
        ListPaymentMethodTypeModel Find(int pPaymentMethodTypeId);
        List<ListPaymentMethodTypeModel> Find();
    }
}
