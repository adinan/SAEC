using System;
using System.Collections.Generic;
using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.InfraEstrutura;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.Dominio.Interfaces.Servicos;
using Microsoft.Practices.ServiceLocation;

namespace SAEC.Dominio.Servicos
{
    public class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;
        protected readonly IUnidadeDeTrabalho UnidadeDeTrabalho;


        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
            UnidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
        }

        public void AddOrUpdate(TEntidade entidade)
        {
            _repositorio.AddOrUpdate(entidade);
        }

        public TEntidade ObterPorId(int id)
        {
            return _repositorio.Obter(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _repositorio.Remover(entidade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void SalvarAlteracoes()
        {
            UnidadeDeTrabalho.Persistir();
        }
    }
}
