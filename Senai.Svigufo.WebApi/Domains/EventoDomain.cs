using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class EventoDomain
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Informe o titulo do evento")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o titulo do evento")]
        public string  Descricao { get; set; }
        [Required(ErrorMessage="Informe a data do evento")]
        [DataType(DataType.Date)]
        public DateTime DataEvento { get; set; }
        [Required(ErrorMessage = "Informe o titulo do evento")]
        public bool AcessoLivre { get; set; }
        public TipoEventoDomain tipoEvento { get; set; }
        [Required(ErrorMessage = "Informe o Tipo de evento")]
        public int TipoEventoId { get; set; }
        public InstituicaoDomain instituicao { get; set; }
        public int InstituicaoId { get; set; }
    }
}
