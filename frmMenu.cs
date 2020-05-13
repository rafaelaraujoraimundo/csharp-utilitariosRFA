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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadastroUsuarioSQL frm = new frmCadastroUsuarioSQL();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCadastroUsuarios frm = new frmCadastroUsuarios();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_configbd frm = new frm_configbd();
            frm.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_sql frm = new frm_sql();
            frm.ShowDialog();
        }
    }
}
