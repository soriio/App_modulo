﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace App_modulo
{
    public partial class Inicio : Form
    {      
        public Inicio()
        {
            InitializeComponent();     
            customizeDesing();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            button1.Visible = false;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Visible = true;
            button1.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }


        int lx, ly;
        int sw, sh;
        private void button3_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            button3.Visible = false;
            button1.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void customizeDesing()
        {
            panelSubMenu.Visible = false;  
            panelSubMenuMas.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubMenu.Visible == true)
                panelSubMenu.Visible = false;

            if (panelSubMenuMas.Visible == true)
                panelSubMenuMas.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnHerramientas_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu);
        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();

            openHijoForm(new Form1());
        }

        private void btnSumini_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();

            openHijoForm(new Supply());
        }

        private void btnSalario_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();

            openHijoForm(new Salary());
        }

        private Form activeForm = null;
        private void openHijoForm(Form hijoForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = hijoForm;
            hijoForm.TopLevel = false;
            hijoForm.FormBorderStyle = FormBorderStyle.None;
            hijoForm.Dock = DockStyle.Fill;
            panelHijo.Controls.Add(hijoForm);
            panelHijo.Tag = hijoForm;
            hijoForm.BringToFront();
            hijoForm.Show();


        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuMas);
        }

        private void btnDocumentacion_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openHijoForm(new Documentacion());
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openHijoForm(new Registro_Usuarios());
        }



        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
           
        }


        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

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
