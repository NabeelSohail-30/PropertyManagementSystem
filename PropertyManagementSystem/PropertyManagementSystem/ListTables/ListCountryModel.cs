using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    class ListCountryModel
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public int CurrencyId { get; set; }
        public ListCurrencyModel Currency { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int UpdatedByUserId { get; set; }
        public UserAccountsModel CreatedByUser { get; set; }
        public UserAccountsModel UpdatedByUser { get; set; }
    }
}
