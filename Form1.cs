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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            cmbProducto.Items.Add("Tecnología");
            cmbProducto.Items.Add("Accesorio");
            cmbProducto.Items.Add("Componente");
            cmbProducto.SelectedIndex = 0; // Dejar uno seleccionado por defecto
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCliente.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProducto.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cliente = txtCliente.Text.Trim();
                string producto = cmbProducto.SelectedItem.ToString();
                bool urgente = chkUrgente.Checked;
                double peso = Convert.ToDouble(nudPeso.Value);
                int distancia = Convert.ToInt32(nudDistancia.Value);

                Pedido pedido = new Pedido(cliente, producto, urgente, peso, distancia);
                RegistroPedidos.Instancia.AgregarPedido(pedido);

                lblResultado.Text = $"Cliente: {pedido.Cliente}\n" +
                    $"Entrega asignada: {pedido.MetodoEntrega.TipoEntrega()}\n" +
                    $"Costo de envío: ${pedido.ObtenerCosto():0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
