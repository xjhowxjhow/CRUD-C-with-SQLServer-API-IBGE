using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    internal class Regiao
    {
        public string Nome { get; set; }
        public string Id { get; set; }

        public string Sigla { get; set; }
        
        public static List<Regiao> BuscaRegiao()
        {
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/regioes";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var regiao = JsonConvert.DeserializeObject<List<Regiao>>(json);

            return regiao;

        }
    }
}
