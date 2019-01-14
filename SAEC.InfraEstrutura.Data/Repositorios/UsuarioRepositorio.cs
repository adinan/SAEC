using System.Collections.Generic;
using System.Linq;
using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.Repositorios;

namespace SAEC.InfraEstrutura.Data.Repositorios
{
    public sealed class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public IEnumerable<Usuario> ObterUsuariosPaginacao(int pagina, int quantidadePorPagina)
        {
            return Contexto.Usuario
                .OrderBy(c => c.Nome)
                .Skip((pagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .AsEnumerable();
        }

        public IEnumerable<Usuario> ObterTodosUsuariosAtivos()
        {
            var troxa = Contexto.Usuario.ToList();
            return troxa;
        }

        public Usuario ObterPorCpf(string userCpf)
        {
            return Contexto.Usuario.FirstOrDefault(u => u.Cpf == userCpf);
        }
    }
}

