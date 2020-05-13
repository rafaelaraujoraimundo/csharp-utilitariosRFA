using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Projeto3Camadas.Code.BLL;
namespace Projeto3Camadas
{
    public partial class frm_login : Form
    {
        ClienteBLLSQL bll = new ClienteBLLSQL();
        public bool login = false;
        
        public frm_login()
        {
           
           InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login = bll.Verificalogin(txt_usuario.Text, txt_senha.Text);
            if (login)
            {
                this.Dispose();
              
            }
            else
            {
                bll.Contador = bll.Contador + 1;
                MessageBox.Show("Login Incorreto, favor tentar novamente.\n" +
                "Tentativa " + bll.Contador + " de 3","login Incorreto",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (bll.Contador >= 3)
                {
                    MessageBox.Show("Tentativas exedidas!\n " +
                    "Programa será encerrado!", "login Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                }
                    
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            frm_configbd frm = new frm_configbd();
            frm.ShowDialog();
        }
    }
}
