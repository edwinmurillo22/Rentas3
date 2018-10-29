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
    public partial class FormProductos : Form
    {

        ProductosBL _productos;

        public FormProductos()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }


        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;
            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)
            {
                listaProductosBindingSource.ResetBindings(false);

                DeshabilitarHabilitarBotones(true);

            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

    


        private void DeshabilitarHabilitarBotones(bool valor)
        {

            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripCancelar.Visible = !valor;
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
           
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
            {
                var id = Convert.ToInt32(idTextBox.Text);
                Eliminar(id);

            }

                
            }
            }
            
        private void Eliminar(int id)
        { 
            var resultado = _productos.EliminarProducto(id);

            if (resultado== true)
            {

                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Eliminar el Producto");

            }

        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }


}
