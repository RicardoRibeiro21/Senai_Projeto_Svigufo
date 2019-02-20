using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario"></param>
        void Cadastrar(UsuarioDomain usuario);
        /// <summary>
        /// Busca por email e senha o usuario, e o retorna.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        UsuarioDomain BurcarPorEmailSenha(string email, string senha);
    }
}
