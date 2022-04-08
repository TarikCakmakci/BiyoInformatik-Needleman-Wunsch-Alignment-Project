﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiyoInformatik_Needleman_Wunsch_Alignment_Project
{
    public partial class DosyaYoluForm : Form
    {
        
        SonucForm sf = new SonucForm();
        public DosyaYoluForm()
        {
            InitializeComponent();
        }

        private void DosyaYoluForm_Load(object sender, EventArgs e)
        {

            int matchValue = DegerAlmaForm.matchValue;
            int mismatchValue = DegerAlmaForm.mismatchValue;
            int gapValue = DegerAlmaForm.gapValue;
            listBox1.Items.Add("Match Değeri: " + matchValue);
            listBox1.Items.Add("Mismatch Değeri: " + mismatchValue);
            listBox1.Items.Add("Gap Değeri:" + gapValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            sf.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dosya1 seçim
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                label7.Text = sFileName;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dosya2 seçim
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                label8.Text = sFileName;
                
            }

        }
    }
}
