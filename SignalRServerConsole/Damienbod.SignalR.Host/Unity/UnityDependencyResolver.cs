using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Unity
{
    /// <summary>
    /// NOT USED DUE TO SIGNALR DEPENDENCYRESOLVER PROBLEM !!! TODO !!!
    /// An implementation of the <see cref="IDependencyResolver"/> interface that wraps a Unity container.
    /// </summary>
    public sealed class UnityDependencyResolver : DefaultDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
            
        }

        #region IDependencyResolver Members

        public override object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return base.GetService(serviceType);
            }
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return base.GetServices(serviceType);
            }
        }

        #endregion

    }
}
