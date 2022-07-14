using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    public class UserRolesModel
    {
        public int UserRoleId { get; set; }
        public int UserAccountId { get; set; }
        public int RoleId { get; set; }
        public bool DefaultPageRole { get; set; }
        public RolesModel Role { get; set; }
        public List<RoleAuthorizationModel> RoleAuthorizations { get; set; }
    }
}
