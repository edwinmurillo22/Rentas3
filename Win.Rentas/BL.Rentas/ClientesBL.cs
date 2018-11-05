using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{

    public class ClientesBL
    {
        Contexto _contexto;
      public  BindingList<Cliente> ListaClientes { get; set; }
        public ClientesBL()
        {

            ListaClientes = new BindingList<Cliente>();

            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();



        }
        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();
            return ListaClientes;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }

        }

        public Resultadoc GuardarClientes(Cliente cliente)
        {

            var resultadoc = Validar(cliente);
            if (resultadoc.Exitoso==false)
            {

                return resultadoc;
            }

            _contexto.SaveChanges();
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
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }



        private Resultadoc Validar(Cliente cliente)
        {
            var resultadoc = new Resultadoc();
            resultadoc.Exitoso = true;

             if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultadoc.Mensaje = "Ingrese un Nombre";
                resultadoc.Exitoso = false;

            }


            if (string.IsNullOrEmpty(cliente.Direccion) == true )
            {
                resultadoc.Mensaje = "Ingrese una Direccion";
                resultadoc.Exitoso = false;
            }



           
            
            if (cliente.Telefono < 0)
            {
                resultadoc.Mensaje = "Ingrese un numero telefonico";
                resultadoc.Exitoso = false;

            }


            if (cliente.CiudadId == 0)
            {
                resultadoc.Mensaje = "Seleccione una ciudad";
                resultadoc.Exitoso = false;
            }


            if (cliente.CiudadId == 0)
            {
                resultadoc.Mensaje = "Seleccione una ciudad";
                resultadoc.Exitoso = false;
            }

         


            return resultadoc;
        }

        public class Cliente
        {

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public int CiudadId { get; set; }
            public Ciudad Ciudad { get; set; }
            public int Telefono { get; set; }
            public string Correo { get; set; }
            public byte[] Foto { get; set; }
            public bool Activo { get; set; }

            public Cliente()

            {
                Activo = true;
            }
        }

    }

  public class Resultadoc
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }

}
