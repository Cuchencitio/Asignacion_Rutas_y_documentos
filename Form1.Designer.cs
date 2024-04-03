namespace AutomatizacionRutas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox_id_consulta = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox_manuales = new TextBox();
            comboBox_tipo_documento = new ComboBox();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            textBox_rebotados = new TextBox();
            button_rebotados = new Button();
            label5 = new Label();
            label6 = new Label();
            button4 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            button5 = new Button();
            label3 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            check_directorio = new PictureBox();
            check_rutas = new PictureBox();
            check_bbdd = new PictureBox();
            check_nMascotas = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            cmb_tipo_documento = new ComboBox();
            btn_producto_anterior = new Button();
            btn_producto_siguiente = new Button();
            button8 = new Button();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            txt_repartidor_re = new TextBox();
            txt_forma_envio_re = new TextBox();
            txt_notas_re = new TextBox();
            txt_total_re = new TextBox();
            txt_cantidad_re = new TextBox();
            txt_peso_re = new TextBox();
            txt_producto_re = new TextBox();
            txt_correo_re = new TextBox();
            txt_telefono_re = new TextBox();
            txt_comuna_re = new TextBox();
            txt_direccion_re = new TextBox();
            txt_nombre_mascota_re = new TextBox();
            txt_nombre_re = new TextBox();
            label12 = new Label();
            label11 = new Label();
            txt_pedido_resagado = new TextBox();
            button7 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_directorio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_rutas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_bbdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_nMascotas).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_id_consulta
            // 
            textBox_id_consulta.Location = new Point(6, 493);
            textBox_id_consulta.Name = "textBox_id_consulta";
            textBox_id_consulta.Size = new Size(165, 23);
            textBox_id_consulta.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(979, 259);
            button2.Name = "button2";
            button2.Size = new Size(196, 25);
            button2.TabIndex = 4;
            button2.Text = "Generar rutas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 466);
            label1.Name = "label1";
            label1.Size = new Size(139, 24);
            label1.TabIndex = 5;
            label1.Text = "Pedido corte";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 279);
            label2.Name = "label2";
            label2.Size = new Size(189, 24);
            label2.TabIndex = 13;
            label2.Text = "Boletas manuales";
            // 
            // textBox_manuales
            // 
            textBox_manuales.Location = new Point(54, 316);
            textBox_manuales.Name = "textBox_manuales";
            textBox_manuales.Size = new Size(117, 23);
            textBox_manuales.TabIndex = 14;
            // 
            // comboBox_tipo_documento
            // 
            comboBox_tipo_documento.FormattingEnabled = true;
            comboBox_tipo_documento.Items.AddRange(new object[] { "BM", "BE", "F" });
            comboBox_tipo_documento.Location = new Point(6, 316);
            comboBox_tipo_documento.Name = "comboBox_tipo_documento";
            comboBox_tipo_documento.Size = new Size(42, 23);
            comboBox_tipo_documento.TabIndex = 15;
            // 
            // button3
            // 
            button3.Location = new Point(6, 345);
            button3.Name = "button3";
            button3.Size = new Size(165, 23);
            button3.TabIndex = 17;
            button3.Text = "Agregar boletas manuales";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 522);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1272, 24);
            progressBar1.TabIndex = 18;
            progressBar1.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(8, 112);
            label4.Name = "label4";
            label4.Size = new Size(280, 24);
            label4.TabIndex = 19;
            label4.Text = "N° de orden en JumpSeller";
            label4.Click += label4_Click;
            // 
            // textBox_rebotados
            // 
            textBox_rebotados.Location = new Point(8, 139);
            textBox_rebotados.Name = "textBox_rebotados";
            textBox_rebotados.Size = new Size(282, 23);
            textBox_rebotados.TabIndex = 20;
            // 
            // button_rebotados
            // 
            button_rebotados.Location = new Point(6, 168);
            button_rebotados.Name = "button_rebotados";
            button_rebotados.Size = new Size(284, 23);
            button_rebotados.TabIndex = 21;
            button_rebotados.Text = "Agregar Rebotados";
            button_rebotados.UseVisualStyleBackColor = true;
            button_rebotados.Click += button_rebotados_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Gold;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 16);
            label5.Name = "label5";
            label5.Size = new Size(955, 77);
            label5.TabIndex = 25;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Gold;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.FlatStyle = FlatStyle.Popup;
            label6.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(8, 220);
            label6.Name = "label6";
            label6.Size = new Size(602, 52);
            label6.TabIndex = 20;
            label6.Text = "Aqui agrega todas las boletas del reporte de productos por despachar\r\nque deban ser despachadas, incluyendo las rebotadas";
            // 
            // button4
            // 
            button4.Location = new Point(979, 366);
            button4.Name = "button4";
            button4.Size = new Size(196, 23);
            button4.TabIndex = 28;
            button4.Text = "Generar BBDD Final";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(979, 164);
            button1.Name = "button1";
            button1.Size = new Size(194, 23);
            button1.TabIndex = 29;
            button1.Text = "Elegir ruta de destino de archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(979, 471);
            button5.Name = "button5";
            button5.Size = new Size(194, 23);
            button5.TabIndex = 30;
            button5.Text = "Generar nombres de mascotas";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(979, 125);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 31;
            label3.Text = "Paso 1:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(979, 229);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 32;
            label7.Text = "Paso 2:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(979, 328);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 33;
            label8.Text = "Paso 3:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(979, 437);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 34;
            label9.Text = "Paso 4:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Gold;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(8, 397);
            label10.Name = "label10";
            label10.Size = new Size(322, 52);
            label10.TabIndex = 35;
            label10.Text = "Aqui debes agregar el ultimo pedido\r\ndespachado del día de ayer";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(296, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(67, 69);
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Location = new Point(177, 275);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 64);
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Location = new Point(177, 452);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(67, 64);
            pictureBox3.TabIndex = 38;
            pictureBox3.TabStop = false;
            // 
            // check_directorio
            // 
            check_directorio.BackColor = Color.Transparent;
            check_directorio.BackgroundImage = (Image)resources.GetObject("check_directorio.BackgroundImage");
            check_directorio.BackgroundImageLayout = ImageLayout.Center;
            check_directorio.Location = new Point(1181, 145);
            check_directorio.Name = "check_directorio";
            check_directorio.Size = new Size(100, 50);
            check_directorio.TabIndex = 39;
            check_directorio.TabStop = false;
            check_directorio.Visible = false;
            // 
            // check_rutas
            // 
            check_rutas.BackColor = Color.Transparent;
            check_rutas.BackgroundImage = (Image)resources.GetObject("check_rutas.BackgroundImage");
            check_rutas.BackgroundImageLayout = ImageLayout.Center;
            check_rutas.Location = new Point(1181, 243);
            check_rutas.Name = "check_rutas";
            check_rutas.Size = new Size(100, 50);
            check_rutas.TabIndex = 40;
            check_rutas.TabStop = false;
            check_rutas.Visible = false;
            // 
            // check_bbdd
            // 
            check_bbdd.BackColor = Color.Transparent;
            check_bbdd.BackgroundImage = (Image)resources.GetObject("check_bbdd.BackgroundImage");
            check_bbdd.BackgroundImageLayout = ImageLayout.Center;
            check_bbdd.Location = new Point(1181, 349);
            check_bbdd.Name = "check_bbdd";
            check_bbdd.Size = new Size(100, 50);
            check_bbdd.TabIndex = 41;
            check_bbdd.TabStop = false;
            check_bbdd.Visible = false;
            // 
            // check_nMascotas
            // 
            check_nMascotas.BackColor = Color.Transparent;
            check_nMascotas.BackgroundImage = (Image)resources.GetObject("check_nMascotas.BackgroundImage");
            check_nMascotas.BackgroundImageLayout = ImageLayout.Center;
            check_nMascotas.Location = new Point(1181, 456);
            check_nMascotas.Name = "check_nMascotas";
            check_nMascotas.Size = new Size(100, 50);
            check_nMascotas.TabIndex = 42;
            check_nMascotas.TabStop = false;
            check_nMascotas.Visible = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1311, 585);
            tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Gold;
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(check_nMascotas);
            tabPage1.Controls.Add(check_directorio);
            tabPage1.Controls.Add(check_bbdd);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(check_rutas);
            tabPage1.Controls.Add(textBox_rebotados);
            tabPage1.Controls.Add(pictureBox3);
            tabPage1.Controls.Add(button_rebotados);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(textBox_id_consulta);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(progressBar1);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(comboBox_tipo_documento);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox_manuales);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label6);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1303, 557);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Gold;
            tabPage2.Controls.Add(cmb_tipo_documento);
            tabPage2.Controls.Add(btn_producto_anterior);
            tabPage2.Controls.Add(btn_producto_siguiente);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(label23);
            tabPage2.Controls.Add(label22);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(label20);
            tabPage2.Controls.Add(label19);
            tabPage2.Controls.Add(label18);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(txt_repartidor_re);
            tabPage2.Controls.Add(txt_forma_envio_re);
            tabPage2.Controls.Add(txt_notas_re);
            tabPage2.Controls.Add(txt_total_re);
            tabPage2.Controls.Add(txt_cantidad_re);
            tabPage2.Controls.Add(txt_peso_re);
            tabPage2.Controls.Add(txt_producto_re);
            tabPage2.Controls.Add(txt_correo_re);
            tabPage2.Controls.Add(txt_telefono_re);
            tabPage2.Controls.Add(txt_comuna_re);
            tabPage2.Controls.Add(txt_direccion_re);
            tabPage2.Controls.Add(txt_nombre_mascota_re);
            tabPage2.Controls.Add(txt_nombre_re);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(txt_pedido_resagado);
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(button6);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1303, 557);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // cmb_tipo_documento
            // 
            cmb_tipo_documento.FormattingEnabled = true;
            cmb_tipo_documento.Items.AddRange(new object[] { "Jumpseller", "BM", "BE", "F" });
            cmb_tipo_documento.Location = new Point(452, 28);
            cmb_tipo_documento.Name = "cmb_tipo_documento";
            cmb_tipo_documento.Size = new Size(95, 23);
            cmb_tipo_documento.TabIndex = 33;
            // 
            // btn_producto_anterior
            // 
            btn_producto_anterior.Location = new Point(522, 243);
            btn_producto_anterior.Name = "btn_producto_anterior";
            btn_producto_anterior.Size = new Size(26, 55);
            btn_producto_anterior.TabIndex = 32;
            btn_producto_anterior.Text = "<";
            btn_producto_anterior.UseVisualStyleBackColor = true;
            btn_producto_anterior.Click += btn_producto_anterior_Click;
            // 
            // btn_producto_siguiente
            // 
            btn_producto_siguiente.Location = new Point(812, 243);
            btn_producto_siguiente.Name = "btn_producto_siguiente";
            btn_producto_siguiente.Size = new Size(26, 55);
            btn_producto_siguiente.TabIndex = 31;
            btn_producto_siguiente.Text = ">";
            btn_producto_siguiente.UseVisualStyleBackColor = true;
            btn_producto_siguiente.Click += btn_producto_siguiente_Click;
            // 
            // button8
            // 
            button8.Location = new Point(451, 489);
            button8.Name = "button8";
            button8.Size = new Size(355, 23);
            button8.TabIndex = 30;
            button8.Text = "Agregar a Ruta y BBDD";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(451, 452);
            label23.Name = "label23";
            label23.Size = new Size(65, 15);
            label23.TabIndex = 29;
            label23.Text = "Repartidor:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(451, 423);
            label22.Name = "label22";
            label22.Size = new Size(92, 15);
            label22.TabIndex = 28;
            label22.Text = "Forma de envio:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(451, 394);
            label21.Name = "label21";
            label21.Size = new Size(44, 15);
            label21.TabIndex = 27;
            label21.Text = "Notas: ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(451, 365);
            label20.Name = "label20";
            label20.Size = new Size(38, 15);
            label20.TabIndex = 26;
            label20.Text = "Total: ";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(451, 336);
            label19.Name = "label19";
            label19.Size = new Size(58, 15);
            label19.TabIndex = 25;
            label19.Text = "Cantidad:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(451, 307);
            label18.Name = "label18";
            label18.Size = new Size(35, 15);
            label18.TabIndex = 24;
            label18.Text = "Peso:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(452, 263);
            label17.Name = "label17";
            label17.Size = new Size(64, 15);
            label17.TabIndex = 23;
            label17.Text = "Productos:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(451, 217);
            label16.Name = "label16";
            label16.Size = new Size(46, 15);
            label16.TabIndex = 22;
            label16.Text = "Correo:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(451, 188);
            label15.Name = "label15";
            label15.Size = new Size(55, 15);
            label15.TabIndex = 21;
            label15.Text = "Telefono:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(451, 159);
            label14.Name = "label14";
            label14.Size = new Size(56, 15);
            label14.TabIndex = 20;
            label14.Text = "Comuna:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(451, 130);
            label13.Name = "label13";
            label13.Size = new Size(63, 15);
            label13.TabIndex = 19;
            label13.Text = "Dirección: ";
            // 
            // txt_repartidor_re
            // 
            txt_repartidor_re.Location = new Point(553, 449);
            txt_repartidor_re.Name = "txt_repartidor_re";
            txt_repartidor_re.Size = new Size(253, 23);
            txt_repartidor_re.TabIndex = 18;
            // 
            // txt_forma_envio_re
            // 
            txt_forma_envio_re.Location = new Point(553, 420);
            txt_forma_envio_re.Name = "txt_forma_envio_re";
            txt_forma_envio_re.Size = new Size(253, 23);
            txt_forma_envio_re.TabIndex = 17;
            // 
            // txt_notas_re
            // 
            txt_notas_re.Location = new Point(553, 391);
            txt_notas_re.Name = "txt_notas_re";
            txt_notas_re.Size = new Size(253, 23);
            txt_notas_re.TabIndex = 16;
            // 
            // txt_total_re
            // 
            txt_total_re.Location = new Point(553, 362);
            txt_total_re.Name = "txt_total_re";
            txt_total_re.Size = new Size(253, 23);
            txt_total_re.TabIndex = 15;
            // 
            // txt_cantidad_re
            // 
            txt_cantidad_re.Location = new Point(553, 333);
            txt_cantidad_re.Name = "txt_cantidad_re";
            txt_cantidad_re.Size = new Size(253, 23);
            txt_cantidad_re.TabIndex = 14;
            // 
            // txt_peso_re
            // 
            txt_peso_re.Location = new Point(553, 304);
            txt_peso_re.Name = "txt_peso_re";
            txt_peso_re.Size = new Size(253, 23);
            txt_peso_re.TabIndex = 13;
            // 
            // txt_producto_re
            // 
            txt_producto_re.Location = new Point(553, 243);
            txt_producto_re.Multiline = true;
            txt_producto_re.Name = "txt_producto_re";
            txt_producto_re.Size = new Size(253, 55);
            txt_producto_re.TabIndex = 12;
            // 
            // txt_correo_re
            // 
            txt_correo_re.Location = new Point(553, 214);
            txt_correo_re.Name = "txt_correo_re";
            txt_correo_re.Size = new Size(253, 23);
            txt_correo_re.TabIndex = 11;
            // 
            // txt_telefono_re
            // 
            txt_telefono_re.Location = new Point(553, 185);
            txt_telefono_re.Name = "txt_telefono_re";
            txt_telefono_re.Size = new Size(253, 23);
            txt_telefono_re.TabIndex = 10;
            // 
            // txt_comuna_re
            // 
            txt_comuna_re.Location = new Point(553, 156);
            txt_comuna_re.Name = "txt_comuna_re";
            txt_comuna_re.Size = new Size(253, 23);
            txt_comuna_re.TabIndex = 9;
            // 
            // txt_direccion_re
            // 
            txt_direccion_re.Location = new Point(553, 127);
            txt_direccion_re.Name = "txt_direccion_re";
            txt_direccion_re.Size = new Size(253, 23);
            txt_direccion_re.TabIndex = 8;
            // 
            // txt_nombre_mascota_re
            // 
            txt_nombre_mascota_re.Location = new Point(553, 98);
            txt_nombre_mascota_re.Name = "txt_nombre_mascota_re";
            txt_nombre_mascota_re.Size = new Size(253, 23);
            txt_nombre_mascota_re.TabIndex = 7;
            // 
            // txt_nombre_re
            // 
            txt_nombre_re.Location = new Point(553, 69);
            txt_nombre_re.Name = "txt_nombre_re";
            txt_nombre_re.Size = new Size(253, 23);
            txt_nombre_re.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(451, 101);
            label12.Name = "label12";
            label12.Size = new Size(102, 15);
            label12.TabIndex = 5;
            label12.Text = "Nombre Mascota:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(451, 72);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 4;
            label11.Text = "Nombre:";
            // 
            // txt_pedido_resagado
            // 
            txt_pedido_resagado.Location = new Point(553, 28);
            txt_pedido_resagado.Name = "txt_pedido_resagado";
            txt_pedido_resagado.Size = new Size(164, 23);
            txt_pedido_resagado.TabIndex = 3;
            // 
            // button7
            // 
            button7.Location = new Point(723, 28);
            button7.Name = "button7";
            button7.Size = new Size(83, 23);
            button7.TabIndex = 2;
            button7.Text = "Buscar";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1188, 481);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 0;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1313, 589);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)check_directorio).EndInit();
            ((System.ComponentModel.ISupportInitialize)check_rutas).EndInit();
            ((System.ComponentModel.ISupportInitialize)check_bbdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)check_nMascotas).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_rebotados;
        private TextBox textBox_id_consulta;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox_manuales;
        private ComboBox comboBox_tipo_documento;
        private Button button3;
        private ProgressBar progressBar1;
        private Label label4;
        private TextBox textBox_rebotados;
        private Label label5;
        private Label label6;
        private Button button4;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button button5;
        private Label label3;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox check_directorio;
        private PictureBox check_rutas;
        private PictureBox check_bbdd;
        private PictureBox check_nMascotas;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button6;
        private Button button7;
        private TextBox txt_pedido_resagado;
        private TextBox txt_telefono_re;
        private TextBox txt_comuna_re;
        private TextBox txt_direccion_re;
        private TextBox txt_nombre_mascota_re;
        private TextBox txt_nombre_re;
        private Label label12;
        private Label label11;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox txt_repartidor_re;
        private TextBox txt_forma_envio_re;
        private TextBox txt_notas_re;
        private TextBox txt_total_re;
        private TextBox txt_cantidad_re;
        private TextBox txt_peso_re;
        private TextBox txt_producto_re;
        private TextBox txt_correo_re;
        private Button button8;
        private Button btn_producto_anterior;
        private Button btn_producto_siguiente;
        private ComboBox cmb_tipo_documento;
    }
}