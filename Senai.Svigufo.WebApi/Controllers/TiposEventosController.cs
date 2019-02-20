using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")] //Informando qual a saída do Get
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades em nosso controller (substitui o frombody)
    public class TiposEventosController : ControllerBase
    {
        //Gerando Lista de Tipos Eventos
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Games"}

        };
        //Declarando que a lista será carregada do repositório
        private ITipoEventoRepository tipoEventoRepository { get; set; }
        public TiposEventosController()
        {
            tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Retorna a Lista de Tipos Eventos 
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return tipoEventoRepository.Listar();
        }

        /// <summary>
        /// Busca o tipo de evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return um tipo de evento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Verificando se o id passsado existe no banco de dados
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Id == id);
            if (tipoEvento == null)
            {
                //Se o objeto não foi encontrado...
                return NotFound();
            }
            //Se encontrou, retorna o objeto que foi encontrado.
            return Ok(tipoEvento);
        }
        [HttpPost] //Inserir dados 
        public IActionResult Post(TipoEventoDomain tipoEventoRecebido)
        {
            //Inserindo um novo tipo de evento, retornando a lista
            tiposEventos.Add(new TipoEventoDomain
            {
                Id = tiposEventos.Count + 1,
                Nome = tipoEventoRecebido.Nome
            });
            return Ok(tiposEventos);
        }

        /// <summary>
        /// Comando para Atualizar um dados passando o Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoEventoRecebido"></param>
        /// <returns>Retorna a lista de eventos com a atualização que o usuário fez</returns>
        
            
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, TipoEventosDomain tipoEventoRecebido)
        //{
        //    return Ok(tiposEventos);
        //}

        /// <summary>
        /// Deleta dados com o Id passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a lista com o dado deletado</returns>
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
        {
            tiposEventos.Remove(tiposEventos.Find(x => x.Id == id));
            return Ok(tiposEventos);
        }






        [HttpPut] //Verbo para Atualizar 
        public IActionResult Put(TipoEventoDomain tipoEventoRecebido)
        {
            tipoEventoRepository.Alterar(tipoEventoRecebido);
            return Ok(tiposEventos);
        }
        /// <summary>
        /// Procura o TipoEvento por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Retorna o TipoEvento dado o nome</returns>
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            //Verificando se o nome passsado existe no banco de dados
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Nome == nome);
            if (tipoEvento == null)
            {
                //Se o objeto não foi encontrado...
                return NotFound();
            }
            //Se encontrou, retorna o objeto que foi encontrado.
            return Ok(tipoEvento);
        }

     




        //Adicionando método Get
        //[HttpGet]
        //public string Get()
        //{
        //    return "Recebi sua requisição";
        //}
    }
}