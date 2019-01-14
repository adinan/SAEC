using System.Collections.Generic;
using SAEC.Dominio.Entidades;

namespace SAEC.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : EntidadeBase
    {
        void AddOrUpdate(TEntidade entidade);
        TEntidade ObterPorId(int id);
        IEnumerable<TEntidade> ObterTodos();
        void Remover(TEntidade entidade);
        void Dispose();
        void SalvarAlteracoes();
    }
}