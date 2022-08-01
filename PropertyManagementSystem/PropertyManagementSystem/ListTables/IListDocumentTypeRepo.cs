using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListDocumentTypeRepo
    {
        ListDocumentTypeModel Find(int pDocumentTypeId);
        List<ListDocumentTypeModel> Find();
    }
}
