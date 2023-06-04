using SpreadsheetLight;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.InkML;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Bitacora_Entrada
{
    public partial class Form1 : Form
    {
        int registro = 0;
        public Form1()
        {
            InitializeComponent();
            SLDocument oSLDocument = new SLDocument();
            DataTable table = new DataTable();
            datos();
            cbmedida.SelectedIndex = 0;
            cbusuario.Select();
            TimerHora.Start();
        }
        private List<string> usuarios = new List<string> { };
        private List<string> nombres = new List<string> { };
        private List<string> transportes = new List<string> { };
        static async Task Base(string labelhora, string labelfecha, string usuario, string nombre, string transportista, string placas, string marca, string factura, decimal num, string medida)
        { 
            using (var db = new DatabaseDbContext())
            {
                await db.Database.EnsureCreatedAsync();
                var dato = new Dato()
                {
                    Hora = labelhora,
                    Fecha = labelfecha,
                    NombreUsuario = usuario,
                    NombreChofer = nombre,
                    NombreTransportista = transportista,
                    Placas = placas,
                    Marca = marca,
                    Factura = factura,
                    Cantidad = num,
                    Medida = medida
                };
                db.Add(dato);
                await db.SaveChangesAsync();
            }
        }
        private class Dato
        {
            public int BaseId { get; set; }
            public string Hora { get; set; }
            public string Fecha { get; set; }
            public string NombreUsuario { get; set; }
            public string NombreChofer { get; set; }
            public string NombreTransportista { get; set; }
            public string Placas { get; set; }
            public string Marca { get; set; }
            public string Factura { get; set; }
            public decimal Cantidad { get; set; }
            public string Medida { get; set; }
        }

        public class DatabaseDbContext : DbContext
        {
            private DbSet<Dato> Datos { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string databasePath = "C:\\Bitacora\\basededatos.db"; // Ruta personalizada hacia la base de datos SQLite
                if (!File.Exists(databasePath))
                {
                    File.Create(databasePath).Close();
                }
                optionsBuilder.UseSqlite($"Data Source={databasePath}",
                    sqliteOptionsAction: op =>
                    {
                        op.MigrationsAssembly(
                            Assembly.GetExecutingAssembly().FullName
                            );
                    });
                base.OnConfiguring(optionsBuilder);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Dato>().ToTable("Datos");
                modelBuilder.Entity<Dato>(entity =>
                {
                    entity.HasKey(x => x.BaseId);
                });
            }

        }
        public void datos()
        {
            string filePath = "C:\\Bitacora\\Proveedores.txt";
            string filePath2 = "C:\\Bitacora\\Usuarios.txt";
            string filePath3 = "C:\\Bitacora\\Transportes.txt";
            // Leer el contenido del archivo y asignarlo a una matriz de cadenas
            string[] nombresArray = File.ReadAllLines(filePath);
            string[] usuariosArray = File.ReadAllLines(filePath2);
            string[] transportesArray = File.ReadAllLines(filePath3);

            nombres = new List<string>(nombresArray);
            usuarios = new List<string>(usuariosArray);
            transportes = new List<string>(transportesArray);

            cbmarca.DataSource = nombres;
            cbusuario.DataSource = usuarios;
            cbtransportes.DataSource = transportes;
            cbmarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbmarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbmarca.AutoCompleteCustomSource.AddRange(nombres.ToArray());

            cbusuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbusuario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbusuario.AutoCompleteCustomSource.AddRange(usuarios.ToArray());

            cbtransportes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbtransportes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbtransportes.AutoCompleteCustomSource.AddRange(transportes.ToArray());

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estás Seguro que Deseas Salir del Programa?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Result == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private async void guardar_Click(object sender, EventArgs e)
        {
            if (txtplacas.Text != "" && lbhora.Text != "" && lbfecha.Text != " " && txtnombre.Text != String.Empty && cbmarca.Text != String.Empty &&
            txtfactura.Text != String.Empty && num.Value != 0 && cbusuario.Text != "Seleccione una opción:" && cbmarca.Text != "Seleccione una opción:")
            {
                if (!checktransportista.Checked || checktransportista.Checked && cbtransportes.Text == "Seleccione una opción:")
                    cbtransportes.Text = "N/A";

                await Base(lbhora.Text,lbfecha.Text,cbusuario.Text, txtnombre.Text, cbtransportes.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value, cbmedida.Text);
                string path = "C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx";
                bool fileExist = File.Exists(path);
                if (fileExist)
                {
                    SLDocument sl = new SLDocument("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx", "Sheet1");
                    int i = 1;
                    while (sl.HasCellValue("A" + i))
                    {
                        i++;
                    }
                    int[] columnas = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    foreach (int columna in columnas)
                    {
                        sl.SetColumnWidth(columna, 30);
                        if (columna == 1)
                            sl.SetColumnWidth(columna, 5);
                        if (columna == 6 || columna == 3 || columna == 8 || columna == 9)
                            sl.SetColumnWidth(columna, 10);
                        if (columna == 5)
                            sl.SetColumnWidth(columna, 40);
                    }
                    sl.SetCellValue("A" + i, i - 1);
                    sl.SetCellValue("B" + i, cbusuario.Text);
                    sl.SetCellValue("C" + i, lbhora.Text);
                    sl.SetCellValue("D" + i, lbfecha.Text);
                    if (checktransportista.Checked)
                        sl.SetCellValue("E" + i, txtnombre.Text + " DE " + cbtransportes.Text);
                    else
                        sl.SetCellValue("E" + i, txtnombre.Text);
                    sl.SetCellValue("F" + i, txtplacas.Text);
                    sl.SetCellValue("G" + i, cbmarca.Text);
                    sl.SetCellValue("H" + i, txtfactura.Text);
                    sl.SetCellValue("I" + i, num.Value + " " + cbmedida.Text);
                    sl.SaveAs("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx");

                    txtnombre.Text = String.Empty;
                    checktransportista.Checked = false;
                    cbmarca.Text = "Seleccione una opción:";
                    txtfactura.Text = String.Empty;
                    txtplacas.Text = String.Empty;
                    num.Value = 0;
                    cbmedida.SelectedIndex = 0;
                    MessageBox.Show("Registro Guardado con Éxito", "¡Listo!");
                    registros.Text = (i - 1).ToString();
                    txtnombre.Select();


                }
                else if (!fileExist)
                {
                    SLDocument oSLDocument = new SLDocument();
                    DataTable table = new DataTable();
                    table.Columns.Add("ID", typeof(int));
                    table.Columns.Add("Vigilante/Usuario", typeof(string));
                    table.Columns.Add("Hora", typeof(string));
                    table.Columns.Add("Fecha", typeof(string));
                    table.Columns.Add("Chofer", typeof(string));
                    table.Columns.Add("Placas", typeof(string));
                    table.Columns.Add("Proveedor", typeof(string));
                    table.Columns.Add("Factura", typeof(string));
                    table.Columns.Add("Bultos/Tarimas", typeof(string));
                    if (checktransportista.Checked)
                        table.Rows.Add(1, cbusuario.Text, lbhora.Text, lbfecha.Text, txtnombre.Text + " DE " + cbtransportes.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value + " " + cbmedida.Text);
                    else
                        table.Rows.Add(1, cbusuario.Text, lbhora.Text, lbfecha.Text, txtnombre.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value + " " + cbmedida.Text);
                    oSLDocument.ImportDataTable(1, 1, table, true);
                    oSLDocument.SaveAs("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx");

                    txtnombre.Text = String.Empty;
                    checktransportista.Checked = false;
                    cbmarca.Text = "Seleccione una opción:";
                    cbmedida.SelectedIndex = 0;
                    cbmarca.Text = "Seleccione una opción:";
                    txtfactura.Text = String.Empty;
                    txtplacas.Text = String.Empty;
                    num.Value = 0;
                    MessageBox.Show("Registro Guardado con Éxito", "¡Listo!");
                    registro += 1;
                    registros.Text = registro.ToString();
                    txtnombre.Select();
                }
            }
            else
            {
                MessageBox.Show("Aún no has llenado todos los campos", "¡Espera!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void agregar_Click_1(object sender, EventArgs e)
        {
            if (txtplacas.Text != "" && lbhora.Text != "" && lbfecha.Text != " " && txtnombre.Text != String.Empty && cbmarca.Text != String.Empty &&
            txtfactura.Text != String.Empty && num.Value != 0 && cbusuario.Text != "Seleccione una opción:" && cbmarca.Text != "Seleccione una opción:")
            {
                if (!checktransportista.Checked || checktransportista.Checked && cbtransportes.Text == "Seleccione una opción:")
                    cbtransportes.Text = "N/A";

                await Base(lbhora.Text, lbfecha.Text, cbusuario.Text, txtnombre.Text, cbtransportes.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value, cbmedida.Text);
                string path = "C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx";
                bool fileExist = File.Exists(path);
                if (fileExist)
                {
                    SLDocument sl = new SLDocument("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx", "Sheet1");
                    int i = 1;
                    while (sl.HasCellValue("A" + i))
                    {
                        i++;
                    }
                    sl.SetCellValue("A" + i, i - 1);
                    sl.SetCellValue("B" + i, cbusuario.Text);
                    sl.SetCellValue("C" + i, lbhora.Text);
                    sl.SetCellValue("D" + i, lbfecha.Text);
                    if (checktransportista.Checked)
                        sl.SetCellValue("E" + i, txtnombre.Text + " DE " + cbtransportes.Text);
                    else
                        sl.SetCellValue("E" + i, txtnombre.Text);
                    sl.SetCellValue("F" + i, txtplacas.Text);
                    sl.SetCellValue("G" + i, cbmarca.Text);
                    sl.SetCellValue("H" + i, txtfactura.Text);
                    sl.SetCellValue("I" + i, num.Value + " " + cbmedida.Text);
                    sl.SaveAs("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx");
                    txtfactura.Text = String.Empty;
                    num.Value = 0;
                    cbmedida.SelectedIndex = 0;
                    MessageBox.Show("Registro Guardado con Éxito", "¡Listo!");
                    registros.Text = (i - 1).ToString();
                    cbmarca.Text = "Seleccione una opción:";
                    cbmarca.Select(0, cbmarca.Text.Length);
                    cbmarca.Focus();


                }
                else if (!fileExist)
                {
                    SLDocument oSLDocument = new SLDocument();
                    DataTable table = new DataTable();
                    table.Columns.Add("ID", typeof(int));
                    table.Columns.Add("Vigilante/Usuario", typeof(string));
                    table.Columns.Add("Hora", typeof(string));
                    table.Columns.Add("Fecha", typeof(string));
                    table.Columns.Add("Chofer", typeof(string));
                    table.Columns.Add("Placas", typeof(string));
                    table.Columns.Add("Proveedor", typeof(string));
                    table.Columns.Add("Factura", typeof(string));
                    table.Columns.Add("Bultos/Tarimas", typeof(string));
                    if (checktransportista.Checked)
                        table.Rows.Add(1, cbusuario.Text, lbhora.Text, lbfecha.Text, txtnombre.Text + " DE " + cbtransportes.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value + " " + cbmedida.Text);
                    else
                        table.Rows.Add(1, cbusuario.Text, lbhora.Text, lbfecha.Text, txtnombre.Text, txtplacas.Text, cbmarca.Text, txtfactura.Text, num.Value + " " + cbmedida.Text);

                    oSLDocument.ImportDataTable(1, 1, table, true);
                    oSLDocument.SaveAs("C:\\Bitacora\\Bitacora" + DateTime.Now.ToString(" yyyy-MM-dd") + ".xlsx");


                    cbmarca.Text = "Seleccione una opción:";
                    txtfactura.Text = String.Empty;
                    num.Value = 0;
                    cbmedida.SelectedIndex = 0;
                    MessageBox.Show("Registro Guardado con Éxito", "¡Listo!");
                    registro += 1;
                    registros.Text = registro.ToString();
                    cbmarca.Select(0, cbmarca.Text.Length);
                    cbmarca.Focus();
                }
            }
            else
            {
                MessageBox.Show("Aún no has llenado todos los campos", "¡Espera!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cbusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void cbmarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }

        }

        private void cbusuario_Leave(object sender, EventArgs e)
        {
            if (!usuarios.Contains(cbusuario.Text) && cbusuario.Text != "Seleccione una opción:")
            {
                MessageBox.Show("Dato no válido, Seleccione solo los de la lista");
                cbusuario.Select();
            }
        }

        private void cbmarca_Leave(object sender, EventArgs e)
        {
            if (!nombres.Contains(cbmarca.Text) && cbmarca.Text != "Seleccione una opción:")
            {
                MessageBox.Show("Dato no válido, Seleccione solo los de la lista");
                cbmarca.Select();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checktransportista.Checked)
            {
                hidetext.Visible = true;
                cbtransportes.Enabled = true;
                cbtransportes.Visible = true;
                string u = "Seleccione una opción:";
                cbtransportes.Text = u;

            }
            if (!checktransportista.Checked)
            {

                hidetext.Visible = false;
                cbtransportes.Enabled = false;
                cbtransportes.Text = string.Empty;
                cbtransportes.Visible = false;
            }
        }

        private void cbtransportes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }

        }

        private void cbtransportes_Leave(object sender, EventArgs e)
        {
            if (!transportes.Contains(cbtransportes.Text) && cbusuario.Text != "Seleccione una opción:")
            {
                MessageBox.Show("Dato no válido, Seleccione solo los de la lista");
                cbtransportes.Select();
            }

        }


        private void checktransportista_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (checktransportista.Checked)
            {
                checktransportista.Checked = false;
            }
            else
            {
                checktransportista.Checked = true;
            }

        }


        private void cbusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtnombre.Focus();
            }
        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && checktransportista.Checked)
            {
                e.SuppressKeyPress = true;
                cbtransportes.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtplacas.Focus();
            }
        }

        private void txtplacas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbmarca.Focus();
            }
        }

        private void cbmarca_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true;
                txtfactura.Focus();
            }
        }

        private void txtfactura_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true;
                num.Select(0, num.Text.Length);
                num.Focus();
            }
        }

        private void num_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (txtplacas.Text != "" && lbhora.Text != "" && lbfecha.Text != " " && txtnombre.Text != String.Empty && txtfactura.Text != String.Empty && num.Value != 0 && cbusuario.Text != "Seleccione una opción:" && cbmarca.Text != "Seleccione una opción:")
                {
                    DialogResult result = MessageBox.Show("¿Deseas Guardar el Registro?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        guardar_Click(sender, e);
                    }
                    else
                    {
                        e.SuppressKeyPress = true;
                        txtnombre.Focus();
                    }

                }
                else
                {
                    e.SuppressKeyPress = true;
                    txtnombre.Focus();
                }
            }

        }

        private void cbtransportes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtplacas.Focus();
            }
        }

        private void txtplacas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != '-' && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras, Números y Guiones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtfactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != '-' && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras, Números y Guiones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string u = "Seleccione una opción:";
            cbmarca.Refresh();
            cbmarca.Text = u;
            cbmarca.Refresh();
            cbusuario.Refresh();
            cbusuario.Text = u;
            cbusuario.Refresh();
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbfecha.Text = DateTime.Now.ToLongDateString();
            lbhora.Text = lbhora.Text.ToUpper();
        }

        private void cbmedida_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true;
                num.Select(0, num.Text.Length);
                num.Focus();
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                MessageBox.Show("Solo Se Permiten Números Enteros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}