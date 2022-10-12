

using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("READQ?");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void busca_Click(object sender, EventArgs e)
        {
            Console.WriteLine("QUERYYY");
            using (SqlConnection connection = new SqlConnection(Conn.StrCon))
            {
                connection.Open();
                //MessageBox.Show("Connected successfully");
                //Pega o nome da coluna do comboBox//
                var table_sel = comboBox1.Text;
                
                Console.WriteLine(table_sel);

                //
                var select_all = "SELECT * FROM "+ table_sel;
                using (SqlDataAdapter adapter = new SqlDataAdapter(select_all, connection))
                {
                    using (DataTable table = new DataTable())
                    {
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //botao INSERIR/
            tabControl1.SelectedIndex = 2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //botao Busca
            tabControl1.SelectedIndex = 0;
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("FUNÇÃO EDITAR CHANGED COMBOBOX");
            using (SqlConnection con = new SqlConnection(Conn.StrCon))
            {
                con.Open();
                //MessageBox.Show("Connected successfully");
                //Pega o nome da coluna do comboBox//
                var table_sel2 = comboBox2.Text;

                Console.WriteLine(table_sel2);
                // CHAMA FUNCAO DANDO ARGUMENTO E RECEENDO DEVOLTA
                Console.WriteLine(Conn.Retorno(table_sel2));




                var select_all2 = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('dbo."+table_sel2+"')";
                using (SqlCommand Command = new SqlCommand(select_all2, con))
                {
                    SqlDataReader rdr = Command.ExecuteReader();
                    List<string> list = new List<string>();
                    while (rdr.Read())
                    {
                        var dados = rdr.GetString(0);
                        //ADD NA LISTA
                        list.Add(dados);
                    }
                    //REMOVE INTEMS,
                    try { 
                    
                        this.add_coluns_comb.Controls.Clear();
                    }
                    catch {
                        Console.WriteLine("Nao possui");
                    }

                    var locais = comboBox2.Text;





                    for (int i = 0; i < list.Count; i++)
                    {   //TRADA OS DAOS AGR
                        //Console.WriteLine(list[i]);
                        Label lbl = new Label();
                        lbl.Text = list[i].ToString();
                        this.add_coluns_comb.Controls.Add(lbl);

                        //TESTE REGIAO




                        switch (list[i])
                        {
                            case "Sexo":
                                
                                ComboBox cmb_insert = new ComboBox();
                                cmb_insert.Name = list[i].ToString();
                                cmb_insert.Items.Add("Feminino");
                                cmb_insert.Items.Add("Masculino");
                                cmb_insert.Size = new System.Drawing.Size(100, 23);

                                this.add_coluns_comb.Controls.Add(cmb_insert);
                                break;

                            case "Data_Nascimento":
                                DateTimePicker date_insert = new DateTimePicker();
                                date_insert.Name = list[i].ToString();
                                date_insert.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                                date_insert.Size = new System.Drawing.Size(100, 23);
                                this.add_coluns_comb.Controls.Add(date_insert);
                                break;

                            case "Cidade":
                                ComboBox cmb_cidade_insert = new ComboBox();
                                cmb_cidade_insert.Name = list[i].ToString();

                                // insere as regioes cmb_insert.Items.Add("Feminino");

                                cmb_cidade_insert.Size = new System.Drawing.Size(100, 23);

                                this.add_coluns_comb.Controls.Add(cmb_cidade_insert);
                                break;

                            case "Estado":

                                ComboBox cmb_estado_insert = new ComboBox();
                                cmb_estado_insert.Name = list[i].ToString();

                                // insere as regioes cmb_insert.Items.Add("Feminino");

                                cmb_estado_insert.Size = new System.Drawing.Size(100, 23);

                                this.add_coluns_comb.Controls.Add(cmb_estado_insert);
                                break;

                            case "Região":
                                ComboBox cmb_regiao_insert = new ComboBox();
                                cmb_regiao_insert.Name = list[i].ToString();



                                var reg = Regiao.BuscaRegiao();
                                //ADICIONANDO REGIOES NO COMBO
                                for (int r = 1; r < reg.Count; r++)
                                {
                                    cmb_regiao_insert.Items.Add(reg[r].Nome) ;
                                }

                                cmb_regiao_insert.Size = new System.Drawing.Size(100, 23);

                                this.add_coluns_comb.Controls.Add(cmb_regiao_insert);
                                break;

                            default:
                                TextBox txt_insert = new TextBox();
                                txt_insert.Name = list[i].ToString();
                                this.add_coluns_comb.Controls.Add(txt_insert);
                                break;
                        }

                        
                        

                        //adc nome do text para ser acessivel
                        

                        
                        
                        cadastrode.Text = "Cadastrar "+comboBox2.Text.ToString();

                    }

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BOTAO ADICIONA NOVO ITEM
            // FRAME PANEL add_coluns_comb
            var num_text = add_coluns_comb.Controls.Count;
            //tirando os labels divide por 2
            var op = num_text / 2;
            
            var argumentocombo = comboBox2.Text;

            List<string> list_itens = new List<string>();
            // CHAMA FUNÇÃO DE PEGAR OS FILHOES sqdb.cs
            foreach (Control ctrl in Conn.ChildControls(add_coluns_comb))
            {
                string nome = ctrl.Name;
                if (string.IsNullOrEmpty(nome))
                {
                }
                else
                {
                    list_itens.Add(ctrl.Name);
                }
                

            }

            for (int i = 1; i < list_itens.Count; i++)
            {
                string item = list_itens[i];


                TextBox ctn = this.Controls.Find(item, true).FirstOrDefault() as TextBox;
                Console.WriteLine(ctn.Text);
            }
            
        }




    }
}