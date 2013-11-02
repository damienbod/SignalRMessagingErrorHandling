using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Unity
{
    /// <summary>
    /// An implementation of the <see cref="IDependencyResolver"/> interface that wraps a Unity container.
    /// </summary>
    public sealed class UnityDependencyResolver : Microsoft.AspNet.SignalR.IDependencyResolver

    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public  IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }

        public void Register(Type serviceType, Func<object> activator)
        {
            throw new NotImplementedException();
        }

        public void Register(Type serviceType, IEnumerable<Func<object>> activators)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
