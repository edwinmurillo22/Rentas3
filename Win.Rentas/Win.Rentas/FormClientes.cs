using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL.Rentas.ClientesBL;

namespace Win.Rentas
{
    public partial class FormClientes : Form
    {
        ClientesBL _clientes;
        CiudadesBL _ciudadesBL;
        

        public FormClientes()
        {
            InitializeComponent();

            _clientes = new ClientesBL();
            clienteBindingSource.DataSource = _clientes.ObtenerClientes();
   


            _ciudadesBL = new CiudadesBL();
            listaCiudadesBindingSource.DataSource = _ciudadesBL.ObtenerCiudades();
       
        }

        public void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void activoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)

        {
            clienteBindingSource.EndEdit();
            var cliente = (Cliente)clienteBindingSource.Current;


            if (fotoPictureBoxC.Image != null)
            {
                cliente.Foto = Program.imagenToByteArray(fotoPictureBoxC.Image);

            }

            else
            {
                cliente.Foto = null;

            }

            var resultadoc = _clientes.GuardarClientes(cliente);

            if (resultadoc.Exitoso== true)
            {
                clienteBindingSource.ResetBindings(false);

                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cliente guardado Exitosamente");
            }
            else
            {

                MessageBox.Show(resultadoc.Mensaje);
            }
        }

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientes.AgregarCliente();
            clienteBindingSource.MoveLast();

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

           toolStripButtonCancelar.Visible= !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text !="")
            {
                var resultadoc = MessageBox.Show("Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultadoc == DialogResult.Yes)
                {

                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }

            }
        }

        private void Eliminar(int id)
        {
           
            var resultadoc = _clientes.EliminarCliente(id);

            if (resultadoc == true)
                {
                    clienteBindingSource.ResetBindings(false);
                
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al Eliminar el cliente");

                }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _clientes.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
           
        }

        private void fotoLabel_Click(object sender, EventArgs e)
        {

        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
             var cliente = (Cliente)clienteBindingSource.Current;

            if (cliente != null) 

            { 

            openFileDialog1.ShowDialog();
            var archivo1 = openFileDialog1.FileName;

                if (archivo1 != "")
                {
                    var fileInfo = new FileInfo(archivo1);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBoxC.Image = Image.FromStream(fileStream);
                            }


            }
            else
            {
                MessageBox.Show("Ingrese datos del cliente antes de asignar una imagen");
             }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBoxC.Image = null;
        }

        private void ciudadIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefrescar_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var clienteId = Convert.ToInt32(idTextBox.Text);
                _clientes.RefrescarDatos(clienteId);

                clienteBindingSource.ResetBindings(false);
            }
        }
    }
}