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

    internal class Estados
    {
        public string Nome { get; set; }
        public string Id { get; set; }

        public string Sigla { get; set; }

        public static List<Estados> BuscaEstado(int id)
        {
            Console.WriteLine("REGIÇÃO RECEBIDA COM INDEX DE " + id);
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/regioes/"+id.ToString()+"/estados";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var regiao = JsonConvert.DeserializeObject<List<Estados>>(json);

            return regiao;

        }
    }

    internal class Cidades
    {
        public string Nome { get; set; }
        public string Id { get; set; }

        

        public static List<Cidades> BuscaCidade(string uf)
        {
            Console.WriteLine("REGIÇÃO RECEBIDA COM INDEX DE " + uf);
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + uf.ToString() + "/municipios";
            string json = (new System.Net.WebClient()).DownloadString(url);

            var regiao = JsonConvert.DeserializeObject<List<Cidades>>(json);

            return regiao;

        }
    }



}
