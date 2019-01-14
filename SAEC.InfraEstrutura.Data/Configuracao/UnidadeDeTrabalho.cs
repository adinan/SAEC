using SAEC.Dominio.Interfaces.InfraEstrutura;
using SAEC.InfraEstrutura.Data.Contexto;
using Microsoft.Practices.ServiceLocation;

namespace SAEC.InfraEstrutura.Data.Configuracao
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly ContextoEF _contexto;

        public UnidadeDeTrabalho()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>() as GerenciadorDeRepositorio;

            _contexto = gerenciador?.Contexto;

        }

        public int Persistir()
        {
            return _contexto.SaveChanges();
        }
    }
}
