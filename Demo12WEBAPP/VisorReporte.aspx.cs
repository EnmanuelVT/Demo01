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

            Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;
         
            //Export the RDLC Report to Byte Array.
            byte[] bytes = ReportViewer1.LocalReport.Render(rbFormat.SelectedItem.Value, null, out contentType, out encoding, out extension, out streamIds, out warnings);
         
            //Download the RDLC Report in Word, Excel, PDF and Image formats.
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}