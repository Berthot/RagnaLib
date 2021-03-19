using System.IO;
using System.Net;
using Newtonsoft.Json;
using RagnaLib.Wrapper.ModelsAPI;

namespace RagnaLib.Wrapper.RagnaPride
{
    public class RagnaplaceApi
    {
        public MonsterCollection GetMonster(string id)
        {
            var url = $"https://ragnarokapi.herokuapp.com/api/v1.0/monster/{id}";
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
                return JsonConvert.DeserializeObject<MonsterCollection>(objResponse.ToString());
                // Console.WriteLine(objResponse.ToString());
            }
            catch (WebException)
            {
                return new MonsterCollection() {Id = "-1"};
            }
        }

    }
}