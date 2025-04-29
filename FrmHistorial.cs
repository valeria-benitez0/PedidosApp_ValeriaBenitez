using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            cmbFiltroTipoEntrega.Items.Add("Todos");
            cmbFiltroTipoEntrega.Items.Add("Dron");
            cmbFiltroTipoEntrega.Items.Add("Motocicleta");
            cmbFiltroTipoEntrega.Items.Add("Camión");
            cmbFiltroTipoEntrega.Items.Add("Bicicleta");
            cmbFiltroTipoEntrega.SelectedIndex = 0;

            CargarPedidos("Todos");
        }

        private void CargarPedidos(string filtro)
        {
            dgvPedidos.Rows.Clear();
            dgvPedidos.Columns.Clear();

            dgvPedidos.Columns.Add("cliente", "Cliente");
            dgvPedidos.Columns.Add("producto", "Producto");
            dgvPedidos.Columns.Add("urgente", "Urgente");
            dgvPedidos.Columns.Add("peso", "Peso (kg)");
            dgvPedidos.Columns.Add("distancia", "Distancia (km)");
            dgvPedidos.Columns.Add("entrega", "Tipo Entrega");
            dgvPedidos.Columns.Add("costo", "Costo ($)");

            var pedidos = RegistroPedidos.Instancia.Pedidos;

            foreach (var p in pedidos)
            {
                string tipoEntrega = p.MetodoEntrega.TipoEntrega();

                if (filtro == "Todos" || tipoEntrega.Equals(filtro, StringComparison.OrdinalIgnoreCase))
                {
                    dgvPedidos.Rows.Add(
                        p.Cliente,
                        p.Producto,
                        p.Urgente ? "Sí" : "No",
                        p.Peso,
                        p.Distancia,
                        tipoEntrega,
                        p.ObtenerCosto().ToString("0.00")
                    );
                }
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtroSeleccionado = cmbFiltroTipoEntrega.SelectedItem?.ToString() ?? "Todos";
            CargarPedidos(filtroSeleccionado);

            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
        }
    }
}
