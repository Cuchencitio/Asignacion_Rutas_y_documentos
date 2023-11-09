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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_directorio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_rutas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_bbdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)check_nMascotas).BeginInit();
            SuspendLayout();
            // 
            // textBox_id_consulta
            // 
            textBox_id_consulta.Location = new Point(12, 486);
            textBox_id_consulta.Name = "textBox_id_consulta";
            textBox_id_consulta.Size = new Size(165, 23);
            textBox_id_consulta.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(985, 252);
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
            label1.Location = new Point(12, 459);
            label1.Name = "label1";
            label1.Size = new Size(139, 24);
            label1.TabIndex = 5;
            label1.Text = "Pedido corte";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 272);
            label2.Name = "label2";
            label2.Size = new Size(189, 24);
            label2.TabIndex = 13;
            label2.Text = "Boletas manuales";
            // 
            // textBox_manuales
            // 
            textBox_manuales.Location = new Point(60, 309);
            textBox_manuales.Name = "textBox_manuales";
            textBox_manuales.Size = new Size(117, 23);
            textBox_manuales.TabIndex = 14;
            // 
            // comboBox_tipo_documento
            // 
            comboBox_tipo_documento.FormattingEnabled = true;
            comboBox_tipo_documento.Items.AddRange(new object[] { "BM", "BE", "F" });
            comboBox_tipo_documento.Location = new Point(12, 309);
            comboBox_tipo_documento.Name = "comboBox_tipo_documento";
            comboBox_tipo_documento.Size = new Size(42, 23);
            comboBox_tipo_documento.TabIndex = 15;
            // 
            // button3
            // 
            button3.Location = new Point(12, 338);
            button3.Name = "button3";
            button3.Size = new Size(165, 23);
            button3.TabIndex = 17;
            button3.Text = "Agregar boletas manuales";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 515);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1272, 24);
            progressBar1.TabIndex = 18;
            progressBar1.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(14, 105);
            label4.Name = "label4";
            label4.Size = new Size(280, 24);
            label4.TabIndex = 19;
            label4.Text = "N° de orden en JumpSeller";
            label4.Click += label4_Click;
            // 
            // textBox_rebotados
            // 
            textBox_rebotados.Location = new Point(14, 132);
            textBox_rebotados.Name = "textBox_rebotados";
            textBox_rebotados.Size = new Size(282, 23);
            textBox_rebotados.TabIndex = 20;
            // 
            // button_rebotados
            // 
            button_rebotados.Location = new Point(12, 161);
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
            label5.Location = new Point(12, 9);
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
            label6.Location = new Point(14, 213);
            label6.Name = "label6";
            label6.Size = new Size(602, 52);
            label6.TabIndex = 20;
            label6.Text = "Aqui agrega todas las boletas del reporte de productos por despachar\r\nque deban ser despachadas, incluyendo las rebotadas";
            // 
            // button4
            // 
            button4.Location = new Point(985, 359);
            button4.Name = "button4";
            button4.Size = new Size(196, 23);
            button4.TabIndex = 28;
            button4.Text = "Generar BBDD Final";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(985, 157);
            button1.Name = "button1";
            button1.Size = new Size(194, 23);
            button1.TabIndex = 29;
            button1.Text = "Elegir ruta de destino de archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(985, 464);
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
            label3.Location = new Point(985, 118);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 31;
            label3.Text = "Paso 1:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(985, 222);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 32;
            label7.Text = "Paso 2:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(985, 321);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 33;
            label8.Text = "Paso 3:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(985, 430);
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
            label10.Location = new Point(14, 390);
            label10.Name = "label10";
            label10.Size = new Size(322, 52);
            label10.TabIndex = 35;
            label10.Text = "Aqui debes agregar el ultimo pedido\r\ndespachado del día de ayer";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(302, 86);
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
            pictureBox2.Location = new Point(183, 268);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 64);
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Location = new Point(183, 445);
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
            check_directorio.Location = new Point(1187, 138);
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
            check_rutas.Location = new Point(1187, 236);
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
            check_bbdd.Location = new Point(1187, 342);
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
            check_nMascotas.Location = new Point(1187, 449);
            check_nMascotas.Name = "check_nMascotas";
            check_nMascotas.Size = new Size(100, 50);
            check_nMascotas.TabIndex = 42;
            check_nMascotas.TabStop = false;
            check_nMascotas.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1296, 549);
            Controls.Add(check_nMascotas);
            Controls.Add(check_bbdd);
            Controls.Add(check_rutas);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBox_manuales);
            Controls.Add(button2);
            Controls.Add(comboBox_tipo_documento);
            Controls.Add(progressBar1);
            Controls.Add(textBox_id_consulta);
            Controls.Add(label4);
            Controls.Add(button_rebotados);
            Controls.Add(textBox_rebotados);
            Controls.Add(pictureBox2);
            Controls.Add(check_directorio);
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
            ResumeLayout(false);
            PerformLayout();
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
    }
}