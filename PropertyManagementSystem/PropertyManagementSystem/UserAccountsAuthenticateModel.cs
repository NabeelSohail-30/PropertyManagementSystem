using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    class UserAccountsAuthenticateModel
    {
        public int UserAccountId { get; set; }
        public bool Active { get; set; }
        public bool AccountLockedOut { get; set; }
        public bool IsLogged { get; set; }
        public bool AllowMultipleLogin { get; set; }
    }
}
