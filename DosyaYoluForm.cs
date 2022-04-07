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
    public partial class DosyaYoluForm : Form
    {
        SonucForm sf = new SonucForm();
        public DosyaYoluForm()
        {
            InitializeComponent();
        }

        private void DosyaYoluForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sf.Show();
        }
    }
}
