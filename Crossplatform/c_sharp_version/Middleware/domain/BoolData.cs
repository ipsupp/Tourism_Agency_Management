using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class BoolData
    {
        public bool status;

        public BoolData(bool status)
        {
            this.status = status;
        }
    }
}
