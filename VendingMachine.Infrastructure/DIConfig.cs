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
            builder.RegisterType<CoinService>().As<ICoinService>().SingleInstance();
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<VendingMachineStateManager>().As<IVendingMachineStateManager>().SingleInstance();

            return builder;
        }
    }
}
