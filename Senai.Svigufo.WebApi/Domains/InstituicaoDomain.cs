using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(2,MinimumLength = 2, ErrorMessage = "O campo só pode ter 2 caracteres")] //Tamanho da string 
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ")] //Para requirir 
        public string CNPJ { get; set; }
    }
}
