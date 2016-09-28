using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using StructureMap;
using IFSP.ADS.Services.Contracts;
using IFSP.ADS.Services.Services;

namespace IFSP.ADS.API.Startup
{
    public partial class Startup
    {
        private IContainer ConfigureDependencies(HttpConfiguration config)
        {
            var container = new Container();

            ServiceLocator.SetInstance(new StructureMapServiceLocator(container));

            ConfigureDependency<ICategoryService>(container, () => new CategoryService());
            ConfigureDependency<IFederationService>(container, () => new FederationService());
            ConfigureDependency<IModalityService>(container, () => new ModalityService());

            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(container));

            return container;
        }

        private void ConfigureDependency<TInterfaceType>(Container container, Func<TInterfaceType> objBuilder = null)
                    where TInterfaceType : class
        {
            container.Configure(x => x.For<TInterfaceType>().Use(typeof(TInterfaceType).FullName, objBuilder));
        }

        #region StructureMapServiceLocator
        private class StructureMapServiceLocator : ServiceLocator
        {
            private Container container;

            public StructureMapServiceLocator(Container container)
            {
                this.container = container;
            }

            protected override TService ResolveInternal<TService>()
            {
                return container.GetInstance<TService>();
            }
        }
        #endregion StructureMapServiceLocator
    }
}