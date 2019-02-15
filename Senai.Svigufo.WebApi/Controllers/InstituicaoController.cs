using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        List<InstituicaoDomain> LID = new List<InstituicaoDomain>();

        private IInstituicaoRepository IIR { get; set; }

        public InstituicaoController()
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
            LID.Add(new InstituicaoDomain {
                Id = LID.Count + 1,
                NomeFantasia = ITD.NomeFantasia,
                RazaoSocial = ITD.RazaoSocial,
                Logradouro = ITD.Logradouro,
                Cidade = ITD.Cidade,
                Uf = ITD.Uf,
                CEP = ITD.CEP,
                CNPJ = ITD.CNPJ
            });
            IIR.Gravar(ITD);
            return Ok(ITD);
        }

        [HttpGet("{ID}")]
        public IActionResult GetById(int ID)
        {
            IIR.GetByID(ID);
            return Ok(LID);
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            IIR.Excluir(ID);
            return Ok(LID);
        }
        [HttpPut]
        public IActionResult Put(int ID )
        {
            InstituicaoDomain ITD = LID.Find(X => X.Id == ID);
            IIR.Alterar(ID);
            return Ok(LID);
        }

    }
}