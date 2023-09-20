using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class ProductoBsale
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public object? description { get; set; }
        public int? classification { get; set; }
        public string? ledgerAccount { get; set; }
        public string? costCenter { get; set; }
        public int? allowDecimal { get; set; }
        public int? stockControl { get; set; }
        public int? printDetailPack { get; set; }
        public int? state { get; set; }
        public int? prestashopProductId { get; set; }
        public int? presashopAttributeId { get; set; }
        public Product_Type product_type { get; set; }
        public Variants variants { get; set; }
        public Product_Taxes product_taxes { get; set; }
    }

    public class Product_Type
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class Variants
    {
        public string? href { get; set; }
    }

    public class Product_Taxes
    {
        public string? href { get; set; }
    }

}
