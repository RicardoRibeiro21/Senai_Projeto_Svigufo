using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;
using Senai.Svigufo.WebApi.VieiwModels;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }
        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try {
                UsuarioDomain usuarioBuscado = UsuarioRepository.BurcarPorEmailSenha(login.Email, login.Senha);
                if (usuarioBuscado == null)

                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                //SENTA QUE LÁ VEM MERDA 2.0
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-authenticacao"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                       //Nome do Issuer, de onde esta vindo
                       issuer: "Svigufo.WebApi",
                     //Nome da Audience, de onde está vindo
                     audience: "Svigufo.WebApi",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds

                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                //Pode descansar agora meu rapaz 2.0
            }
            catch {
                return BadRequest();
            }
        }
    } }
    