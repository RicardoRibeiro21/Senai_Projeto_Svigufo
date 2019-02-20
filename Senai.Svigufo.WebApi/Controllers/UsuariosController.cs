using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController ()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        //IactionRsult pode retornar o próprio código ou qualquer comando.
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
       
    }
}