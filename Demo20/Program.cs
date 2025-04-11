using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo20
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient wc = new HttpClient())
            {
                for (int i = 0; i < 1; i++)
                {
                    #region Consulta Padron
                    // var json = await wc.GetStringAsync("https://compulaboratoriomendez.com/lib/?Key=567811&MUN_CED=001&SEQ_CED=0078278&VER_CED=8");
                    var json = await wc.GetStringAsync("https://compulaboratoriomendez.com/lib/?Key=567811&MUN_CED=001&SEQ_CED=0078278&VER_CED=8");
                    #endregion

                    Console.WriteLine(json);

                    var js = JsonConvert.SerializeObject(json);

                    var k = json.Replace('[', ' ').Replace(']', ' ');
                    var j = JObject.Parse(k);

                    dynamic data = JObject.Parse(k);
                    Console.WriteLine(data.NOMBRES);

                    var myDetails = JsonConvert.DeserializeObject<Cliente>(k);
                     Console.WriteLine(myDetails.Nombres); 

                    Console.WriteLine(j["NOMBRES"]);
                    Console.WriteLine(j["APELLIDO1"]);
                }
            }
        }
    }
}
