using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core;
using VendingMachine.Core.Coins;

namespace VendingMachine.Infrastructure
{
    public static class DIConfig
    {
        public static ContainerBuilder ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CoinService>().As<ICoinService>();

            return builder;
        }
    }
}
