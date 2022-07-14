using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    public interface IUserRolesRepo
    {
        List<UserRolesModel> Find(int pUserAccountId);
    }
}
