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
    public partial class FormReporteFactura : Form
    {
        FacturaBL _facturaBL;


        public FormReporteFactura()
        {
            InitializeComponent();

             _facturaBL = new FacturaBL();

            /* var bindingsource = new BindingSource();
            bindingsource.DataSource = _facturaBL.ObtenerFacturas();

            var reporte = new ReportesFacturas();
            reporte.SetDataSource(bindingsource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
            */
        }
    




        private void button1_Click_1(object sender, EventArgs e)
        {
            var fechainicial = dateTimePicker1.Value;
            var fechafinal = dateTimePicker2.Value;
                
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturaBL.ObtenerFacturas(fechainicial, fechafinal);

            var reporte = new ReportesFacturas();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
