﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public class EntregaDron : IMetodoEntrega
    {
        public double CalcularCosto(int km)
        {
            return 20 * km;
        }

        public string TipoEntrega()
        {
            return "Dron";
        }
    }
}
