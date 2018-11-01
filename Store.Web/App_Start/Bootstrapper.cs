using System;
using System.Reflection;
using Autofac;
using Store.Web.Mappings;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Store.Common;

namespace Store.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(Assembly.GetExecutingAssembly());

                DependencyRegistrar.Instance.Register(builder);

                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}