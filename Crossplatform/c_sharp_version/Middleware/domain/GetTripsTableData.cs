using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class GetTripsTableData
    {
        public DataTable dataTable;

        public GetTripsTableData(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }
    }
}
