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
    public partial class Form1 : Form
    {
        int matchValue = +1;
        int mismatchValue = -1;
        int gapValue = -2;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Match Değeri: " + matchValue);
            listBox1.Items.Add("Mismatch Değeri: " + mismatchValue);
            listBox1.Items.Add("Gap Değeri:" + gapValue);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" )
            {
                DialogResult dia = MessageBox.Show("Değerleri girmezseniz default değerler kullanılacaktır.Default değerlerin kullanılmasını istiyorsanız yes'i, değer girecekseniz no'yu seçiniz.", "Match,Mismatch,Gap Value", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    //Default değerler alınacak
                }
                if (dia == DialogResult.No)
                {
                    //yeni değerleri alıp işlem yapacağız
                }
            }
            if (textBox1.Text != null)
            {
                matchValue = Convert.ToInt32(textBox1.Text);
                MessageBox.Show("Textbox1 dolu.");
            }
            

            listBox1.Items.Add("Match Değeri: "+matchValue);
            listBox1.Items.Add("Mismatch Değeri: "+mismatchValue);
            listBox1.Items.Add("Gap Değeri:"+ gapValue);


        }
    }
}
