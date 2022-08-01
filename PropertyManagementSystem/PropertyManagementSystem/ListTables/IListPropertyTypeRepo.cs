using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListPropertyTypeRepo
    {
        ListPropertyTypeModel Find(int pPropertyTypeId);
        List<ListPropertyTypeModel> Find();
    }
}
