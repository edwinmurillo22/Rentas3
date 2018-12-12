using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();


        }


        public void Autorizar(Usuario usuario)
        {
            productosToolStripMenuItem.Enabled = usuario.PuedeVerProductos;
            clientesToolStripMenuItem.Enabled = usuario.PuedeVerClientes;
           
            productosToolStripMenuItem.Enabled = usuario.PuedeVerProductos;



        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.MenuPrincipal = this;    
            formLogin.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProductos = new FormProductos();
            formProductos.MdiParent = this;
            formProductos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void rentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRentas = new FormRentas();
            formRentas.MdiParent = this;
            formRentas.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();

        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProveedores = new FormProveedores();
            formProveedores.MdiParent = this;
            formProveedores.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCompras = new FormCompras();
            formCompras.MdiParent = this;
            formCompras.Show();


        }

        private void reportesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteProductos = new FormReporteProductos();
            formReporteProductos.MdiParent = this;
            formReporteProductos.Show();

        }

        private void reporteDeFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFactura = new FormReporteFactura();
            formReporteFactura.MdiParent = this;
            formReporteFactura.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesDeRentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteProveedores = new FormReporteProveedores();
            formReporteProveedores.MdiParent = this;
            formReporteProveedores.Show();
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {


            var formReporteClientes = new FormReporteClientes();
            formReporteClientes.MdiParent = this;
            formReporteClientes.Show();


        }

        private void reporteDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteCompras = new FormReporteCompras();
            formReporteCompras.MdiParent = this;
            formReporteCompras.Show();


        }
    }
}
