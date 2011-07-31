using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System.Web.Mvc;
using Castle.MicroKernel.SubSystems.Configuration;
using TheStorage.Web.Controllers;

namespace TheStorage.Web.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(ConfigureControllers()));
        }

        private ConfigureDelegate ConfigureControllers()
        {
            return c => c.LifeStyle.Transient;
        }

        private BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<HomeController>())
                .If(t => t.Name.EndsWith("Controller"));
        }
    }
}