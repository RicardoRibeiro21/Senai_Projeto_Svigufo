using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
    
namespace Senai.Svigufo.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=SENAI_SVIGUFO;User ID = sa; Password = 132;";

        public void Alterar(InstituicaoDomain ITD, int ID)
        {
            using (SqlConnection con = new SqlConnection(StringConexao  ))
            {
                InstituicaoDomain instituicaoDomain = new InstituicaoDomain();
                string Alterar = "UPDATE INSTITUICOES SET ID = ID, NOME_FANTASIA = @A, RAZAO_SOCIAL = @B, LOGRADOURO = @C, UF = @D, CIDADE = @E, CEP = @ F, CNPJ = @G WHERE ID = @ID";
                SqlCommand CMD = new SqlCommand(Alterar, con);
                CMD.Parameters.AddWithValue("@ID", ID);
                CMD.Parameters.AddWithValue("@A", instituicaoDomain.NomeFantasia);
                CMD.Parameters.AddWithValue("@B", instituicaoDomain.RazaoSocial);
                CMD.Parameters.AddWithValue("@C", instituicaoDomain.Logradouro);
                CMD.Parameters.AddWithValue("@D", instituicaoDomain.Uf);
                CMD.Parameters.AddWithValue("@E", instituicaoDomain.Cidade);
                CMD.Parameters.AddWithValue("@F", instituicaoDomain.CEP);
                CMD.Parameters.AddWithValue("@G", instituicaoDomain.CNPJ);
                con.Open();
                CMD.ExecuteNonQuery();
            }
        }


        public void Excluir(int ID)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Delete = "DELETE FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand CMD = new SqlCommand(Delete, con);
                CMD.Parameters.AddWithValue("@ID", ID);
                con.Open();
                CMD.ExecuteNonQuery();
            }
        }

        public InstituicaoDomain GetByID(int ID)
        {
            InstituicaoDomain ITD = new InstituicaoDomain();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string SelectID = "SELECT NOME_FANTASIA, RAZAO_SOCIAL, LOGRADOURO, UF, CIDADE, CEP, CNPJ FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand CMD = new SqlCommand(SelectID, con);
                CMD.Parameters.AddWithValue("@NOME_FANTASIA, @RAZAO_SOCIAL, @LOGRADOURO, @UF, @CIDADE, @CEP, @CNPJ", ID);
                con.Open();
                CMD.ExecuteReader();
            }
            return ITD;
        }

        public void Gravar(InstituicaoDomain ITD)
        {
            List<InstituicaoDomain> LID = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Insert = "INSERT INTO INSTITUICOES (NOME_FANTASIA, RAZAO_SOCIAL, LOGRADOURO, UF, CIDADE, CEP, CNPJ) VALUES (@NOME_FANTASIA, @RAZAO_SOCIAL, @LOGRADOURO, @UF, @CIDADE, @CEP, @CNPJ)";
                SqlCommand CMD = new SqlCommand(Insert, con);
                con.Open();
                CMD.Parameters.AddWithValue("@NOME_FANTASIA", ITD.NomeFantasia);
                CMD.Parameters.AddWithValue("@RAZAO_SOCIAL", ITD.RazaoSocial);
                CMD.Parameters.AddWithValue("@LOGRADOURO", ITD.Logradouro);
                CMD.Parameters.AddWithValue("@UF", ITD.Uf);
                CMD.Parameters.AddWithValue("@CIDADE", ITD.Cidade);
                CMD.Parameters.AddWithValue("@CEP", ITD.CEP);
                CMD.Parameters.AddWithValue("@CNPJ", ITD.CNPJ);
                CMD.ExecuteNonQuery();
            }
        }

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> LID = new List<InstituicaoDomain>();  
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, LOGRADOURO, UF, CIDADE, CEP, CNPJ FROM INSTITUICOES";
                con.Open();
                SqlDataReader SQLRD;

                using (SqlCommand CMD = new SqlCommand(Query, con))
                {
                    SQLRD = CMD.ExecuteReader();
                    if (SQLRD.HasRows) { 
                    while (SQLRD.Read())
                    {
                        InstituicaoDomain ITD = new InstituicaoDomain()
                        {
                            Id = Convert.ToInt32(SQLRD["ID"]),
                            NomeFantasia = (SQLRD["NOME_FANTASIA"]).ToString(),
                            RazaoSocial = (SQLRD["RAZAO_SOCIAL"]).ToString(),
                            Logradouro = (SQLRD["LOGRADOURO"]).ToString(),
                            Uf = (SQLRD["UF"]).ToString(),
                            Cidade = (SQLRD["CIDADE"]).ToString(),
                            CNPJ = (SQLRD["CNPJ"]).ToString(),
                            CEP = (SQLRD["CEP"]).ToString()
                        };
                        LID.Add(ITD);
            return LID;       
                    }
                    } return null;
                }
            }
        }
    }
}
