using System.Windows.Forms;

namespace Bitacora_Entrada
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Color listTextColor = Color.DimGray;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            enviar = new Panel();
            cbmedida = new ComboBox();
            lbhora = new Label();
            lbfecha = new Label();
            hidetext = new Label();
            cbtransportes = new ComboBox();
            checktransportista = new CheckBox();
            label13 = new Label();
            cbusuario = new ComboBox();
            cbmarca = new ComboBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            exportar = new PictureBox();
            registros = new Label();
            label8 = new Label();
            label7 = new Label();
            txtplacas = new TextBox();
            guardar = new PictureBox();
            agregar = new PictureBox();
            label6 = new Label();
            num = new NumericUpDown();
            label5 = new Label();
            txtfactura = new TextBox();
            label4 = new Label();
            labelchofer = new Label();
            txtnombre = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            TimerHora = new System.Windows.Forms.Timer(components);
            enviar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exportar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guardar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)agregar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // enviar
            // 
            enviar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            enviar.BackColor = SystemColors.ActiveCaption;
            enviar.Controls.Add(cbmedida);
            enviar.Controls.Add(lbhora);
            enviar.Controls.Add(lbfecha);
            enviar.Controls.Add(hidetext);
            enviar.Controls.Add(cbtransportes);
            enviar.Controls.Add(checktransportista);
            enviar.Controls.Add(label13);
            enviar.Controls.Add(cbusuario);
            enviar.Controls.Add(cbmarca);
            enviar.Controls.Add(label12);
            enviar.Controls.Add(label11);
            enviar.Controls.Add(label10);
            enviar.Controls.Add(label9);
            enviar.Controls.Add(exportar);
            enviar.Controls.Add(registros);
            enviar.Controls.Add(label8);
            enviar.Controls.Add(label7);
            enviar.Controls.Add(txtplacas);
            enviar.Controls.Add(guardar);
            enviar.Controls.Add(agregar);
            enviar.Controls.Add(label6);
            enviar.Controls.Add(num);
            enviar.Controls.Add(label5);
            enviar.Controls.Add(txtfactura);
            enviar.Controls.Add(label4);
            enviar.Controls.Add(labelchofer);
            enviar.Controls.Add(txtnombre);
            enviar.Controls.Add(label2);
            enviar.Controls.Add(pictureBox1);
            enviar.Location = new Point(0, 0);
            enviar.Name = "enviar";
            enviar.Size = new Size(1266, 730);
            enviar.TabIndex = 0;
            // 
            // cbmedida
            // 
            cbmedida.Anchor = AnchorStyles.Top;
            cbmedida.BackColor = Color.White;
            cbmedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmedida.FlatStyle = FlatStyle.Flat;
            cbmedida.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbmedida.FormattingEnabled = true;
            cbmedida.Items.AddRange(new object[] { "BULTOS", "TARIMAS" });
            cbmedida.Location = new Point(1131, 144);
            cbmedida.Name = "cbmedida";
            cbmedida.Size = new Size(121, 24);
            cbmedida.TabIndex = 8;
            cbmedida.KeyDown += cbmedida_KeyDown;
            // 
            // lbhora
            // 
            lbhora.Anchor = AnchorStyles.Top;
            lbhora.AutoSize = true;
            lbhora.BackColor = SystemColors.ActiveCaption;
            lbhora.FlatStyle = FlatStyle.Flat;
            lbhora.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbhora.ForeColor = Color.Black;
            lbhora.Location = new Point(12, 23);
            lbhora.Name = "lbhora";
            lbhora.Size = new Size(53, 18);
            lbhora.TabIndex = 33;
            lbhora.Text = "0:0:0";
            lbhora.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbfecha
            // 
            lbfecha.Anchor = AnchorStyles.Top;
            lbfecha.AutoSize = true;
            lbfecha.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbfecha.Location = new Point(12, 64);
            lbfecha.Name = "lbfecha";
            lbfecha.Size = new Size(53, 18);
            lbfecha.TabIndex = 34;
            lbfecha.Text = "0:0:0";
            lbfecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hidetext
            // 
            hidetext.Anchor = AnchorStyles.Top;
            hidetext.AutoSize = true;
            hidetext.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            hidetext.Location = new Point(307, 266);
            hidetext.Name = "hidetext";
            hidetext.Size = new Size(161, 18);
            hidetext.TabIndex = 30;
            hidetext.Text = "Nombre del Chofer";
            hidetext.Visible = false;
            // 
            // cbtransportes
            // 
            cbtransportes.Anchor = AnchorStyles.Top;
            cbtransportes.Enabled = false;
            cbtransportes.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbtransportes.FormattingEnabled = true;
            cbtransportes.Items.AddRange(new object[] { "Seleccione una opción:" });
            cbtransportes.Location = new Point(249, 228);
            cbtransportes.MaxDropDownItems = 5;
            cbtransportes.Name = "cbtransportes";
            cbtransportes.Size = new Size(291, 24);
            cbtransportes.TabIndex = 4;
            cbtransportes.Visible = false;
            cbtransportes.KeyDown += cbtransportes_KeyDown;
            cbtransportes.KeyPress += cbtransportes_KeyPress;
            cbtransportes.Leave += cbtransportes_Leave;
            // 
            // checktransportista
            // 
            checktransportista.Anchor = AnchorStyles.Top;
            checktransportista.AutoSize = true;
            checktransportista.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checktransportista.Location = new Point(249, 161);
            checktransportista.Name = "checktransportista";
            checktransportista.Size = new Size(160, 22);
            checktransportista.TabIndex = 2;
            checktransportista.Text = "¿Es transportista?";
            checktransportista.UseVisualStyleBackColor = true;
            checktransportista.CheckedChanged += checkBox1_CheckedChanged;
            checktransportista.KeyPress += checktransportista_KeyPress;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(12, 228);
            label13.Name = "label13";
            label13.Size = new Size(231, 18);
            label13.TabIndex = 29;
            label13.Text = "Nombre Vigilante / Usuario";
            // 
            // cbusuario
            // 
            cbusuario.Anchor = AnchorStyles.Top;
            cbusuario.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbusuario.FormattingEnabled = true;
            cbusuario.Location = new Point(12, 190);
            cbusuario.MaxDropDownItems = 5;
            cbusuario.Name = "cbusuario";
            cbusuario.Size = new Size(229, 24);
            cbusuario.TabIndex = 1;
            cbusuario.Text = "Usuario:";
            cbusuario.KeyDown += cbusuario_KeyDown;
            cbusuario.KeyPress += cbusuario_KeyPress;
            cbusuario.Leave += cbusuario_Leave;
            // 
            // cbmarca
            // 
            cbmarca.Anchor = AnchorStyles.Top;
            cbmarca.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbmarca.FormattingEnabled = true;
            cbmarca.Location = new Point(690, 190);
            cbmarca.Name = "cbmarca";
            cbmarca.Size = new Size(331, 24);
            cbmarca.TabIndex = 6;
            cbmarca.Text = "Proveedor:";
            cbmarca.KeyDown += cbmarca_KeyDown;
            cbmarca.KeyPress += cbmarca_KeyPress;
            cbmarca.Leave += cbmarca_Leave;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(999, 393);
            label12.Name = "label12";
            label12.Size = new Size(85, 36);
            label12.TabIndex = 26;
            label12.Text = "Agregar \r\nFactura";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(1173, 393);
            label11.Name = "label11";
            label11.Size = new Size(81, 18);
            label11.TabIndex = 25;
            label11.Text = "Guardar";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Location = new Point(51, 688);
            label10.Name = "label10";
            label10.Size = new Size(169, 15);
            label10.TabIndex = 24;
            label10.Text = "Developed by Atzin Not Found";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(35, 658);
            label9.Name = "label9";
            label9.Size = new Size(206, 21);
            label9.TabIndex = 23;
            label9.Text = "Datos guardados en Excel";
            // 
            // exportar
            // 
            exportar.Anchor = AnchorStyles.Top;
            exportar.Cursor = Cursors.Hand;
            exportar.Enabled = false;
            exportar.Image = (Image)resources.GetObject("exportar.Image");
            exportar.Location = new Point(247, 658);
            exportar.Name = "exportar";
            exportar.Size = new Size(70, 59);
            exportar.SizeMode = PictureBoxSizeMode.StretchImage;
            exportar.TabIndex = 22;
            exportar.TabStop = false;
            // 
            // registros
            // 
            registros.Anchor = AnchorStyles.Top;
            registros.AutoSize = true;
            registros.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            registros.Location = new Point(1181, 23);
            registros.Name = "registros";
            registros.Size = new Size(22, 23);
            registros.TabIndex = 21;
            registros.Text = "0";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(968, 23);
            label8.Name = "label8";
            label8.Size = new Size(225, 23);
            label8.TabIndex = 20;
            label8.Text = "Registros Guardados :";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(578, 228);
            label7.Name = "label7";
            label7.Size = new Size(60, 18);
            label7.TabIndex = 19;
            label7.Text = "Placas";
            // 
            // txtplacas
            // 
            txtplacas.Anchor = AnchorStyles.Top;
            txtplacas.CharacterCasing = CharacterCasing.Upper;
            txtplacas.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtplacas.Location = new Point(546, 190);
            txtplacas.Name = "txtplacas";
            txtplacas.PlaceholderText = "Placas";
            txtplacas.Size = new Size(138, 23);
            txtplacas.TabIndex = 5;
            txtplacas.KeyDown += txtplacas_KeyDown;
            txtplacas.KeyPress += txtplacas_KeyPress;
            // 
            // guardar
            // 
            guardar.Anchor = AnchorStyles.Top;
            guardar.Cursor = Cursors.Hand;
            guardar.Image = (Image)resources.GetObject("guardar.Image");
            guardar.Location = new Point(1181, 309);
            guardar.Name = "guardar";
            guardar.Size = new Size(68, 67);
            guardar.SizeMode = PictureBoxSizeMode.StretchImage;
            guardar.TabIndex = 17;
            guardar.TabStop = false;
            guardar.Click += guardar_Click;
            // 
            // agregar
            // 
            agregar.Anchor = AnchorStyles.Top;
            agregar.Cursor = Cursors.Hand;
            agregar.Image = (Image)resources.GetObject("agregar.Image");
            agregar.Location = new Point(999, 309);
            agregar.Name = "agregar";
            agregar.Size = new Size(70, 67);
            agregar.SizeMode = PictureBoxSizeMode.StretchImage;
            agregar.TabIndex = 16;
            agregar.TabStop = false;
            agregar.Click += agregar_Click_1;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(1181, 228);
            label6.Name = "label6";
            label6.Size = new Size(81, 18);
            label6.TabIndex = 15;
            label6.Text = "Cantidad";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // num
            // 
            num.Anchor = AnchorStyles.Top;
            num.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            num.Location = new Point(1194, 190);
            num.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num.Name = "num";
            num.Size = new Size(58, 23);
            num.TabIndex = 9;
            num.TextAlign = HorizontalAlignment.Center;
            num.KeyDown += num_KeyDown;
            num.KeyPress += num_KeyPress;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1071, 228);
            label5.Name = "label5";
            label5.Size = new Size(67, 18);
            label5.TabIndex = 11;
            label5.Text = "Factura";
            // 
            // txtfactura
            // 
            txtfactura.Anchor = AnchorStyles.Top;
            txtfactura.CharacterCasing = CharacterCasing.Upper;
            txtfactura.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtfactura.Location = new Point(1027, 190);
            txtfactura.Name = "txtfactura";
            txtfactura.PlaceholderText = "Folio de Factura";
            txtfactura.Size = new Size(156, 23);
            txtfactura.TabIndex = 7;
            txtfactura.KeyDown += txtfactura_KeyDown;
            txtfactura.KeyPress += txtfactura_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(770, 228);
            label4.Name = "label4";
            label4.Size = new Size(155, 18);
            label4.TabIndex = 9;
            label4.Text = "Proveedor / Marca";
            // 
            // labelchofer
            // 
            labelchofer.Anchor = AnchorStyles.Top;
            labelchofer.AutoSize = true;
            labelchofer.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelchofer.Location = new Point(307, 228);
            labelchofer.Name = "labelchofer";
            labelchofer.Size = new Size(161, 18);
            labelchofer.TabIndex = 7;
            labelchofer.Text = "Nombre del Chofer";
            // 
            // txtnombre
            // 
            txtnombre.Anchor = AnchorStyles.Top;
            txtnombre.CharacterCasing = CharacterCasing.Upper;
            txtnombre.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtnombre.Location = new Point(249, 189);
            txtnombre.Name = "txtnombre";
            txtnombre.PlaceholderText = "Nombre de Chofer";
            txtnombre.Size = new Size(291, 23);
            txtnombre.TabIndex = 3;
            txtnombre.KeyDown += txtnombre_KeyDown;
            txtnombre.KeyPress += txtnombre_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(88, 228);
            label2.Name = "label2";
            label2.Size = new Size(0, 18);
            label2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(356, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(516, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TimerHora
            // 
            TimerHora.Interval = 1000;
            TimerHora.Tick += TimerHora_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1264, 729);
            Controls.Add(enviar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bitacora Entrada";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            enviar.ResumeLayout(false);
            enviar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exportar).EndInit();
            ((System.ComponentModel.ISupportInitialize)guardar).EndInit();
            ((System.ComponentModel.ISupportInitialize)agregar).EndInit();
            ((System.ComponentModel.ISupportInitialize)num).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel enviar;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox txtnombre;
        private Label label5;
        private TextBox txtfactura;
        private Label label4;
        private Label labelchofer;
        private NumericUpDown num;
        private Label label6;
        private PictureBox agregar;
        private PictureBox guardar;
        private Label label7;
        private TextBox txtplacas;
        private Label registros;
        private Label label8;
        private Label label9;
        private PictureBox exportar;
        private Label label10;
        private Label label12;
        private Label label11;
        private ComboBox cbmarca;
        private Label label13;
        private ComboBox cbusuario;
        private CheckBox checktransportista;
        private ComboBox cbtransportes;
        private Label hidetext;
        private System.Windows.Forms.Timer TimerHora;
        private Label lbhora;
        private Label lbfecha;
        private ComboBox cbmedida;
    }
}