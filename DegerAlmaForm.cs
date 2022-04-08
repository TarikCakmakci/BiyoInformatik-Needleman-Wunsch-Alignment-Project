using System;
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
    public partial class DegerAlmaForm : Form
    {
        DosyaYoluForm dyf = new DosyaYoluForm();

        public static int matchValue;
        public static int mismatchValue;
        public static int gapValue;

        public DegerAlmaForm()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            int matchValue = +1;
            int mismatchValue = -1;
            int gapValue = -2;
            listBox1.Items.Add("Match Değeri: " + matchValue);
            listBox1.Items.Add("Mismatch Değeri: " + mismatchValue);
            listBox1.Items.Add("Gap Değeri:" + gapValue);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" )
            {
                DialogResult dia = MessageBox.Show("Değerleri girmezseniz default değerler kullanılacaktır.Default değerlerin kullanılmasını istiyorsanız yes'i, değer girecekseniz no'yu seçiniz.", "Match,Mismatch,Gap Value", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    matchValue = +1;
                    mismatchValue = -1;
                    gapValue = -2;
                    dyf.Show();
                    this.Hide();
                }
               
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                listBox1.Items.Clear();
                matchValue = Convert.ToInt32(textBox1.Text);
                mismatchValue = Convert.ToInt32(textBox2.Text);
                gapValue = Convert.ToInt32(textBox3.Text);
                listBox1.Items.Add("Match Değeri: " + matchValue);
                listBox1.Items.Add("Mismatch Değeri: " + mismatchValue);
                listBox1.Items.Add("Gap Değeri:" + gapValue);
                dyf.Show();
                this.Hide();
            }


            //listBox1.Items.Add("Match Değeri: "+matchValue);
            //listBox1.Items.Add("Mismatch Değeri: "+mismatchValue);
            //listBox1.Items.Add("Gap Değeri:"+ gapValue);
            
            
            



        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        
    }
}
