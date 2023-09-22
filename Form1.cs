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
using IronXL;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp.Drawing;
using System.Text.RegularExpressions;

namespace AutomatizacionRutas

{
    public partial class Form1 : Form
    {
        DateTime today = DateTime.Today;
        int?[] idGalloNegro = { 453817, 457736 };
        string[] tono = { "las condes", "vitacura", "la reina", "lo barnechea", "ñuñoa", "providencia", "san joaquin", "san joaquín", "vitacura", "la reina", "Toño" };
        string[] ricardo = { "la cisterna", "la granja", "lo espejo", "pedro aguirre cerda", "san miguel", "san ramon", "san ramón", "la cisterna", "Ricardo" };
        string[] victor = { "independencia", "quinta normal", "recoleta", "santiago", "santiago centro", "Victor" };
        string[] sebastian = { "lo prado", "huechuraba", "conchali", "conchalí", "renca", "cerro navia", "pudahuel", "Sebastian" };
        string[] javiera = { "la florida", "macul", "peñalolen", "peñalolén", "Javiera" };
        string[] christian = { "cerrillos", "estación central", "estacion central", "maipú", "maipu", "Christian" };
        string[] ana = { "puente alto", "el bosque", "la pintana", "san bernardo", "Ana" };
        List<String> facturas = new List<String>();
        List<String> boletasManuales = new List<String>();
        List<String> boletasElectronicas = new List<String>();
        List<String> rebotados = new List<String>();
        List<Class1> listaJS = new List<Class1>();
        int icelda = 1;
        WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
        int indice = 0;
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
                WorkSheet Ruta = workBook.CreateWorkSheet("Ruta");
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
                                Ruta["A" + (icelda)].Value = lista[i].order.id;
                                for (int p = 0; p < lista[i].order.products.Length; p++)
                                {
                                    productos = productos + lista[i].order.products[p].qty + "x " + lista[i].order.products[p].name + ", ";
                                }
                                Ruta["B" + (icelda)].Value = productos + " x $" + lista[i].order.total;
                                Ruta["C" + (icelda)].Value = lista[i].order.shipping_address.address + ", " + lista[i].order.shipping_address.municipality;
                                Ruta["D" + (icelda)].Value = lista[i].order.customer.phone_prefix + lista[i].order.customer.phone;
                                Ruta["E" + (icelda)].Value = lista[i].order.customer.fullname;
                                if (tono.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(lista[i].order.shipping_address.municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
                                }
                                else if (idGalloNegro.Contains(lista[i].order.shipping_method_id))
                                {
                                    Ruta["F" + (icelda)].Value = "Gallo Negro";
                                }
                                else if (lista[i].order.shipping_method_id == 159663)
                                {
                                    Ruta["F" + (icelda)].Value = lista[i].order.shipping_method_name;
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
                        Ruta["A" + (icelda)].Value = pedidoUnico.order.id;
                        for (int p = 0; p < pedidoUnico.order.products.Length; p++)
                        {
                            productos = productos + pedidoUnico.order.products[p].qty + "x " + pedidoUnico.order.products[p].name + ", ";
                        }
                        Ruta["B" + (icelda)].Value = productos + " x $" + pedidoUnico.order.total;
                        Ruta["C" + (icelda)].Value = pedidoUnico.order.shipping_address.address + ", " + pedidoUnico.order.shipping_address.municipality;
                        Ruta["D" + (icelda)].Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
                        Ruta["E" + (icelda)].Value = pedidoUnico.order.customer.fullname;
                        if (tono.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
                        }
                        else if (ricardo.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
                        }
                        else if (ana.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
                        }
                        else if (javiera.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
                        }
                        else if (christian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
                        }
                        else if (sebastian.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
                        }
                        else if (victor.Contains(pedidoUnico.order.shipping_address.municipality.ToLower()))
                        {
                            Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
                        }
                        else if (idGalloNegro.Contains(pedidoUnico.order.shipping_method_id))
                        {
                            Ruta["F" + (icelda)].Value = "Gallo Negro";
                        }
                        else if (pedidoUnico.order.shipping_method_id == 159663)
                        {
                            Ruta["F" + (icelda)].Value = pedidoUnico.order.shipping_method_name;
                        }
                        icelda = icelda + 1;
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
                            if (boletaFactura.items[a].document_type.id == "6")
                            {
                                DetalleBoletasBsale detalleFactura = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaFactura.items[a].details.href));
                                for (int p = 0; p < detalleFactura.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleFactura.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosFactura = productosFactura + detalleFactura.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaFactura.items[a].client.href));
                                Ruta["A" + (icelda)].Value = "F-" + boletaFactura.items[a].number;
                                Ruta["B" + (icelda)].Value = productosFactura;
                                Ruta["C" + (icelda)].Value = boletaFactura.items[a].address + ", " + boletaFactura.items[a].municipality;
                                Ruta["D" + (icelda)].Value = infoUsuario.phone;
                                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boletaFactura.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
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
                            if (boletaManual.items[a].document_type.id == "10")
                            {
                                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
                                for (int p = 0; p < detalleBoleta.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosManual = productosManual + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaManual.items[a].client.href));
                                Ruta["A" + (icelda)].Value = "BM-" + boletaManual.items[a].number;
                                Ruta["B" + (icelda)].Value = productosManual;
                                Ruta["C" + (icelda)].Value = boletaManual.items[a].address + ", " + boletaManual.items[a].municipality;
                                Ruta["D" + (icelda)].Value = infoUsuario.phone;
                                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boletaManual.items[a].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
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
                            if (boleta.items[i].document_type.id == "1")
                            {
                                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boleta.items[i].details.href));
                                for (int p = 0; p < detalleBoleta.items.Length; p++)
                                {
                                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
                                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
                                    productosFactura = productosFactura + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
                                }
                                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boleta.items[i].client.href));
                                Ruta["A" + (icelda)].Value = "BE-" + boleta.items[i].number;
                                Ruta["B" + (icelda)].Value = productosFactura;
                                Ruta["C" + (icelda)].Value = boleta.items[i].address + ", " + boleta.items[i].municipality;
                                Ruta["D" + (icelda)].Value = infoUsuario.phone;
                                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
                                if (tono.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
                                }
                                else if (ricardo.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
                                }
                                else if (ana.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
                                }
                                else if (javiera.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
                                }
                                else if (christian.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
                                }
                                else if (sebastian.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
                                }
                                else if (victor.Contains(boleta.items[i].municipality.ToLower()))
                                {
                                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
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
                workBook.SaveAs($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            }
            else
            {
                MessageBox.Show("No se ha ingresado un pedido de corte");
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox_tipo_documento.Text == "F" && textBox_manuales.Text.Trim() != string.Empty)
            {
                facturas.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else if (comboBox_tipo_documento.Text == "BE" && textBox_manuales.Text.Trim() != string.Empty)
            {
                boletasElectronicas.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else if (comboBox_tipo_documento.Text == "BM" && textBox_manuales.Text.Trim() != string.Empty)
            {
                boletasManuales.Add(textBox_manuales.Text);
                textBox_manuales.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else
            {
                MessageBox.Show("Debes ingresar un numero de boleta valido");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button_rebotados_Click(object sender, EventArgs e)
        {
            if (textBox_rebotados.Text.Trim() != string.Empty)
            {
                rebotados.Add(textBox_rebotados.Text);
                textBox_rebotados.Text = string.Empty;
                MessageBox.Show("Valor agregado correctamente");
            }
            else
            {

                MessageBox.Show("Debes ingresar un numero de pedido valido");
            }
        }

        private async void button_bbddfinal_Click(object sender, EventArgs e)
        {
            //icelda = 1;
            //WorkBook wb = WorkBook.Load($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            //WorkSheet Rutas = wb.GetWorkSheet("Ruta");
            //WorkSheet BBDDFinal = workBook.CreateWorkSheet("BBDD Final");
            //string productos = string.Empty;
            //int qty = 0;
            //if (rebotados.Count > 0)
            //{
            //    foreach (string rebotado in rebotados)
            //    {
            //        qty = 0;
            //        productos = string.Empty;
            //        string Rebotado = await ConsultaPedidoUnico(rebotado);
            //        Class1 pedidoUnico = JsonConvert.DeserializeObject<Class1>(Rebotado);
            //        BBDDFinal["A" + (icelda)].Value = pedidoUnico.order.customer.fullname;
            //        BBDDFinal["B" + (icelda)].Value = pedidoUnico.order.additional_fields[0].value;
            //        BBDDFinal["C" + (icelda)].Value = pedidoUnico.order.shipping_address.address;
            //        BBDDFinal["D" + (icelda)].Value = pedidoUnico.order.shipping_address.municipality;
            //        BBDDFinal["E" + (icelda)].Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
            //        BBDDFinal["F" + (icelda)].Value = pedidoUnico.order.customer.email;

            //        BBDDFinal["K" + (icelda)].Value = pedidoUnico.order.payment_method_name;
            //        BBDDFinal["L" + (icelda)].Value = pedidoUnico.order.additional_information;
            //        BBDDFinal["M" + (icelda)].Value = pedidoUnico.order.completed_at;
            //        BBDDFinal["N" + (icelda)].Value = pedidoUnico.order.shipping_method_name;
            //        BBDDFinal["P" + (icelda)].Value = "Casa Matriz";
            //        BBDDFinal["Q" + (icelda)].Value = "Santiago";
            //        BBDDFinal["R" + (icelda)].Value = pedidoUnico.order.id;
            //        int indiceBusqueda = 0;
            //        foreach (var r in BBDDFinal[$"A0:A{rebotados.Count}"])
            //        {
            //            foreach (var p in Rutas[$"A0:A{Rutas.Count}"])
            //            {
            //                if (r.Value == p.Value)
            //                {
            //                    BBDDFinal["O" + (icelda)].Value = Rutas["F" + indiceBusqueda].Value;
            //                    break;
            //                }
            //                indiceBusqueda = indiceBusqueda + 1;
            //            }
            //            break;
            //        }
            //        for (int p = 0; p < pedidoUnico.order.products.Length; p++)
            //        {
            //            productos = productos + pedidoUnico.order.products[p].name;
            //            string kg = Regex.Match(productos, @"\d+").Value;
            //            if (productos.Contains("("))
            //            {
            //                int indice1 = productos.IndexOf('(');
            //                int indice2 = productos.IndexOf(')');
            //                productos.Remove(indice1, (indice2 - indice1));
            //            }
            //            BBDDFinal["G" + (icelda)].Value = productos;
            //            BBDDFinal["H" + (icelda)].Value = kg;
            //            BBDDFinal["I" + (icelda)].Value = pedidoUnico.order.products[p].qty;
            //            BBDDFinal["J" + (icelda)].Value = pedidoUnico.order.products[p].price;
            //            icelda = icelda + 1;
            //        }
            //        //icelda = icelda + 1;
            //    }
            //    workBook.SaveAs($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            //}
            //if (facturas.Count > 0)
            //{
            //    foreach (string nf in facturas)
            //    {
            //        string productosFactura = string.Empty;
            //        BoletaBsale boletaFactura = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nf));
            //        for (int a = 0; a < boletaFactura.items.Length; a++)
            //        {
            //            if (boletaFactura.items[a].document_type.id == "6")
            //            {
            //                DetalleBoletasBsale detalleFactura = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaFactura.items[a].details.href));
            //                for (int p = 0; p < detalleFactura.items.Length; p++)
            //                {
            //                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleFactura.items[p].variant.href));
            //                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
            //                    productosFactura = productosFactura + detalleFactura.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
            //                }
            //                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaFactura.items[a].client.href));
            //                Ruta["A" + (icelda)].Value = "F-" + boletaFactura.items[a].number;
            //                Ruta["B" + (icelda)].Value = productosFactura;
            //                Ruta["C" + (icelda)].Value = boletaFactura.items[a].address + ", " + boletaFactura.items[a].municipality;
            //                Ruta["D" + (icelda)].Value = infoUsuario.phone;
            //                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
            //                if (tono.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
            //                }
            //                else if (ricardo.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
            //                }
            //                else if (ana.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
            //                }
            //                else if (javiera.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
            //                }
            //                else if (christian.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
            //                }
            //                else if (sebastian.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
            //                }
            //                else if (victor.Contains(boletaFactura.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
            //                }
            //                icelda = icelda + 1;
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //}
            //if (boletasManuales.Count > 0)
            //{
            //    foreach (string nbm in boletasManuales)
            //    {
            //        string productosManual = string.Empty;
            //        BoletaBsale boletaManual = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nbm));
            //        for (int a = 0; a < boletaManual.items.Length; a++)
            //        {
            //            if (boletaManual.items[a].document_type.id == "10")
            //            {
            //                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boletaManual.items[a].details.href));
            //                for (int p = 0; p < detalleBoleta.items.Length; p++)
            //                {
            //                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
            //                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
            //                    productosManual = productosManual + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
            //                }
            //                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boletaManual.items[a].client.href));
            //                Ruta["A" + (icelda)].Value = "BM-" + boletaManual.items[a].number;
            //                Ruta["B" + (icelda)].Value = productosManual;
            //                Ruta["C" + (icelda)].Value = boletaManual.items[a].address + ", " + boletaManual.items[a].municipality;
            //                Ruta["D" + (icelda)].Value = infoUsuario.phone;
            //                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
            //                if (tono.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
            //                }
            //                else if (ricardo.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
            //                }
            //                else if (ana.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
            //                }
            //                else if (javiera.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
            //                }
            //                else if (christian.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
            //                }
            //                else if (sebastian.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
            //                }
            //                else if (victor.Contains(boletaManual.items[a].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
            //                }
            //                icelda = icelda + 1;
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //}
            //if (boletasElectronicas.Count > 0)
            //{
            //    foreach (string nboleta in boletasElectronicas)
            //    {
            //        string productosFactura = string.Empty;
            //        BoletaBsale boleta = JsonConvert.DeserializeObject<BoletaBsale>(await consultaBoleta(nboleta));
            //        for (int i = 0; i < boleta.items.Length; i++)
            //        {
            //            if (boleta.items[i].document_type.id == "1")
            //            {
            //                DetalleBoletasBsale detalleBoleta = JsonConvert.DeserializeObject<DetalleBoletasBsale>(await consultasHref(boleta.items[i].details.href));
            //                for (int p = 0; p < detalleBoleta.items.Length; p++)
            //                {
            //                    VarianteProductoBsale variante = JsonConvert.DeserializeObject<VarianteProductoBsale>(await consultasHref(detalleBoleta.items[p].variant.href));
            //                    ProductoBsale productoBsale = JsonConvert.DeserializeObject<ProductoBsale>(await consultasHref(variante.product.href));
            //                    productosFactura = productosFactura + detalleBoleta.items[p].quantity + "x " + productoBsale.name + " " + variante.description + ", ";
            //                }
            //                InformacionUsuarios infoUsuario = JsonConvert.DeserializeObject<InformacionUsuarios>(await consultasHref(boleta.items[i].client.href));
            //                Ruta["A" + (icelda)].Value = "BE-" + boleta.items[i].number;
            //                Ruta["B" + (icelda)].Value = productosFactura;
            //                Ruta["C" + (icelda)].Value = boleta.items[i].address + ", " + boleta.items[i].municipality;
            //                Ruta["D" + (icelda)].Value = infoUsuario.phone;
            //                Ruta["E" + (icelda)].Value = infoUsuario.firstName + " " + infoUsuario.lastName;
            //                if (tono.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = tono[tono.Length - 1];
            //                }
            //                else if (ricardo.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ricardo[ricardo.Length - 1];
            //                }
            //                else if (ana.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = ana[ana.Length - 1];
            //                }
            //                else if (javiera.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = javiera[javiera.Length - 1];
            //                }
            //                else if (christian.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = christian[christian.Length - 1];
            //                }
            //                else if (sebastian.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = sebastian[sebastian.Length - 1];
            //                }
            //                else if (victor.Contains(boleta.items[i].municipality.ToLower()))
            //                {
            //                    Ruta["F" + (icelda)].Value = victor[victor.Length - 1];
            //                }
            //                icelda = icelda + 1;
            //            }
            //            else
            //            {
            //                continue;
            //            }

            //        }
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkSheet BBDDFinal = workBook.CreateWorkSheet("BBDD final");
            workBook.SaveAs($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            icelda = 1;
            WorkBook wb = WorkBook.Load($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");
            WorkSheet Rutas = wb.GetWorkSheet("Ruta");
            WorkSheet BBDDFinal = workBook.CreateWorkSheet("BBDD Final");
            foreach (var pedido in listaJS)
            {                    
                            string productos = string.Empty;
                        
                        
                            string pedidos = pedido.order.id.ToString();                          
                            productos = string.Empty;
                            string Rebotado = await ConsultaPedidoUnico(pedidos);
                            Class1 pedidoUnico = JsonConvert.DeserializeObject<Class1>(Rebotado);
                            BBDDFinal["A" + (icelda)].Value = pedidoUnico.order.customer.fullname;
                            if (pedidoUnico.order.additional_fields.Length > 0)
                            {
                                BBDDFinal["B" + (icelda)].Value = pedidoUnico.order.additional_fields[0].value;
                            }                           
                            BBDDFinal["C" + (icelda)].Value = pedidoUnico.order.shipping_address.address;
                            BBDDFinal["D" + (icelda)].Value = pedidoUnico.order.shipping_address.municipality;
                            BBDDFinal["E" + (icelda)].Value = pedidoUnico.order.customer.phone_prefix + pedidoUnico.order.customer.phone;
                            BBDDFinal["F" + (icelda)].Value = pedidoUnico.order.customer.email;

                            BBDDFinal["K" + (icelda)].Value = pedidoUnico.order.payment_method_name;
                            BBDDFinal["L" + (icelda)].Value = pedidoUnico.order.additional_information;
                            BBDDFinal["M" + (icelda)].Value = pedidoUnico.order.completed_at;
                            BBDDFinal["N" + (icelda)].Value = pedidoUnico.order.shipping_method_name;
                            BBDDFinal["P" + (icelda)].Value = "Casa Matriz";
                            BBDDFinal["Q" + (icelda)].Value = "Santiago";
                            BBDDFinal["R" + (icelda)].Value = pedidoUnico.order.id;                            
                            for (int p = 0; p < pedidoUnico.order.products.Length; p++)
                            {
                                productos = productos + pedidoUnico.order.products[p].name;
                                string kg = Regex.Match(productos, @"\d+").Value;
                                if (productos.Contains("("))
                                {
                                    int indice1 = productos.IndexOf('(');
                                    int indice2 = productos.IndexOf(')');
                                    productos.Remove(indice1, (indice2 - indice1));
                                }
                                BBDDFinal["G" + (icelda)].Value = productos;
                                productos = string.Empty;
                                BBDDFinal["H" + (icelda)].Value = kg;
                                BBDDFinal["I" + (icelda)].Value = pedidoUnico.order.products[p].qty;
                                BBDDFinal["J" + (icelda)].Value = pedidoUnico.order.products[p].price;
                                icelda = icelda + 1;
                            }
                            //icelda = icelda + 1;
                        
                        workBook.SaveAs($"C:\\Users\\cesar\\Documentos\\Archivo Ruta {today.ToString("dd/MM/yyyy")}.xlsx");                   
                    
                }
            }
        }
    }
