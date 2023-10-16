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
        string[] ricardo = { "la cisterna", "la granja", "lo espejo", "pedro aguirre cerda", "san miguel", "san ramon", "san ramón", "san ramón ", "san ramon ",  "la cisterna", "Ricardo" };
        string[] victor = { "independencia", "quinta normal", "quinta normal ", "recoleta", "recoleta ", "santiago", "santiago centro", "Victor" };
        string[] sebastian = { "lo prado", "huechuraba", "conchali", "conchalí", "renca", "cerro navia", "pudahuel", "quilicura", "Sebastian" };
        string[] javiera = { "la florida", "macul", "peñalolen", "peñalolén", "la florida ", "Javiera" };
        string[] christian = { "cerrillos", "estación central", "estacion central", "maipú", "maipu", "maipú ", "maipu ", "Christian" };
        string[] ana = { "puente alto", "el bosque", "la pintana", "san bernardo", "san bernardo ", "puente alto ", "Ana" };

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
        int icelda = 2;
        XLWorkbook workBook = new XLWorkbook();
        int indice = 0;
        string rutaGuardado = string.Empty;
        int totalEnvios = 0;
        float pesoPedido = 0;
        int costoEnvio = 2000;
        int ipedido = 1;
        int contadorPedido = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadExcel()
        {
            Thread.Sleep(5000);
        }
        public async Task<string> consultaBoleta(string boletaManual)
        {
            string url = $"https://api.bsale.cl/v1/documents.json?number={boletaManual}";
            string token = "ad7834766bf55dfd07d1fb70d81e3db3a179f829";
            string consulta = await GetHttpBsale(url, token);
            return consulta;
        }
        public async Task<string> consultasHref(string href)
        {
            string url = href;
            string token = "ad7834766bf55dfd07d1fb70d81e3db3a179f829";
            string consulta = await GetHttpBsale(url, token);
            return consulta;
        }
        public async Task<string> consultasHrefexpand(string href, string expand)
        {
            string url = href + expand;
            string token = "ad7834766bf55dfd07d1fb70d81e3db3a179f829";
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
        public async Task<string> ConsultaPedidoUnico(string id)
        {
            string consultaOrdenes = $"https://api.jumpseller.com/v1/orders/{id}.json?login=6e0af5429c314830f7307a63298f2249&authtoken=59d8fd6f0f60dd72307e38b09078f594";
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
                string consultaOrdenes = $"https://api.jumpseller.com/v1/orders/after/{id}.json?login=6e0af5429c314830f7307a63298f2249&authtoken=59d8fd6f0f60dd72307e38b09078f594&page={ipagina}&limit=100";
                string respuesta = await GetHttp(consultaOrdenes);
                Class1[] lista = JsonConvert.DeserializeObject<Class1[]>(respuesta);
                var Ruta = workBook.AddWorksheet("Ruta");
                Ruta.Cell("A1").Value = "Numero Pedido";
                Ruta.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("B1").Value = "Productos";
                Ruta.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("C1").Value = "Direccion";
                Ruta.Cell("C1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("D1").Value = "Numero de telefono";
                Ruta.Cell("D1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("E1").Value = "Cliente";
                Ruta.Cell("E1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                Ruta.Cell("F1").Value = "Repartidor";
                Ruta.Cell("F1").Style.Fill.SetBackgroundColor(XLColor.Orange);
                string productos = string.Empty;
                if (lista.Length > 0)
                {
                    while (lista.Length > 0)
                    {

                        for (int i = 0; i < lista.Length; i++)
                        {
                            if (lista[i].order.status == "Paid" && lista[i].order.payment_method_name != "Mercadolibre" && lista[i].order.shipping_method_name != "Retiro en Local" && lista[i].order.shipment_status != "No Aplicable")
                            {
                                productos = string.Empty;
                                Ruta.Cell($"A{icelda}").Value = lista[i].order.id;
                                for (int p = 0; p < lista[i].order.products.Length; p++)
                                {
                                    productos = productos + lista[i].order.products[p].qty + "x " + lista[i].order.products[p].name + ", ";
                                }
                                Ruta.Cell($"B{icelda}").Value = productos + " x $" + lista[i].order.total;
                                Ruta.Cell($"C{icelda}").Value = lista[i].order.shipping_address.address + ", " + lista[i].order.shipping_address.municipality + ", " + lista[i].order.shipping_address.complement;
                                Ruta.Cell($"D{icelda}").Value = lista[i].order.customer.phone_prefix + lista[i].order.customer.phone;
                                Ruta.Cell($"E{icelda}").Value = lista[i].order.customer.fullname;
                                if (tono.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = victor[victor.Length - 1];
                                }
                                else if (idGalloNegro.Contains(lista[i].order.shipping_method_id))
                                {
                                    Ruta.Cell($"F{icelda}").Value = "Gallo Negro";
                                }
                                else if (lista[i].order.shipping_method_id == 159663)
                                {
                                    Ruta.Cell($"F{icelda}").Value = lista[i].order.shipping_method_name;
                                }
                                icelda = icelda + 1;



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
                        consultaOrdenes = $"https://api.jumpseller.com/v1/orders/after/{id}.json?login=6e0af5429c314830f7307a63298f2249&authtoken=59d8fd6f0f60dd72307e38b09078f594&page={ipagina}&limit=100";
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
                        Ruta.Cell($"A{icelda}").Value = pedidoUnico.order.id;
                        for (int p = 0; p < pedidoUnico.order.products.Length; p++)
                        {
                            productos = productos + pedidoUnico.order.products[p].qty + "x " + pedidoUnico.order.products[p].name + ", ";
                        }
                        Ruta.Cell($"B{icelda}").Value = productos + " x $" + pedidoUnico.order.total;
                        Ruta.Cell($"C{icelda}").Value = pedidoUnico.order.shipping_address.address + ", " + pedidoUnico.order.shipping_address.municipality + ", " + pedidoUnico.order.shipping_address.complement;
                        Ruta.Cell($"D{icelda}").Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
                        Ruta.Cell($"E{icelda}").Value = pedidoUnico.order.customer.fullname;
                        if (tono.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = tono[tono.Length - 1];
                        }
                        else if (ricardo.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = ricardo[ricardo.Length - 1];
                        }
                        else if (ana.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = ana[ana.Length - 1];
                        }
                        else if (javiera.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = javiera[javiera.Length - 1];
                        }
                        else if (christian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = christian[christian.Length - 1];
                        }
                        else if (sebastian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = sebastian[sebastian.Length - 1];
                        }
                        else if (victor.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta.Cell($"F{icelda}").Value = victor[victor.Length - 1];
                        }
                        else if (idGalloNegro.Contains(pedidoUnico.order.shipping_method_id))
                        {
                            Ruta.Cell($"F{icelda}").Value = "Gallo Negro";
                        }
                        else if (pedidoUnico.order.shipping_method_id == 159663)
                        {
                            Ruta.Cell($"F{icelda}").Value = pedidoUnico.order.shipping_method_name;
                        }
                        icelda = icelda + 1;
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
                                    productosFactura = productosFactura + detalleFactura.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaFactura.items[a].client.href));
                                Ruta.Cell($"A{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                Ruta.Cell($"B{icelda}").Value = productosFactura + " x $" + boletaFactura.items[a].totalAmount;
                                Ruta.Cell($"C{icelda}").Value = boletaFactura.items[a].address + ", " + boletaFactura.items[a].municipality;
                                Ruta.Cell($"D{icelda}").Value = infoUsuario.phone;
                                Ruta.Cell($"E{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = victor[victor.Length - 1];
                                }
                                icelda = icelda + 1;
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
                                    productosManual = productosManual + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaManual.items[a].client.href));
                                Ruta.Cell($"A{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                Ruta.Cell($"B{icelda}").Value = productosManual + " x $" + boletaManual.items[a].totalAmount;
                                Ruta.Cell($"C{icelda}").Value = boletaManual.items[a].address + ", " + boletaManual.items[a].municipality;
                                Ruta.Cell($"D{icelda}").Value = infoUsuario.phone;
                                Ruta.Cell($"E{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = victor[victor.Length - 1];
                                }
                                icelda = icelda + 1;
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
                        string productosFactura = string.Empty;
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
                                    productosFactura = productosFactura + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boleta.items[i].client.href));
                                Ruta.Cell($"A{icelda}").Value = "BE-" + boleta.items[i].number;
                                Ruta.Cell($"B{icelda}").Value = productosFactura + " x $" + boleta.items[i].totalAmount.ToString();
                                Ruta.Cell($"C{icelda}").Value = boleta.items[i].address + ", " + boleta.items[i].municipality;
                                Ruta.Cell($"D{icelda}").Value = infoUsuario.phone;
                                Ruta.Cell($"E{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta.Cell($"F{icelda}").Value = victor[victor.Length - 1];
                                }
                                icelda = icelda + 1;
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
            var BBDDFinal = workBook.AddWorksheet("BBDD Final");
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
            BBDDFinal.Cell("N1").Value = "Fecha venta";
            BBDDFinal.Cell("N1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("O1").Value = "Fecha envío";
            BBDDFinal.Cell("O1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("P1").Value = "Forma de envío";
            BBDDFinal.Cell("P1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("Q1").Value = "Repatidor";
            BBDDFinal.Cell("Q1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("R1").Value = "Estado";
            BBDDFinal.Cell("R1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("S1").Value = "Vendedor";
            BBDDFinal.Cell("S1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("T1").Value = "Sucursal";
            BBDDFinal.Cell("T1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("U1").Value = "Documento";
            BBDDFinal.Cell("U1").Style.Fill.SetBackgroundColor(XLColor.Orange);
            BBDDFinal.Cell("V1").Value = "Documento con indice";
            BBDDFinal.Cell("V1").Style.Fill.SetBackgroundColor(XLColor.Orange);



            foreach (var pedido in listaJS)
            {
                ipedido = 1;
                contadorPedido++;
                pesoPedido = 0;
                string productos = string.Empty;
                string pedidos = pedido.order.id.ToString();
                string Rebotado = await ConsultaPedidoUnico(pedidos);
                Class1 pedidoUnico = JsonConvert.DeserializeObject<Class1>(Rebotado);
                if (pedidoUnico.order.total < 20000 && pedidoUnico.order.shipping_method_id != 159655 && pedidoUnico.order.shipping_method_id != null)
                {
                    totalEnvios = totalEnvios + costoEnvio;
                    BBDDFinal.Cell($"U{icelda}").Style.Fill.SetBackgroundColor(XLColor.Yellow);
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
                    BBDDFinal.Cell($"E{icelda}").Value = pedidoUnico.order.shipping_address.municipality;
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
                    BBDDFinal.Cell($"N{icelda}").Value = pedidoUnico.order.completed_at;
                    BBDDFinal.Cell($"O{icelda}").Value = today.ToString("dd/MM/yyyy");
                    BBDDFinal.Cell($"P{icelda}").Value = pedidoUnico.order.shipping_method_name;
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
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaFactura.items[a].client.href, "?expand=[attributes]"));
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
                                    BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                    if (infoUsuario.attributes.items[0].value != string.Empty)
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                    }
                                    else
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = "-";
                                    }
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaFactura.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaFactura.items[a].municipality;
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
                                    long fechaEmision = boletaFactura.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"N{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaFactura.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"O{icelda}").Value = today.ToString("dd/MM/yyyy");
                                    BBDDFinal.Cell($"U{icelda}").Value = "F-" + boletaFactura.items[a].number;
                                    BBDDFinal.Cell($"V{icelda}").Value = "F-" + boletaFactura.items[a].number;                                    
                                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                                    icelda = icelda + 1;
                                } else
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
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaManual.items[a].client.href, "?expand=[attributes]"));
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
                                    BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                    if (infoUsuario.attributes.items[0].value != string.Empty)
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                    }
                                    else
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = "-";
                                    }
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaManual.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaManual.items[a].municipality;
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
                                    long fechaEmision = boletaManual.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"N{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaManual.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"O{icelda}").Value = today.ToString("dd/MM/yyyy");
                                    BBDDFinal.Cell($"U{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    BBDDFinal.Cell($"V{icelda}").Value = "BM-" + boletaManual.items[a].number;
                                    BBDDFinal.Cell($"A{icelda}").Value = contadorPedido;
                                    icelda = icelda + 1;
                                } else
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
                            InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHrefexpand(boletaElectronica.items[a].client.href, "?expand=[attributes]"));
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
                                    BBDDFinal.Cell($"B{icelda}").Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                    if (infoUsuario.attributes.items[0].value != string.Empty)
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = infoUsuario.attributes.items[0].value;
                                    }
                                    else
                                    {
                                        BBDDFinal.Cell($"C{icelda}").Value = "-";
                                    }
                                    BBDDFinal.Cell($"D{icelda}").Value = boletaElectronica.items[a].address;
                                    BBDDFinal.Cell($"E{icelda}").Value = boletaElectronica.items[a].municipality;
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
                                    long fechaEmision = boletaElectronica.items[a].emissionDate;
                                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(fechaEmision);
                                    BBDDFinal.Cell($"N{icelda}").Value = dateTimeOffset.ToString("dd/MM/yyyy");
                                    if (boletaElectronica.items[a].address == "Av. Gabriela Oriente 2174")
                                    {
                                        BBDDFinal.Cell($"Q{icelda}").Value = "Retiro Local";
                                    }
                                    BBDDFinal.Cell($"S{icelda}").Value = vendedor.firstName + vendedor.lastName;
                                    BBDDFinal.Cell($"T{icelda}").Value = "Santiago";
                                    BBDDFinal.Cell($"O{icelda}").Value = today.ToString("dd/MM/yyyy");
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
            var comunaDeEnvio = BBDDFinal.Cell($"E{indiceBusqueda}").GetValue<string>();
            var metodoDePago = BBDDFinal.Cell($"L{indiceBusqueda}").GetValue<string>();
            var formaDeEnvio = BBDDFinal.Cell($"P{indiceBusqueda}").GetValue<string>();
            var IndiceBBDDFinal = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
            var IndiceRutas = Rutas.Cell($"A{indicePedido}").GetValue<string>();
            while (IndiceBBDDFinal != string.Empty)
            {
                while (IndiceRutas != string.Empty)
                {

                    if (IndiceBBDDFinal == IndiceRutas)
                    {
                        string Repartidor = Rutas.Cell($"F{indicePedido}").GetValue<string>();
                        BBDDFinal.Cell($"Q{indiceBusqueda}").Value = Repartidor;
                        break;
                    }
                    else if (formaDeEnvio.Contains("Retiro"))
                    {
                        BBDDFinal.Cell($"Q{indiceBusqueda}").Value = "Retiro Local";
                        break;
                    }
                    else if (metodoDePago.Contains("Mercado"))
                    {
                        comunaDeEnvio = comunaDeEnvio.ToLower();
                        if (!comunasRM.Contains(comunaDeEnvio))
                        {
                            BBDDFinal.Cell($"Q{indiceBusqueda}").Value = "Mercado Libre";
                            break;
                        }
                        break;
                    }
                    else
                    {
                        indicePedido++;
                        IndiceRutas = Rutas.Cell($"A{indicePedido}").GetValue<string>();
                    }

                }
                indiceBusqueda++;
                IndiceBBDDFinal = BBDDFinal.Cell($"U{indiceBusqueda}").GetValue<string>();
                formaDeEnvio = BBDDFinal.Cell($"P{indiceBusqueda}").GetValue<string>();
                comunaDeEnvio = BBDDFinal.Cell($"E{indiceBusqueda}").GetValue<string>();
                metodoDePago = BBDDFinal.Cell($"L{indiceBusqueda}").GetValue<string>();
                indicePedido = 2;
                IndiceRutas = Rutas.Cell($"A{indicePedido}").GetValue<string>();
                BBDDFinal.Cell($"K{icelda}").Value = totalEnvios;
                BBDDFinal.Cell($"H{icelda}").Value = "ENVIO";
                BBDDFinal.Cell($"B{icelda}").Value = "INGRESOS POR ENVIO";
            }

            button4.Enabled = true;
            progressBar1.Visible = false;
            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
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
            var pedido = BBDDFinal.Cell($"S{indiceBusqueda}").GetValue<string>();
            var Repartidor = BBDDFinal.Cell($"O{indiceBusqueda}").GetValue<string>();
            var Mascota = BBDDFinal.Cell($"B{indiceBusqueda}").GetValue<string>();
            var Direccion = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
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
                    pedido = BBDDFinal.Cell($"S{indiceBusqueda}").GetValue<string>();
                    Repartidor = BBDDFinal.Cell($"O{indiceBusqueda}").GetValue<string>();
                    Mascota = BBDDFinal.Cell($"B{indiceBusqueda}").GetValue<string>();
                    Direccion = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
                }
                else
                {
                    indiceBusqueda++;
                    pedido = BBDDFinal.Cell($"S{indiceBusqueda}").GetValue<string>();
                    Repartidor = BBDDFinal.Cell($"O{indiceBusqueda}").GetValue<string>();
                    Mascota = BBDDFinal.Cell($"B{indiceBusqueda}").GetValue<string>();
                    Direccion = BBDDFinal.Cell($"C{indiceBusqueda}").GetValue<string>() + ", " + BBDDFinal.Cell($"D{indiceBusqueda}").GetValue<string>();
                }
            }
            button5.Enabled = true;
            progressBar1.Visible = false;
            workBook.SaveAs($"{rutaGuardado}\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
        }
    }
}
