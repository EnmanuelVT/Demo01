using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Demo13WinAppExample
{
    public partial class frmMantenimientoCliente: Form
    {
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ofdBuscarImagen.ShowDialog();
            pbImagen.ImageLocation = ofdBuscarImagen.FileName;

            Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();

            /*            try
                        {
                            using (FileStream fs = new FileStream(photo, FileMode.Open, FileAccess.Read))
                            {
                                byte[] data = null;
                                data = new byte[fs.Length];
                                fs.Read(data, 0, (int)fs.Length);
                                image.Bytes = new MemoryStream(data);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed" + photo)
                            throw;
                        }

                        var request = new RecognizeCelebritiesRequest() { Image = image };
                        var response = new rekognitionClient.RecognizeCelebrities(request);

                        foreach (var item in response.CelebrityFaces)
                        {
                            txtSalida.Text += item.Name.ToString() + "=" + item.MatchConfidence.ToString() + "\r\n";
                        }

                        DetectModerationLabelsRequest request = new DetectModerationLabelsRequest() { Image = image };
                        var response = rekognitionClient.DetectModerationLabels(request);
                        foreach (var item in response.ModerationLabels)
                        {
                            txtSalida.Text += item.Name.ToString() + "=" + item.Confidence.ToString() + "\r\n";
                        }

                        var request = new DetectTextRequest() { Image = image };
                        var response rekognitionClient.DetectText(request);

                        foreach (var item in response.TextDetections)
                        {
                            txtSalida.Text += item.DetectedText.ToString() + "=" + item.Confidence.ToString() + "\r\n";
                        } */

                    //DetectLabelsRequest request = new DetectLabelsRequest() { Image = image };
                    //var response = rekognitionClient.DetectLabels(request);

                        //foreach (var item in response.TextDetections)
                        //{
                        //    txtSalida.Text += item.DetectedText.ToString() + "=" + item.Confidence.ToString() + "\r\n";
                        //} 
        }
    }
}
