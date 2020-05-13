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
    public partial class frmCadastroUsuarioSQL : Form
    {
        ClienteBLLSQL bll = new ClienteBLLSQL();
        ClienteDTO dto = new ClienteDTO();
        public frmCadastroUsuarioSQL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void LimparCampos()
        {
            txtemail.Clear();
            txtId.Clear();
            txtusuario.Clear();
            txtnome.Clear();
            txtpassword.Clear();
            txtusuario.Clear();
            btn_altersenha.Enabled = false;
            txtpassword.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dto.Senha = txtpassword.Text;
            dto.Nome = txtusuario.Text;
            dto.Email = txtemail.Text;
            dto.Usuario = txtusuario.Text;

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

        private void frmCadastroUsuarioSQL_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            GridUsuarios.DataSource = bll.SelecionaTodosUsuarios();
        }

        private void btn_altersenha_Click(object sender, EventArgs e)
        {
            dto.Nome = txtusuario.Text;
            dto.Email = txtemail.Text;
            dto.Id = int.Parse(txtId.Text);
            dto.Usuario = txtusuario.Text;
            frmAlteraSenha frm = new frmAlteraSenha(this.dto, this.bll);
            frm.ShowDialog();        }

        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_altersenha.Enabled = true;
            txtpassword.Enabled = false;
            txtpassword.Text = "**********";
            txtId.Text = GridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtusuario.Text = GridUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtnome.Text = GridUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtemail.Text = GridUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
    }
}
