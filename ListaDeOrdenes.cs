using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class Rootobject
    {
        public Class1[] JSON { get; set; }
    }

    public class Class1
    {
        public Order order { get; set; }
    }

    public class Order
    {
        public int? id { get; set; }
        public string? created_at { get; set; }
        public string? completed_at { get; set; }
        public string? currency { get; set; }
        public int? subtotal { get; set; }
        public int? tax { get; set; }
        public int? shipping_tax { get; set; }
        public int? shipping { get; set; }
        public bool? shipping_required { get; set; }
        public int? total { get; set; }
        public int? discount { get; set; }
        public int? shipping_discount { get; set; }
        public object? fulfillment_status { get; set; }
        public int? shipping_method_id { get; set; }
        public object? shipping_service_id { get; set; }
        public string? shipping_method_name { get; set; }
        public string? payment_method_name { get; set; }
        public string? payment_method_type { get; set; }
        public object? payment_information { get; set; }
        public object? additional_information { get; set; }
        public string? duplicate_url { get; set; }
        public string? recovery_url { get; set; }
        public string? review_url { get; set; }
        public string? checkout_url { get; set; }
        public object? coupons { get; set; }
        public string? status_enum { get; set; }
        public Promotion[] promotions { get; set; }
        public Customer customer { get; set; }
        public Shipping_Address shipping_address { get; set; }
        public Billing_Address billing_address { get; set; }
        public Product[] products { get; set; }
        public Additional_Fields[] additional_fields { get; set; }
        public object[] shipping_taxes { get; set; }
        public Source source { get; set; }
        public string? status { get; set; }
        public object? tracking_url { get; set; }
        public object? tracking_company { get; set; }
        public object? tracking_number { get; set; }
        public string? shipping_option { get; set; }
        public bool? same_day_delivery { get; set; }
        public string? shipment_status { get; set; }
        public string? shipment_status_enum { get; set; }
        public object? external_shipping_rate_id { get; set; }
        public object? external_shipping_rate_description { get; set; }
    }

    public class Customer
    {
        public int? id { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? phone_prefix { get; set; }
        public string? ip { get; set; }
        public string? fullname { get; set; }
    }

    public class Shipping_Address
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public object? postal { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public string? country_code { get; set; }
        public string? region_code { get; set; }
        public object? street_number { get; set; }
        public string? complement { get; set; }
        public float? latitude { get; set; }
        public float? longitude { get; set; }
        public string? municipality { get; set; }
    }

    public class Billing_Address
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public object? taxid { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public object? postal { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public string? country_code { get; set; }
        public string? region_code { get; set; }
        public object? street_number { get; set; }
        public string? complement { get; set; }
        public string? municipality { get; set; }
    }

    public class Source
    {
        public string? source_name { get; set; }
        public string? medium { get; set; }
        public object? campaign { get; set; }
        public string? referral_url { get; set; }
        public object? referral_code { get; set; }
        public string? user_agent { get; set; }
        public string? first_page_visited { get; set; }
        public string? first_page_visited_at { get; set; }
        public string? referral_source { get; set; }
    }

    public class Promotion
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public object? code { get; set; }
    }

    public class Product
    {
        public int? id { get; set; }
        public int? variant_id { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public int? qty { get; set; }
        public float? price { get; set; }
        public float? tax { get; set; }
        public float? discount { get; set; }
        public float? weight { get; set; }
        public string? image { get; set; }
        public object[] files { get; set; }
        public object[] taxes { get; set; }
    }

    public class Additional_Fields
    {
        public string? label { get; set; }
        public string? value { get; set; }
        public int? id { get; set; }
        public string? area { get; set; }
    }

}
