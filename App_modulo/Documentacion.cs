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
    public partial class Documentacion : Form
    {
        public Documentacion()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/soriio/App_modulo";
            System.Diagnostics.Process.Start(url);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://charm-traffic-8fc.notion.site/Descripci-n-T-cnica-del-Software_-AppModulo-7465ac4d1be14b1192d2ca98060d17c3?pvs=4";
            System.Diagnostics.Process.Start(url);
        }
    }
}
