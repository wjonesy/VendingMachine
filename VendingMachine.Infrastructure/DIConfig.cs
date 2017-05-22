using Autofac;
using VendingMachine.Core.Coins;
using VendingMachine.Core.Products;
using VendingMachine.Core.State;

namespace VendingMachine.Infrastructure
{
    public static class DIConfig
    {
        public static ContainerBuilder ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CoinService>().As<ICoinService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<VendingMachineStateManager>().As<IVendingMachineStateManager>().InstancePerRequest();

            return builder;
        }
    }
}
