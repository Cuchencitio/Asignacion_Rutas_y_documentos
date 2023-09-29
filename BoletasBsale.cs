using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{
    public class BoletaBsale
    {
        public string? href { get; set; }
        public int? count { get; set; }
        public int? limit { get; set; }
        public int? offset { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string? href { get; set; }
        public int? id { get; set; }
        public long emissionDate { get; set; }
        public int? expirationDate { get; set; }
        public int? generationDate { get; set; }
        public int? rcofDate { get; set; }
        public int? number { get; set; }
        public object? serialNumber { get; set; }
        public string? trackingNumber { get; set; }
        public float? totalAmount { get; set; }
        public float? netAmount { get; set; }
        public float? taxAmount { get; set; }
        public float? exemptAmount { get; set; }
        public float? notExemptAmount { get; set; }
        public float? exportTotalAmount { get; set; }
        public float? exportNetAmount { get; set; }
        public float? exportTaxAmount { get; set; }
        public float? exportExemptAmount { get; set; }
        public float? commissionRate { get; set; }
        public float? commissionNetAmount { get; set; }
        public float? commissionTaxAmount { get; set; }
        public float? commissionTotalAmount { get; set; }
        public float? percentageTaxWithheld { get; set; }
        public float? purchaseTaxAmount { get; set; }
        public float? purchaseTotalAmount { get; set; }
        public string? address { get; set; }
        public string? municipality { get; set; }
        public string? city { get; set; }
        public string? urlTimbre { get; set; }
        public string? urlPublicView { get; set; }
        public string? urlPdf { get; set; }
        public string? urlPublicViewOriginal { get; set; }
        public string? urlPdfOriginal { get; set; }
        public string? token { get; set; }
        public int? state { get; set; }
        public int? commercialState { get; set; }
        public string? urlXml { get; set; }
        public string? ted { get; set; }
        public object? salesId { get; set; }
        public int? informedSii { get; set; }
        public string? responseMsgSii { get; set; }
        public Document_Type document_type { get; set; }
        public Client client { get; set; }
        public Office office { get; set; }
        public User user { get; set; }
        public Coin coin { get; set; }
        public References references { get; set; }
        public Document_Taxes document_taxes { get; set; }
        public Details details { get; set; }
        public Sellers sellers { get; set; }
        public Attributes1 attributes { get; set; }
    }

    public class Document_Type
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class Client
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class Office
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class User
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class Coin
    {
        public string? href { get; set; }
        public string? id { get; set; }
    }

    public class References
    {
        public string? href { get; set; }
    }

    public class Document_Taxes
    {
        public string? href { get; set; }
    }

    public class Details
    {
        public string? href { get; set; }
    }

    public class Sellers
    {
        public string? href { get; set; }
    }

    public class Attributes1
    {
        public string? href { get; set; }
    }
}


