using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListRentPeriodModel
    {
        public int RentPeriodId { get; set; }
        public string RentPeriod { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int UpdatedByUserId { get; set; }
        public UserAccountsModel CreatedByUser { get; set; }
        public UserAccountsModel UpdatedByUser { get; set; }
    }
}
