﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem.ListTables
{
    interface IListCountryRepo
    {
        ListCountryModel Find(int pCountryId);
        List<ListCountryModel> Find();
    }
}
