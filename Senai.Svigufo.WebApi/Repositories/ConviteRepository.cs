using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enums;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class ConviteRepository : IConviteRepository
    {
        private string StringConexao = "Data Source=.\\sqlexpress;Initial Catalog=SENAI_SVIGUFO;Persist Security Info=True;User ID=sa;Password=132";

        public void Aprovar(int idConvite, ConviteDomain convite)
        {
            List<ConviteDomain> convites = new List<ConviteDomain>();
        }

        public void Cadastrar(ConviteDomain convite)
        {
            string QueryInsert = @"INSERT INTO CONVITES(ID_EVENTO, ID_USUARIO, SITUACAO) VALUES (@ID_EVENTO, @ID_USUARIO, @SITUACAO";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@ID_EVENTO", convite.EventoId);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", convite.UsuarioId);
                    cmd.Parameters.AddWithValue("@SITUACAO", convite.situacao);
                    cmd.ExecuteNonQuery();
                }
                EventoDomain evento = new EventoDomain();

            }
        }

        public List<ConviteDomain> Listar()
        {
            string querySelect = @"SELECT
            C.ID AS ID_CONVITE,
            E.TITULO AS TITULO_EVENTO,
            E.DATA_DO_EVENTO,
            TE.DESCRICAO AS ACESSO_EVENTO,
            TE.ID AS ID_TIPO_EVENTO,
            U.NOME AS NOME_USUARIO,
            U.EMAIL AS EMAIL_USUARIO,
            U.ID AS ID_USUARIO
            FROM CONVITES C 
            INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID
            INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID
            INNER JOIN TIPOS_EVENTOS TE ON TE.ID = E.ID_TIPO_EVENTO";
            List<ConviteDomain> lista = new List<ConviteDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();
                    while (sqr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain()
                        {
                            situacao = (EnSituacaoConvite)Convert.ToInt32(sqr["SITUACAO"]),
                            Id = Convert.ToInt32(sqr["ID"]),
                            Usuario = new UsuarioDomain()
                            {
                                Id = Convert.ToInt32(sqr["ID_USUARIO"]),
                                Nome = sqr["NOME_USUARIO"].ToString(),
                                Email = sqr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain()
                            {
                                id = Convert.ToInt32(sqr["ID_EVENTO"]),
                                Titulo = sqr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sqr["DATA_DO_EVENTO"]),
                                tipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sqr["ID_TIPO_EVENTO"]),
                                    Nome = sqr["ACESSO_EVENTO"].ToString()
                                }

                            } 
                        };
                        lista.Add(convite);
                    }
                    return lista;
                }
            }
        }

        public List<ConviteDomain> ListarMeusConvites(int id)
        {
            string querySelect = @"SELECT
                C.ID AS ID_CONVITE,
                E.TITULO AS TITULO_EVENTO,
                E.DATA_DO_EVENTO,
                TE.DESCRICAO AS ACESSO_EVENTO,
                TE.ID AS ID_TIPO_EVENTO,
                U.NOME AS NOME_USUARIO,
                U.EMAIL AS EMAIL_USUARIO,
                U.ID AS ID_USUARIO
                FROM CONVITES C 
                INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID
                INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID
                INNER JOIN TIPOS_EVENTOS TE ON TE.ID = E.ID_TIPO_EVENTO
                WHERE C.ID_USUARIO =@ID;";
            List<ConviteDomain> lista = new List<ConviteDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader sqr = cmd.ExecuteReader();
                    while (sqr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain()
                        {
                            situacao = (EnSituacaoConvite)Convert.ToInt32(sqr["SITUACAO"]),
                            Id = Convert.ToInt32(sqr["ID"]),
                            Usuario = new UsuarioDomain()
                            {
                                Id = Convert.ToInt32(sqr["ID_USUARIO"]),
                                Nome = sqr["NOME_USUARIO"].ToString(),
                                Email = sqr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain()
                            {
                                id = Convert.ToInt32(sqr["ID_EVENTO"]),
                                Titulo = sqr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sqr["DATA_DO_EVENTO"]),
                                tipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sqr["ID_TIPO_EVENTO"]),
                                    Nome = sqr["ACESSO_EVENTO"].ToString()
                                }
                            }
                        };
                        lista.Add(convite);
                    }
                    return lista;
                }
            }
        }
    }
}
