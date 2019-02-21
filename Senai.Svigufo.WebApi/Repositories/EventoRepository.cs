using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private string StringConexao = "Data Source=.\\sqlexpress;Initial Catalog=SENAI_SVIGUFO;Persist Security Info=True;User ID=sa;Password=132";

        public void Cadastrar(EventoDomain evento)
        {
            string Insert = "INSERT INTO EVENTOS VALUES(@TITULO, @DESCRICAO, @DATA_DO_EVENTO, @ACESSO_LIVRE, @ID_INSTITUICAO, @ID_TIPO_EVENTO)";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Insert, con);
                cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                cmd.Parameters.AddWithValue("@DATA_DO_EVENTO", evento.DataEvento);
                cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<EventoDomain> Listar()
        {
            string QuerySelect = "SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO_EVENTO, E.DESCRICAO, E.DATA_DO_EVENTO, E.ACESSO_LIVRE, I.ID AS ID_INSTITUICAO, I.CIDADE, I.CNPJ, I.CEP, I.LOGRADOURO, I.NOME_FANTASIA, I.UF, I.RAZAO_SOCIAL, TE.ID AS ID_TIPO_EVENTO, TE.DESCRICAO AS TITULO_TIPO_EVENTO FROM EVENTOS E INNER JOIN TIPOS_EVENTOS AS TE ON E.ID_TIPO_EVENTO = TE.ID INNER JOIN INSTITUICOES I ON E.ID_INSTITUICAO = I.ID";
            List<EventoDomain> ListaEventos = new List<EventoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand (QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EventoDomain evento = new EventoDomain
                        {
                            id = Convert.ToInt32(sdr["ID_EVENTO"]),
                            Titulo = sdr["TITULO_EVENTO"].ToString(),
                            Descricao = sdr["DESCRICAO"].ToString(),
                            DataEvento = Convert.ToDateTime(sdr["DATA_DO_EVENTO"]),
                            AcessoLivre = Convert.ToBoolean(sdr["ACESSO_LIVRE"]),
                            tipoEvento = new TipoEventoDomain()
                            {
                                Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                                 
                            },
                            instituicao = new InstituicaoDomain()
                            {
                                Id = Convert.ToInt32(sdr["ID_INSTITUICAO"]),
                                NomeFantasia = sdr["NOME_FANTASIA"].ToString(),
                                RazaoSocial = sdr["RAZAO_SOCIAL"].ToString(),
                                Cidade = sdr["CIDADE"].ToString(),
                                Logradouro = sdr["LOGRADOURO"].ToString(),
                                Uf = sdr["UF"].ToString(),
                                CEP = sdr["CEP"].ToString(),
                                CNPJ = sdr["CNPJ"].ToString()
                            }

                        };
                        ListaEventos.Add(evento);
                    }
                }
            }

            return ListaEventos;

        }
        public void Atualizar(int id, EventoDomain evento)
        {
            string QueryUpdate = "UPDATE EVENTOS SET TITULO = @TITULO, DESCRICAO =  @DESCRICAO, DATA_DO_EVENTO = @DATA_DO_EVENTO, ACESSO_LIVRE = @ACESSO_LIVRE,ID_INSTITUICAO = @ID_INSTITUICAO, ID_TIPO_EVENTO = @ID_TIPO_EVENTO";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(QueryUpdate, con);
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                cmd.Parameters.AddWithValue("@DATA_DO_EVENTO", evento.DataEvento);
                cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
