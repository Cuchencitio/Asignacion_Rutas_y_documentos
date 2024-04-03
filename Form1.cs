using Microsoft.VisualBasic;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.ApplicationServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using Nancy.Conventions;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Drawing;

namespace AutomatizacionRutas

{
    public partial class Form1 : Form
    {
        DateTime today = DateTime.Today;
        int?[] idGalloNegro = { 453817, 457736 };
        string[] tono = { "las condes", "vitacura", "la reina", "lo barnechea", "ñuñoa", "ñuñoa ", "providencia", "san joaquin", "san joaquín", "vitacura", "la reina", "Toño" };
        string[] ricardo = { "la cisterna", "la granja", "lo espejo", "pedro aguirre cerda", "san miguel", "san ramon", "san ramón", "san ramón ", "san ramon ", "la cisterna", "Ricardo" };
        string[] victor = { "independencia", "quinta normal", "quinta normal ", "recoleta", "recoleta ", "santiago", "santiago centro", "Victor" };
        string[] sebastian = { "lo prado", "huechuraba", "conchali", "conchalí", "renca", "cerro navia", "pudahuel", "quilicura", "Sebastian" };
        string[] javiera = { "la florida", "macul", "peñalolen", "peñalolén", "la florida ", "Javiera" };
        string[] christian = { "cerrillos", "estación central", "estacion central", "maipú", "maipu", "maipú ", "maipu ", "Christian" };
        string[] ana = { "puente alto", "el bosque", "la pintana", "san bernardo", "san bernardo ", "puente alto ", "la pintana ", "Ana" };

        string[] comunasRM = { "las condes", "vitacura", "la reina", "lo barnechea", "ñuñoa", "providencia", "san joaquin", "san joaquín", "vitacura", "la reina",
                               "la cisterna", "la granja", "lo espejo", "pedro aguirre cerda", "san miguel", "san ramon", "san ramón", "san ramón ", "la cisterna",
                               "independencia", "quinta normal", "recoleta", "santiago", "santiago centro",
                               "lo prado", "huechuraba", "conchali", "conchalí", "renca", "cerro navia", "pudahuel", "quilicura",
                               "la florida", "macul", "peñalolen", "peñalolén",
                               "cerrillos", "estación central", "estacion central", "maipú", "maipu",
                               "puente alto", "el bosque", "la pintana", "san bernardo", "puente alto "};
        List<String> facturas = new List<String>();
        List<String> boletasManuales = new List<String>();
        List<String> boletasElectronicas = new List<String>();
        List<String> rebotados = new List<String>();
        List<Class1> listaJS = new List<Class1>();
        List<SO> MultiProducto = new List<SO>();
        List<MultiproductoBsale> MultiproductoBsale = new List<MultiproductoBsale>();
        int icelda = 2;
        XLWorkbook workBook = new XLWorkbook();
        int indice = 0;
        string rutaGuardado = string.Empty;
        int totalEnvios = 0;
        float pesoPedido = 0;
        int costoEnvio = 2000;
        int ipedido = 1;
        int contadorPedido = 0;
        bool multiProducto = false;
        int indiceMultiProducto = 0;
        int totalmultiproducto = 0;
        int contadorResagados = 2;
        string medioPagoRe = string.Empty;
        string vendedorRe = string.Empty;

        public Form1()
        {
            InitializeComponent();
            btn_producto_anterior.Enabled = false;
            btn_producto_siguiente.Enabled = false;
        }
        private void LoadExcel()
        {
            Thread.Sleep(5000);
        }
        public async Task<string> consultaBoleta(string boletaManual)
        {
            string url = $"https://api.bsale.cl/v1/documents.json?number={boletaManual}";
            string token = "";
            string consulta = await GetHttpBsale(url, token);
            return consulta;
        }
        public async Task<string> consultasHref(string href)
        {
            string url = href;
            string token = "";
            string consulta = await GetHttpBsale(url, token);
            return consulta;
        }
        public async Task<string> consultasHrefexpand(string href, string expand)
        {
            string url = href + expand;
            string token = "";
            string consulta = await GetHttpBsale(url, token);
            return consulta;
        }

        public Task<string> GetHttp(string url)
        {

            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEndAsync();

        }
        public async Task<string> GetHttpBsale(string url, string token)
        {
            WebRequest peticion;
            peticion = WebRequest.Create(url);
            peticion.Headers.Add("access_token", token);
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Method = "GET";
            HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(respuesta.GetResponseStream());
            return await reader.ReadToEndAsync();
        }
        public void Clear()
        {
            txt_nombre_re.Text = string.Empty;
            txt_nombre_mascota_re.Text = string.Empty;
            txt_direccion_re.Text = string.Empty;
            txt_comuna_re.Text = string.Empty;
            txt_telefono_re.Text = string.Empty;
            txt_correo_re.Text = string.Empty;
            txt_peso_re.Text = string.Empty;
            txt_cantidad_re.Text = string.Empty;
            txt_producto_re.Text = string.Empty;
            txt_total_re.Text = string.Empty;
            txt_notas_re.Text = string.Empty;
            txt_forma_envio_re.Text = string.Empty;
            txt_repartidor_re.Text = string.Empty;

        }
        public async Task<string> ConsultaPedidoUnico(string id)
        {
            string consultaOrdenes = $"https://api.jumpseller.com/v1/orders/{id}.json?login=&authtoken=";
            string respuesta = await GetHttp(consultaOrdenes);
            return respuesta;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    rutaGuardado = fd.SelectedPath;
                    check_directorio.Visible = true;
                }
            }
        }
        public async void button2_Click(object sender, EventArgs e)
        {


            if (textBox_id_consulta.Text.Trim() != string.Empty)
            {
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                // simply start and await the loading task
                button2.Enabled = false;
                await Task.Run(() => LoadExcel());
                int ipagina = 1;
                string id = textBox_id_consulta.Text;
                string consultaOrdenes = $"https://api.jumpseller.com/v1/orders/after/{id}.json?login=&authtoken=&page={ipagina}&limit=100";
                string respuesta = await GetHttp(consultaOrdenes);
                Class1[] lista = JsonConvert.DeserializeObject<Class1[]>(respuesta);
                var Ruta = workBook.AddWorksheet("Ruta");
                Ruta.Cell("A1").Value = "CODIGO CLIENTE";
                Ruta.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("B1").Value = "CLIENTE";
                Ruta.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("C1").Value = "DOMICILIO";
                Ruta.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("D1").Value = "NOTAS DOMICILIO";
                Ruta.Cell("D1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("E1").Value = "ARTICULO";
                Ruta.Cell("E1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("F1").Value = "OBSERVACION";
                Ruta.Cell("F1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("G1").Value = "FACTURA";
                Ruta.Cell("G1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("H1").Value = "CARGA PRIMARIA";
                Ruta.Cell("H1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("I1").Value = "HORA DESDE";
                Ruta.Cell("I1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("J1").Value = "HORA HASTA";
                Ruta.Cell("J1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("K1").Value = "EMAIL COMPRADOR";
                Ruta.Cell("K1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("L1").Value = "TELEFONO CONTACTO";
                Ruta.Cell("L1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("N1").Value = "GRUPO";
                Ruta.Cell("N1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("M1").Value = "NOMBRE CONTACTO";
                Ruta.Cell("M1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                string productos = string.Empty;
                if (lista.Length > 0)
                {
                    while (lista.Length > 0)
                    {

                        for (int i = 0; i < lista.Length; i++)
                        {
                            if (lista[i].order.status == "Paid" && lista[i].order.payment_method_name != "Mercadolibre" && lista[i].order.shipping_method_id != 159655 && lista[i].order.shipment_status != "No Aplicable")
                            {

                                for (int p = 0; p < lista[i].order.products.Length; p++)
                                {
                                    productos = string.Empty;
                                    productos = lista[i].order.products[p].qty + "x " + lista[i].order.products[p].name + " x $" + (lista[i].order.products[p].price - lista[i].order.products[p].discount);
                                    Ruta.Cell($"E{icelda}").Value = productos;
                                    Ruta.Cell($"B{icelda}").Value = lista[i].order.customer.fullname;
                                    Ruta.Cell($"C{icelda}").Value = lista[i].order.shipping_address.address + ", " + lista[i].order.shipping_address.municipality + ", " + lista[i].order.shipping_address.complement;
                                    Ruta.Cell($"L{icelda}").Value = lista[i].order.customer.phone_prefix + lista[i].order.customer.phone;
                                    Ruta.Cell($"H{icelda}").Value = 1;
                                    Ruta.Cell($"I{icelda}").Value = "00:00";
                                    Ruta.Cell($"J{icelda}").Value = "23:59";
                                    Ruta.Cell($"M{icelda}").Value = lista[i].order.shipping_address.complement;
                                    Ruta.Cell($"K{icelda}").Value = lista[i].order.customer.email;
                                    Ruta.Cell($"M{icelda}").Value = lista[i].order.customer.fullname;
                                    Ruta.Cell($"AU{icelda}").Value = lista[i].order.id;
                                    Ruta.Cell($"G{icelda}").Value = lista[i].order.id;
                                    if (tono.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = tono[tono.Length - 1];
                                    }
                                    else if (ricardo.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = ricardo[ricardo.Length - 1];
                                    }
                                    else if (ana.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = ana[ana.Length - 1];
                                    }
                                    else if (javiera.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = javiera[javiera.Length - 1];
                                    }
                                    else if (christian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = christian[christian.Length - 1];
                                    }
                                    else if (sebastian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = sebastian[sebastian.Length - 1];
                                    }
                                    else if (victor.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = victor[victor.Length - 1];
                                    }
                                    else if (idGalloNegro.Contains(lista[i].order.shipping_method_id))
                                    {
                                        Ruta.Cell($"N{icelda}").Value = "Gallo Negro";
                                    }
                                    else if (lista[i].order.shipping_method_id == 159663)
                                    {
                                        Ruta.Cell($"N{icelda}").Value = lista[i].order.shipping_method_name;
                                    }
                                    icelda++;
                                };
                            }
                            else if (lista[i].order.status == "Canceled" || lista[i].order.status == "Abandoned")
                            {
                                continue;
                            }
                            if (lista[i].order.status == "Paid")
                            {
                                listaJS.Add(lista[i]);
                            }
                        }
                        ipagina++;
                        id = textBox_id_consulta.Text;
                        consultaOrdenes = $"https://api.jumpseller.com/v1/orders/after/{id}.json?login=&authtoken=&page={ipagina}&limit=100";
                        respuesta = await GetHttp(consultaOrdenes);
                        lista = JsonConvert.DeserializeObject<Class1[]>(respuesta);



                    }
                }
                if (rebotados.Count > 0)
                {
                    foreach (string rebotado in rebotados)
                    {
                        productos = string.Empty;
                        string Rebotado = await ConsultaPedidoUnico(rebotado);
                        Class1 pedidoUnico = JsonConvert.DeserializeObject<Class1>(Rebotado);
                        for (int p = 0; p < pedidoUnico.order.products.Length; p++)
                        {
                            productos = string.Empty;
                            productos = pedidoUnico.order.products[p].qty + "x " + pedidoUnico.order.products[p].name + " x $" + (pedidoUnico.order.products[p].price - pedidoUnico.order.products[p].discount);
                            Ruta.Cell($"E{icelda}").Value = productos;
                            Ruta.Cell($"B{icelda}").Value = pedidoUnico.order.customer.fullname;
                            if (pedidoUnico.order.shipping_address == null)
                            {
                                Ruta.Cell($"C{icelda}").Value = "-";
                                Ruta.Cell($"M{icelda}").Value = "-";
                                Ruta.Cell($"N{icelda}").Value = "-";
                            } else
                            {
                                Ruta.Cell($"C{icelda}").Value = pedidoUnico.order.shipping_address.address + ", " + pedidoUnico.order.shipping_address.municipality + ", " + pedidoUnico.order.shipping_address.complement;
                                Ruta.Cell($"M{icelda}").Value = pedidoUnico.order.shipping_address.complement;
                                if (tono.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"N{icelda}").Value = victor[victor.Length - 1];
                                }
                                else if (idGalloNegro.Contains(pedidoUnico.order.shipping_method_id))
                                {
                                    Ruta.Cell($"N{icelda}").Value = "Gallo Negro";
                                }
                                else if (pedidoUnico.order.shipping_method_id == 159663)
                                {
                                    Ruta.Cell($"N{icelda}").Value = pedidoUnico.order.shipping_method_name;
                                }
                            }
                            Ruta.Cell($"L{icelda}").Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
                            Ruta.Cell($"H{icelda}").Value = 1;
                            Ruta.Cell($"I{icelda}").Value = "00:00";
                            Ruta.Cell($"J{icelda}").Value = "23:59";
                            Ruta.Cell($"K{icelda}").Value = pedidoUnico.order.customer.email;
                            Ruta.Cell($"M{icelda}").Value = pedidoUnico.order.customer.fullname;
                            Ruta.Cell($"AU{icelda}").Value = pedidoUnico.order.id;
                            Ruta.Cell($"G{icelda}").Value = pedidoUnico.order.id;
                            
                            icelda++;
                        }
                        listaJS.Add(pedidoUnico);
                    }
                }
                if (facturas.Count > 0)
                {
                    foreach (string nf in facturas)
                    {
                        string productosFactura = string.Empty;
                        BoletaBsale boletaFactura = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nf));

                        for (int a = 0; a < boletaFactura.items.Length; a++)
                        {
                            if (boletaFactura.items[a].document_type.id == "6" && boletaFactura.items[a].address != "Av. Gabriela Oriente 2174")
                            {
                                DetalleBoletasBsale detalleFactura = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaFactura.items[a].details.href));

                                for (int p = 0; p < detalleFactura.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleFactura.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosFactura = detalleFactura.items[p].quantity + "x " + productoBsale.name + " " + variante.description + " x $";
                                    if (boletaFactura.items[a].client == null)
                                    {
                                        Ruta.Cell($"L{icelda}").Value = "Sin información";
                                        Ruta.Cell($"B{icelda}").Value = "Sin información";
                                        Ruta.Cell($"M{icelda}").Value = "Sin información";
                                        Ruta.Cell($"K{icelda}").Value = "Sin información";
                                    } else
                                    {
                                        InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaFactura.items[a].client.href));
                                        Ruta.Cell($"L{icelda}").Value = infoUsuario.phone;
                                        Ruta.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"M{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"K{icelda}").Value = infoUsuario.email;
                                    }                                    
                                    Ruta.Cell($"AU{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                    Ruta.Cell($"E{icelda}").Value = productosFactura + " x $" + boletaFactura.items[a].totalAmount;
                                    Ruta.Cell($"C{icelda}").Value = boletaFactura.items[a].address + ", " + boletaFactura.items[a].municipality;                                    
                                    Ruta.Cell($"H{icelda}").Value = "1";
                                    Ruta.Cell($"I{icelda}").Value = "00:00";
                                    Ruta.Cell($"J{icelda}").Value = "23:59";                                    
                                    Ruta.Cell($"G{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                    if (boletaFactura.items[a].municipality == null)
                                    {
                                        Ruta.Cell($"N{icelda}").Value = "Sin informacion";
                                    } else
                                    {
                                        if (tono.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = tono[tono.Length - 1];
                                        }
                                        else if (ricardo.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ricardo[ricardo.Length - 1];
                                        }
                                        else if (ana.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ana[ana.Length - 1];
                                        }
                                        else if (javiera.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = javiera[javiera.Length - 1];
                                        }
                                        else if (christian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = christian[christian.Length - 1];
                                        }
                                        else if (sebastian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = sebastian[sebastian.Length - 1];
                                        }
                                        else if (victor.Contains(boletaFactura.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = victor[victor.Length - 1];
                                        }
                                           
                                    }
                                    icelda++;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                if (boletasManuales.Count > 0)
                {
                    foreach (string nbm in boletasManuales)
                    {
                        string productosManual = string.Empty;
                        BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nbm));
                        for (int a = 0; a < boletaManual.items.Length; a++)
                        {
                            if (boletaManual.items[a].document_type.id == "10" && boletaManual.items[a].address != "Av. Gabriela Oriente 2174")
                            {
                                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));

                                for (int p = 0; p < detalleBoleta.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosManual = detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + " x $";
                                    if (boletaManual.items[a].client == null)
                                    {
                                        Ruta.Cell($"L{icelda}").Value = "Sin información";
                                        Ruta.Cell($"B{icelda}").Value = "Sin información";
                                        Ruta.Cell($"M{icelda}").Value = "Sin información";
                                        Ruta.Cell($"K{icelda}").Value = "Sin información";
                                    }
                                    else
                                    {
                                        InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaManual.items[a].client.href));
                                        Ruta.Cell($"L{icelda}").Value = infoUsuario.phone;
                                        Ruta.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"M{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"K{icelda}").Value = infoUsuario.email;
                                    }                                    
                                    Ruta.Cell($"AU{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    Ruta.Cell($"E{icelda}").Value = productosManual + " x $" + boletaManual.items[a].totalAmount;
                                    Ruta.Cell($"C{icelda}").Value = boletaManual.items[a].address + ", " + boletaManual.items[a].municipality;
                                    Ruta.Cell($"H{icelda}").Value = "1";
                                    Ruta.Cell($"I{icelda}").Value = "00:00";
                                    Ruta.Cell($"J{icelda}").Value = "23:59";
                                    Ruta.Cell($"G{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    if (boletaManual.items[a].municipality == null)
                                    {
                                        Ruta.Cell($"N{icelda}").Value = "Sin informacion";
                                    } else 
                                    {
                                        if (tono.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = tono[tono.Length - 1];
                                        }
                                        else if (ricardo.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ricardo[ricardo.Length - 1];
                                        }
                                        else if (ana.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ana[ana.Length - 1];
                                        }
                                        else if (javiera.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = javiera[javiera.Length - 1];
                                        }
                                        else if (christian.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = christian[christian.Length - 1];
                                        }
                                        else if (sebastian.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = sebastian[sebastian.Length - 1];
                                        }
                                        else if (victor.Contains(boletaManual.items[a].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = victor[victor.Length - 1];
                                        }                                        
                                    }
                                    icelda++;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                if (boletasElectronicas.Count > 0)
                {
                    foreach (string nboleta in boletasElectronicas)
                    {
                        string productosElectronica = string.Empty;
                        BoletaBsale boleta = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nboleta));
                        for (int i = 0; i < boleta.items.Length; i++)
                        {
                            if (boleta.items[i].document_type.id == "1" && boleta.items[i].address != "Av. Gabriela Oriente 2174")
                            {
                                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boleta.items[i].details.href));

                                for (int p = 0; p < detalleBoleta.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosElectronica = detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + " x $";
                                    if (boleta.items[i].client == null)
                                    {
                                        Ruta.Cell($"L{icelda}").Value = "Sin información";
                                        Ruta.Cell($"B{icelda}").Value = "Sin información";
                                        Ruta.Cell($"M{icelda}").Value = "Sin información";
                                        Ruta.Cell($"K{icelda}").Value = "Sin información";
                                    } else
                                    {
                                        InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boleta.items[i].client.href));
                                        Ruta.Cell($"L{icelda}").Value = infoUsuario.phone;
                                        Ruta.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"M{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                        Ruta.Cell($"K{icelda}").Value = infoUsuario.email;
                                    }                                    
                                    Ruta.Cell($"AU{icelda}").Value = "BE-" + boleta.items[i].number;
                                    Ruta.Cell($"E{icelda}").Value = productosElectronica + " x $" + boleta.items[i].totalAmount;
                                    Ruta.Cell($"C{icelda}").Value = boleta.items[i].address + ", " + boleta.items[i].municipality;                                    
                                    Ruta.Cell($"H{icelda}").Value = "1";
                                    Ruta.Cell($"I{icelda}").Value = "00:00";
                                    Ruta.Cell($"J{icelda}").Value = "23:59";
                                    Ruta.Cell($"G{icelda}").Value = "BE-" + boleta.items[i].number;
                                    if (boleta.items[i].municipality == null)
                                    {
                                        Ruta.Cell($"N{icelda}").Value = "Sin informacion";
                                    } else
                                    {
                                        if (tono.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = tono[tono.Length - 1];
                                        }
                                        else if (ricardo.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ricardo[ricardo.Length - 1];
                                        }
                                        else if (ana.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = ana[ana.Length - 1];
                                        }
                                        else if (javiera.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = javiera[javiera.Length - 1];
                                        }
                                        else if (christian.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = christian[christian.Length - 1];
                                        }
                                        else if (sebastian.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = sebastian[sebastian.Length - 1];
                                        }
                                        else if (victor.Contains(boleta.items[i].municipality.ToLower()))
                                        {
                                            Ruta.Cell($"N{icelda}").Value = victor[victor.Length - 1];
                                        }                                        
                                    }
                                    icelda++;
                                }
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                }
                button2.Enabled = true;
                progressBar1.Visible = false;
                workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
                check_rutas.Visible = true;
            }
            else
            {
                MessageBox.Show("No se ha ingresado un pedido de corte");
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox_tipo_documento.Text == "F" && textBox_manuales.Text.Trim() != string.Empty && !facturas.Contains(textBox_manuales.Text.ToString()))
            {
                facturas.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else if (comboBox_tipo_documento.Text == "BE" && textBox_manuales.Text.Trim() != string.Empty && !boletasElectronicas.Contains(textBox_manuales.Text.ToString()))
            {
                boletasElectronicas.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else if (comboBox_tipo_documento.Text == "BM" && textBox_manuales.Text.Trim() != string.Empty && !boletasManuales.Contains(textBox_manuales.Text.ToString()))
            {
                boletasManuales.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else
            {
                MessageBox.Show("Boleta Invalida o ya fue agregada");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button_rebotados_Click(object sender, EventArgs e)
        {
            if (textBox_rebotados.Text.Trim() != string.Empty && !rebotados.Contains(textBox_rebotados.Text.ToString()))
            {
                rebotados.Add(textBox_rebotados.Text);
                textBox_rebotados.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else
            {

                MessageBox.Show("Pedido invalido o ya ingresado");
            }
        }

        private async void button_bbddfinal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var BBDDFinal = workBook.AddWorksheet("BBDD Final");
            workBook.SaveAs($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // simply start and await the loading task
            button4.Enabled = false;
            await Task.Run(() => LoadExcel());
            string formatoProducto = string.Empty;
            int indiceBusqueda = 2;
            int indicePedido = 2;
            string medida = string.Empty;
            icelda = 2;
            var workBook = new XLWorkbook($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            var Rutas = workBook.Worksheet("Ruta");
            var reRoutix = workBook.AddWorksheet("Resagados ROUTIX");
            var reBBDDFinal = workBook.AddWorksheet("Resagados BBDD Final");
            var BBDDFinal = workBook.AddWorksheet("BBDD Final");

            //Formato para BBDD final
            BBDDFinal.Cell("A1").Value = "CONTADOR";
            BBDDFinal.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("B1").Value = "Cliente";
            BBDDFinal.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("C1").Value = "Nombre Mascota";
            BBDDFinal.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("D1").Value = "Direccion";
            BBDDFinal.Cell("D1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("E1").Value = "Comuna";
            BBDDFinal.Cell("E1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("F1").Value = "Telefono";
            BBDDFinal.Cell("F1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("G1").Value = "Correo";
            BBDDFinal.Cell("G1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("H1").Value = "Producto";
            BBDDFinal.Cell("H1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("I1").Value = "Peso";
            BBDDFinal.Cell("I1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("J1").Value = "Cantidad";
            BBDDFinal.Cell("J1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("K1").Value = "Total";
            BBDDFinal.Cell("K1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("L1").Value = "Medio de pago";
            BBDDFinal.Cell("L1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("M1").Value = "Notas";
            BBDDFinal.Cell("M1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("N1").Value = "Stock";
            BBDDFinal.Cell("N1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("O1").Value = "Estado";
            BBDDFinal.Cell("O1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("P1").Value = "Fecha venta";
            BBDDFinal.Cell("P1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("Q1").Value = "Forma de envío";
            BBDDFinal.Cell("Q1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("R1").Value = "Repatidor";
            BBDDFinal.Cell("R1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("S1").Value = "Vendedor";
            BBDDFinal.Cell("S1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("T1").Value = "Sucursal";
            BBDDFinal.Cell("T1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("U1").Value = "Documento";
            BBDDFinal.Cell("U1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("V1").Value = "Documento con indice";
            BBDDFinal.Cell("V1").Style.Fill.SetBackgroundColor(XLColor.Orange);


            //Formato para BBDD Final resagados
            reBBDDFinal.Cell("A1").Value = "CONTADOR";
            reBBDDFinal.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("B1").Value = "Cliente";
            reBBDDFinal.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("C1").Value = "Nombre Mascota";
            reBBDDFinal.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("D1").Value = "Direccion";
            reBBDDFinal.Cell("D1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("E1").Value = "Comuna";
            reBBDDFinal.Cell("E1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("F1").Value = "Telefono";
            reBBDDFinal.Cell("F1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("G1").Value = "Correo";
            reBBDDFinal.Cell("G1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("H1").Value = "Producto";
            reBBDDFinal.Cell("H1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("I1").Value = "Peso";
            reBBDDFinal.Cell("I1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("J1").Value = "Cantidad";
            reBBDDFinal.Cell("J1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("K1").Value = "Total";
            reBBDDFinal.Cell("K1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("L1").Value = "Medio de pago";
            reBBDDFinal.Cell("L1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("M1").Value = "Notas";
            reBBDDFinal.Cell("M1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("N1").Value = "Stock";
            reBBDDFinal.Cell("N1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("O1").Value = "Estado";
            reBBDDFinal.Cell("O1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("P1").Value = "Fecha venta";
            reBBDDFinal.Cell("P1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("Q1").Value = "Forma de envío";
            reBBDDFinal.Cell("Q1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("R1").Value = "Repatidor";
            reBBDDFinal.Cell("R1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("S1").Value = "Vendedor";
            reBBDDFinal.Cell("S1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("T1").Value = "Sucursal";
            reBBDDFinal.Cell("T1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("U1").Value = "Documento";
            reBBDDFinal.Cell("U1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reBBDDFinal.Cell("V1").Value = "Documento con indice";
            reBBDDFinal.Cell("V1").Style.Fill.SetBackgroundColor(XLColor.Orange);


            // Formato ruta resagados
            reRoutix.Cell("A1").Value = "CODIGO CLIENTE";
            reRoutix.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("B1").Value = "CLIENTE";
            reRoutix.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("C1").Value = "DOMICILIO";
            reRoutix.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("D1").Value = "NOTAS DOMICILIO";
            reRoutix.Cell("D1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("E1").Value = "ARTICULO";
            reRoutix.Cell("E1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("F1").Value = "OBSERVACION";
            reRoutix.Cell("F1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("G1").Value = "FACTURA";
            reRoutix.Cell("G1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("H1").Value = "CARGA PRIMARIA";
            reRoutix.Cell("H1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("I1").Value = "HORA DESDE";
            reRoutix.Cell("I1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("J1").Value = "HORA HASTA";
            reRoutix.Cell("J1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("K1").Value = "EMAIL COMPRADOR";
            reRoutix.Cell("K1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("L1").Value = "TELEFONO CONTACTO";
            reRoutix.Cell("L1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("N1").Value = "GRUPO";
            reRoutix.Cell("N1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            reRoutix.Cell("M1").Value = "NOMBRE CONTACTO";
            reRoutix.Cell("M1").Style.Fill.SetBackgroundColor(XLColor.Orange);




            foreach (var pedido in listaJS)
            {
                ipedido = 1;
                contadorPedido++;
                pesoPedido = 0;
                string productos = string.Empty;
                string pedidos = pedido.order.id.ToString();
                string Rebotado = await ConsultaPedidoUnico(pedidos);
                Class1 pedidoUnico = JsonConvert.DeserializeObject<Class1>(Rebotado);
                //Calcula el precio de los envios que mantienen condiciones en las cuales se cobra
                if (pedidoUnico.order.shipping != 0)
                {
                    totalEnvios = totalEnvios + (int)pedidoUnico.order.shipping;
                }
                for (int p = 0; p < pedidoUnico.order.products.Length; p++)
                {
                    productos = productos + pedidoUnico.order.products[p].name;
                    productos = productos.Replace(",", ".");
                    string kg = Regex.Match(productos, @"([-+]?[0-9]*\.?[0-9]+)").Value;
                    if (productos.Contains("kg") || productos.Contains("Kg") || productos.Contains("KG"))
                    {
                        productos = productos.Replace("kg", "");
                        productos = productos.Replace("KG", "");
                        productos = productos.Replace("Kg", "");
                        medida = "Kg";
                        pesoPedido = pesoPedido + float.Parse(kg, CultureInfo.InvariantCulture);
                    }
                    if (kg.Trim() != string.Empty)
                    {
                        if (productos.Contains($"{kg}g") || productos.Contains($"{kg} g"))
                        {
                            productos = productos.Replace($"{kg}g", "");
                            productos = productos.Replace($"{kg} g", "");
                            medida = "g";
                        }
                        else if (productos.Contains($"{kg} un"))
                        {
                            productos = productos.Replace($"{kg} g", "");
                            medida = "un";
                        }
                    }
                    else if (!productos.Contains($"{kg}g") || !productos.Contains($"{kg} g") || !productos.Contains("kg") || !productos.Contains("Kg") || !productos.Contains("KG"))
                    {
                        medida = "No Aplica";
                    }
                    if (productos.Contains(kg) && productos.Contains(kg) != null && kg != string.Empty && !productos.Contains("TOP K"))
                    {
                        productos = productos.Replace(kg, "");
                    }
                    if (productos.Contains("TOP K"))
                    {
                        string pesoArenas = productos.Substring(productos.IndexOf('('));
                        string kgArena = Regex.Match(pesoArenas, @"([-+]?[0-9]*\.?[0-9]+)").Value;
                        kg = kgArena;
                    }
                    if (productos.Contains("("))
                    {
                        int indice1 = productos.IndexOf('(');
                        productos = productos.Remove(indice1);
                    }
                    BBDDFinal.Cell($"B{icelda}").Value = pedidoUnico.order.customer.fullname;
                    if (pedidoUnico.order.additional_fields.Length > 0)
                    {
                        BBDDFinal.Cell($"C{icelda}").Value = pedidoUnico.order.additional_fields[0].value;
                    }
                    if (pedidoUnico.order.shipping_address != null)
                    {
                        BBDDFinal.Cell($"D{icelda}").Value = pedidoUnico.order.shipping_address.address + ", " + pedidoUnico.order.shipping_address.complement;
                    }
                    if (idGalloNegro.Contains(pedidoUnico.order.shipping_method_id))
                    {
                        if (ipedido <= 1)
                        {
                            totalEnvios = totalEnvios + costoEnvio;
                        }
                        if (pesoPedido > 40)
                        {
                            totalEnvios = totalEnvios + costoEnvio;
                        }
                    }
                    BBDDFinal.Cell($"H{icelda}").Value = productos;
                    productos = string.Empty;
                    formatoProducto = kg + " " + medida;
                    formatoProducto = formatoProducto.Replace(".", ",");
                    BBDDFinal.Cell($"I{icelda}").Value = formatoProducto;
                    BBDDFinal.Cell($"J{icelda}").Value = pedidoUnico.order.products[p].qty;
                    BBDDFinal.Cell($"K{icelda}").Value = (pedidoUnico.order.products[p].price - pedidoUnico.order.products[p].discount) * pedidoUnico.order.products[p].qty;
                    if (pedidoUnico.order.shipping_address != null)
                    {
                        BBDDFinal.Cell($"E{icelda}").Value = pedidoUnico.order.shipping_address.municipality;
                        BBDDFinal.Cell($"Q{icelda}").Value = pedidoUnico.order.shipping_method_name;
                    }
                    else
                    {
                        BBDDFinal.Cell($"E{icelda}").Value = "-";
                        BBDDFinal.Cell($"Q{icelda}").Value = "No aplica";
                    }

                    BBDDFinal.Cell($"F{icelda}").Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
                    BBDDFinal.Cell($"G{icelda}").Value = pedidoUnico.order.customer.email;
                    BBDDFinal.Cell($"L{icelda}").Value = pedidoUnico.order.payment_method_name;
                    if (pedidoUnico.order.additional_information == null)
                    {
                        BBDDFinal.Cell($"M{icelda}").Value = "-";
                    }
                    else
                    {
                        BBDDFinal.Cell($"M{icelda}").Value = pedidoUnico.order.additional_information.ToString();
                    }
                    BBDDFinal.Cell($"P{icelda}").Value = pedidoUnico.order.completed_at;
                    BBDDFinal.Cell($"S{icelda}").Value = "Casa Matriz";
                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                    BBDDFinal.Cell($"U{icelda}").Value = pedidoUnico.order.id;
                    BBDDFinal.Cell($"V{icelda}").Value = pedidoUnico.order.id + "" + ipedido;
                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                    icelda = icelda + 1;
                    ipedido++;

                }

            }

            if (facturas.Count > 0)
            {
                foreach (string nf in facturas)
                {
                    contadorPedido++;
                    string productosFactura = string.Empty;
                    BoletaBsale boletaFactura = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nf));
                    for (int a = 0; a < boletaFactura.items.Length; a++)
                    {
                        if (boletaFactura.items[a].document_type.id == "6")
                        {
                            if (boletaFactura.items[a].client == null)
                            {
                                BBDDFinal.Cell($"B{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"F{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"G{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"C{icelda}").Value = "-";
                                BBDDFinal.Cell($"M{icelda}").Value = "-";
                            } else
                            {
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaFactura.items[a].client.href, "?expand=[attributes]"));
                                BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (infoUsuario.attributes.items[0].value != string.Empty)
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                }
                                else
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = "-";
                                }
                                BBDDFinal.Cell($"F{icelda}").Value = infoUsuario.phone;
                                BBDDFinal.Cell($"G{icelda}").Value = infoUsuario.email;
                                BBDDFinal.Cell($"L{icelda}").Value = "-";
                                if (infoUsuario.note == null)
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = "-";
                                }
                                else
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = infoUsuario.note.ToString();
                                }
                            }
                            
                            DetalleBoletasBsale detalleFactura = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaFactura.items[a].details.href));
                            Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaFactura.items[a].user.href));
                            for (int p = 0; p < detalleFactura.items.Length; p++)
                            {

                                VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleFactura.items[p].variant.href));
                                ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));

                                if (productoBsale.id != 338)
                                {
                                    BBDDFinal.Cell($"H{icelda}").Value = productoBsale.name;
                                    formatoProducto = variante.description.ToString();
                                    formatoProducto = formatoProducto.Replace(".", ",");
                                    formatoProducto = formatoProducto.Trim();
                                    BBDDFinal.Cell($"I{icelda}").Value = formatoProducto;
                                    BBDDFinal.Cell($"J{icelda}").Value = detalleFactura.items[p].quantity;
                                    BBDDFinal.Cell($"K{icelda}").Value = detalleFactura.items[p].totalAmount;      
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaFactura.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaFactura.items[a].municipality;
                                    long fechaEmision = boletaFactura.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaFactura.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"U{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                    BBDDFinal.Cell($"V{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                                    icelda = icelda + 1;
                                }
                                else
                                {
                                    totalEnvios = totalEnvios + costoEnvio;
                                }

                            }

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            if (boletasManuales.Count > 0)
            {
                foreach (string nf in boletasManuales)
                {
                    contadorPedido++;
                    string productosBoletaManual = string.Empty;
                    BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nf));
                    for (int a = 0; a < boletaManual.items.Length; a++)
                    {
                        if (boletaManual.items[a].document_type.id == "10")
                        {
                            if (boletaManual.items[a].client == null)
                            {
                                BBDDFinal.Cell($"B{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"F{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"G{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"C{icelda}").Value = "-";
                                BBDDFinal.Cell($"M{icelda}").Value = "-";
                            } else
                            {
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaManual.items[a].client.href, "?expand=[attributes]"));
                                BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (infoUsuario.attributes.items[0].value != string.Empty)
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                }
                                else
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = "-";
                                }
                                BBDDFinal.Cell($"F{icelda}").Value = infoUsuario.phone;
                                BBDDFinal.Cell($"G{icelda}").Value = infoUsuario.email;
                                BBDDFinal.Cell($"L{icelda}").Value = "-";
                                if (infoUsuario.note == null)
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = "-";
                                }
                                else
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = infoUsuario.note.ToString();
                                }
                            }
                            DetalleBoletasBsale detalleBoletaManual = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
                            Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaManual.items[a].user.href));
                            for (int p = 0; p < detalleBoletaManual.items.Length; p++)
                            {

                                VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoletaManual.items[p].variant.href));
                                ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                if (productoBsale.id != 338)
                                {
                                    BBDDFinal.Cell($"H{icelda}").Value = productoBsale.name;
                                    formatoProducto = variante.description.ToString();
                                    formatoProducto = formatoProducto.Replace(".", ",");
                                    formatoProducto = formatoProducto.Trim();
                                    BBDDFinal.Cell($"I{icelda}").Value = formatoProducto;
                                    BBDDFinal.Cell($"J{icelda}").Value = detalleBoletaManual.items[p].quantity;
                                    BBDDFinal.Cell($"K{icelda}").Value = detalleBoletaManual.items[p].totalAmount;
                                    
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaManual.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaManual.items[a].municipality;                                    
                                    long fechaEmision = boletaManual.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaManual.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"U{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    BBDDFinal.Cell($"V{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                                    icelda = icelda + 1;
                                }
                                else
                                {
                                    totalEnvios = totalEnvios + costoEnvio;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            if (boletasElectronicas.Count > 0)
            {
                foreach (string nf in boletasElectronicas)
                {
                    contadorPedido++;
                    string productosBoletaElectronica = string.Empty;
                    BoletaBsale boletaElectronica = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nf));
                    for (int a = 0; a < boletaElectronica.items.Length; a++)
                    {
                        if (boletaElectronica.items[a].document_type.id == "1")
                        {
                            if (boletaElectronica.items[a].client == null)
                            {
                                BBDDFinal.Cell($"B{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"F{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"G{icelda}").Value = "Sin informacion";
                                BBDDFinal.Cell($"C{icelda}").Value = "-";
                                BBDDFinal.Cell($"M{icelda}").Value = "-";
                            } else
                            {
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaElectronica.items[a].client.href, "?expand=[attributes]"));
                                BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (infoUsuario.attributes.items[0].value != string.Empty)
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                }
                                else
                                {
                                    BBDDFinal.Cell($"C{icelda}").Value = "-";
                                }
                                BBDDFinal.Cell($"F{icelda}").Value = infoUsuario.phone;
                                BBDDFinal.Cell($"G{icelda}").Value = infoUsuario.email;
                                BBDDFinal.Cell($"L{icelda}").Value = "-";
                                if (infoUsuario.note == null)
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = "-";
                                }
                                else
                                {
                                    BBDDFinal.Cell($"M{icelda}").Value = infoUsuario.note.ToString();
                                }
                            }                            
                            DetalleBoletasBsale detalleBoletaElectronica = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaElectronica.items[a].details.href));
                            Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaElectronica.items[a].user.href));
                            for (int p = 0; p < detalleBoletaElectronica.items.Length; p++)
                            {
                                VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoletaElectronica.items[p].variant.href));
                                ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                if (productoBsale.id != 338)
                                {
                                    BBDDFinal.Cell($"H{icelda}").Value = productoBsale.name;
                                    formatoProducto = variante.description.ToString();
                                    formatoProducto = formatoProducto.Replace(".", ",");
                                    formatoProducto = formatoProducto.Trim();
                                    BBDDFinal.Cell($"I{icelda}").Value = formatoProducto;
                                    BBDDFinal.Cell($"J{icelda}").Value = detalleBoletaElectronica.items[p].quantity;
                                    BBDDFinal.Cell($"K{icelda}").Value = detalleBoletaElectronica.items[p].totalAmount;                                   
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaElectronica.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaElectronica.items[a].municipality;                                    
                                    long fechaEmision = boletaElectronica.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaElectronica.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"U{icelda}").Value = "BE-" + boletaElectronica.items[a].number;
                                    BBDDFinal.Cell($"V{icelda}").Value = "BE-" + boletaElectronica.items[a].number;
                                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                                    icelda = icelda + 1;
                                }
                                else
                                {
                                    totalEnvios = totalEnvios + costoEnvio;
                                }
                            }

                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
            BBDDFinal.Cell($"K{icelda}").Value = totalEnvios;
            BBDDFinal.Cell($"H{icelda}").Value = "ENVIO";
            BBDDFinal.Cell($"B{icelda}").Value = "INGRESOS POR ENVIO";
            var comunaDeEnvio = BBDDFinal.Cell($"E{indiceBusqueda}").GetValue<string>();
            var metodoDePago = BBDDFinal.Cell($"L{indiceBusqueda}").GetValue<string>();
            var formaDeEnvio = BBDDFinal.Cell($"P{indiceBusqueda}").GetValue<string>();
            var IndiceBBDDFinal = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
            var IndiceRutas = Rutas.Cell($"AU{indicePedido}").GetValue<string>();
            while (IndiceBBDDFinal != string.Empty)
            {
                while (IndiceRutas != string.Empty)
                {

                    if (IndiceBBDDFinal == IndiceRutas)
                    {
                        string Repartidor = Rutas.Cell($"N{indicePedido}").GetValue<string>();
                        BBDDFinal.Cell($"R{indiceBusqueda}").Value = Repartidor;
                        break;
                    }
                    else if (formaDeEnvio.Contains("Retiro"))
                    {
                        BBDDFinal.Cell($"R{indiceBusqueda}").Value = "Retiro Local";
                        break;
                    }
                    else if (metodoDePago.Contains("Mercado"))
                    {
                        comunaDeEnvio = comunaDeEnvio.ToLower();
                        if (!comunasRM.Contains(comunaDeEnvio))
                        {
                            BBDDFinal.Cell($"R{indiceBusqueda}").Value = "Mercado Libre";
                            break;
                        }
                        break;
                    }
                    else
                    {
                        indicePedido++;
                        IndiceRutas = Rutas.Cell($"AU{indicePedido}").GetValue<string>();
                    }

                }
                indiceBusqueda++;
                IndiceBBDDFinal = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
                formaDeEnvio = BBDDFinal.Cell($"P{indiceBusqueda}").GetValue<string>();
                comunaDeEnvio = BBDDFinal.Cell($"E{indiceBusqueda}").GetValue<string>();
                metodoDePago = BBDDFinal.Cell($"L{indiceBusqueda}").GetValue<string>();
                indicePedido = 2;
                IndiceRutas = Rutas.Cell($"AU{indicePedido}").GetValue<string>();

            }

            button4.Enabled = true;
            progressBar1.Visible = false;
            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            check_bbdd.Visible = true;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // simply start and await the loading task
            button5.Enabled = false;
            await Task.Run(() => LoadExcel());
            int indiceBusqueda = 2;
            icelda = 2;
            var workBook = new XLWorkbook($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            var BBDDFinal = workBook.Worksheet("BBDD Final");
            var NombresMascotas = workBook.AddWorksheet("Nombres de mascotas");
            var pedido = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
            var Repartidor = BBDDFinal.Cell($"R{indiceBusqueda}").GetValue<string>();
            var Mascota = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>();
            var Direccion = BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
            NombresMascotas.Cell("A1").Value = "Dirección";
            NombresMascotas.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            NombresMascotas.Cell("B1").Value = "Nombre Mascota";
            NombresMascotas.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            NombresMascotas.Cell("C1").Value = "Repartidor";
            NombresMascotas.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            while (pedido != string.Empty)
            {
                if (Mascota != string.Empty)
                {
                    NombresMascotas.Cell($"A{icelda}").Value = Direccion;
                    NombresMascotas.Cell($"B{icelda}").Value = Mascota;
                    NombresMascotas.Cell($"C{icelda}").Value = Repartidor;
                    icelda++;
                    indiceBusqueda++;
                    pedido = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
                    Repartidor = BBDDFinal.Cell($"R{indiceBusqueda}").GetValue<string>();
                    Mascota = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>();
                    Direccion = BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
                }
                else
                {
                    indiceBusqueda++;
                    pedido = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
                    Repartidor = BBDDFinal.Cell($"R{indiceBusqueda}").GetValue<string>();
                    Mascota = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>();
                    Direccion = BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
                }
            }
            button5.Enabled = true;
            progressBar1.Visible = false;
            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            check_nMascotas.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var workBook = new XLWorkbook($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            var BBDDFinal = workBook.Worksheet("BBDD Final");
            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");



            //string idPedido = textBox_id_pedido.Text;
            //string comentario = textBox_notas.Text;
            //string url = $"https://api.jumpseller.com/v1/orders/{idPedido}.json?login=&authtoken=";
            //ConsultaOrden ObjetoPost = new ConsultaOrden()
            //{
            //    order = new Order
            //    {
            //    }
            //};
            //ObjetoPost.order.additional_information = comentario;
            //var content = new StringContent(JsonConvert.SerializeObject(ObjetoPost), Encoding.UTF8, "application/json");
            //var cliente = new HttpClient();
            //var respuesta = await cliente.PutAsync(url, content);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            Clear();
            MultiProducto.Clear();
            MultiproductoBsale.Clear();
            indiceMultiProducto = 0;
            string productosUnicos = string.Empty;
            string id = txt_pedido_resagado.Text;
            if (cmb_tipo_documento.Text == "Jumpseller")
            {

                string consultaOrdenes = $"https://api.jumpseller.com/v1/orders/{id}.json?login=&authtoken=";
                string respuesta = await GetHttp(consultaOrdenes);
                SO singleorder = JsonConvert.DeserializeObject<SO>(respuesta);
                MultiProducto.Add(singleorder);
                if (singleorder.order.products.Length > 1)
                {
                    multiProducto = true;
                    btn_producto_anterior.Enabled = multiProducto;
                    btn_producto_siguiente.Enabled = multiProducto;
                }
                txt_nombre_re.Text = singleorder.order.customer.fullname;
                txt_nombre_mascota_re.Text = singleorder.order.additional_fields[0].value;
                if (singleorder.order.shipping_address == null)
                {
                    txt_direccion_re.Text = "-";
                    txt_comuna_re.Text = "-";
                } else
                {
                    txt_direccion_re.Text = singleorder.order.shipping_address.address;
                    txt_comuna_re.Text = singleorder.order.shipping_address.municipality;
                }
                txt_telefono_re.Text = singleorder.order.customer.phone;
                txt_correo_re.Text = singleorder.order.customer.email;
                txt_producto_re.Text = singleorder.order.products[indiceMultiProducto].name;
                txt_peso_re.Text = singleorder.order.products[indiceMultiProducto].weight.ToString();
                txt_cantidad_re.Text = singleorder.order.products[indiceMultiProducto].qty.ToString();
                if (singleorder.order.additional_information != null)
                {
                    txt_notas_re.Text = singleorder.order.additional_information.ToString();
                }
                medioPagoRe = singleorder.order.payment_method_name;
                if (singleorder.order.additional_information == null)
                {
                    txt_notas_re.Text = "-";
                }
                else
                {
                    txt_notas_re.Text = singleorder.order.additional_information.ToString();
                }
                txt_forma_envio_re.Text = singleorder.order.shipping_method_name;
                totalmultiproducto = ((int)singleorder.order.products[indiceMultiProducto].qty * (int)singleorder.order.products[indiceMultiProducto].price) - (int)singleorder.order.products[indiceMultiProducto].discount;
                txt_total_re.Text = totalmultiproducto.ToString();
            }
            else if (cmb_tipo_documento.Text == "BM")
            {
                BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(id));
                for (int a = 0; a < boletaManual.items.Length; a++)
                {
                    if (boletaManual.items[a].document_type.id == "10")
                    {
                        if (boletaManual.items[a].client == null)
                        {
                            txt_nombre_mascota_re.Text = "-";
                            txt_nombre_re.Text = "-";
                            txt_telefono_re.Text = "-";
                            txt_correo_re.Text = "-";
                            txt_notas_re.Text = "-";
                        } else
                        {
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaManual.items[a].client.href, "?expand=[attributes]"));
                            if (infoUsuario.attributes.items[0].value != string.Empty)
                            {
                                txt_nombre_mascota_re.Text = infoUsuario.attributes.items[0].value;
                            }
                            else
                            {
                                txt_nombre_mascota_re.Text = "-";
                            }
                            txt_nombre_re.Text = infoUsuario.firstName + " " + infoUsuario.lastName;
                            txt_telefono_re.Text = infoUsuario.phone;
                            txt_correo_re.Text = infoUsuario.email;
                            if (infoUsuario.note == null)
                            {
                                txt_notas_re.Text = "-";
                            }
                            else
                            {
                                txt_notas_re.Text = infoUsuario.note.ToString();
                            }
                        }
                        
                        DetalleBoletasBsale detalleBoletaManual = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
                        Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaManual.items[a].user.href));
                        if (detalleBoletaManual.items.Length > 1)
                        {
                            multiProducto = true;
                            btn_producto_anterior.Enabled = multiProducto;
                            btn_producto_siguiente.Enabled = multiProducto;
                        }
                        for (int p = 0; p < detalleBoletaManual.items.Length; p++)
                        {
                            VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoletaManual.items[p].variant.href));
                            ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                            if (productoBsale.id != 338)
                            {

                                string formatoProducto = variante.description.ToString();
                                formatoProducto = formatoProducto.Replace(".", ",");
                                formatoProducto = formatoProducto.Trim();
                                MultiproductoBsale mbsaleLista = new MultiproductoBsale();
                                mbsaleLista.nombre = productoBsale.name;
                                mbsaleLista.peso = formatoProducto;
                                mbsaleLista.cantidad = detalleBoletaManual.items[p].quantity.ToString();
                                mbsaleLista.precio = detalleBoletaManual.items[p].totalAmount.ToString();
                                MultiproductoBsale.Add(mbsaleLista);                               
                                txt_producto_re.Text = MultiproductoBsale[0].nombre;
                                txt_direccion_re.Text = boletaManual.items[a].address;
                                txt_comuna_re.Text = boletaManual.items[a].municipality;                                
                                txt_peso_re.Text = MultiproductoBsale[0].peso;
                                txt_cantidad_re.Text = MultiproductoBsale[0].cantidad;
                                txt_total_re.Text = MultiproductoBsale[0].precio;
                                vendedorRe = vendedor.firstName + " " + vendedor.lastName;                                
                                //long fechaEmision = boletaManual.items[a].emissionDate;
                                //DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                //BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                if (boletaManual.items[a].address == "Av. Gabriela Oriente 2174")
                                {
                                    txt_repartidor_re.Text = "Retiro Local";
                                }
                            }
                        }
                    }
                }
            }
            else if (cmb_tipo_documento.Text == "BE")
            {
                BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(id));
                for (int a = 0; a < boletaManual.items.Length; a++)
                {
                    if (boletaManual.items[a].document_type.id == "1")
                    {
                        if (boletaManual.items[a].client == null)
                        {
                            txt_nombre_mascota_re.Text = "-";
                            txt_nombre_re.Text = "-";
                            txt_telefono_re.Text = "-";
                            txt_correo_re.Text = "-";
                            txt_notas_re.Text = "-";
                        } else
                        {
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaManual.items[a].client.href, "?expand=[attributes]"));
                            if (infoUsuario.attributes.items[0].value != string.Empty)
                            {
                                txt_nombre_mascota_re.Text = infoUsuario.attributes.items[0].value;
                            }
                            else
                            {
                                txt_nombre_mascota_re.Text = "-";
                            }
                            txt_nombre_re.Text = infoUsuario.firstName + " " + infoUsuario.lastName;
                            txt_telefono_re.Text = infoUsuario.phone;
                            txt_correo_re.Text = infoUsuario.email;
                            if (infoUsuario.note == null)
                            {
                                txt_notas_re.Text = "-";
                            }
                            else
                            {
                                txt_notas_re.Text = infoUsuario.note.ToString();
                            }
                        }
                        DetalleBoletasBsale detalleBoletaManual = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
                        Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaManual.items[a].user.href));
                        if (detalleBoletaManual.items.Length > 1)
                        {
                            multiProducto = true;
                            btn_producto_anterior.Enabled = multiProducto;
                            btn_producto_siguiente.Enabled = multiProducto;
                        }
                        for (int p = 0; p < detalleBoletaManual.items.Length; p++)
                        {
                            VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoletaManual.items[p].variant.href));
                            ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                            if (productoBsale.id != 338)
                            {

                                string formatoProducto = variante.description.ToString();
                                formatoProducto = formatoProducto.Replace(".", ",");
                                formatoProducto = formatoProducto.Trim();
                                MultiproductoBsale mbsaleLista = new MultiproductoBsale();
                                mbsaleLista.nombre = productoBsale.name;
                                mbsaleLista.peso = formatoProducto;
                                mbsaleLista.cantidad = detalleBoletaManual.items[p].quantity.ToString();
                                mbsaleLista.precio = detalleBoletaManual.items[p].totalAmount.ToString();
                                MultiproductoBsale.Add(mbsaleLista);
                                txt_producto_re.Text = MultiproductoBsale[0].nombre;
                                txt_direccion_re.Text = boletaManual.items[a].address;
                                txt_comuna_re.Text = boletaManual.items[a].municipality;                                
                                txt_peso_re.Text = MultiproductoBsale[0].peso;
                                txt_cantidad_re.Text = MultiproductoBsale[0].cantidad;
                                txt_total_re.Text = MultiproductoBsale[0].precio;
                                vendedorRe = vendedor.firstName + " " + vendedor.lastName;                                
                                //long fechaEmision = boletaManual.items[a].emissionDate;
                                //DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                //BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                if (boletaManual.items[a].address == "Av. Gabriela Oriente 2174")
                                {
                                    txt_repartidor_re.Text = "Retiro Local";
                                }
                            }
                        }
                    }
                }
            }
            else if (cmb_tipo_documento.Text == "F")
            {
                BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(id));
                for (int a = 0; a < boletaManual.items.Length; a++)
                {
                    if (boletaManual.items[a].document_type.id == "6")
                    {
                        if (boletaManual.items[a].client == null)
                        {
                            txt_nombre_mascota_re.Text = "-";
                            txt_nombre_re.Text = "-";
                            txt_telefono_re.Text = "-";
                            txt_correo_re.Text = "-";
                            txt_notas_re.Text = "-";
                        } else
                        {
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaManual.items[a].client.href, "?expand=[attributes]"));
                            if (infoUsuario.attributes.items[0].value != string.Empty)
                            {
                                txt_nombre_mascota_re.Text = infoUsuario.attributes.items[0].value;
                            }
                            else
                            {
                                txt_nombre_mascota_re.Text = "-";
                            }
                            txt_nombre_re.Text = infoUsuario.firstName + " " + infoUsuario.lastName;
                            txt_telefono_re.Text = infoUsuario.phone;
                            txt_correo_re.Text = infoUsuario.email;
                            if (infoUsuario.note == null)
                            {
                                txt_notas_re.Text = "-";
                            }
                            else
                            {
                                txt_notas_re.Text = infoUsuario.note.ToString();
                            }
                        }                        
                        DetalleBoletasBsale detalleBoletaManual = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
                        Vendedor vendedor = JsonConvert.DeserializeObject<Vendedor>(await consultasHref(boletaManual.items[a].user.href));
                        if (detalleBoletaManual.items.Length > 1)
                        {
                            multiProducto = true;
                            btn_producto_anterior.Enabled = multiProducto;
                            btn_producto_siguiente.Enabled = multiProducto;
                        }
                        for (int p = 0; p < detalleBoletaManual.items.Length; p++)
                        {
                            VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoletaManual.items[p].variant.href));
                            ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                            if (productoBsale.id != 338)
                            {

                                string formatoProducto = variante.description.ToString();
                                formatoProducto = formatoProducto.Replace(".", ",");
                                formatoProducto = formatoProducto.Trim();
                                MultiproductoBsale mbsaleLista = new MultiproductoBsale();
                                mbsaleLista.nombre = productoBsale.name;
                                mbsaleLista.peso = formatoProducto;
                                mbsaleLista.cantidad = detalleBoletaManual.items[p].quantity.ToString();
                                mbsaleLista.precio = detalleBoletaManual.items[p].totalAmount.ToString();
                                MultiproductoBsale.Add(mbsaleLista);
                                
                                txt_producto_re.Text = MultiproductoBsale[0].nombre;
                                txt_direccion_re.Text = boletaManual.items[a].address;
                                txt_comuna_re.Text = boletaManual.items[a].municipality;
                                
                                txt_peso_re.Text = MultiproductoBsale[0].peso;
                                txt_cantidad_re.Text = MultiproductoBsale[0].cantidad;
                                txt_total_re.Text = MultiproductoBsale[0].precio;
                                vendedorRe = vendedor.firstName + " " + vendedor.lastName;
                                
                                //long fechaEmision = boletaManual.items[a].emissionDate;
                                //DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                //BBDDFinal.Cell($"P{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                if (boletaManual.items[a].address == "Av. Gabriela Oriente 2174")
                                {
                                    txt_repartidor_re.Text = "Retiro Local";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_producto_siguiente_Click(object sender, EventArgs e)
        {
            totalmultiproducto = 0;
            if (multiProducto)
            {
                if (cmb_tipo_documento.Text == "Jumpseller")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiProducto[0].order.products.Length - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto++;
                        txt_producto_re.Text = MultiProducto[0].order.products[indiceMultiProducto].name;
                        txt_peso_re.Text = MultiProducto[0].order.products[indiceMultiProducto].weight.ToString();
                        txt_cantidad_re.Text = MultiProducto[0].order.products[indiceMultiProducto].qty.ToString();
                        totalmultiproducto = ((int)MultiProducto[0].order.products[indiceMultiProducto].qty * (int)MultiProducto[0].order.products[indiceMultiProducto].price) - (int)MultiProducto[0].order.products[indiceMultiProducto].discount;
                        txt_total_re.Text = totalmultiproducto.ToString();
                    }
                }
                if (cmb_tipo_documento.Text == "BE")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiproductoBsale.Count - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto++;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
                if (cmb_tipo_documento.Text == "BM")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiproductoBsale.Count - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto++;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
                if (cmb_tipo_documento.Text == "BF")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiproductoBsale.Count - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto++;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
            }
        }

        private void btn_producto_anterior_Click(object sender, EventArgs e)
        {
            totalmultiproducto = 0;
            if (multiProducto)
            {
                if (cmb_tipo_documento.Text == "Jumpseller")
                {
                    if (indiceMultiProducto > 0)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto--;
                        txt_producto_re.Text = MultiProducto[0].order.products[indiceMultiProducto].name;
                        txt_peso_re.Text = MultiProducto[0].order.products[indiceMultiProducto].weight.ToString();
                        txt_cantidad_re.Text = MultiProducto[0].order.products[indiceMultiProducto].qty.ToString();
                        totalmultiproducto = ((int)MultiProducto[0].order.products[indiceMultiProducto].qty * (int)MultiProducto[0].order.products[indiceMultiProducto].price) - (int)MultiProducto[0].order.products[indiceMultiProducto].discount;
                        txt_total_re.Text = totalmultiproducto.ToString();
                    }
                }
                if (cmb_tipo_documento.Text == "BE")
                {
                    if (indiceMultiProducto > 0)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto--;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
                if (cmb_tipo_documento.Text == "BM")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiproductoBsale.Count - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto--;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
                if (cmb_tipo_documento.Text == "F")
                {
                    if (indiceMultiProducto > -1 && indiceMultiProducto < MultiproductoBsale.Count - 1)
                    {
                        txt_producto_re.Text = string.Empty;
                        indiceMultiProducto--;
                        txt_producto_re.Text = MultiproductoBsale[indiceMultiProducto].nombre;
                        txt_peso_re.Text = MultiproductoBsale[indiceMultiProducto].peso;
                        txt_cantidad_re.Text = MultiproductoBsale[indiceMultiProducto].cantidad;
                        txt_total_re.Text = MultiproductoBsale[indiceMultiProducto].precio;
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var workBook = new XLWorkbook($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            var reRoutix = workBook.Worksheet("Resagados ROUTIX");
            var reBBDDFinal = workBook.Worksheet("Resagados BBDD Final");
            if (cmb_tipo_documento.Text == "Jumpseller")
            {
                reBBDDFinal.Cell($"B{contadorResagados}").Value = txt_nombre_re.Text;
                reBBDDFinal.Cell($"C{contadorResagados}").Value = txt_nombre_mascota_re.Text;
                reBBDDFinal.Cell($"D{contadorResagados}").Value = txt_direccion_re.Text;
                reBBDDFinal.Cell($"E{contadorResagados}").Value = txt_comuna_re.Text;
                reBBDDFinal.Cell($"F{contadorResagados}").Value = txt_telefono_re.Text;
                reBBDDFinal.Cell($"G{contadorResagados}").Value = txt_correo_re.Text;
                reBBDDFinal.Cell($"H{contadorResagados}").Value = txt_producto_re.Text;
                reBBDDFinal.Cell($"I{contadorResagados}").Value = txt_peso_re.Text;
                reBBDDFinal.Cell($"J{contadorResagados}").Value = txt_cantidad_re.Text;
                reBBDDFinal.Cell($"K{contadorResagados}").Value = txt_total_re.Text;
                reBBDDFinal.Cell($"L{contadorResagados}").Value = medioPagoRe;
                reBBDDFinal.Cell($"M{contadorResagados}").Value = txt_notas_re.Text;
                reBBDDFinal.Cell($"Q{contadorResagados}").Value = txt_forma_envio_re.Text;
                reBBDDFinal.Cell($"R{contadorResagados}").Value = txt_repartidor_re.Text;
                reBBDDFinal.Cell($"S{contadorResagados}").Value = "Casa Matriz";
                reBBDDFinal.Cell($"T{contadorResagados}").Value = "Santiago";
                reBBDDFinal.Cell($"U{contadorResagados}").Value = txt_pedido_resagado.Text;
                reBBDDFinal.Cell($"V{contadorResagados}").Value = txt_pedido_resagado.Text + "" + (indiceMultiProducto + 1);
                // Formato ruta resagados
                reRoutix.Cell($"B{contadorResagados}").Value = txt_nombre_re.Text;
                reRoutix.Cell($"C{contadorResagados}").Value = txt_direccion_re.Text + ", " + txt_comuna_re.Text;
                reRoutix.Cell($"E{contadorResagados}").Value = txt_cantidad_re.Text + "x " + txt_producto_re.Text + " por $" + txt_total_re.Text;
                reRoutix.Cell($"G{contadorResagados}").Value = txt_pedido_resagado.Text;
                reRoutix.Cell($"H{contadorResagados}").Value = "1";
                reRoutix.Cell($"I{contadorResagados}").Value = "00:00";
                reRoutix.Cell($"J{contadorResagados}").Value = "23:59";
                reRoutix.Cell($"K{contadorResagados}").Value = txt_correo_re.Text;
                reRoutix.Cell($"L{contadorResagados}").Value = txt_telefono_re.Text;
                reRoutix.Cell($"N{contadorResagados}").Value = txt_repartidor_re.Text;
                reRoutix.Cell($"M{contadorResagados}").Value = txt_nombre_re.Text;
            }
            else
            {
                reBBDDFinal.Cell($"B{contadorResagados}").Value = txt_nombre_re.Text;
                reBBDDFinal.Cell($"C{contadorResagados}").Value = txt_nombre_mascota_re.Text;
                reBBDDFinal.Cell($"D{contadorResagados}").Value = txt_direccion_re.Text;
                reBBDDFinal.Cell($"E{contadorResagados}").Value = txt_comuna_re.Text;
                reBBDDFinal.Cell($"F{contadorResagados}").Value = txt_telefono_re.Text;
                reBBDDFinal.Cell($"G{contadorResagados}").Value = txt_correo_re.Text;
                reBBDDFinal.Cell($"H{contadorResagados}").Value = txt_producto_re.Text;
                reBBDDFinal.Cell($"I{contadorResagados}").Value = txt_peso_re.Text;
                reBBDDFinal.Cell($"J{contadorResagados}").Value = txt_cantidad_re.Text;
                reBBDDFinal.Cell($"K{contadorResagados}").Value = txt_total_re.Text;
                reBBDDFinal.Cell($"L{contadorResagados}").Value = "-";
                reBBDDFinal.Cell($"M{contadorResagados}").Value = txt_notas_re.Text;
                reBBDDFinal.Cell($"Q{contadorResagados}").Value = txt_forma_envio_re.Text;
                reBBDDFinal.Cell($"R{contadorResagados}").Value = txt_repartidor_re.Text;
                reBBDDFinal.Cell($"S{contadorResagados}").Value = vendedorRe;
                reBBDDFinal.Cell($"T{contadorResagados}").Value = "Santiago";
                reBBDDFinal.Cell($"U{contadorResagados}").Value = cmb_tipo_documento.Text + "-" + txt_pedido_resagado.Text;
                reBBDDFinal.Cell($"V{contadorResagados}").Value = cmb_tipo_documento.Text + "-" + txt_pedido_resagado.Text;
                // Formato ruta resagados
                reRoutix.Cell($"B{contadorResagados}").Value = txt_nombre_re.Text;
                reRoutix.Cell($"C{contadorResagados}").Value = txt_direccion_re.Text + ", " + txt_comuna_re.Text;
                reRoutix.Cell($"E{contadorResagados}").Value = txt_cantidad_re.Text + "x " + txt_producto_re.Text + " de " + txt_peso_re.Text + " Kg" + " por $" + txt_total_re.Text;
                reRoutix.Cell($"G{contadorResagados}").Value = txt_pedido_resagado.Text;
                reRoutix.Cell($"H{contadorResagados}").Value = "1";
                reRoutix.Cell($"I{contadorResagados}").Value = "00:00";
                reRoutix.Cell($"J{contadorResagados}").Value = "23:59";
                reRoutix.Cell($"K{contadorResagados}").Value = txt_correo_re.Text;
                reRoutix.Cell($"L{contadorResagados}").Value = txt_telefono_re.Text;
                reRoutix.Cell($"N{contadorResagados}").Value = txt_repartidor_re.Text;
                reRoutix.Cell($"M{contadorResagados}").Value = txt_nombre_re.Text;
            }



            ////Formato para BBDD Final resagados           

            //reBBDDFinal.Cell("P1").Value = "Fecha venta";
            //reBBDDFinal.Cell("P1").Style.Fill.SetBackgroundColor(XLColor.Orange);deletesystem32

            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            contadorResagados++;
        }
    }
}
