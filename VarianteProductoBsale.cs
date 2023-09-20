using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class VarianteProductoBsale
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public string? description { get; set; }
        public int? unlimitedStock { get; set; }
        public int? allowNegativeStock { get; set; }
        public int? state { get; set; }
        public string? barCode { get; set; }
        public string? code { get; set; }
        public int? imagestionCenterCost { get; set; }
        public int? imagestionAccount { get; set; }
        public int? imagestionConceptCod { get; set; }
        public int? imagestionProyectCod { get; set; }
        public int? imagestionCategoryCod { get; set; }
        public int? imagestionProductId { get; set; }
        public int? serialNumber { get; set; }
        public int? isLot { get; set; }
        public int? prestashopCombinationId { get; set; }
        public int? prestashopValueId { get; set; }
        public Producto product { get; set; }
        public Attribute_Values attribute_values { get; set; }
        public Costs costs { get; set; }
    }

    public class Producto
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class Attribute_Values
    {
        public string? href { get; set; }
    }

    public class Costs
    {
        public string? href { get; set; }
    }

}
