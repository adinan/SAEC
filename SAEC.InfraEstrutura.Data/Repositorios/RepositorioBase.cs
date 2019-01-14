using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.InfraEstrutura;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.InfraEstrutura.Data.Configuracao;
using SAEC.InfraEstrutura.Data.Contexto;
using Microsoft.Practices.ServiceLocation;

namespace SAEC.InfraEstrutura.Data.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly ContextoEF Contexto;
        private IDbSet<TEntidade> Entidade => Contexto.Set<TEntidade>();

        protected RepositorioBase()
        {
            var gerenciador = (GerenciadorDeRepositorio)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
            Contexto = gerenciador.Contexto;
        }


        public IEnumerable<TEntidade> Obter(Expression<Func<TEntidade, bool>> predicate)
        {
            return Entidade.Where(predicate);
        }

        public TEntidade Obter(int id)
        {
            return Entidade.Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Entidade.AsEnumerable();
        }


        public void AddOrUpdate(IEnumerable<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                AddOrUpdate(entidade);
            }
        }

        public void AddOrUpdate(TEntidade entidade)
        {
            if (entidade.Id > 0)
                Update(entidade);
            else
                Add(entidade);
        }

        private void Add(TEntidade entidade)
        {
            entidade.DataCadastro = DateTime.Now;
            Entidade.Add(entidade);
        }

        private void Update(TEntidade entidade)
        {
            Contexto.Entry(entidade).State = EntityState.Modified;
        }


        public void Remover(IEnumerable<TEntidade> entidades)
        {
            Contexto.Set<TEntidade>().RemoveRange(entidades);
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }

        public void Remover(TEntidade entidade)
        {
            Entidade.Remove(entidade);
        }
    }
}
