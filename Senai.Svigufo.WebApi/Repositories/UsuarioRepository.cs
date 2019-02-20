using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Criando string de conexão com o banco de dados
        private string StringConexao = "Data Source=.\\sqlexpress;Initial Catalog=SENAI_SVIGUFO;Persist Security Info=True;User ID=sa;Password=132";

        public UsuarioDomain BurcarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, NOME, EMAIL, SENHA, TIPO_USUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
                using(SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);
                    con.Open();

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();
                    while (sqr.Read())
                    {
                            usuario.Id = Convert.ToInt32(sqr["ID"]);
                            usuario.Nome = (sqr["NOME"]).ToString();
                            usuario.Email = (sqr["EMAIL"]).ToString();
                            usuario.TipoUsuario = (sqr["TIPO_USUARIO"]).ToString();
                    }
                        return usuario;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO USUARIOS(NOME, EMAIL, SENHA, TIPO_USUARIO) VALUES(@NOME, @EMAIL, @SENHA, @TIPO_USUARIO) ";
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.senha);
                    cmd.Parameters.AddWithValue("@TIPO_USUARIO", usuario.TipoUsuario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
