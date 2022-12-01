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
    public partial class Forma_Desni_Glavni : Form
    {
        public Forma_HomeScreen FormaHomeScreen;

        public Forma_Desni_Glavni(Forma_HomeScreen konstruktor)
        {
            InitializeComponent();
            FormaHomeScreen = konstruktor;
        }

        public void PromenaJezika()
        {
            this.Text                      = FormaHomeScreen.jezik[112];
            label_Upozorenje.Text          = FormaHomeScreen.jezik[113];
            label_DimenzijePneumatika.Text = FormaHomeScreen.jezik[114];
            label_Sirina.Text              = FormaHomeScreen.jezik[115];
            label_Visina.Text              = FormaHomeScreen.jezik[116];
            label_PrecnikFelne.Text        = FormaHomeScreen.jezik[117];
            label_POD.Text                 = FormaHomeScreen.jezik[118];
            label_mm.Text                  = FormaHomeScreen.jezik[119];
            label_Posto.Text               = FormaHomeScreen.jezik[120];
            label_Inches.Text              = FormaHomeScreen.jezik[121];
            label_IzmereneVrednosti.Text   = FormaHomeScreen.jezik[122];
            label_BrzinaVozila.Text        = FormaHomeScreen.jezik[123];
            label_Frekvencija.Text         = FormaHomeScreen.jezik[124];
            button_Racun.Text              = FormaHomeScreen.jezik[125];
        }

        private void Forma_Desni_Glavni_Load(object sender, EventArgs e)
        {
            PromenaJezika();
            this.Location = new Point(FormaHomeScreen.Left + 20, FormaHomeScreen.Top + 20);

            textBox_W_Watermark();
            textBox_H_Watermark();
            textBox_R_Watermark();
            textBox_I_Watermark();

            textBox_V1_Watermark();
            textBox_V2_Watermark();
            textBox_V3_Watermark();

            textBox_F11_Watermark();
            textBox_F12_Watermark();
            textBox_F13_Watermark();

            textBox_F21_Watermark();
            textBox_F22_Watermark();
            textBox_F23_Watermark();

            textBox_F31_Watermark();
            textBox_F32_Watermark();
            textBox_F33_Watermark();
        }

        private void Forma_Desni_Glavni_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormaHomeScreen.FormaDesniGlavni  = null;
            FormaHomeScreen.dugmeDesnoEnabled = true;
        }

        #region text box sranja

        private void textBox_W_Enter(object sender, EventArgs e)
        {
            if (textBox_W.ForeColor == Color.Black)
                return;
            textBox_W.Text = "";
            textBox_W.ForeColor = Color.Black;
        }

        private void textBox_W_Leave(object sender, EventArgs e)
        {
            if (textBox_W.Text.Trim() == "") textBox_W_Watermark();
        }

        private void textBox_W_Watermark()
        {
            this.textBox_W.Text = "W";
            textBox_W.ForeColor = Color.Gray;
        }



        private void textBox_H_Enter(object sender, EventArgs e)
        {
            if (textBox_H.ForeColor == Color.Black)
                return;
            textBox_H.Text = "";
            textBox_H.ForeColor = Color.Black;
        }

        private void textBox_H_Leave(object sender, EventArgs e)
        {
            if (textBox_H.Text.Trim() == "") textBox_H_Watermark();
        }

        private void textBox_H_Watermark()
        {
            this.textBox_H.Text = "H";
            textBox_H.ForeColor = Color.Gray;
        }



        private void textBox_R_Enter(object sender, EventArgs e)
        {
            if (textBox_R.ForeColor == Color.Black)
                return;
            textBox_R.Text = "";
            textBox_R.ForeColor = Color.Black;
        }

        private void textBox_R_Leave(object sender, EventArgs e)
        {
            if (textBox_R.Text.Trim() == "") textBox_R_Watermark();
        }

        private void textBox_R_Watermark()
        {
            this.textBox_R.Text = "R";
            textBox_R.ForeColor = Color.Gray;
        }



        private void textBox_I_Enter(object sender, EventArgs e)
        {
            if (textBox_I.ForeColor == Color.Black)
                return;
            textBox_I.Text = "";
            textBox_I.ForeColor = Color.Black;
        }

        private void textBox_I_Leave(object sender, EventArgs e)
        {
            if (textBox_I.Text.Trim() == "") textBox_I_Watermark();
        }

        private void textBox_I_Watermark()
        {
            this.textBox_I.Text = "I";
            textBox_I.ForeColor = Color.Gray;
        }



        private void textBox_V1_Enter(object sender, EventArgs e)
        {
            if (textBox_V1.ForeColor == Color.Black)
                return;
            textBox_V1.Text = "";
            textBox_V1.ForeColor = Color.Black;
        }

        private void textBox_V1_Leave(object sender, EventArgs e)
        {
            if (textBox_V1.Text.Trim() == "") textBox_V1_Watermark();
        }

        private void textBox_V1_Watermark()
        {
            this.textBox_V1.Text = "V1";
            textBox_V1.ForeColor = Color.Gray;
        }



        private void textBox_V2_Enter(object sender, EventArgs e)
        {
            if (textBox_V2.ForeColor == Color.Black)
                return;
            textBox_V2.Text = "";
            textBox_V2.ForeColor = Color.Black;
        }

        private void textBox_V2_Leave(object sender, EventArgs e)
        {
            if (textBox_V2.Text.Trim() == "") textBox_V2_Watermark();
        }

        private void textBox_V2_Watermark()
        {
            this.textBox_V2.Text = "V2";
            textBox_V2.ForeColor = Color.Gray;
        }



        private void textBox_V3_Enter(object sender, EventArgs e)
        {
            if (textBox_V3.ForeColor == Color.Black)
                return;
            textBox_V3.Text = "";
            textBox_V3.ForeColor = Color.Black;
        }

        private void textBox_V3_Leave(object sender, EventArgs e)
        {
            if (textBox_V3.Text.Trim() == "") textBox_V3_Watermark();
        }

        private void textBox_V3_Watermark()
        {
            this.textBox_V3.Text = "V3";
            textBox_V3.ForeColor = Color.Gray;
        }



        private void textBox_F11_Enter(object sender, EventArgs e)
        {
            if (textBox_F11.ForeColor == Color.Black)
                return;
            textBox_F11.Text = "";
            textBox_F11.ForeColor = Color.Black;
        }

        private void textBox_F11_Leave(object sender, EventArgs e)
        {
            if (textBox_F11.Text.Trim() == "") textBox_F11_Watermark();
        }

        private void textBox_F11_Watermark()
        {
            this.textBox_F11.Text = "F11";
            textBox_F11.ForeColor = Color.Gray;
        }



        private void textBox_F12_Enter(object sender, EventArgs e)
        {
            if (textBox_F12.ForeColor == Color.Black)
                return;
            textBox_F12.Text = "";
            textBox_F12.ForeColor = Color.Black;
        }

        private void textBox_F12_Leave(object sender, EventArgs e)
        {
            if (textBox_F12.Text.Trim() == "") textBox_F12_Watermark();
        }

        private void textBox_F12_Watermark()
        {
            this.textBox_F12.Text = "F12";
            textBox_F12.ForeColor = Color.Gray;
        }



        private void textBox_F13_Enter(object sender, EventArgs e)
        {
            if (textBox_F13.ForeColor == Color.Black)
                return;
            textBox_F13.Text = "";
            textBox_F13.ForeColor = Color.Black;
        }

        private void textBox_F13_Leave(object sender, EventArgs e)
        {
            if (textBox_F13.Text.Trim() == "") textBox_F13_Watermark();
        }

        private void textBox_F13_Watermark()
        {
            this.textBox_F13.Text = "F13";
            textBox_F13.ForeColor = Color.Gray;
        }



        private void textBox_F21_Enter(object sender, EventArgs e)
        {
            if (textBox_F21.ForeColor == Color.Black)
                return;
            textBox_F21.Text = "";
            textBox_F21.ForeColor = Color.Black;
        }

        private void textBox_F21_Leave(object sender, EventArgs e)
        {
            if (textBox_F21.Text.Trim() == "") textBox_F21_Watermark();
        }

        private void textBox_F21_Watermark()
        {
            this.textBox_F21.Text = "F21";
            textBox_F21.ForeColor = Color.Gray;
        }



        private void textBox_F22_Enter(object sender, EventArgs e)
        {
            if (textBox_F22.ForeColor == Color.Black)
                return;
            textBox_F22.Text = "";
            textBox_F22.ForeColor = Color.Black;
        }

        private void textBox_F22_Leave(object sender, EventArgs e)
        {
            if (textBox_F22.Text.Trim() == "") textBox_F22_Watermark();
        }

        private void textBox_F22_Watermark()
        {
            this.textBox_F22.Text = "F22";
            textBox_F22.ForeColor = Color.Gray;
        }



        private void textBox_F23_Enter(object sender, EventArgs e)
        {
            if (textBox_F23.ForeColor == Color.Black)
                return;
            textBox_F23.Text = "";
            textBox_F23.ForeColor = Color.Black;
        }

        private void textBox_F23_Leave(object sender, EventArgs e)
        {
            if (textBox_F23.Text.Trim() == "") textBox_F23_Watermark();
        }

        private void textBox_F23_Watermark()
        {
            this.textBox_F23.Text = "F23";
            textBox_F23.ForeColor = Color.Gray;
        }



        private void textBox_F31_Enter(object sender, EventArgs e)
        {
            if (textBox_F31.ForeColor == Color.Black)
                return;
            textBox_F31.Text = "";
            textBox_F31.ForeColor = Color.Black;
        }

        private void textBox_F31_Leave(object sender, EventArgs e)
        {
            if (textBox_F31.Text.Trim() == "") textBox_F31_Watermark();
        }

        private void textBox_F31_Watermark()
        {
            this.textBox_F31.Text = "F31";
            textBox_F31.ForeColor = Color.Gray;
        }



        private void textBox_F32_Enter(object sender, EventArgs e)
        {
            if (textBox_F32.ForeColor == Color.Black)
                return;
            textBox_F32.Text = "";
            textBox_F32.ForeColor = Color.Black;
        }

        private void textBox_F32_Leave(object sender, EventArgs e)
        {
            if (textBox_F32.Text.Trim() == "") textBox_F32_Watermark();
        }

        private void textBox_F32_Watermark()
        {
            this.textBox_F32.Text = "F32";
            textBox_F32.ForeColor = Color.Gray;
        }



        private void textBox_F33_Enter(object sender, EventArgs e)
        {
            if (textBox_F33.ForeColor == Color.Black)
                return;
            textBox_F33.Text = "";
            textBox_F33.ForeColor = Color.Black;
        }

        private void textBox_F33_Leave(object sender, EventArgs e)
        {
            if (textBox_F33.Text.Trim() == "") textBox_F33_Watermark();
        }

        private void textBox_F33_Watermark()
        {
            this.textBox_F33.Text = "F33";
            textBox_F33.ForeColor = Color.Gray;
        }

        #endregion

        #region matematika

        Boolean _v1unet, _v2unet, _v3unet;
        public Boolean v1unet, v2unet, v3unet;
        Double _W, _H, _R, _I,
                _V1,  _V2,  _V3,
                _F11, _F12, _F13,
                _F21, _F22, _F23,
                _F31, _F32, _F33;
        public Double W, H, R, I,
                        V1,  V2,  V3,
                        F11, F12, F13,
                        F21, F22, F23,
                        F31, F32, F33;
        public Double DT,
                        FT1,   FT2,   FT3,
                        FT1x2, FT2x2, FT3x2,
                        FT1x3, FT2x3, FT3x3,
                        FT1x4, FT2x4, FT3x4,
                        FK1,   FK2,   FK3,
                        FK1x2, FK2x2, FK3x2,
                        FK1x3, FK2x3, FK3x3,
                        FK1x4, FK2x4, FK3x4;

        private void ResetVrednosti()
        {
            _v1unet = _v2unet = _v3unet = false;
            _W = _H = _R = _I = _V1 = _V2 = _V3 = _F11 = _F12 = _F13 = _F21 = _F22 = _F23 = _F31 = _F32 = _F33 = 0;
        }

        #endregion

        private void button_Racun_Click(object sender, EventArgs e)
        {
            ResetVrednosti();
        }
    }
}
