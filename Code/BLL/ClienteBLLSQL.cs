using Projeto3Camadas.Code.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Projeto3Camadas.Code.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto3Camadas.Code.BLL
{
    public class ClienteBLLSQL
    {
        private int contador = 0;
        AcessoBancodeDadosSQLSERVER sql;

        public int Contador { get => contador; set => contador = value; }

        public void Inserir(ClienteDTO dto)
        {
            try
            {
                sql = new AcessoBancodeDadosSQLSERVER();
                string nome = dto.Nome.Replace("'", "''");
                sql.Conectar();
                string comando = "insert into usuarios (usuario,nome,email,senha) VALUES ('" + dto.Usuario + "','" + nome + "','" + dto.Email + "','" + dto.Senha + "')";
                sql.ExecutarComandoSQL(comando);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar Cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                sql = null;
            }
        }

        public void Atualizar(ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();
                string comando = "update usuarios set nome = '" + nome +"', email = '" + dto.Email + "' where id = " + dto.Id ;
                sql.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                sql = null;
            }
        }

        public void AlterarSenha(ClienteDTO dto)
        {
            try
            {
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();
                string comando = "update usuarios set senha = '" + dto.Senha + "' where id = " + dto.Id;
                sql.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Alterar senha: " + ex.Message);
            }
            finally
            {
                sql = null;
            }
        }
        public void Excluir(ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();
                string comando = "delete from usuarios where id = " + dto.Id;
                sql.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Excluir o cliente: " + ex.Message);
            }
            finally
            {
                sql = null;
            }
        }

        public DataTable SelecionaTodosUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();
                dt = sql.RetDataTable("Select id,usuario,nome, email from usuarios");
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Listar todos os Usuarios: " + ex.Message);
            }
            finally
            {
                sql = null;
            }
        }
        // FAz login no sistema

        public bool Verificalogin(String usuario, String senha)
        {
            bool logar = false;
            try
            {
                SqlDataReader dr;
                sql = new AcessoBancodeDadosSQLSERVER();
                sql.Conectar();

               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from usuarios where usuario = '"+ usuario + "' and senha = '" + Projeto3Camadas.Code.DTO.ClienteDTO.AcertaSenha(senha) + "'";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", Projeto3Camadas.Code.DTO.ClienteDTO.AcertaSenha(senha));
                dr = sql.RetDataReader(cmd.CommandText);
                if(dr.HasRows)
                {
                    logar = true;
                }

            }
            catch (SqlException erro)
            {

                MessageBox.Show("Erro no login: " +erro.Message);
            }
            return logar;
        }
    }
}
