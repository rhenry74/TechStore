using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Container
    {
        public string id { get; set; }
        public string partitionKeyPath { get; set; } = "US";
    }
}
