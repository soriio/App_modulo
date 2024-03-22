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
    public partial class Registro_Usuarios : Form
    {
        public Registro_Usuarios()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("No se puede crear el usuario. Por favor, asegúrate de que los campos de usuario y contraseña estén llenos.", "Error al Crear", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (txtContraseña.Text == txtContraseña.Text)
            {
                if (UsuarioDAL.CrearCuentas(txtUsuario.Text, txtContraseña.Text) > 0)
                {
                    MessageBox.Show("Usuario Creado Con Exito!");

                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    txtConfirmar.Text = "";
                }
                else
                    MessageBox.Show("No Se Pudo Crear El Usuario");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
