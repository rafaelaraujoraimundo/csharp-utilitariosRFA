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

namespace Projeto3Camadas
{
    
    public partial class frm_sql : Form
    {
        private const string V = ";";

        public frm_sql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Selecione o arquivo de Origem";
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.Filter = "Arquivos CSV (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            textOrigem.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Arquivo Texto|*.txt";
            saveFileDialog1.Title = "Salvando script de SQL";
            saveFileDialog1.ShowDialog();
            txtdestino.Text = saveFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            var path = textOrigem.Text;
            var pathDes = txtdestino.Text;
            String ResultadoSQL = "";
            String ResultadoItens;
            try
            {
               
                using (StreamWriter sw = new StreamWriter(pathDes))
                {

                    using (StreamReader sr = new StreamReader(path))
                    {
                       
                        string line;
                        int count = 0;
                        string[] ConjuntoArray = null;
                        while ((line = sr.ReadLine()) != null)
                        {

                            ConjuntoArray = line.Split(';');
                            if (count == 0)
                            {
                                ResultadoSQL = "INSERT INTO " + txttabela.Text + " (";
                                for (int i = 0; i < ConjuntoArray.Length; i++)
                                {

                                    ResultadoSQL += ConjuntoArray[i];
                                    if (ConjuntoArray.Length - 1 != i)
                                    {
                                        ResultadoSQL += ",";
                                    }
                                    if (ConjuntoArray.Length - 1 == i)
                                    {
                                        ResultadoSQL += ", R_E_C_N_O_) VALUES (";
                                    }
                                }
                               
                            }
                            else
                            {

                                ResultadoItens = ResultadoSQL;
                                for (int i = 0; i < ConjuntoArray.Length; i++)
                                {
                                    ResultadoItens += "'" + ConjuntoArray[i] + "'";
                                    if (ConjuntoArray.Length - 1 != i)
                                    {
                                        ResultadoItens += ",";
                                    }
                                    if (ConjuntoArray.Length - 1 == i)
                                    {
                                        ResultadoItens += " ,(select ISNULL(MAX(R_E_C_N_O_),0)+1 FROM " + txttabela.Text + "));";
                                    }

                                }
                            }
                        }
                        MessageBox.Show("Arquivo Gerado com sucesso!", "Geração de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Execução: " + ex.Message, "Geração de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
