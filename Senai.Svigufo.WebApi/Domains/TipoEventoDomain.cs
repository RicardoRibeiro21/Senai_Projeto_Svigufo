using System.ComponentModel.DataAnnotations;

namespace Senai.Svigufo.WebApi.Domains
{
    /// <summary>
    /// Classe que representa os tipos de eventos 
    /// </summary>
    public class TipoEventoDomain
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Insira o nome do tipo de eventos")]
        public string Nome { get; set; }
    }
}
