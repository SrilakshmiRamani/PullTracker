using System;
using Autofac;
using Autofac.Integration.Web;

namespace PullTracker.Common
{
    public class AutofacHelper
    {
        [NonSerialized]
        private static ILifetimeScope scope;

        [NonSerialized]
        private static IContainerProvider containerProvider;


        /// <summary>
        /// Assigns the container provider for this application.
        /// </summary>
        public static void ContainerProvider(IContainerProvider objContainerProvider)
        {
            containerProvider = objContainerProvider;
        }

        public static ILifetimeScope Scope
        {
            get { return scope ?? containerProvider.RequestLifetime; }
            set { scope = value; }
        }
    }
}
