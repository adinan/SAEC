using CommonServiceLocator.SimpleInjectorAdapter;
using SAEC.Dominio.Interfaces.InfraEstrutura;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.Dominio.Interfaces.Servicos;
using SAEC.Dominio.Servicos;
using SAEC.InfraEstrutura.Data.Configuracao;
using SAEC.InfraEstrutura.Data.Repositorios;

using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace SAEC.InfraEstrutura.IoC
{
    public class Bindings
    {
        /// <summary>
        /// Install-Package SimpleInjector
        /// Install-Package CommonServiceLocator -Version 1.3.0
        /// Install-Package CommonServiceLocator.SimpleInjectorAdapter
        /// </summary>
        public static void Start(Container container)
        {
            //Infra
            container.Register<IGerenciadorDeRepositorio, GerenciadorDeRepositorio>();
            container.Register<IUnidadeDeTrabalho, UnidadeDeTrabalho>();

            //Repositorio
            //container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), Lifestyle.Scoped);
            container.Register(typeof(IUsuarioRepositorio), typeof(UsuarioRepositorio), Lifestyle.Scoped);
            container.Register(typeof(IAlunoRepositorio), typeof(AlunoRepositorio), Lifestyle.Scoped);
            container.Register(typeof(ICidadeRepositorio), typeof(CidadeRepositorio), Lifestyle.Scoped);


            //Dominio

            //Aplicacao
            container.Register(typeof(IUsuarioServico), typeof(UsuarioServico), Lifestyle.Scoped);
            container.Register(typeof(IAlunoServico), typeof(AlunoServico), Lifestyle.Scoped);
            container.Register(typeof(ICidadeServico), typeof(CidadeServico), Lifestyle.Scoped);


            //Service Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
