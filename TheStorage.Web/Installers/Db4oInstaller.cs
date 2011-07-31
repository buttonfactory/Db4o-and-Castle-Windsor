using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.MicroKernel;
using TheStorage.Web.DataAccess;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;


namespace TheStorage.Web.Installers
{
    public class Db4oInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
              //  Component.For<IObjectContainer>().Instance(CreateObjectContainer()).LifeStyle.Singleton,
              //  Component.For<ISession>().ImplementedBy<Db4oSession>().LifeStyle.PerWebRequest,
              Component.For<IObjectContainer>().Instance(CreateObjectContainer()).LifeStyle.PerWebRequest,
              Component.For<IRepository>().ImplementedBy<Db4oRepository>().LifeStyle.Transient);
        }


        //this is pretty much the same as a Session in Nhibernate
        static IObjectContainer CreateObjectContainer()
        {
            return Db4oClientServer.OpenClient(Db4oClientServer.NewClientConfiguration(),
                  "localhost", 4433, "db4o", "db4o");
        }
    }
}