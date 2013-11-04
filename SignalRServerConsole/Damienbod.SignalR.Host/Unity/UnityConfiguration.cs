using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damienbod.SignalR.MyHub;
using Damienbod.Slab;
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
            // Add your register logic here...
            var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Damienbod")).ToArray();

            container.RegisterType<ISlabLogger, HubLogger>();
            container.RegisterType<IMyHub, Service.MyHub>();

            //container.RegisterType(typeof(Startup));

            //container.RegisterTypes(
            //     UnityHelpers.GetTypesWithCustomAttribute<LifecycleSingletonAttribute>(myAssemblies),
            //     WithMappings.FromMatchingInterface,
            //     WithName.Default,
            //     WithLifetime.ContainerControlled,
            //     null
            //    ).RegisterTypes(
            //            UnityHelpers.GetTypesWithCustomAttribute<LifecycleTransientAttribute>(myAssemblies),
            //            WithMappings.FromMatchingInterface,
            //            WithName.Default,
            //            WithLifetime.Transient);

        }
    }
}
