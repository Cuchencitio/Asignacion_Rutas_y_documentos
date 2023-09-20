using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class InformacionUsuarios
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? code { get; set; }
        public string? phone { get; set; }
        public string? company { get; set; }
        public object? note { get; set; }
        public object? facebook { get; set; }
        public object? twitter { get; set; }
        public object? hasCredit { get; set; }
        public float? maxCredit { get; set; }
        public int? state { get; set; }
        public string? activity { get; set; }
        public string? city { get; set; }
        public int? commerciallyBlocked { get; set; }
        public string? municipality { get; set; }
        public string? address { get; set; }
        public int? companyOrPerson { get; set; }
        public int? accumulatePoints { get; set; }
        public float? points { get; set; }
        public int? pointsUpdated { get; set; }
        public int? sendDte { get; set; }
        public int? isForeigner { get; set; }
        public int? prestashopClienId { get; set; }
        public int? createdAt { get; set; }
        public int? updatedAt { get; set; }
        public Contacts contacts { get; set; }
        public Attributes attributes { get; set; }
        public Addresses addresses { get; set; }
    }

    public class Contacts
    {
        public string? href { get; set; }
    }

    public class Attributes
    {
        public string? href { get; set; }
    }

    public class Addresses
    {
        public string? href { get; set; }
    }

}
