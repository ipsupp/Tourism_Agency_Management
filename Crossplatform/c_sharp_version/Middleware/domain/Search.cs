using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.domain
{
    [System.Serializable]
    public class Search
    {
        public string location;
        public int time_start;
        public int time_end;
        
        
        public Search(string location, int dep_start, int dep_end)
        {
            this.time_start=dep_start;
            this.time_end=dep_end;
            this.location=location;
        }
    }
}
