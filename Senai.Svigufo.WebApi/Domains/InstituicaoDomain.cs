using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Logradouro { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string CNPJ { get; set; }
    }
}
