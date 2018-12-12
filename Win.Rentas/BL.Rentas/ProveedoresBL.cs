using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProveedoresBL
    {
        Contexto _contexto;
        public BindingList<Proveedor> ListaProveedores { get; set; }

        public ProveedoresBL()
        {
            _contexto = new Contexto();
            ListaProveedores = new BindingList<Proveedor>();
        }

        public BindingList<Proveedor> ObtenerProveedores()
        {
            _contexto.Proveedores.Load();
            ListaProveedores = _contexto.Proveedores.Local.ToBindingList();
            return ListaProveedores;
        }

        public void AgregarProveedores()
        {
            var nuevoProveedor = new Proveedor();
            ListaProveedores.Add(nuevoProveedor);

        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }

        }

        public Resultado GuardarProveedor(Proveedor proveedor)
        {

            var resultado = Validar(proveedor);
            if (resultado.Exitoso == false)
            {

                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }


        private Resultado Validar(Proveedor proveedor)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;


            if (proveedor == null)
            {
                resultado.Mensaje = "Agregue un nuevo proveedor valido";
                resultado.Exitoso = false;

                return resultado;
            }



            if (string.IsNullOrEmpty(proveedor.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un Nombre del proveedor";
                resultado.Exitoso = false;

            }


            if (string.IsNullOrEmpty(proveedor.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese una Direccion";
                resultado.Exitoso = false;
            }





            if (proveedor.Telefono < 0)
            {
                resultado.Mensaje = "Ingrese un numero telefonico";
                resultado.Exitoso = false;

            }

            return resultado;
        }


        public bool EliminarProveedor(int id)

        {

            foreach (var proveedor in ListaProveedores)
            {
                if (proveedor.Id == id)
                {
                    ListaProveedores.Remove(proveedor);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;

        }




        //Formulario a Actualizar

        public void RefrescarDatos(int proveedorId)
        {
            var proveedor = _contexto.Proveedores.Find(proveedorId);
            if (proveedor != null)
            {
                _contexto.Entry(proveedor).Reload();
            }
        }
    }




    public class Proveedor
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
         public string Email { get; set; }
        public bool Activo { get; set; }


    }


}

