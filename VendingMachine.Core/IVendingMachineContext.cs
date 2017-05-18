﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core
{
    public interface IVendingMachineContext
    {
        DbSet<Product> Products { get; }
    }
}
