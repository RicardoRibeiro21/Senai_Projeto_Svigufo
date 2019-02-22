using Senai.Svigufo.WebApi.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }
        public EventoDomain Evento { get; set; }
        public UsuarioDomain Usuario { get; set; }
        public EnSituacaoConvite situacao { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
    }
}
