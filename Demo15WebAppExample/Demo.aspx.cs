using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System.IO;


namespace Demo15WebAppExample
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void ShowMessage(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (fuArchivo.HasFiles)
            {
                foreach (var item in fuArchivo.PostedFiles)
                {
                    item.SaveAs(MapPath("Imagen") + "\\" + item.FileName);
                }
            }
            if (fuArchivo.HasFile)
            {
                fuArchivo.SaveAs(MapPath("Imagen") + "\\" + fuArchivo.FileName);

                AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("PONTULLAVE", "PONTULLAVE", RegionEndpoint.USEast1);
                Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();

                try
                {
                    using (FileStream fs = new FileStream(fuArchivo.FileName, FileMode.Open, FileAccess.Read))
                    {
                        byte[] data = null;
                        data = new byte[fs.Length];
                        fs.Read(data, 0, (int)fs.Length);
                        image.Bytes = new MemoryStream(data);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                    throw;
                }


                DetectModerationLabelsRequest requestMod = new DetectModerationLabelsRequest() { Image = image };
                DetectModerationLabelsResponse responseMod = rekognitionClient.DetectModerationLabels(requestMod);

                var responseMessageMod = "";

                foreach (var item in responseMod.ModerationLabels)
                {
                    responseMessageMod += item.Name.ToString() + "=" + item.Confidence.ToString() + "\r\n";
                }


            }
            imgFoto.ImageUrl = "/imagen/" + fuArchivo.FileName;
        }
    }
}