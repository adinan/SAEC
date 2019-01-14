using System.Collections.Generic;
using SAEC.Dominio.Entidades;

namespace SAEC.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        IEnumerable<Usuario> ObterUsuariosPaginacao(int pagina, int quantidadePorPagina);
        Usuario ObterPorCpf(string userCpf);
    }
}
