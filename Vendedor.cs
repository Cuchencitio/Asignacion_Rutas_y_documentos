using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class Vendedor
    {
        public string href { get; set; }
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int state { get; set; }
        public Office office { get; set; }
    }

    public class Sucursal
    {
        public string href { get; set; }
        public string id { get; set; }
    }

}
