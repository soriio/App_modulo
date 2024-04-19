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
    public partial class Inicio : Form
    {      
        public Inicio()
        {
            InitializeComponent();          
        }

        private void btnAgrec_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdminSuminis_Click(object sender, EventArgs e)
        {
                Supply supply = new Supply();
                supply.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.ShowDialog();
        }
    }
}
