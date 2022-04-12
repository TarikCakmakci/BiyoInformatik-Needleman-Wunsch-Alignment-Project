using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiyoInformatik_Needleman_Wunsch_Alignment_Project
{
    public partial class SonucForm : Form
    {
        public SonucForm()
        {
            InitializeComponent();
        }

        public void SonucForm_Load(object sender, EventArgs e)
        {
            int match = DegerAlmaForm.matchValue;
            int misMatch = DegerAlmaForm.mismatchValue;
            int gap = DegerAlmaForm.gapValue;
            label10.Text = match.ToString();
            label11.Text = misMatch.ToString();
            label12.Text = gap.ToString();
            string fileName11 = DosyaYoluForm.fileName1;
            string fileName22 = DosyaYoluForm.fileName2;
            label4.Text = fileName11;
            label6.Text = fileName22;

            using (StreamReader file = new StreamReader(fileName11))
            {
                int counter = 0;
                string ln;
                int diziBoyutu = 0;
                char[] karakterDizi = new char[0];
                string s= "";
                while ((ln = file.ReadLine()) != null)
                {
                    listBox1.Items.Add(counter+". satır  = "+ln);
                    if (counter==0)
                    {
                        diziBoyutu = Int32.Parse(ln);
                        karakterDizi = new char[diziBoyutu];
                    }
                    if (counter==1)
                    {
                        s = ln;
                    }
                    counter++;
                    
                }
                file.Close();
                for (int i = 0; i <s.Length; i++)
                {
                    karakterDizi[i] = s[i];
                }
               
            }
            using (StreamReader file = new StreamReader(fileName22))
            {
                int counter2 = 0;
                string ln2;
                int diziBoyutu2 = 0;
                char[] karakterDizi2 = new char[0];
                string s2 = "";
                while ((ln2 = file.ReadLine()) != null)
                {
                    listBox2.Items.Add(counter2 + ". satır  = " + ln2);
                    if (counter2 == 0)
                    {
                        diziBoyutu2 = Int32.Parse(ln2);
                        karakterDizi2 = new char[diziBoyutu2];
                    }
                    if (counter2 == 1)
                    {
                        s2 = ln2;
                    }
                    counter2++;

                }
                file.Close();
                for (int i = 0; i < s2.Length; i++)
                {
                    karakterDizi2[i] = s2[i];
                }

            }
           
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
