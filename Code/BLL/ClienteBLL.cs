using Projeto3Camadas.Code.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace Projeto3Camadas.Code.BLL
{
    public class ClienteBLL
    {
        AcessoBancoDados bd;
        public void Inserir(ClienteDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                string nome = dto.Nome.Replace("'", "''");
                bd.Conectar();
                string comando = "insert into usuarios (usuario,email,senha) VALUES ('" + nome + "','" + dto.Email + "','" + dto.Senha + "')";
                bd.ExecutarComandoSQL(comando);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar Cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }

        public void Atualizar(ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "update usuarios set usuario = '" + nome +"', email = '" + dto.Email + "' where id = " + dto.Id ;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }

        public void AlterarSenha(ClienteDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "update usuarios set senha = '" + dto.Senha + "' where id = " + dto.Id;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }
        public void Excluir(ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "delete from usuarios where id = " + dto.Id;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Excluir o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }

        public DataTable SelecionaTodosUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {

           
            
            bd = new AcessoBancoDados();
            bd.Conectar();
                dt = bd.RetDataTable("Select id,usuario, email from usuarios");
            return dt;
                     }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar Listar todos os Usuarios: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }
    }
}
