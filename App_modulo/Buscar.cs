using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_modulo
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }


        public Cliente ClienteSeleccionado { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ClienteDAL.BuscarCliente(textContacto.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                ClienteSeleccionado = ClienteDAL.ObtenerCliente(ID);
                Close();
            }
            else
            {
                MessageBox.Show("No se puede seguir con el proceso. Por favor, asegúrate de que hayas seleccionado un contacto.", "Error de Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
