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
    public partial class FormProveedores : Form
    {

        ProveedoresBL _proveedores;

        public FormProveedores()
        {
            InitializeComponent();

            _proveedores = new ProveedoresBL();
            listaProveedoresBindingSource.DataSource = _proveedores.ObtenerProveedores();


        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            _proveedores.AgregarProveedores();
            listaProveedoresBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);

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

            toolStripButtonCancelar.Visible = !valor;
        }

        private void listaProveedoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProveedoresBindingSource.EndEdit();
            var proveedor = (Proveedor)listaProveedoresBindingSource.Current;

            
            var resultado = _proveedores.GuardarProveedor(proveedor);

            if (resultado.Exitoso == true)
            {
                listaProveedoresBindingSource.ResetBindings(false);

                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Proveedor guardado Exitosamente");
            }
            else
            {

                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {

                var id = Convert.ToInt32(idTextBox.Text);
                Eliminar(id);
            }

        }

        private void Eliminar(int id)
        {

            var resultado = _proveedores.EliminarProveedor(id);

            if (resultado == true)
            {
                listaProveedoresBindingSource.ResetBindings(false);

            }
            else
            {
                MessageBox.Show("Ocurrio un error al Eliminar el proveedor");

            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _proveedores.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }
    }
}


