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
            button2.Location = new Point(816, 260);
            button2.Name = "button2";
            button2.Size = new Size(468, 25);
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
            label5.BackColor = Color.FromArgb(255, 128, 0);
            label5.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(953, 75);
            label5.TabIndex = 25;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(255, 128, 0);
            label6.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 213);
            label6.Name = "label6";
            label6.Size = new Size(600, 50);
            label6.TabIndex = 20;
            label6.Text = "Aqui agrega todas las boletas del reporte de productos por despachar\r\nque deban ser despachadas, incluyendo las rebotadas";
            // 
            // button4
            // 
            button4.Location = new Point(816, 347);
            button4.Name = "button4";
            button4.Size = new Size(468, 23);
            button4.TabIndex = 28;
            button4.Text = "Generar BBDD Final";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(816, 188);
            button1.Name = "button1";
            button1.Size = new Size(466, 23);
            button1.TabIndex = 29;
            button1.Text = "Elegir ruta de destino de archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(816, 441);
            button5.Name = "button5";
            button5.Size = new Size(466, 23);
            button5.TabIndex = 30;
            button5.Text = "Generar nombres de mascotas";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(816, 149);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 31;
            label3.Text = "Paso 1:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(816, 230);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 32;
            label7.Text = "Paso 2:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(816, 309);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 33;
            label8.Text = "Paso 3:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(816, 398);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 34;
            label9.Text = "Paso 4:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.DarkOrange;
            label10.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(14, 390);
            label10.Name = "label10";
            label10.Size = new Size(320, 50);
            label10.TabIndex = 35;
            label10.Text = "Aqui debes agregar el ultimo pedido\r\ndespachado del día de ayer";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 549);
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
            Name = "Form1";
            Text = "Form1";
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
    }
}