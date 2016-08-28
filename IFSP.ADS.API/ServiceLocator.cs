using System;

namespace IFSP.ADS.API
{
    public class ServiceLocator
    {
        private static ServiceLocator instance = new ServiceLocator();

        protected virtual TService ResolveInternal<TService>()
        {
            throw new InvalidOperationException("ServiceLocator não configurado.");
        }


        public static TService Resolve<TService>()
        {
            return instance.ResolveInternal<TService>();
        }

        public static void SetInstance(ServiceLocator serviceLocator)
        {
            instance = serviceLocator;
        }
    }
}