using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace Demo12WEBAPP
{
	public partial class LogExample : System.Web.UI.Page
	{
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}