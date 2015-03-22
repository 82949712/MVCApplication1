using Infrastrusture.MVC;
using Ninject.Web.Mvc.FilterBindingSyntax;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcApplication3.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcApplication3.App_Start.NinjectWebCommon), "Stop")]

namespace MvcApplication3.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Collections.Generic;
    using Ninject.Modules;
    using IoC;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                //Create a container to be used later
                kernel.Bind<IContainer>()
                    .To<NinjectContainer>()
                    .InSingletonScope()
                    .WithConstructorArgument(typeof (IKernel), kernel);
                ContextAccessor.CurrentContext = kernel.Get<IContainer>();

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var modules = new List<INinjectModule>(){
                new RepositoryModule(),
                new InfrastructureModule()
            };
            kernel.Load(modules);
        }        
    }
}
