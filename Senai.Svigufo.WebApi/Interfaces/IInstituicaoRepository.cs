using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();
        void Gravar(InstituicaoDomain ITD);
        void Excluir(int ID);
        void Alterar(InstituicaoDomain ITD, int ID);
        InstituicaoDomain GetByID(int ID);
    }
}
