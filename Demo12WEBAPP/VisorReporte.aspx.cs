using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo12WEBAPP.MyDataDataSetTableAdapters;
using Microsoft.Reporting.WebForms;
using static Demo12WEBAPP.MyDataDataSet;

namespace Demo12WEBAPP
{
	public partial class VisorReporte : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
			tblClientesTableAdapter adapter = new tblClientesTableAdapter();
			tblClientesDataTable tbl = adapter.GetDataByDoc(int.Parse(txtTipoDoc.Text), txtDoc.Text);
			ReportViewer1.LocalReport.DataSources.Clear();
			ReportDataSource dataSource = new ReportDataSource("DsClientes", (DataTable)tbl);
			ReportViewer1.LocalReport.DataSources.Add(dataSource);
			ReportViewer1.LocalReport.Refresh();
        }
    }
}