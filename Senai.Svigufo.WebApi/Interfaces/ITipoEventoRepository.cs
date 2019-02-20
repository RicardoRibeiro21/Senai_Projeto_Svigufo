using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Interfaces
{
    //Interface só declara os métodos
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos 
        /// </summary>
        /// <returns>Retorna uma lista de eventos</returns>
        List<TipoEventoDomain> Listar();

        void Cadastrar(TipoEventoDomain tipoEvento);

        void Alterar(TipoEventoDomain tipoEvento);
        void Deletar(int ID);
    }
}
