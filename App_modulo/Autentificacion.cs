﻿using System;
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
    public partial class Autentificacion : Form
    {
        public Autentificacion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (UsuarioDAL.Autentificar(txtUsuario.Text, txtContraseña.Text) > 0)
            {
                Hide();
                Inicio inicio = new Inicio();
                inicio.ShowDialog();
            }
            else
                MessageBox.Show("Error en las credenciales");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}