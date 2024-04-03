using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionRutas
{

    public class SO
    {
        public SingleOrder order { get; set; }
    }

    public class SingleOrder
    {
        public int id { get; set; }
        public string created_at { get; set; }
        public string completed_at { get; set; }
        public string currency { get; set; }
        public int subtotal { get; set; }
        public int tax { get; set; }
        public int shipping_tax { get; set; }
        public int shipping { get; set; }
        public bool shipping_required { get; set; }
        public int total { get; set; }
        public int discount { get; set; }
        public int shipping_discount { get; set; }
        public object fulfillment_status { get; set; }
        public int? shipping_method_id { get; set; }
        public object shipping_service_id { get; set; }
        public string shipping_method_name { get; set; }
        public string payment_method_name { get; set; }
        public string payment_method_type { get; set; }
        public string payment_information { get; set; }
        public string additional_information { get; set; }
        public string duplicate_url { get; set; }
        public object recovery_url { get; set; }
        public string review_url { get; set; }
        public string checkout_url { get; set; }
        public string coupons { get; set; }
        public string status_enum { get; set; }
        public Promotion[] promotions { get; set; }
        public Customer customer { get; set; }
        public Shipping_Branch shipping_branch { get; set; }
        public Shipping_Address shipping_address { get; set; }
        public Billing_Address billing_address { get; set; }
        public object pickup_address { get; set; }
        public Product[] products { get; set; }
        public Additional_Fields[] additional_fields { get; set; }
        public object[] shipping_taxes { get; set; }
        public Source source { get; set; }
        public string status { get; set; }
        public object tracking_url { get; set; }
        public object tracking_company { get; set; }
        public object tracking_number { get; set; }
        public string shipping_option { get; set; }
        public bool same_day_delivery { get; set; }
        public string shipment_status { get; set; }
        public string shipment_status_enum { get; set; }
        public object external_shipping_rate_id { get; set; }
        public object external_shipping_rate_description { get; set; }
        public object billing_information { get; set; }
    }

    public class Cliente
    {
        public int id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string phone_prefix { get; set; }
        public string ip { get; set; }
        public string fullname { get; set; }
    }

    public class Shipping_Branch
    {
        public object id { get; set; }
        public object name { get; set; }
    }

    public class Direccion_envio
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public object postal { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string region_code { get; set; }
        public object street_number { get; set; }
        public string complement { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string municipality { get; set; }
    }

    public class Direccion_facturacion
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string taxid { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public object postal { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string region_code { get; set; }
        public object street_number { get; set; }
        public string complement { get; set; }
        public string municipality { get; set; }
    }

    public class Producto_orden
    {
        public int id { get; set; }
        public int variant_id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public float price { get; set; }
        public float tax { get; set; }
        public float discount { get; set; }
        public float weight { get; set; }
        public string image { get; set; }
        public object[] taxes { get; set; }
        public object[] files { get; set; }
    }

    public class campos_adicionales
    {
        public string label { get; set; }
        public string value { get; set; }
        public int id { get; set; }
        public string area { get; set; }
    }

}
