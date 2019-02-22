using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IConviteRepository
    {
        List<ConviteDomain> Listar();

        List<ConviteDomain> ListarMeusConvites(int id);
 
        void Cadastrar(ConviteDomain convite);

        void Aprovar(int idConvite, ConviteDomain convite);
    }
}
