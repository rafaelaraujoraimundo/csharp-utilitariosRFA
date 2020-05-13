using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3Camadas.Code.DTO
{
    public class ClienteDTO
    {
        private int id;
        private string nome;
        private string email;
        private string senha;
        private string usuario;
       public int Id { get => id; set => id = value; }
      public string Nome { get => nome; set => nome = value; }
      public string Email { get => email; set => email = value; }
      public string Senha { get => senha ; set => senha = AcertaSenha(value); }
        public string Usuario { get => usuario; set => usuario = value; }

        public static string AcertaSenha(string _senha)
        {
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes(_senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            return senha.ToString();
        }
    }
}
