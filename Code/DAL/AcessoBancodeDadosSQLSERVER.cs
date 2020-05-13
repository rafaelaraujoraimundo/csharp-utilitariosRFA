using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto3Camadas.Code.BLL;
using Projeto3Camadas.Code.DTO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.util;

namespace Projeto3Camadas.Code.DAL { 
public class AcessoBancodeDadosSQLSERVER
{

    public string mErro = "";



    // Variaveis de configuração de acesso ao banco de dados
    //static string connectString = Properties.Settings.Default.bd_sistemas;
   // static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
        private string Server = Properties.Settings.Default.servidor;
        private string Database = Properties.Settings.Default.bancodedados;
        private string Usuario = Properties.Settings.Default.usuario;
        private string Senha = Properties.Settings.Default.senha;
   
    public SqlConnection conn;
    private DataTable data;
    private SqlDataAdapter da;

    public void Conectar()
    {
        if (conn != null)
            conn.Close();
        try
        {
            string connectionStrings = "";
            connectionStrings = string.Format("Server={0},1433;Database={1};User ID={2};Password={3}", Server, Database, Usuario, Senha);
            conn = new SqlConnection(connectionStrings);
            conn.Open();
        }
        catch (Exception erro)
        {
            mErro = erro.Message;
            conn = null;
        }
    }

    // Verifica se existe erro
    public bool ExisteErro()
    {
        if (mErro.Length > 0)
        {
            return true;
        }
        return false;
    }

  


    // Abre conexao com o Banco de Dados
    public bool OpenConexao()
    {
        bool _return = true;
        try
        {
            conn.Open();
        }
        catch (Exception erro)
        {
            mErro = erro.Message;
            _return = false;
        }

        return _return;
    }

    // Fecha conexao com o Banco de Dados
    public void CloseConexao()
    {
        conn.Close();
        conn.Dispose();
    }

    public void ExecutarComandoSQL(string comandoSql)
    {
        SqlCommand comando = new SqlCommand(comandoSql, conn);
        comando.ExecuteNonQuery(); //Chama o método "ExecuteNonQuery()" da classe "MySqlCommand" para execução do comando
        conn.Close(); //Garante o fechamento da conexão com o banco de dados
    }

    public DataTable RetDataTable(string sql)
    {
        //Como a função retorna um objeto DataTable, precisamos garantir um objeto que será retornado.
        //Concretiza-se a criação do objeto "data" do tipo DataTable
        data = new DataTable();

        //Concretiza a criação do objeto "da". Observe que os parâmetros "sql" e "conn" são passados para o construtor da classe "MySqlDataAdapter"
        da = new SqlDataAdapter(sql, conn);

        //Preenche o objeto "data" com os dados que estão no objeto "da"
        da.Fill(data);

        //Retorna o objeto "data" já preenchido
        return data;
    }

    public static Array BuscaConexaoAtual()
    {
        //string connectString = Properties.Settings.Default.bd_sistemas;
        //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
        // Retrieve the DataSource property.
        
       string[] dados = new string[5];
       dados[0] = Properties.Settings.Default.servidor;
       dados[1] = Properties.Settings.Default.bancodedados;
       dados[2] = Properties.Settings.Default.usuario;
       dados[3] = Properties.Settings.Default.senha;

        return dados;
    }


    public static void PutConexao(string servidor, string bd, string usuario, string Senha)
    {
      //  Properties.Settings.Default["db_sistemasConnectionString"] = "Data Source = " + servidor + "; Initial Catalog = " + bd + "; Persist Security Info = True; User ID = " + usuario + "; Password = " + Senha; ;
            Properties.Settings.Default.servidor = servidor;
            Properties.Settings.Default.bancodedados = bd;
            Properties.Settings.Default.usuario = usuario;
            Properties.Settings.Default.senha = Senha;
            Properties.Settings.Default.Save();


    }

        public SqlDataReader RetDataReader(string sql)
        {
            //Concretiza a criação do objeto "comando" 
            //Observe que os parâmetros "sql" e "conn" são passados para o construtor da classe "MySqlCommand"
            SqlCommand comando = new SqlCommand(sql, conn);

            //Agora que o objeto "comando" está criado, basta executá-lo de modo que ele retorno um objeto do tipo "MySqlDataReader" 
            //Observe a criação e ao mesmo tempo a atribuição de valor para o objeto dr
            SqlDataReader dr = comando.ExecuteReader();

            //O objeto precisa ser lido para liberar seu uso
            dr.Read();

            //Retorno do objeto "dr" já preenchido
            return dr;
        }
    }

}