using System.Collections.Generic;
using System.Linq;
using SAEC.Common;
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
        
        public Usuario ObterPorCpf(string userCpf)
        {
            var cpfLimpo = userCpf.RemoveMask();
            return Contexto.Usuario.FirstOrDefault(u => u.Cpf == cpfLimpo);
        }
    }
}

