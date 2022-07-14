using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_Login
{
    public class RoleAuthorizationModel
    {
        public int RoleAuthorizationId { get; set; }
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowRead { get; set; }
        public RolesModel Role { get; set; }
        public PagesModel Page { get; set; }
    }
}
