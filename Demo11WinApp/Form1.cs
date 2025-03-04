using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo11WinApp.ClientesTableAdapters;
using Microsoft.Reporting.WinForms;

namespace Demo11WinApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clientes.tblClientes' table. You can move, or remove it, as needed.
            this.tblClientesTableAdapter.Fill(this.clientes.tblClientes);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clientes.tblClientes' table. You can move, or remove it, as needed.
            this.tblClientesTableAdapter.Fill(this.clientes.tblClientes);

            this.reportViewer1.RefreshReport();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            tblClientesTableAdapter adapter = new tblClientesTableAdapter();
            Clientes.tblClientesDataTable tbl = adapter.GetDataByDoc(int.Parse(txtTipoDoc.Text), txtDoc.Text);
            ReportDataSource dr = new ReportDataSource("Clientes", (DataTable) tbl);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dr);
            reportViewer1.LocalReport.Refresh();
            // TODO: This line of code loads data into the 'clientes.tblClientes' table. You can move, or remove it, as needed.
            this.tblClientesTableAdapter.Fill(tbl);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
