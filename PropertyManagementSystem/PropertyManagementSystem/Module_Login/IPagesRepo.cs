using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public interface IPagesRepo
    {
        List<PagesModel> Find();
        PagesModel Find(int pPageId);
    }
}
