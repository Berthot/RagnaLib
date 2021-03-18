using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RagnaLib.Wrapper.ModelsAPI;

namespace RagnaLib.Wrapper
{
    public class RagnaPrideApi
    {
        public RagnarokPrideMonster GetMonster(int id)
        {
            var url = $"https://www.divine-pride.net/api/database/Monster/?apiKey=a7b51c0e03758da5942c71076cb2b46b&server=bRo&id={id.ToString()}";
            var requestWeb = WebRequest.CreateHttp(url);
            // 'desabilitar' ssl
            requestWeb.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            requestWeb.Method = "GET";
            requestWeb.ContentType = "application/json";
            requestWeb.UserAgent = "RequisicaoWebDemo";
            try
            {
                using var resposta = requestWeb.GetResponse();
                using var streamOne = resposta.GetResponseStream();
                using var reader = new StreamReader(streamOne);
                object objResponse = reader.ReadToEnd();
                
                // var json = JsonConvert.SerializeObject(objResponse, Formatting.Indented);
                // Console.WriteLine(json);
                
                // return JsonConvert.DeserializeObject<object>(objResponse.ToString());
                RagnarokPrideMonster myDeserializedClass = JsonConvert.DeserializeObject<RagnarokPrideMonster>(objResponse.ToString());
                return myDeserializedClass;
                // Console.WriteLine(objResponse.ToString());
            }
            catch (WebException)
            {
                Console.WriteLine("ERROR");
                return new RagnarokPrideMonster() {id = -1};
            }
        }

        public static void Main(string[] args)
        {
            var rag = new RagnaPrideApi();
            var monst = rag.GetMonster(1001);
            Console.WriteLine($"{monst.id} -- {monst.name} -- {monst.dbname}");

        }
    }
}