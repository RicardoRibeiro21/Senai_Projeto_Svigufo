using System.ComponentModel.DataAnnotations;

namespace Senai.Svigufo.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Informe seu nome")]
        public string  Nome { get; set; }
        [Required(ErrorMessage="Informe seu email")]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }
        [Required(ErrorMessage="Informe a senha")]
        public string senha { get; set; }
        [Required(ErrorMessage="Informe o tipo de usuário")]
        public string TipoUsuario { get; set; }

    }
}
