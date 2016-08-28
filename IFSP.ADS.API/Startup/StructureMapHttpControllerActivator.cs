using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace IFSP.ADS.API.Startup
{
    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public StructureMapHttpControllerActivator(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var scopedContainer = _container.GetNestedContainer();
            scopedContainer.Inject(typeof(HttpRequestMessage), request);
            request.RegisterForDispose(scopedContainer);
            return (IHttpController)scopedContainer.GetInstance(controllerType);
        }
    }
}