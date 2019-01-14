﻿
using System.Reflection;
using System.Web.Mvc;
using SAEC.MVC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace SAEC.MVC
{
    /// <summary>
    /// Install-Package SimpleInjector
    /// Install-Package SimpleInjector.Integration.Web
    /// Install-Package SimpleInjector.Integration.Web.Mvc
    /// Install-Package WebActivator -Version 1.5.3
    /// </summary>
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            InfraEstrutura.IoC.Bindings.Start(container);
        }
    }
}