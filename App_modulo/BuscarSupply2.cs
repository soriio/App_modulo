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
    public partial class BuscarSupply2 : Form
    {
        public BuscarSupply2()
        {
            InitializeComponent();
        }

        public Suministro2 SuministroSeleccionado2 { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                SuministroSeleccionado2 = SuministroDAL2.ObtenerSuministro2(ID);
                Close();
            }
            else
            {
                MessageBox.Show("No se puede seguir con el proceso. Por favor, asegúrate de que hayas seleccionado un elemento.", "Error de Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SuministroDAL2.BuscarSuministro2(textEquipo.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
