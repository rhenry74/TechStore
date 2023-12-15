using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Artifact
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; } = false;
        public int Order { get; set; }
        public string FileName { get; set; }

    }
}
