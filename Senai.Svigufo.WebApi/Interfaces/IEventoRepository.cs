using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Lista os eventos do banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de eventos</returns>
        List<EventoDomain> Listar();
        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento"></param>
        void Cadastrar(EventoDomain evento);
        void Atualizar(int id, EventoDomain evento);
    }
}
