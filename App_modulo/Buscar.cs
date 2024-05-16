using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            btnRestaurar.Visible = false;
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

         ////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        } 

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);







    }
}
