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
    public partial class Forma_TestVoznja : Form
    {
#pragma warning disable IDE1006

        Forma_HomeScreen FormaHomeScreen;

        public Forma_TestVoznja(Forma_HomeScreen konstruktor)
        {
            InitializeComponent();
            FormaHomeScreen = konstruktor;
        }

        Int32 PreRoadTestInspection, RoadTest, SAtest, NCDStest, DStest, TCtest, ST1, ST2, NRUtest, ELtest, EAtest;

        public void PromenaJezika()
        {
            this.Text = FormaHomeScreen.Jezik[191];

            #region dokument

            label1.Text = FormaHomeScreen.Jezik[204];

            label2.Location = new Point(label1.Location.X, label1.Bottom + 20);
            label2.Text = FormaHomeScreen.Jezik[205];

            label3.Location = new Point(label1.Location.X, label2.Bottom + 20);
            label3.Text = FormaHomeScreen.Jezik[206];

            label4.Location = new Point(label1.Location.X, label3.Bottom + 20);
            label4.Text = FormaHomeScreen.Jezik[207];

            label5.Location = new Point(label1.Location.X, label4.Bottom + 20);
            label5.Text = FormaHomeScreen.Jezik[208];

            label6.Location = new Point(label1.Location.X, label5.Bottom + 20);
            label6.Text = FormaHomeScreen.Jezik[209];

            label7.Location = new Point(label1.Location.X, label6.Bottom + 20);
            label7.Text = FormaHomeScreen.Jezik[210];

            label8.Location = new Point(label1.Location.X, label7.Bottom + 20);
            label8.Text = FormaHomeScreen.Jezik[211];

            label9.Location = new Point(label1.Location.X, label8.Bottom + 20);
            label9.Text = FormaHomeScreen.Jezik[212];

            label10.Location = new Point(label1.Location.X, label9.Bottom + 20);
            label10.Text = FormaHomeScreen.Jezik[213];

            label11.Location = new Point(label1.Location.X, label10.Bottom + 20);
            label11.Text = FormaHomeScreen.Jezik[214];

            label12.Location = new Point(label1.Location.X, label11.Bottom + 20);
            label12.Text = FormaHomeScreen.Jezik[215];

            label13.Location = new Point(label1.Location.X, label12.Bottom + 20);
            label13.Text = FormaHomeScreen.Jezik[216];

            label14.Location = new Point(label1.Location.X, label13.Bottom + 20);
            label14.Text = FormaHomeScreen.Jezik[217];

            label15.Location = new Point(label1.Location.X, label14.Bottom + 20);
            label15.Text = FormaHomeScreen.Jezik[218];

            label16.Location = new Point(label1.Location.X, label15.Bottom + 20);
            label16.Text = FormaHomeScreen.Jezik[219];

            label17.Location = new Point(label1.Location.X, label16.Bottom + 20);
            label17.Text = FormaHomeScreen.Jezik[220];

            label18.Location = new Point(label1.Location.X, label17.Bottom + 20);
            label18.Text = FormaHomeScreen.Jezik[221];

            label19.Location = new Point(label1.Location.X, label18.Bottom + 20);
            label19.Text = FormaHomeScreen.Jezik[222];

            label20.Location = new Point(label1.Location.X, label19.Bottom + 20);
            label20.Text = FormaHomeScreen.Jezik[223];

            label21.Location = new Point(label1.Location.X, label20.Bottom + 20);
            label21.Text = FormaHomeScreen.Jezik[224];

            label22.Location = new Point(label1.Location.X, label21.Bottom + 20);
            label22.Text = FormaHomeScreen.Jezik[225];

            label23.Location = new Point(label1.Location.X, label22.Bottom + 20);
            label23.Text = FormaHomeScreen.Jezik[226];

            label24.Location = new Point(label1.Location.X, label23.Bottom + 20);
            label24.Text = FormaHomeScreen.Jezik[227];

            label25.Location = new Point(label1.Location.X, label24.Bottom + 20);
            label25.Text = FormaHomeScreen.Jezik[228];

            label26.Location = new Point(label1.Location.X, label25.Bottom + 20);
            label26.Text = FormaHomeScreen.Jezik[229];

            label27.Location = new Point(label1.Location.X, label26.Bottom + 20);
            label27.Text = FormaHomeScreen.Jezik[230];
            
            label28.Location = new Point(label1.Location.X, label27.Bottom + 20);
            label28.Text = FormaHomeScreen.Jezik[231];

            label29.Location = new Point(label1.Location.X, label28.Bottom + 20);
            label29.Text = FormaHomeScreen.Jezik[232];

            label30.Location = new Point(label1.Location.X, label29.Bottom + 20);
            label30.Text = FormaHomeScreen.Jezik[233];

            label31.Location = new Point(label1.Location.X, label30.Bottom + 20);
            label31.Text = FormaHomeScreen.Jezik[234];

            label32.Location = new Point(label1.Location.X, label31.Bottom + 20);
            label32.Text = FormaHomeScreen.Jezik[235];

            label33.Location = new Point(label1.Location.X, label32.Bottom + 20);
            label33.Text = FormaHomeScreen.Jezik[236];

            label34.Location = new Point(label1.Location.X, label33.Bottom + 20);
            label34.Text = FormaHomeScreen.Jezik[237];

            label35.Location = new Point(label1.Location.X, label34.Bottom + 20);
            label35.Text = FormaHomeScreen.Jezik[238];

            label36.Location = new Point(label1.Location.X, label35.Bottom + 20);
            label36.Text = FormaHomeScreen.Jezik[239];

            label37.Location = new Point(label1.Location.X, label36.Bottom + 20);
            label37.Text = FormaHomeScreen.Jezik[240];

            label38.Location = new Point(label1.Location.X, label37.Bottom + 20);
            label38.Text = FormaHomeScreen.Jezik[241];

            label39.Location = new Point(label1.Location.X, label38.Bottom + 20);
            label39.Text = FormaHomeScreen.Jezik[242];

            label40.Location = new Point(label1.Location.X, label39.Bottom + 20);
            label40.Text = FormaHomeScreen.Jezik[243];

            label41.Location = new Point(label1.Location.X, label40.Bottom + 20);
            label41.Text = FormaHomeScreen.Jezik[244];

            label42.Location = new Point(label1.Location.X, label41.Bottom + 20);
            label42.Text = FormaHomeScreen.Jezik[245];

            label43.Location = new Point(label1.Location.X, label42.Bottom + 20);
            label43.Text = FormaHomeScreen.Jezik[246];

            label44.Location = new Point(label1.Location.X, label43.Bottom + 20);
            label44.Text = FormaHomeScreen.Jezik[247];

            label45.Location = new Point(label1.Location.X, label44.Bottom + 20);
            label45.Text = FormaHomeScreen.Jezik[248];

            label46.Location = new Point(label1.Location.X, label45.Bottom + 20);
            label46.Text = FormaHomeScreen.Jezik[249];

            button1.Text = FormaHomeScreen.Jezik[315];
            button1.Location = new Point(button1.Location.X, label46.Location.Y - (button1.Height - label46.Height) - 5);

            #endregion

            PreRoadTestInspection = label3.Location.Y  - 5;
            RoadTest              = label5.Location.Y  - 5;
            SAtest                = label16.Location.Y - 5;
            NCDStest              = label19.Location.Y - 5;
            DStest                = label22.Location.Y - 5;
            TCtest                = label25.Location.Y - 5;
            ST1                   = label28.Location.Y - 5;
            ST2                   = label31.Location.Y - 5;
            NRUtest               = label34.Location.Y - 5;
            ELtest                = label37.Location.Y - 5;
            EAtest                = label43.Location.Y - 5;
        }

        private void Forma_TestVoznja_Load(object sender, EventArgs e)
        {
            PromenaJezika();
            this.Location = new Point(0, 0);
        }

        private void Forma_TestVoznja_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormaHomeScreen.FormaTestVoznja  = null;
            FormaHomeScreen.DugmeLevoEnabled = true;
        }

        private void cursorHand(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand; // ovo je za MouseMove na labelima koju sluze kao linkovi, da bi se mis pretvorio u onaj kursor sa pokazujucom rukom kao u browserima
        }

        private void gotoPreRoadTestInspection(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, PreRoadTestInspection);
        }

        private void gotoRoadTest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, RoadTest);
        }

        private void gotoBeginning(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 0);
        }

        private void gotoSAtest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, SAtest);
        }

        private void gotoNCDStest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, NCDStest);
        }

        private void gotoDStest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, DStest);
        }

        private void gotoTCtest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, TCtest);
        }

        private void gotoST1(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, ST1);
        }

        private void gotoST2(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, ST2);
        }

        private void gotoNRUtest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, NRUtest);
        }

        private void gotoELtest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, ELtest);
        }

        private void gotoEAtest(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, EAtest);
        }

#pragma warning restore IDE1006
    }
}
