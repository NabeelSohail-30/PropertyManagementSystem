using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.Module_PropertyDetails
{
    class PropertyDetailsModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyTag { get; set; }
        public string Street { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int YearBuilt { get; set; }
        public int Age { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
