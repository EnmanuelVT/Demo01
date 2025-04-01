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
        static void Main(string[] args)
        {
            using (HttpClient wc = new HttpClient())
            {
                for (int i = 0; i < 1; i++)
                {
                    // Consulta padron
                    Console.WriteLine(json);
                    var js = JsonConvert.SerializeObject(json);

                    var k = json.Replace('[', '').Replace(']', ' ');
                    var j = JObject.Parse(k);

                    dynamic data = JObject.Parse(k);
                    Console.WriteLine(data.Nombres);

                    var myDetails = JsonConvert.DeserializeObject<Padron>(k);
                    Console.WriteLine(myDetails.NOMBRES);

                    Console.WriteLine(j["NOMBRES"]);
                    Console.WriteLine(j["APELLIDO1"]);
                }
            }
        }
    }
}
