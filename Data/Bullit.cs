using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data
{
    public class Bullit
    {
        public string Text { get; set; }
        public int Indent { get; set; } = 0;
        public int Order { get; set; } = 1;
    }
}
