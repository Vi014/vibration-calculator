﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proracun_vibracija
{
    public partial class Forma_Centar_Grafik_1 : Form
    {
        Forma_Centar_Glavni FormaCentarGlavni;

        Graphics g;
        Pen p = new Pen(Color.Black, 2);
        Font font = new Font("Arial", 8);
        SolidBrush cetka = new SolidBrush(Color.Black);

        Stack<Double> RPM_Stek = new Stack<Double>();
        Stack<Double> Frekvencije_Stek = new Stack<Double>();
        Double[] RPM_Niz, Frekvencije_Niz;

        Int32 i, j;
        Int32 brPodeljakaX, brPodeljakaY, podeljakX, podeljakY;
        Int32 centarX, centarY;

        Double pom;
        Double Xmax, Ymax;
        Double X_Razdaljina_Piksel, Y_Razdaljina_Piksel;
        Double konverzijaX, konverzijaY;

        Double y;

        public Forma_Centar_Grafik_1(Forma_Centar_Glavni konstruktor)
        {
            InitializeComponent();
            FormaCentarGlavni = konstruktor;
        }

        public void PromenaJezika()
        {
            this.Text    = FormaCentarGlavni.FormaHomeScreen.jezik[57];
            button1.Text = FormaCentarGlavni.FormaHomeScreen.jezik[58];
            button2.Text = FormaCentarGlavni.FormaHomeScreen.jezik[59];
            label1.Text  = FormaCentarGlavni.FormaHomeScreen.jezik[60];
        }

        private void Forma_Centar_Grafik_1_Load(object sender, EventArgs e)
        {
            PromenaJezika();
            //this.Location = new Point(FormaCentarGlavni.Right, FormaCentarGlavni.Bottom);
            this.Location = new Point(0, 0);

            g = panel1.CreateGraphics();

            centarX = 30;
            centarY = panel1.Height - 30;
        }

        private void Forma_Centar_Grafik_1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormaCentarGlavni.FormaCentarGrafik1 = null;
            FormaCentarGlavni.button2Enabled     = true;
        }

        private void Forma_Centar_Grafik_1_Shown(object sender, EventArgs e)
        {
            Racun();
        }

        public void Racun()
        {
            RPM_Stek.Clear();
            Frekvencije_Stek.Clear();

            if (FormaCentarGlavni.rpm1unet)
            {
                RPM_Stek.Push(FormaCentarGlavni.RPM1);
                if (FormaCentarGlavni.F11 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F11);
                if (FormaCentarGlavni.F12 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F12);
                if (FormaCentarGlavni.F13 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F13);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM1);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM12);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM13);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM14);
                Frekvencije_Stek.Push(FormaCentarGlavni.FB1);
                Frekvencije_Stek.Push(FormaCentarGlavni.FP1);
            }
            if (FormaCentarGlavni.rpm2unet)
            {
                RPM_Stek.Push(FormaCentarGlavni.RPM2);
                if (FormaCentarGlavni.F21 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F21);
                if (FormaCentarGlavni.F22 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F22);
                if (FormaCentarGlavni.F23 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F23);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM2);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM22);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM23);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM24);
                Frekvencije_Stek.Push(FormaCentarGlavni.FB2);
                Frekvencije_Stek.Push(FormaCentarGlavni.FP2);
            }
            if (FormaCentarGlavni.rpm3unet)
            {
                RPM_Stek.Push(FormaCentarGlavni.RPM3);
                if (FormaCentarGlavni.F31 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F31);
                if (FormaCentarGlavni.F32 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F32);
                if (FormaCentarGlavni.F33 != 0) Frekvencije_Stek.Push(FormaCentarGlavni.F33);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM3);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM32);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM33);
                Frekvencije_Stek.Push(FormaCentarGlavni.FM34);
                Frekvencije_Stek.Push(FormaCentarGlavni.FB3);
                Frekvencije_Stek.Push(FormaCentarGlavni.FP3);
            }

            RPM_Niz         = RPM_Stek.ToArray();
            Frekvencije_Niz = Frekvencije_Stek.ToArray();

            #region sortiraj RPM_Niz
            for (i = 0; i < RPM_Niz.Length - 1; i++)
            {
                for (j = i + 1; j < RPM_Niz.Length; j++)
                {
                    if (RPM_Niz[i] > RPM_Niz[j])
                    {
                        pom = RPM_Niz[i];
                        RPM_Niz[i] = RPM_Niz[j];
                        RPM_Niz[j] = pom;
                    }
                }
            }
            #endregion

            #region sortiraj Frekvencije_Niz
            for (i = 0; i < Frekvencije_Niz.Length - 1; i++)
            {
                for (j = i + 1; j < Frekvencije_Niz.Length; j++)
                {
                    if (Frekvencije_Niz[i] > Frekvencije_Niz[j])
                    {
                        pom = Frekvencije_Niz[i];
                        Frekvencije_Niz[i] = Frekvencije_Niz[j];
                        Frekvencije_Niz[j] = pom;
                    }
                }
            }
            #endregion

            Xmax = RPM_Niz[RPM_Niz.Length - 1];
            Ymax = Frekvencije_Niz[Frekvencije_Niz.Length - 1];

            X_Razdaljina_Piksel = panel1.Width - centarX;
            Y_Razdaljina_Piksel = centarY;

            konverzijaX = (Double)X_Razdaljina_Piksel / Xmax;
            konverzijaY = (Double)Y_Razdaljina_Piksel / Ymax;

            brPodeljakaX = Convert.ToInt32(Xmax / 100);
            brPodeljakaY = Convert.ToInt32(Ymax / 10);

            podeljakX = Convert.ToInt32(X_Razdaljina_Piksel) / brPodeljakaX;
            podeljakY = Convert.ToInt32(Y_Razdaljina_Piksel) / brPodeljakaY;

            IscrtajGrafik();
        }

        private void IscrtajGrafik()
        {
            g.Clear(Color.White);

            g.DrawLine(p, 0, centarY, panel1.Width, centarY);  // iscrtaj x-osu
            g.DrawLine(p, centarX, 0, centarX, panel1.Height); // iscrtaj y-osu

            // iscrtaj strelicu na y-osi
            g.DrawLine(p, panel1.Width, centarY, panel1.Width - 5, centarY - 5);
            g.DrawLine(p, panel1.Width, centarY, panel1.Width - 5, centarY + 5);
            g.DrawString("X", font, cetka, panel1.Width - 12, panel1.Height - 40);

            // iscrtaj strelicu na y-osi
            g.DrawLine(p, centarX, 0, centarX - 5, 5);
            g.DrawLine(p, centarX, 0, centarX + 5, 5);
            g.DrawString("Y", font, cetka, centarX + 6, 0);

            // x-brojaci
            j = 100;
            for (i = centarX + podeljakX; i < panel1.Width; i += podeljakX)
            {
                g.DrawLine(p, i, centarY - 5, i, centarY + 5);
                g.DrawString(j.ToString(), font, cetka, i - 15, centarY + 7);
                j += 100;
            }

            // y-brojaci
            j = 10;
            for (i = centarY - podeljakY; i > 0; i -= podeljakY)
            {
                g.DrawLine(p, centarX - 5, i, centarX + 5, i);
                g.DrawString(j.ToString(), font, cetka, 0, i - 7);
                j += 10;
            }

            if (FormaCentarGlavni.rpm1unet)
            {
                if (FormaCentarGlavni.F11 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM1 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F11 * konverzijaY) - 6));
                if (FormaCentarGlavni.F12 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM1 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F12 * konverzijaY) - 6));
                if (FormaCentarGlavni.F13 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM1 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F13 * konverzijaY) - 6));
            }

            if (FormaCentarGlavni.rpm2unet)
            {
                if (FormaCentarGlavni.F21 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM2 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F21 * konverzijaY) - 6));
                if (FormaCentarGlavni.F22 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM2 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F22 * konverzijaY) - 6));
                if (FormaCentarGlavni.F23 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM2 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F23 * konverzijaY) - 6));
            }

            if (FormaCentarGlavni.rpm3unet)
            {
                if (FormaCentarGlavni.F31 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM3 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F31 * konverzijaY) - 6));
                if (FormaCentarGlavni.F32 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM3 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F32 * konverzijaY) - 6));
                if (FormaCentarGlavni.F33 != 0) g.DrawString("X", font, cetka, (centarX + Convert.ToInt32(FormaCentarGlavni.RPM3 * konverzijaX) - 10), (centarY - Convert.ToInt32(FormaCentarGlavni.F33 * konverzijaY) - 6));
            }



            if (checkBox_L1.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FM1;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FM2;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FM3;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }

            if (checkBox_L2.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FM12;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FM22;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FM32;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }

            if (checkBox_L3.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FM13;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FM23;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FM33;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }

            if (checkBox_L4.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FM14;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FM24;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FM34;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }

            if (checkBox_L5.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FB1;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FB2;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FB3;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }

            if (checkBox_L6.Checked)
            {
                if      (Xmax == FormaCentarGlavni.RPM1) y = FormaCentarGlavni.FP1;
                else if (Xmax == FormaCentarGlavni.RPM2) y = FormaCentarGlavni.FP2;
                else if (Xmax == FormaCentarGlavni.RPM3) y = FormaCentarGlavni.FP3;

                g.DrawLine(p, centarX, centarY, (centarX + Convert.ToInt32(Xmax * konverzijaX)), (centarY - Convert.ToInt32(y * konverzijaY)));
            }
        }

        private void PozoviIscrtajGrafik(object sender, EventArgs e)
        {
            IscrtajGrafik();
        }

        private void button_FM_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F23 + 1)))))) ||

                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FM1 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM1 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM2 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM2 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM3 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM3 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[61]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[62]);
        }

        private void button_FM2_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F23 + 1)))))) ||
                                                                                    
                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FM12 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM12 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM22 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM22 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM32 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM32 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[63]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[64]);
        }

        private void button_FM3_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F23 + 1)))))) ||

                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FM13 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM13 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM23 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM23 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM33 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM33 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[65]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[66]);
        }

        private void button_FM4_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F23 + 1)))))) ||

                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FM14 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM14 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM24 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM24 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FM34 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FM34 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[67]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[68]);
        }

        private void button_FB_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F23 + 1)))))) ||

                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FB1 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FB1 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FB2 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FB2 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FB3 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FB3 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[69]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[70]);
        }

        private void button_FP_Click(object sender, EventArgs e)
        {
            if     ((FormaCentarGlavni.rpm1unet && ((FormaCentarGlavni.F11 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F11 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F11 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F11 + 1)))) ||
                                                    (FormaCentarGlavni.F12 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F12 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F12 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F12 + 1)))) ||
                                                    (FormaCentarGlavni.F13 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F13 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F13 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F13 + 1)))))) ||

                    (FormaCentarGlavni.rpm2unet && ((FormaCentarGlavni.F21 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F21 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F21 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F21 + 1)))) ||
                                                    (FormaCentarGlavni.F22 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F22 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F22 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F22 + 1)))) ||
                                                    (FormaCentarGlavni.F23 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F23 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F23 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F23 + 1)))))) ||

                    (FormaCentarGlavni.rpm3unet && ((FormaCentarGlavni.F31 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F31 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F31 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F31 + 1)))) ||
                                                    (FormaCentarGlavni.F32 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F32 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F32 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F32 + 1)))) ||
                                                    (FormaCentarGlavni.F33 != 0 && ((FormaCentarGlavni.FP1 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FP1 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FP2 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FP2 <= (FormaCentarGlavni.F33 + 1)) ||
                                                                                    (FormaCentarGlavni.FP3 >= (FormaCentarGlavni.F33 - 1) && FormaCentarGlavni.FP3 <= (FormaCentarGlavni.F33 + 1)))))))
                 MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[71]);
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.jezik[72]);
        }
    }
}
