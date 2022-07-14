using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    interface IRoleAuthorizationRepo
    {
        List<RoleAuthorizationModel> Find(int pRoleId);
    }
}
