using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using PullTracker.ApiConsumer;
using PullTracker.Common;
using PullTracker.Facade;
using PullTracker.Repository;

namespace PullTracker
{
    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {
        private static IContainer _container;

        private static IContainerProvider _containerProvider;

        /// <summary>
        /// Gets the container.
        /// </summary>
        public IContainer Container
        {
            get { return _container; }
        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register: create and configure the container
            _container = BootstrapContainer();            

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            var builder = new ContainerBuilder();

            //var configurationRepository =
            //    new ConfigurationRepository.ConfigurationRepository() as IConfigurationRepository;

            //builder.Register(c => configurationRepository).As<IConfigurationRepository>().SingleInstance();

            builder.RegisterType<StashCoreApiConsumer>().As<IStashCoreApiConsumer>();

            builder.RegisterType<PullTrackerRepository>().As<IPullTrackerRepository>();

            builder.RegisterType<RequestProcessFacade>().As<IRequestProcessFacade>();

            IContainer localContainer = builder.Build();

            AutofacHelper.Scope = localContainer;

            _containerProvider = new ContainerProvider(localContainer);
        }

        /// <summary>
        /// Bootstrapper is the place where you create and configure your container
        /// </summary>
        /// <returns>An Autofac container</returns>
        private IContainer BootstrapContainer()
        {
            var builder = new ContainerBuilder();
            // You can make property injection available to your MVC views by adding the ViewRegistrationSource to your ContainerBuilder before building the application container.
            builder.RegisterSource(new ViewRegistrationSource());
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            return builder.Build();
        }
    }
}
