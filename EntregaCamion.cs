﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public class EntregaCamion : IMetodoEntrega
    {
        public double CalcularCosto(int km)
        {
            return 5 * km;
        }

        public string TipoEntrega()
        {
            return "Camión";
        }
    }
}
