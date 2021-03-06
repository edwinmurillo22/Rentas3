﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Rentas.ClientesBL;

namespace BL.Rentas
{
   public  class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";
            usuarioAdmin.PuedeVerFacturas = true;
            usuarioAdmin.PuedeVerClientes = true;
            usuarioAdmin.PuedeVerProductos = true;
            usuarioAdmin.PuedeVerCompras = true;
            usuarioAdmin.PuedeVerProveedores = true;


            contexto.Usuario.Add(usuarioAdmin);

            var usuario1 = new Usuario();
            usuario1.Nombre = "stalen";
            usuario1.Contrasena = "spiderman";
            usuario1.PuedeVerFacturas = true;
            usuario1.PuedeVerClientes = true;
            usuario1.PuedeVerProductos = true;
            usuario1.PuedeVerReportes = true;
            usuarioAdmin.PuedeVerCompras = true;
            usuarioAdmin.PuedeVerProveedores = true;


            contexto.Usuario.Add(usuario1);


            var categoria1 = new Categoria();
            categoria1.Descripcion = "Acción y Aventura";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Deportes";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Disparo";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Educativos";
            contexto.Categorias.Add(categoria4);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Consolas";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Video Juegos";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Accesorios";
            contexto.Tipos.Add(tipo3);

            var ciudad1 = new Ciudad();
            ciudad1.DescripcionC = "San Pedro Sula";
            contexto.Ciudades.Add(ciudad1);


            var ciudad2 = new Ciudad();
            ciudad2.DescripcionC = "Tegucigalpa";
            contexto.Ciudades.Add(ciudad2);

            var ciudad3 = new Ciudad();
            ciudad3.DescripcionC = "La Ceiba";
            contexto.Ciudades.Add(ciudad3);


            var ciudad4 = new Ciudad();
            ciudad4.DescripcionC = "Puerto Cortes";
            contexto.Ciudades.Add(ciudad4);

            var ciudad5 = new Ciudad();
            ciudad5.DescripcionC = "El Progreso";
            contexto.Ciudades.Add(ciudad5);








            base.Seed(contexto);



        }






    }
}
