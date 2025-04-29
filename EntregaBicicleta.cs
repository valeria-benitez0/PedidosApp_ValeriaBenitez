using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public class EntregaBicicleta : IMetodoEntrega
    {
        public double CalcularCosto(int km)
        {
            return 3 * km;
        }

        public string TipoEntrega()
        {
            return "Bicicleta";
        }
    }
}
