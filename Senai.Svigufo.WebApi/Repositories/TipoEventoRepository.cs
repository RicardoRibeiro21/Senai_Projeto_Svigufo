using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        //Criando string de conexão com o banco de dados
        private string StringConexao = "Data Source=.\\SQLEXPRESS; initial catalog=SENAI_SVIGUFO; Persist Security Info=True; user ID=sa;Password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryASerExecutada = "UPDATE TIPOS_EVENTOS SET DESCRICAO = @DESCRICAO WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(QueryASerExecutada, con);
                cmd.Parameters.AddWithValue("@DESCRICAO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@Id", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryaSerExecutada = "INSERT INTO TIPOS_EVENTOS (DESCRICAO) VALUES (@DESCRICAO)";
                SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con);
                //Passa o valor do Parâmetro
                cmd.Parameters.AddWithValue("@DESCRICAO", tipoEvento.Nome);
                //Abre a conexão
                con.Open();
                cmd.ExecuteNonQuery();
               
            }
        }

        public void Deletar(int ID)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryASerExecutada = "DELETE FROM TIPOS_EVENTOS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(QueryASerExecutada, con);
                cmd.Parameters.AddWithValue("@Id", ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    
        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string QueryaSerExecutada = "SELECT ID, DESCRICAO FROM TIPOS_EVENTOS";

                //Abrindo o banco de dados
                con.Open();

                //Declaro um SqlDataReader para percorrer a lista
                SqlDataReader rdr;

                //Comandos que quero executar
                using (SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con))
                {
                    //Executa a query 
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain()
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Nome = rdr["DESCRICAO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);
                    };
                }
            }
            return tiposEventos;
        }

    }
    }

