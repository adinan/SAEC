using System.Collections.Generic;
using SAEC.Dominio.Entidades;

namespace SAEC.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        IEnumerable<Usuario> ObterUsuariosPaginacao(int pagina, int quantidadePorPagina);
        IEnumerable<Usuario> ObterTodosUsuariosAtivos();
        Usuario ObterPorCpf(string userCpf);
    }
}
