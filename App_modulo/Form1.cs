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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Cliente ClienteActual { get; set; }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtContacto.Text) &&
                string.IsNullOrWhiteSpace(txtCliente.Text) &&
                string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                string.IsNullOrWhiteSpace(txtCelular.Text) &&
                string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                string.IsNullOrWhiteSpace(txtCargo.Text) &&
                string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                string.IsNullOrWhiteSpace(txtNit.Text) &&
                string.IsNullOrWhiteSpace(txtCiudad.Text) &&
                string.IsNullOrWhiteSpace(txtVendedor.Text))
            {
                MessageBox.Show("No se puede guardar. Por favor, asegúrate de que al menos un campo esté lleno.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Cliente Cliente = new Cliente
            {
                CONTACTO = txtContacto.Text,
                CLIENTE = txtCliente.Text,
                TELEFONO = txtTelefono.Text,
                CELULAR = txtCelular.Text,
                CORREO = txtCorreo.Text,
                CARGO = txtCargo.Text,
                DIRECCION = txtDireccion.Text,
                NIT = txtNit.Text,
                CUIDAD = txtCiudad.Text,
                VENDEDOR = txtVendedor.Text
            };


            int resultado = ClienteDAL.Agregar(Cliente);
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
            Buscar pBuscar = new Buscar();
            pBuscar.ShowDialog();

            if (pBuscar.ClienteSeleccionado != null)
            {
                ClienteActual = pBuscar.ClienteSeleccionado;
                txtContacto.Text = pBuscar.ClienteSeleccionado.CONTACTO;
                txtCliente.Text = pBuscar.ClienteSeleccionado.CLIENTE;
                txtTelefono.Text = pBuscar.ClienteSeleccionado.TELEFONO;
                txtCelular.Text = pBuscar.ClienteSeleccionado.CELULAR;
                txtCorreo.Text = pBuscar.ClienteSeleccionado.CORREO;
                txtCargo.Text = pBuscar.ClienteSeleccionado.CARGO;
                txtDireccion.Text = pBuscar.ClienteSeleccionado.DIRECCION;
                txtNit.Text = pBuscar.ClienteSeleccionado.NIT;
                txtCiudad.Text = pBuscar.ClienteSeleccionado.CUIDAD;
                txtVendedor.Text = pBuscar.ClienteSeleccionado.VENDEDOR;

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnEleminar.Enabled = true;

            }


        }

        private void bntCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Cliente pCliente = new Cliente
            {
                CONTACTO = txtContacto.Text,
                CLIENTE = txtCliente.Text,
                TELEFONO = txtTelefono.Text,
                CELULAR = txtCelular.Text,
                CORREO = txtCorreo.Text,
                CARGO = txtCargo.Text,
                DIRECCION = txtDireccion.Text,
                NIT = txtNit.Text,
                CUIDAD = txtCiudad.Text,
                VENDEDOR = txtVendedor.Text,
                ID = ClienteActual.ID,

            };
            int resultado = ClienteDAL.Modificar(pCliente);

                
            if (resultado > 0)
            {
                MessageBox.Show("Contacto Editado Correctamente!",
                    "Contacto Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                btnEleminar.Enabled = false;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            }

            else
            {
                MessageBox.Show("No Se Pudo Editar El Contacto", "Ocurrio un Error");
            }        

        }

        void limpiar()
        { 
            txtContacto.Clear();
            txtCliente.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
            txtCargo.Clear();
            txtDireccion.Clear();
            txtNit.Clear();
            txtCiudad.Clear();
            txtVendedor.Clear();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEleminar.Enabled = false;
        }

        private void btnEleminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro Que Quieres Eliminar Este Contacto??", "Estas Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                int resultado = ClienteDAL.Eliminar((int)ClienteActual.ID);

                if (resultado > 0)
                {
                    MessageBox.Show("Eliminado Correctamente", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();

                    btnEleminar.Enabled = false;
                    btnModificar.Enabled = false;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Registro_Usuarios re = new Registro_Usuarios(); 
            re.Show();

        }
    }
}
