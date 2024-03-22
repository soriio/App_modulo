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
    public partial class Supply : Form
    {
        public Supply()
        {
            InitializeComponent();
        }

        public Suministro SuministroActual { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEquipo.Text) &&
                string.IsNullOrWhiteSpace(txtTransporte.Text) &&
                string.IsNullOrWhiteSpace(txtInstalacion.Text) &&
                string.IsNullOrWhiteSpace(txtConfigura.Text))
            {
                MessageBox.Show("No se puede guardar. Por favor, asegúrate de que al menos un campo esté lleno.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Suministro Suministro = new Suministro
            {
                EQUIPO = txtEquipo.Text,
                TRANSPORTE = txtTransporte.Text,
                INSTALACION = txtInstalacion.Text,
                CONFIGURACION = txtConfigura.Text,
            };

            int resultado = SuministroDAL.Agregar(Suministro);
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
            BuscarSupply sBuscar = new BuscarSupply();
            sBuscar.ShowDialog();

            if (sBuscar.SuministroSeleccionado != null)
            {
                SuministroActual = sBuscar.SuministroSeleccionado;
                txtEquipo.Text = sBuscar.SuministroSeleccionado.EQUIPO;
                txtTransporte.Text = sBuscar.SuministroSeleccionado.TRANSPORTE;
                txtInstalacion.Text = sBuscar.SuministroSeleccionado.INSTALACION;
                txtConfigura.Text = sBuscar.SuministroSeleccionado.CONFIGURACION;

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
            Suministro sSuministro = new Suministro();
            {
                sSuministro.EQUIPO = txtEquipo.Text;
                sSuministro.TRANSPORTE = txtTransporte.Text;
                sSuministro.INSTALACION = txtInstalacion.Text;
                sSuministro.CONFIGURACION = txtConfigura.Text;
                sSuministro.ID = SuministroActual.ID;
            };
            int resultado = SuministroDAL.Modicar(sSuministro);

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
            txtEquipo.Clear();
            txtTransporte.Clear();
            txtInstalacion.Clear();
            txtConfigura.Clear();
        }

        private void Supply_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false ;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro Que Quieres Eliminar Este Producto??", "Estas Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                int resultado = SuministroDAL.Eliminar((int)SuministroActual.ID);

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
