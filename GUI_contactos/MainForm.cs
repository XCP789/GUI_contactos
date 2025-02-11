using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_contactos
{
    public partial class MainForm : Form
    {
        private ListBox lstContactos;
        public MainForm()
        {
            InitializeComponent();
            ConfiguracionForm();
        }

        private void ConfiguracionForm()
        {
            this.Text = "Gestión de Contactos";
            this.Width = 400;
            this.Height = 350;

            Label lblTitulo = new Label() { Text = "Gestión de Contactos", Top = 10, Left = 100, Width = 200 };
            Label lblNombre = new Label() { Text = "Nombre:", Top = 50, Left = 10 };
            Label lblTelefono = new Label() { Text = "Teléfono:", Top = 80, Left = 10 };
            Label lblCorreo = new Label() { Text = "Correo:", Top = 110, Left = 10 };

            TextBox txtNombre = new TextBox() { Top = 50, Left = 80, Width = 200 };
            TextBox txtTelefono = new TextBox() { Top = 80, Left = 80, Width = 200 };
            TextBox txtCorreo = new TextBox() { Top = 110, Left = 80, Width = 200 };

            lstContactos = new ListBox() { Top = 150, Left = 10, Width = 350, Height = 100 };
            Button btnAgregar = new Button() { Text = "Agregar", Top = 260, Left = 10 };
            Button btnEliminar = new Button() { Text = "Eliminar", Top = 260, Left = 100 };
            Button btnLimpiar = new Button() { Text = "Limpiar", Top = 260, Left = 200 };

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menuArchivo = new ToolStripMenuItem("Archivo");
            ToolStripMenuItem menuSalir = new ToolStripMenuItem("Salir");
            ToolStripMenuItem menuAcercaDe = new ToolStripMenuItem("Acerca de");
            menuArchivo.DropDownItems.Add(menuSalir);
            menuStrip.Items.Add(menuArchivo);
            menuStrip.Items.Add(menuAcercaDe);
            this.MainMenuStrip = menuStrip;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblNombre);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(lblCorreo);
            this.Controls.Add(txtNombre);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(txtCorreo);
            this.Controls.Add(lstContactos);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEliminar);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(menuStrip);

            btnAgregar.Click += (sender, e) => AgregarC(txtNombre, txtTelefono, txtCorreo);
            btnEliminar.Click += (sender, e) => EliminarC();
            btnLimpiar.Click += (sender, e) => limpiarC(txtNombre, txtTelefono, txtCorreo);
            menuSalir.Click += (sender, e) => Application.Exit();
            menuAcercaDe.Click += (sender, e) => MessageBox.Show("Gestión de Contactos v1.0\nDesarrollado en C# WinForms", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AgregarC(TextBox txtNombre, TextBox txtTelefono, TextBox txtCorreo)
        {
            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lstContactos.Items.Add($"{txtNombre.Text} - {txtTelefono.Text} - {txtCorreo.Text}");
            MessageBox.Show("Contacto agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EliminarC()
        {
            if (lstContactos.SelectedItem != null)
            {
                lstContactos.Items.Remove(lstContactos.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void limpiarC(TextBox txtNombre, TextBox txtTelefono, TextBox txtCorreo)
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}

