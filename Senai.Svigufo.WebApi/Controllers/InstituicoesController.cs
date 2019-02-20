using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        List<InstituicaoDomain> LID = new List<InstituicaoDomain>();

        private IInstituicaoRepository IIR { get; set; }

        public InstituicoesController()
        {
            IIR = new InstituicaoRepository();
        }

        [HttpGet]
       
        public IEnumerable<InstituicaoDomain> Get()
        {
            return IIR.Listar();
        }

        [HttpPost]
        public IActionResult Post(InstituicaoDomain ITD)
        {
            try
            {
                IIR.Gravar(ITD);
                return Ok(ITD);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Procura a instituição pelo Id passado na url
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Retorna a insituição que tenha o Id passado</returns>
        [HttpGet("{ID}")]
        public IActionResult GetById(int ID)
        {
            IIR.GetByID(ID);
            return Ok(LID);
        }

        /// <summary>
        /// Deleta uma instituição 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            IIR.Excluir(ID);
            return Ok(LID);
        }
        /// <summary>
        /// Altera uma instituiçãpo passando o Id
        /// </summary>
        /// <param name="instituicao"></param>
        /// <param name="ID"></param>
        /// <returns>Uma instituição alterada</returns>
        [HttpPut("{ID}")]
        public IActionResult Put(InstituicaoDomain instituicao, int ID )
        {
            InstituicaoDomain instituicaoBuscada = IIR.GetByID(ID);

            if (instituicaoBuscada== null)
            {
                return NotFound();
            }
            try
            {
                IIR.Alterar(instituicao, ID);
                return Ok(LID);
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}