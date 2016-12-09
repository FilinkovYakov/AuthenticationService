using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using InternshipAuthenticationService.Repository;

namespace InternshipAuthenticationService.AuthenticationService
{
    public static class DependencyContainer
    {
        private readonly static UnityContainer container;

        static DependencyContainer() {
            container = new UnityContainer();
            container.LoadConfiguration();
        }

        public static IUnityContainer Container
        {
            get { return container; }
        }
    }
}