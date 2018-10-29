using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{

    public class ClientesBL
    {
        BindingList<Cliente> ListaClientes { get; set; }
        public ClientesBL()
        {

            ListaClientes = new BindingList<Cliente>();

            var cliente1 = new Cliente();
            cliente1.Id = 1;
            cliente1.Nombre = "Edwin Murillo";
            cliente1.Direccion = "San pedro Sula";
            cliente1.Telefono = 2545457;
            cliente1.Correo = "edwin@mail.hn";
            cliente1.Activo = true;

            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Id = 2;
            cliente2.Nombre = "Jennife Murillo";
            cliente2.Direccion = "San pedro Sula";
            cliente2.Telefono = 2545457;
            cliente2.Correo = "jennifer@mail.hn";
            cliente2.Activo = true;

            ListaClientes.Add(cliente2);


            var cliente3 = new Cliente();
            cliente3.Id = 3;
            cliente3.Nombre = "Icela Murillo";
            cliente3.Direccion = "San pedro Sula";
            cliente3.Telefono = 2545457;
            cliente3.Correo = "icela@mail.hn";
            cliente3.Activo = true;

            ListaClientes.Add(cliente3);





        }
        public BindingList<Cliente> ObtenerClientes()
        {
            return ListaClientes;
        }

        public Resultadoc GuardarClientes(Cliente cliente)
        {

            var resultadoc = Validar(cliente);
            if (resultadoc.Exitoso==false)
            {

                return resultadoc;
            }

            if (cliente.Id == 0)
            {

                cliente.Id = ListaClientes.Max(item => item.Id) + 1;
            }
            resultadoc.Exitoso = true;
            return resultadoc;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);

        }

        public bool EliminarCliente(int id)
        {

            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    return true;
                }
            }
            return false;
        }



        private Resultadoc Validar(Cliente cliente)
        {
            var resultadoc = new Resultadoc();
            resultadoc.Exitoso = true;

if (string.IsNullOrWhiteSpace(cliente.Direccion) == true)
            {
                resultadoc.Mensaje = "Ingrese una Direccion";
                resultadoc.Exitoso = false;
            }



            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultadoc.Mensaje = "Ingrese un Nombre";
                resultadoc.Exitoso = false;

            }

            
            if (cliente.Telefono < 0)
            {
                resultadoc.Mensaje = "Ingrese un numero telefonico";
                resultadoc.Exitoso = false;

            }


            return resultadoc;
        }



        public class Cliente
        {

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public int Telefono { get; set; }
            public string Correo { get; set; }
            public bool Activo { get; set; }


        }

        public class Resultadoc
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }


    }
}
