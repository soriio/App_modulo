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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        public Salario SalarioActual { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOcupacion.Text) &&
                string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MessageBox.Show("No se puede guardar. Por favor, asegúrate de que al menos un campo esté lleno.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Salario Salario = new Salario();
            {
                Salario.OCUPACION = txtOcupacion.Text;
                Salario.VALORDIA = txtSalario.Text;
            };

            int resultado = SalarioDAL.Agregar(Salario);
            if (resultado > 0)
            {
                MessageBox.Show("Guardado Correctamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("No Guardado", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarSalario vBuscar = new BuscarSalario();
            vBuscar.ShowDialog();
            if (vBuscar.SalarioSeleccionado != null)
            {
                SalarioActual = vBuscar.SalarioSeleccionado;
                txtOcupacion.Text = vBuscar.SalarioSeleccionado.OCUPACION;
                txtSalario.Text = vBuscar.SalarioSeleccionado.VALORDIA;

                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Salario vSalario = new Salario();
            {
                vSalario.OCUPACION = txtOcupacion.Text;
                vSalario.VALORDIA = txtSalario.Text;
                vSalario.ID = SalarioActual.ID;
            };
            int resultado = SalarioDAL.Modificar(vSalario);

            if (resultado > 0)
            {
                MessageBox.Show("Suministro Editado Correctamente!",
                 "Suministro Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Se Pudo Editar El Suministro", "Ocurrio un Error");
            }

        }

        void limpiar()
        {
            txtOcupacion.Clear();
            txtSalario.Clear();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro Que Quieres Eliminar Este Producto??", "Estas Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                int resultado = SalarioDAL.Eliminar((int)SalarioActual.ID);

                if (resultado > 0)
                {
                    MessageBox.Show("Eliminado Correctamente", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();

                    btnEliminar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No Se Pudo Eliminar", "Algo Esta Mal!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se Cancelo La Eliminacion", "Cancelado");
        }
    }
}
