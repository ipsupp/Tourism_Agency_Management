﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class GetReservationTable
    {
        public DataTable dataTable;

        public GetReservationTable(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }
    }
}