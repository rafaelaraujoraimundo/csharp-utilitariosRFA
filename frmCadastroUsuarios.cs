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
   public partial class frmCadastroUsuarios : Form
    {
        ClienteBLLSQL bll = new ClienteBLLSQL();
        ClienteDTO dto = new ClienteDTO();

        public frmCadastroUsuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dto.Senha = txtpassword.Text;
            dto.Nome = txtnome.Text;
            dto.Email = txtemail.Text;
           if (txtId.Text == "")
            {
                bll.Inserir(dto);
                MessageBox.Show("Usuario Cadastrado com Sucesso!", "Cadastro de Usuarios");
            
            }
            else
            {
                dto.Id = int.Parse(txtId.Text);
                bll.Atualizar(dto);
                MessageBox.Show("Usuario Atualizado com Sucesso!", "Cadastro de Usuarios");
            }
            LimparCampos();
            CarregarGrid();

        }

        private void frmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            GridUsuarios.DataSource = bll.SelecionaTodosUsuarios();
        }

        private void GridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = GridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtnome.Text = GridUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtemail.Text = GridUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtpassword.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtemail.Clear();
            txtId.Clear();
            txtnome.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem Certeza?", "Confirmação de Exclusão.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
            dto.Nome = txtnome.Text;
            dto.Email = txtemail.Text;
            dto.Id = int.Parse(txtId.Text);
            bll.Excluir(dto);
            LimparCampos();
            CarregarGrid();
            MessageBox.Show("Usuario Excluido com Sucesso!", "Cadastro de Usuarios");
            }
        }

        private void btn_altersenha_Click(object sender, EventArgs e)
        {
            dto.Nome = txtnome.Text;
            dto.Email = txtemail.Text;
            dto.Id = int.Parse(txtId.Text);
            frmAlteraSenha frm = new frmAlteraSenha(this.dto, this.bll);
            frm.Show();
            Properties.Settings.Default.bd_sistemas = "";
        }
    }
}
