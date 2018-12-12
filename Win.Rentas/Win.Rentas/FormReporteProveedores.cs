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
    public partial class FormReporteProveedores : Form
    {
        public FormReporteProveedores()
        {
            InitializeComponent();

            var _proveedoresBL = new ProveedoresBL();
            var bindingsource = new BindingSource();
            bindingsource.DataSource = _proveedoresBL.ObtenerProveedores();

            var reporte = new ReportesProveedores();
            reporte.SetDataSource(bindingsource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
