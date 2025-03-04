using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo11WinApp
{
    public partial class frmReporte: Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clientes.tblClientes' table. You can move, or remove it, as needed.
            this.tblClientesTableAdapter.Fill(this.clientes.tblClientes);
            // TODO: This line of code loads data into the 'clientes.tblClientes' table. You can move, or remove it, as needed.
            this.tblClientesTableAdapter.Fill(this.clientes.tblClientes);

            this.reportViewer1.RefreshReport();
        }
    }
}
