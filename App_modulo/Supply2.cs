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
    public partial class Supply2 : Form
    {
        public Supply2()
        {
            InitializeComponent();
        }

        public Suministro2 SuministroActual2 { get; set; }



        void limpiar()
        {
            txtEquipo.Clear();
            txtTransporte.Clear();
            txtInstalacion.Clear();
            txtConfigura.Clear();
            txtMantenimiento.Clear();
        }

        private void Supply2_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }



        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarSupply2 sBuscar2 = new BuscarSupply2();
            sBuscar2.ShowDialog();

            if (sBuscar2.SuministroSeleccionado2 != null)
            {
                SuministroActual2 = sBuscar2.SuministroSeleccionado2;
                txtEquipo.Text = sBuscar2.SuministroSeleccionado2.EQUIPO;
                txtTransporte.Text = sBuscar2.SuministroSeleccionado2.TRANSPORTE;
                txtInstalacion.Text = sBuscar2.SuministroSeleccionado2.INSTALACION;
                txtConfigura.Text = sBuscar2.SuministroSeleccionado2.CONFIGURACION;
                txtMantenimiento.Text = sBuscar2.SuministroSeleccionado2.MANTENIMIENTO;

                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEquipo.Text) &&
               string.IsNullOrWhiteSpace(txtTransporte.Text) &&
               string.IsNullOrWhiteSpace(txtInstalacion.Text) &&
               string.IsNullOrWhiteSpace(txtConfigura.Text) &&
               string.IsNullOrWhiteSpace(txtMantenimiento.Text))
            {
                MessageBox.Show("No se puede guardar. Por favor, asegúrate de que al menos un campo esté lleno.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Suministro2 Suministro2 = new Suministro2
            {
                EQUIPO = txtEquipo.Text,
                TRANSPORTE = txtTransporte.Text,
                INSTALACION = txtInstalacion.Text,
                CONFIGURACION = txtConfigura.Text,
                MANTENIMIENTO = txtMantenimiento.Text,
            };

            int resultado = SuministroDAL2.Agregar(Suministro2);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro Que Quieres Eliminar Este Producto??", "Estas Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int resultado = SuministroDAL2.Eliminar((int)SuministroActual2.ID);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Suministro2 sSuministro2 = new Suministro2();
            {
                sSuministro2.EQUIPO = txtEquipo.Text;
                sSuministro2.TRANSPORTE = txtTransporte.Text;
                sSuministro2.INSTALACION = txtInstalacion.Text;
                sSuministro2.CONFIGURACION = txtConfigura.Text;
                sSuministro2.MANTENIMIENTO = txtMantenimiento.Text;
                sSuministro2.ID = SuministroActual2.ID;
            };

            // Comprueba si2 los valores han cambiado
            if (sSuministro2.EQUIPO == SuministroActual2.EQUIPO &&
                sSuministro2.TRANSPORTE == SuministroActual2.TRANSPORTE &&
                sSuministro2.INSTALACION == SuministroActual2.INSTALACION &&
                sSuministro2.CONFIGURACION == SuministroActual2.CONFIGURACION &&
                sSuministro2.MANTENIMIENTO == SuministroActual2.MANTENIMIENTO)
            {
                MessageBox.Show("Debes realizar cambios antes de poder modificar.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int resultado = SuministroDAL2.Modicar(sSuministro2);

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
    }
}
