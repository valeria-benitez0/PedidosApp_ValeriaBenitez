using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public static class EntregaFactory
    {
        public static IMetodoEntrega CrearEntrega(string tipoProducto, bool urgente, double peso)
        {
            if (peso > 10)
                return new EntregaCamion();

            if (tipoProducto == "Accesorio" && peso < 2 && !urgente)
                return new EntregaBicicleta();
            if (tipoProducto == "Tecnología" && urgente)
                return new EntregaDron();
            if (tipoProducto == "Accesorio")
                return new EntregaMoto();
            if (tipoProducto == "Componente" || peso > 10)
                return new EntregaCamion();
           
                return new EntregaMoto(); 
        }
    }
}
