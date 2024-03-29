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
    public partial class Forma_Centar_Agregat_Glavni : Form
    {
#pragma warning disable IDE1006

        public Forma_Centar_Glavni         FormaCentarGlavni;
        public Forma_Centar_Agregat_Tabela FormaCentarAgregatTabela;
        public Forma_Centar_Agregat_Grafik FormaCentarAgregatGrafik;

        public Forma_Centar_Agregat_Glavni(Forma_Centar_Glavni konstruktor)
        {
            InitializeComponent();
            FormaCentarGlavni = konstruktor;
        }

        public void PromenaJezika()
        {
            this.Text             = FormaCentarGlavni.FormaHomeScreen.Jezik[57];
            label_Upozorenje.Text = FormaCentarGlavni.FormaHomeScreen.Jezik[58];
            label1.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[59];
            label2.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[60];
            label3.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[61];
            label4.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[62];
            label5.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[63];
            label6.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[64];
            label7.Text           = FormaCentarGlavni.FormaHomeScreen.Jezik[65];
            button_Racun.Text     = FormaCentarGlavni.FormaHomeScreen.Jezik[66];
            label_PR.Text = FormaCentarGlavni.FormaHomeScreen.Jezik[510];
        }

        private void Forma_Centar_Agregat_Glavni_Load(object sender, EventArgs e)
        {
            PromenaJezika();
            this.Location = new Point(FormaCentarGlavni.Left + 20, FormaCentarGlavni.Top + 20);

            PresetUnos();
        }

        private void Forma_Centar_Agregat_Glavni_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormaCentarGlavni.FormaCentarAgregatGlavni = null;
            FormaCentarGlavni.ButtonAgregatEnabled     = true;
        }

        #region text box sranja

        private void textBox_DR_Enter(object sender, EventArgs e)
        {
            if (textBox_DR.ForeColor == Color.Black)
                return;
            textBox_DR.Text = "";
            textBox_DR.ForeColor = Color.Black;
        }

        private void textBox_DR_Leave(object sender, EventArgs e)
        {
            if (textBox_DR.Text.Trim() == "") textBox_DR_Watermark();
        }

        private void textBox_DR_Watermark()
        {
            this.textBox_DR.Text = "DR";
            textBox_DR.ForeColor = Color.Gray;
        }



        private void textBox_D1_Enter(object sender, EventArgs e)
        {
            if (textBox_D1.ForeColor == Color.Black)
                return;
            textBox_D1.Text = "";
            textBox_D1.ForeColor = Color.Black;
        }

        private void textBox_D1_Leave(object sender, EventArgs e)
        {
            if (textBox_D1.Text.Trim() == "") textBox_D1_Watermark();
        }

        private void textBox_D1_Watermark()
        {
            this.textBox_D1.Text = "D1";
            textBox_D1.ForeColor = Color.Gray;
        }



        private void textBox_D2_Enter(object sender, EventArgs e)
        {
            if (textBox_D2.ForeColor == Color.Black)
                return;
            textBox_D2.Text = "";
            textBox_D2.ForeColor = Color.Black;
        }

        private void textBox_D2_Leave(object sender, EventArgs e)
        {
            if (textBox_D2.Text.Trim() == "") textBox_D2_Watermark();
        }

        private void textBox_D2_Watermark()
        {
            this.textBox_D2.Text = "D2";
            textBox_D2.ForeColor = Color.Gray;
        }



        private void textBox_D3_Enter(object sender, EventArgs e)
        {
            if (textBox_D3.ForeColor == Color.Black)
                return;
            textBox_D3.Text = "";
            textBox_D3.ForeColor = Color.Black;
        }

        private void textBox_D3_Leave(object sender, EventArgs e)
        {
            if (textBox_D3.Text.Trim() == "") textBox_D3_Watermark();
        }

        private void textBox_D3_Watermark()
        {
            this.textBox_D3.Text = "D3";
            textBox_D3.ForeColor = Color.Gray;
        }



        private void textBox_D4_Enter(object sender, EventArgs e)
        {
            if (textBox_D4.ForeColor == Color.Black)
                return;
            textBox_D4.Text = "";
            textBox_D4.ForeColor = Color.Black;
        }

        private void textBox_D4_Leave(object sender, EventArgs e)
        {
            if (textBox_D4.Text.Trim() == "") textBox_D4_Watermark();
        }

        private void textBox_D4_Watermark()
        {
            this.textBox_D4.Text = "D4";
            textBox_D4.ForeColor = Color.Gray;
        }



        private void textBox_D5_Enter(object sender, EventArgs e)
        {
            if (textBox_D5.ForeColor == Color.Black)
                return;
            textBox_D5.Text = "";
            textBox_D5.ForeColor = Color.Black;
        }

        private void textBox_D5_Leave(object sender, EventArgs e)
        {
            if (textBox_D5.Text.Trim() == "") textBox_D5_Watermark();
        }

        private void textBox_D5_Watermark()
        {
            this.textBox_D5.Text = "D5";
            textBox_D5.ForeColor = Color.Gray;
        }



        private void textBox_D6_Enter(object sender, EventArgs e)
        {
            if (textBox_D6.ForeColor == Color.Black)
                return;
            textBox_D6.Text = "";
            textBox_D6.ForeColor = Color.Black;
        }

        private void textBox_D6_Leave(object sender, EventArgs e)
        {
            if (textBox_D6.Text.Trim() == "") textBox_D6_Watermark();
        }

        private void textBox_D6_Watermark()
        {
            this.textBox_D6.Text = "D6";
            textBox_D6.ForeColor = Color.Gray;
        }

        #endregion

        #region matematika

        public Double DR, D1, D2, D3, D4, D5, D6;
        Double _DR, _D1, _D2, _D3, _D4, _D5, _D6;

        public Double D11, D21, D31, D41, D51, D61,
                      D12, D22, D32, D42, D52, D62,
                      D13, D23, D33, D43, D53, D63;

        private Boolean ucitavanje()
        {
            Boolean uspeh = true;
            //////////////////////////////////////////////////////////
            if (!Double.TryParse(textBox_DR.Text, out _DR))
            {
                errorProvider1.SetError(textBox_DR, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                uspeh = false;
            }
            if (_DR <= 0)
            {
                errorProvider1.SetError(textBox_DR, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                uspeh = false;
            }
            //////////////////////////////////////////////////////////
            if (textBox_D1.Text != "D1")
            {
                if (Double.TryParse(textBox_D1.Text, out _D1))
                {
                    if (_D1 <= 0)
                    {
                        errorProvider1.SetError(textBox_D1, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D1, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            if (textBox_D2.Text != "D2")
            {
                if (Double.TryParse(textBox_D2.Text, out _D2))
                {
                    if (_D2 <= 0)
                    {
                        errorProvider1.SetError(textBox_D2, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D2, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            if (textBox_D3.Text != "D3")
            {
                if (Double.TryParse(textBox_D3.Text, out _D3))
                {
                    if (_D3 <= 0)
                    {
                        errorProvider1.SetError(textBox_D3, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D3, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            if (textBox_D4.Text != "D4")
            {
                if (Double.TryParse(textBox_D4.Text, out _D4))
                {
                    if (_D4 <= 0)
                    {
                        errorProvider1.SetError(textBox_D4, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D4, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            if (textBox_D5.Text != "D5")
            {
                if (Double.TryParse(textBox_D5.Text, out _D5))
                {
                    if (_D5 <= 0)
                    {
                        errorProvider1.SetError(textBox_D5, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D5, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            if (textBox_D6.Text != "D6")
            {
                if (Double.TryParse(textBox_D6.Text, out _D6))
                {
                    if (_D6 <= 0)
                    {
                        errorProvider1.SetError(textBox_D6, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                        uspeh = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox_D6, FormaCentarGlavni.FormaHomeScreen.Jezik[308]);
                    uspeh = false;
                }
            }
            //////////////////////////////////////////////////////////
            return uspeh;
            //////////////////////////////////////////////////////////
        }

        private void konvertovanje()
        {
            DR = _DR;
            D1 = _D1;
            D2 = _D2;
            D3 = _D3;
            D4 = _D4;
            D5 = _D5;
            D6 = _D6;
        }

        public void Racun()
        {
            #region RPM1Unet
            if (FormaCentarGlavni.RPM1Unet)
            {
                if (D1 != 0)
                {
                    D11 = (FormaCentarGlavni.RPM1 / 60) * (DR / D1);
                    D11 = Math.Round(D11, 1, MidpointRounding.AwayFromZero);
                }
                if (D2 != 0)
                {
                    D21 = (FormaCentarGlavni.RPM1 / 60) * (DR / D2);
                    D21 = Math.Round(D21, 1, MidpointRounding.AwayFromZero);
                }
                if (D3 != 0)
                {
                    D31 = (FormaCentarGlavni.RPM1 / 60) * (DR / D3);
                    D31 = Math.Round(D31, 1, MidpointRounding.AwayFromZero);
                }
                if (D4 != 0)
                {
                    D41 = (FormaCentarGlavni.RPM1 / 60) * (DR / D4);
                    D41 = Math.Round(D41, 1, MidpointRounding.AwayFromZero);
                }
                if (D5 != 0)
                {
                    D51 = (FormaCentarGlavni.RPM1 / 60) * (DR / D5);
                    D51 = Math.Round(D51, 1, MidpointRounding.AwayFromZero);
                }
                if (D6 != 0)
                {
                    D61 = (FormaCentarGlavni.RPM1 / 60) * (DR / D6);
                    D61 = Math.Round(D61, 1, MidpointRounding.AwayFromZero);
                }
            }
            #endregion

            #region RPM2Unet
            if (FormaCentarGlavni.RPM2Unet)
            {
                if (D1 != 0)
                {
                    D12 = (FormaCentarGlavni.RPM2 / 60) * (DR / D1);
                    D12 = Math.Round(D12, 1, MidpointRounding.AwayFromZero);
                }
                if (D2 != 0)
                {
                    D22 = (FormaCentarGlavni.RPM2 / 60) * (DR / D2);
                    D22 = Math.Round(D22, 1, MidpointRounding.AwayFromZero);
                }
                if (D3 != 0)
                {
                    D32 = (FormaCentarGlavni.RPM2 / 60) * (DR / D3);
                    D32 = Math.Round(D32, 1, MidpointRounding.AwayFromZero);
                }
                if (D4 != 0)
                {
                    D42 = (FormaCentarGlavni.RPM2 / 60) * (DR / D4);
                    D42 = Math.Round(D42, 1, MidpointRounding.AwayFromZero);
                }
                if (D5 != 0)
                {
                    D52 = (FormaCentarGlavni.RPM2 / 60) * (DR / D5);
                    D52 = Math.Round(D52, 1, MidpointRounding.AwayFromZero);
                }
                if (D6 != 0)
                {
                    D62 = (FormaCentarGlavni.RPM2 / 60) * (DR / D6);
                    D62 = Math.Round(D62, 1, MidpointRounding.AwayFromZero);
                }
            }
            #endregion

            #region RPM3Unet
            if (FormaCentarGlavni.RPM3Unet)
            {
                if (D1 != 0)
                {
                    D13 = (FormaCentarGlavni.RPM3 / 60) * (DR / D1);
                    D13 = Math.Round(D13, 1, MidpointRounding.AwayFromZero);
                }
                if (D2 != 0)
                {
                    D23 = (FormaCentarGlavni.RPM3 / 60) * (DR / D2);
                    D23 = Math.Round(D23, 1, MidpointRounding.AwayFromZero);
                }
                if (D3 != 0)
                {
                    D33 = (FormaCentarGlavni.RPM3 / 60) * (DR / D3);
                    D33 = Math.Round(D33, 1, MidpointRounding.AwayFromZero);
                }
                if (D4 != 0)
                {
                    D43 = (FormaCentarGlavni.RPM3 / 60) * (DR / D4);
                    D43 = Math.Round(D43, 1, MidpointRounding.AwayFromZero);
                }
                if (D5 != 0)
                {
                    D53 = (FormaCentarGlavni.RPM3 / 60) * (DR / D5);
                    D53 = Math.Round(D53, 1, MidpointRounding.AwayFromZero);
                }
                if (D6 != 0)
                {
                    D63 = (FormaCentarGlavni.RPM3 / 60) * (DR / D6);
                    D63 = Math.Round(D63, 1, MidpointRounding.AwayFromZero);
                }
            }
            #endregion

            Aktivirano = true;
            button_Tabela.Enabled = button_Grafik.Enabled = true;
            if (FormaCentarAgregatTabela != null) FormaCentarAgregatTabela.IspisVrednosti();
            if (FormaCentarAgregatGrafik != null) FormaCentarAgregatGrafik.Racun();
        }

        #endregion

        public Boolean Aktivirano = false; /* ova promenljiva sluzi da FormaCentarGlavni moze da proveri da li je FormaCentarAgregatGlavni ucitana,
                                            * i samim tim da zna da li treba da pozove FormaCentarAgregatGlavni.Racun() kada se klikne na dugme za vrsenje
                                            * racuna na FormaCentarGlavni. Medjutim ako nismo nista uneli na FormaCentarAgregatGlavni, program bi zabagovao,
                                            * tako da imamo ovu promenljivu da proverimo da li su vrednosti unete minimum jedanput. Originalni plan mi je bio
                                            * da proverim da li je ili FormaCentarAgregatTabela ili FormaCentarAgregatGrafik ucitana, ali to bi dovelo do
                                            * bagova ako ni jedna ni druga od tih nisu ucitane (kada bi korisnik ucitao jednu od njih naknadno, ali bez
                                            * azuriranja vrednosti na FormaCentarAgregatGlavni, Grafik i Tabela bi imali azurirane vrednosti sa FormaCentarGlavni,
                                            * ali ne i sa FormaCentarAgregatGlavni. Drugi plan mi je bio da proverim jednostavno da li je DR = 0 posto se
                                            * ta promenljiva uvek unosi, tako da verujem da bi to radilo, ali na kraju sam odlucio samo da dodam novu promenljivu cistoce radi. */

        private void button_Racun_Click(object sender, EventArgs e)
        {
            _DR = _D1 = _D2 = _D3 = _D4 = _D5 = _D6 = 0;
            errorProvider1.SetError(textBox_DR, "");
            errorProvider1.SetError(textBox_D1, "");
            errorProvider1.SetError(textBox_D2, "");
            errorProvider1.SetError(textBox_D3, "");
            errorProvider1.SetError(textBox_D4, "");
            errorProvider1.SetError(textBox_D5, "");
            errorProvider1.SetError(textBox_D6, "");

            if (textBox_DR.Text != "DR" && (textBox_D1.Text != "D1" || textBox_D2.Text != "D2" || textBox_D3.Text != "D3" || textBox_D4.Text != "D4" || textBox_D5.Text != "D5" || textBox_D6.Text != "D6"))
            {
                if (ucitavanje())
                {
                    konvertovanje();
                    Racun();
                    // if (!aktivirano) aktivirano = true; // prebaceno u Racun()
                    // if (FormaCentarAgregatTabela == null && FormaCentarAgregatGrafik == null) button_Tabela.Enabled = button_Grafik.Enabled = true; // prebaceno u Racun()
                }
                else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.Jezik[68], FormaCentarGlavni.FormaHomeScreen.Jezik[311], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show(FormaCentarGlavni.FormaHomeScreen.Jezik[67], FormaCentarGlavni.FormaHomeScreen.Jezik[311], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Tabela_Click(object sender, EventArgs e)
        {
            FormaCentarAgregatTabela = new Forma_Centar_Agregat_Tabela(this);
            FormaCentarAgregatTabela.Owner = this;
            FormaCentarAgregatTabela.Show();

            button_Tabela.Enabled = false;
        }

        public Boolean ButtonTabelaEnabled
        {
            get { return button_Tabela.Enabled;  }
            set { button_Tabela.Enabled = value; }
        }

        private void button_Grafik_Click(object sender, EventArgs e)
        {
            FormaCentarAgregatGrafik = new Forma_Centar_Agregat_Grafik(this);
            FormaCentarAgregatGrafik.Owner = this;
            FormaCentarAgregatGrafik.Show();

            button_Grafik.Enabled = false;
        }

        public Boolean ButtonGrafikEnabled
        {
            get { return button_Grafik.Enabled;  }
            set { button_Grafik.Enabled = value; }
        }

        public void PresetUnos()
        {
            switch (FormaCentarGlavni.ComboBoxPresetSelectedIndex)
            {
                case 0:
                    {
                        textBox_DR_Watermark();
                        textBox_D1_Watermark();
                        textBox_D2_Watermark();
                        textBox_D3_Watermark();
                        textBox_D4_Watermark();
                        textBox_D5_Watermark();
                        textBox_D6_Watermark();

                        break;
                    }
                case 1:
                    {
                        DR = 10;
                        D1 = 10;
                        D2 = 10;
                        D3 = 10;
                        D4 = 10;
                        D5 = 10;
                        D6 = 10;

                        textBox_DR.Text = "10";
                        textBox_D1.Text = "10";
                        textBox_D2.Text = "10";
                        textBox_D3.Text = "10";
                        textBox_D4.Text = "10";
                        textBox_D5.Text = "10";
                        textBox_D6.Text = "10";

                        textBox_DR.ForeColor = textBox_D1.ForeColor = textBox_D2.ForeColor = textBox_D3.ForeColor = textBox_D4.ForeColor = textBox_D5.ForeColor = textBox_D6.ForeColor = Color.Black;
                        Racun();
                        // button_Tabela.Enabled = button_Grafik.Enabled = true; // prebaceno u Racun()

                        break;
                    }
                case 2:
                    {
                        DR = 15;
                        D1 = 7;
                        D2 = 7;
                        D3 = 7;
                        D4 = 7;
                        D5 = 7;
                        D6 = 7;

                        textBox_DR.Text = "15";
                        textBox_D1.Text = "7";
                        textBox_D2.Text = "7";
                        textBox_D3.Text = "7";
                        textBox_D4.Text = "7";
                        textBox_D5.Text = "7";
                        textBox_D6.Text = "7";

                        textBox_DR.ForeColor = textBox_D1.ForeColor = textBox_D2.ForeColor = textBox_D3.ForeColor = textBox_D4.ForeColor = textBox_D5.ForeColor = textBox_D6.ForeColor = Color.Black;
                        Racun();
                        // button_Tabela.Enabled = button_Grafik.Enabled = true; // prebaceno u Racun()

                        break;
                    }
                default: break;
            }
        }

#pragma warning restore IDE1006
    }
}
