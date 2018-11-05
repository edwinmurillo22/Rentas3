﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenu());
        }

        public static byte[] imagenToByteArray(Image imagenIn)
        {
            var ms = new MemoryStream();
            imagenIn.Save(ms, imagenIn.RawFormat);

            return ms.ToArray();
        }
    }
}
