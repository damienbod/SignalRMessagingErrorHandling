using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damienbod.SignalR.Host.Hubs;
using Damienbod.SignalR.IHubSync.Client;
using Damienbod.Slab.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Unity
{
    public class UnityConfiguration
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                    {
                        yield return type;
                    }
                }
            }
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Damienbod")).ToArray();

            container.RegisterType<IHubLogger, HubLogger>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISendHubSync, Service.SendHubSync>(new ContainerControlledLifetimeManager());

            // Hub must be transient see signalr docs
            container.RegisterType<HubSync, HubSync>(new TransientLifetimeManager());
            container.RegisterType<Hub, Hub>(new TransientLifetimeManager());
            container.RegisterType<IHubActivator, UnityHubActivator>(new ContainerControlledLifetimeManager());
        }
    }
}
