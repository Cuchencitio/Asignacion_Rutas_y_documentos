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
            checkBox_victor = new CheckBox();
            checkBox_ricardo = new CheckBox();
            checkBox_sebastian = new CheckBox();
            checkBox_christian = new CheckBox();
            checkBox_javiera = new CheckBox();
            checkBox_tono = new CheckBox();
            checkBox_ana = new CheckBox();
            label2 = new Label();
            textBox_manuales = new TextBox();
            comboBox_tipo_documento = new ComboBox();
            label3 = new Label();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            textBox_rebotados = new TextBox();
            button_rebotados = new Button();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox_id_consulta
            // 
            textBox_id_consulta.Location = new System.Drawing.Point(12, 448);
            textBox_id_consulta.Name = "textBox_id_consulta";
            textBox_id_consulta.Size = new System.Drawing.Size(165, 23);
            textBox_id_consulta.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(12, 521);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(468, 23);
            button2.TabIndex = 4;
            button2.Text = "Generar rutas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 426);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 19);
            label1.TabIndex = 5;
            label1.Text = "Pedido corte";
            // 
            // checkBox_victor
            // 
            checkBox_victor.AutoSize = true;
            checkBox_victor.Location = new System.Drawing.Point(12, 496);
            checkBox_victor.Name = "checkBox_victor";
            checkBox_victor.Size = new System.Drawing.Size(57, 19);
            checkBox_victor.TabIndex = 6;
            checkBox_victor.Text = "Victor";
            checkBox_victor.UseVisualStyleBackColor = true;
            // 
            // checkBox_ricardo
            // 
            checkBox_ricardo.AutoSize = true;
            checkBox_ricardo.Location = new System.Drawing.Point(303, 496);
            checkBox_ricardo.Name = "checkBox_ricardo";
            checkBox_ricardo.Size = new System.Drawing.Size(66, 19);
            checkBox_ricardo.TabIndex = 7;
            checkBox_ricardo.Text = "Ricardo";
            checkBox_ricardo.UseVisualStyleBackColor = true;
            // 
            // checkBox_sebastian
            // 
            checkBox_sebastian.AutoSize = true;
            checkBox_sebastian.Location = new System.Drawing.Point(142, 496);
            checkBox_sebastian.Name = "checkBox_sebastian";
            checkBox_sebastian.Size = new System.Drawing.Size(76, 19);
            checkBox_sebastian.TabIndex = 8;
            checkBox_sebastian.Text = "Sebastian";
            checkBox_sebastian.UseVisualStyleBackColor = true;
            // 
            // checkBox_christian
            // 
            checkBox_christian.AutoSize = true;
            checkBox_christian.Location = new System.Drawing.Point(224, 496);
            checkBox_christian.Name = "checkBox_christian";
            checkBox_christian.Size = new System.Drawing.Size(73, 19);
            checkBox_christian.TabIndex = 9;
            checkBox_christian.Text = "Christian";
            checkBox_christian.UseVisualStyleBackColor = true;
            // 
            // checkBox_javiera
            // 
            checkBox_javiera.AutoSize = true;
            checkBox_javiera.Location = new System.Drawing.Point(75, 496);
            checkBox_javiera.Name = "checkBox_javiera";
            checkBox_javiera.Size = new System.Drawing.Size(61, 19);
            checkBox_javiera.TabIndex = 10;
            checkBox_javiera.Text = "Javiera";
            checkBox_javiera.UseVisualStyleBackColor = true;
            // 
            // checkBox_tono
            // 
            checkBox_tono.AutoSize = true;
            checkBox_tono.Location = new System.Drawing.Point(375, 496);
            checkBox_tono.Name = "checkBox_tono";
            checkBox_tono.Size = new System.Drawing.Size(52, 19);
            checkBox_tono.TabIndex = 11;
            checkBox_tono.Text = "Toño";
            checkBox_tono.UseVisualStyleBackColor = true;
            // 
            // checkBox_ana
            // 
            checkBox_ana.AutoSize = true;
            checkBox_ana.Location = new System.Drawing.Point(433, 496);
            checkBox_ana.Name = "checkBox_ana";
            checkBox_ana.Size = new System.Drawing.Size(47, 19);
            checkBox_ana.TabIndex = 12;
            checkBox_ana.Text = "Ana";
            checkBox_ana.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 272);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(189, 24);
            label2.TabIndex = 13;
            label2.Text = "Boletas manuales";
            label2.Click += label2_Click;
            // 
            // textBox_manuales
            // 
            textBox_manuales.Location = new System.Drawing.Point(60, 309);
            textBox_manuales.Name = "textBox_manuales";
            textBox_manuales.Size = new System.Drawing.Size(117, 23);
            textBox_manuales.TabIndex = 14;
            // 
            // comboBox_tipo_documento
            // 
            comboBox_tipo_documento.FormattingEnabled = true;
            comboBox_tipo_documento.Items.AddRange(new object[] { "BM", "BE", "F" });
            comboBox_tipo_documento.Location = new System.Drawing.Point(12, 309);
            comboBox_tipo_documento.Name = "comboBox_tipo_documento";
            comboBox_tipo_documento.Size = new System.Drawing.Size(42, 23);
            comboBox_tipo_documento.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 474);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(229, 19);
            label3.TabIndex = 16;
            label3.Text = "Repartidores disponibles";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(12, 338);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(165, 23);
            button3.TabIndex = 17;
            button3.Text = "Agregar boletas manuales";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(12, 550);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(468, 23);
            progressBar1.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(14, 105);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(280, 24);
            label4.TabIndex = 19;
            label4.Text = "N° de orden en JumpSeller";
            label4.Click += label4_Click;
            // 
            // textBox_rebotados
            // 
            textBox_rebotados.Location = new System.Drawing.Point(14, 132);
            textBox_rebotados.Name = "textBox_rebotados";
            textBox_rebotados.Size = new System.Drawing.Size(282, 23);
            textBox_rebotados.TabIndex = 20;
            // 
            // button_rebotados
            // 
            button_rebotados.Location = new System.Drawing.Point(12, 161);
            button_rebotados.Name = "button_rebotados";
            button_rebotados.Size = new System.Drawing.Size(284, 23);
            button_rebotados.TabIndex = 21;
            button_rebotados.Text = "Agregar Rebotados";
            button_rebotados.UseVisualStyleBackColor = true;
            button_rebotados.Click += button_rebotados_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label5.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(12, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(953, 75);
            label5.TabIndex = 25;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label6.Font = new Font("Leelawadee UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(12, 213);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(600, 50);
            label6.TabIndex = 20;
            label6.Text = "Aqui agrega todas las boletas del reporte de productos por despachar\r\nque deban ser despachadas, incluyendo las rebotadas";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1296, 607);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(checkBox_javiera);
            Controls.Add(button3);
            Controls.Add(checkBox_ricardo);
            Controls.Add(checkBox_christian);
            Controls.Add(checkBox_victor);
            Controls.Add(textBox_manuales);
            Controls.Add(button2);
            Controls.Add(comboBox_tipo_documento);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(checkBox_ana);
            Controls.Add(checkBox_sebastian);
            Controls.Add(textBox_id_consulta);
            Controls.Add(label4);
            Controls.Add(button_rebotados);
            Controls.Add(checkBox_tono);
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
        private CheckBox checkBox_victor;
        private CheckBox checkBox_ricardo;
        private CheckBox checkBox_sebastian;
        private CheckBox checkBox_christian;
        private CheckBox checkBox_javiera;
        private CheckBox checkBox_tono;
        private CheckBox checkBox_ana;
        private Label label2;
        private TextBox textBox_manuales;
        private ComboBox comboBox_tipo_documento;
        private Label label3;
        private Button button3;
        private ProgressBar progressBar1;
        private Label label4;
        private TextBox textBox_rebotados;
        private Label label5;
        private Label label6;
    }
}