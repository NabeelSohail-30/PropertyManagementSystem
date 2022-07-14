using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public interface IRolesRepo
    {
        List<RolesModel> Find();
        RolesModel Find(int pRoleId);
    }
}
