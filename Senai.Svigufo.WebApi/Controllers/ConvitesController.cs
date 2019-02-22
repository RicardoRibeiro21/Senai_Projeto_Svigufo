using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enums;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvitesController : ControllerBase
    {
        private IConviteRepository ConviteRepository { get; set; }
        public ConvitesController()
        {
            ConviteRepository = new ConviteRepository();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(ConviteRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("meus")]
        [HttpGet]
        public IActionResult ListarMeusConvites()
        {
            try
            {
                //Usando o register claim para pegar o Id alocado na chave do token e convertendo para int32 Para passar no método
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(ConviteRepository.ListarMeusConvites(usuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("entrar/{eventoId}")]  //Passando o Id do evento para que ele não referencie ao Convite, e sim a inscrição
        public IActionResult Inscricao(int eventoId)
        {
            try
            {
                ConviteDomain convite = new ConviteDomain();
                convite.EventoId = eventoId;
                convite.UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                if (convite.Evento.AcessoLivre == true)
                {
                    convite.situacao = EnSituacaoConvite.Aprovado;
                } else
                {
                    convite.situacao = EnSituacaoConvite.Aguardando;
                }

                ConviteRepository.Cadastrar(convite);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("{convidar}")]
        public IActionResult Convidar (ConviteDomain convite)
        {
            try
            {
                ConviteRepository.Cadastrar(convite);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{IdConvite}")]
        public IActionResult Aprovar()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
    }
}

    }
}