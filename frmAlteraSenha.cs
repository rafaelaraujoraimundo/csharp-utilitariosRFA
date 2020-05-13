using DotLiquid.Tags;
using Projeto3Camadas.Code.BLL;
using Projeto3Camadas.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3Camadas
{
    public partial class frmAlteraSenha : Form
    {
        public ClienteDTO dto2;
        private ClienteBLLSQL bll2;
        public frmAlteraSenha(ClienteDTO dto,ClienteBLLSQL bll)
            
        {
            dto2 = dto;
            bll2 = bll;
            InitializeComponent();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpass1.Text == txtpass2.Text)
            {
                dto2.Senha = txtpass1.Text;
                bll2.AlterarSenha(dto2);
                MessageBox.Show("Senhas alterada com sucesso.", "Alteração de senhas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Senhas não são iguais, \nFavor verificar", "Alteração de senhas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmAlteraSenha_Load(object sender, EventArgs e)
        {

        }
    }
}
