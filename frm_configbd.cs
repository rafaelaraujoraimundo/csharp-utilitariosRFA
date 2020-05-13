using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Projeto3Camadas.Code.DAL;

namespace Projeto3Camadas
{
    public partial class frm_configbd : Form
    {
        private AcessoBancodeDadosSQLSERVER sql;

        public frm_configbd()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frm_configbd_Load(object sender, EventArgs e)
        {
            var conn = AcessoBancodeDadosSQLSERVER.BuscaConexaoAtual().OfType<object>().Select(o => o.ToString()).ToArray();
           // string[5] conn = AcessoBancodeDadosSQLSERVER.BuscaConexaoAtual();
            txtServidor.Text = conn[0];
            txtbd.Text = conn[1];
            txtusuario.Text = conn[2];
            txtpassword.Text = conn[3];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtbd.Enabled = true;
            txtpassword.Enabled = true;
            txtServidor.Enabled = true;
            button3.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = false;
            txtbd.Enabled = false;
            txtpassword.Enabled = false;
            txtServidor.Enabled = false;
            AcessoBancodeDadosSQLSERVER.PutConexao(txtServidor.Text, txtbd.Text, txtusuario.Text, txtpassword.Text);
            button3.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();
                if (sql.mErro == "")
                {
                    MessageBox.Show("Conectado com Sucesso!");
                }
               else
            { 
                MessageBox.Show("Erro ao Conectar: " + sql.mErro); 
            }
            
           
            
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            txtusuario.Text = "";
            txtbd.Text = "";
            txtpassword.Text = "";
            txtServidor.Text = "";
        }
    }
}
