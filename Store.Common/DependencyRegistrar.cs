using Autofac;
using Store.DAL;
using Store.Service;

namespace Store.Common
{
    public class DependencyRegistrar
    {
        private static DependencyRegistrar instance;

        public static DependencyRegistrar Instance
        {
            get { return instance ?? (instance = new DependencyRegistrar()); }
        }

        public ContainerBuilder Register(ContainerBuilder builder)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            builder.Register<IDbContext>(c => new StoreEntities()).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<GadgetService>().As<IGadgetService>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
