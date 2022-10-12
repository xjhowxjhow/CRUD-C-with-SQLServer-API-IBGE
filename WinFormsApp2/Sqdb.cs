using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace WinFormsApp2
{

    class Conn
    {
        private static string server = "JHONATAN";
        private static string database = "banco";

        public static string StrCon
        {
            get { return "Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True"; }
        }


        public static string Retorno(string argumento)
        {
            return "Aqui retona algo de uma função como argumento fornecio" + argumento;
        }

        public static string Retorna_Col(string argumento, int index)
        {
            Console.WriteLine("FUNÇÃO EDITAR CHANGED COMBOBOX");
            using (SqlConnection con = new SqlConnection(Conn.StrCon))
            {
                con.Open();
                //MessageBox.Show("Connected successfully");
                //Pega o nome da coluna do comboBox//
                var table_sel2 = argumento;

                Console.WriteLine(table_sel2);
                // CHAMA FUNCAO DANDO ARGUMENTO E RECEENDO DEVOLTA
                Console.WriteLine(Conn.Retorno(table_sel2));
                List<string> list = new List<string>();
                var select_all2 = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo." + table_sel2 + "')";
                using (SqlCommand Command = new SqlCommand(select_all2, con))
                {
                    SqlDataReader rdr = Command.ExecuteReader();
                   
                    while (rdr.Read())
                    {
                        var dados = rdr.GetString(0);
                        //ADD NA LISTA
                        list.Add(dados);
                        Console.WriteLine(dados);
                    }
                    
                }
                

                return list[index];

                // ("Data Source=JHONATAN;Initial Catalog=banco;Integrated Security=True")
            }


        }
        public static IEnumerable<Control> ChildControls(Control parent)
        {
            List<Control> controls = new List<Control>();
            controls.Add(parent);
            foreach (Control ctrl in parent.Controls)
            {
                controls.AddRange(ChildControls(ctrl));
            }
            return controls;
        }
       
    }
}