using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class DetalleBoletasBsale
    {
        public string? href { get; set; }
        public int? count { get; set; }
        public int? limit { get; set; }
        public int? offset { get; set; }
        public Item1[] items { get; set; }
    }

    public class Item1
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public int? lineNumber { get; set; }
        public float? quantity { get; set; }
        public int? netUnitValue { get; set; }
        public int? totalUnitValue { get; set; }
        public float? netAmount { get; set; }
        public float? taxAmount { get; set; }
        public float? totalAmount { get; set; }
        public float? netDiscount { get; set; }
        public float? totalDiscount { get; set; }
        public Variant variant { get; set; }
        public string? note { get; set; }
        public int? relatedDetailId { get; set; }
    }

    public class Variant
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public string? description { get; set; }
        public string? code { get; set; }
    }

}
