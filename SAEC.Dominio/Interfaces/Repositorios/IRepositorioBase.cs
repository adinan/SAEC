using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SAEC.Dominio.Entidades;

namespace SAEC.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio { }//Contraint

    public interface IRepositorioBase<TEntidade> : IRepositorio where TEntidade : EntidadeBase
    {

        TEntidade Obter(int id);
        IEnumerable<TEntidade> ObterTodos();
        IEnumerable<TEntidade> Obter(Expression<Func<TEntidade, bool>> predicate);
        
        void AddOrUpdate(TEntidade entity);
        void AddOrUpdate(IEnumerable<TEntidade> entities);

        void Remover(TEntidade entity);
        void Remover(IEnumerable<TEntidade> entities);
        void Dispose();
    }
}
