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
        public char[] karakterDizi;
        public char[] karakterDizi2;
        
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            string karakterSt = new string(karakterDizi);
            string karakterSt2 = new string(karakterDizi2);
            int a = karakterSt.Length + 1;
            int b = karakterSt2.Length + 1;
            int match = DegerAlmaForm.matchValue;
            int misMatch = DegerAlmaForm.mismatchValue;
            int gap = DegerAlmaForm.gapValue;
            int[,] ScoreMatrix = new int[a, b];
            char[,] tracebackMatrix = new char[a, b];
            ScoreMatrix[0, 0] = 0;
            for (int i = 1; i < a; i++)
            {
                ScoreMatrix[i, 0] = i * gap;
                tracebackMatrix[i, 0] = 'U';

            }
            for (int j = 1; j < b; j++)
            {
                ScoreMatrix[0, j] = j * gap;
                tracebackMatrix[0, j] = 'L';
            }
            for (int i = 1; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    int scroeDiag = 0;
                    if (karakterSt.Substring(j-1,1) == karakterSt2.Substring(i-1,1))
                    {
                        scroeDiag = ScoreMatrix[i - 1, j - 1] + match;
                    }
                    else
                    {
                        scroeDiag = ScoreMatrix[i - 1, j - 1] + misMatch;
                        int scroeLeft = ScoreMatrix[i, j - 1] + gap;
                        int scroeUp = ScoreMatrix[i - 1, j] + gap;
                        int maxScore = Math.Max(Math.Max(scroeDiag, scroeLeft), scroeUp);
                        ScoreMatrix[i, j] = maxScore;
                        if (ScoreMatrix[i,j] ==scroeDiag)
                        {
                            tracebackMatrix[i, j] = 'D';
                        }
                        else if (ScoreMatrix[i,j]==scroeLeft)
                        {
                            tracebackMatrix[i, j] = 'L';
                        }
                        else if (ScoreMatrix[i,j]==scroeUp)
                        {
                            tracebackMatrix[i, j] = 'U';
                        }
                    }
                }
            }
            dataGridView1.DataSource = ConvertArrayToDataTable(ScoreMatrix, a, b);
            //dataGridView1.DataBind();
            //dataGridView2.DataSource = ConvertArrayToDataTable(tracebackMatrix, a, b);
            //TraceBack(tracebackMatrix, karakterSt, karakterSt2);


        }
        public DataTable ConvertArrayToDataTable(int[,] ScoreMatrix,int a,int b)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < b; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            for (int i = 0; i < a; i++)
            {
                dt.Rows.Add();
                for (int j = 0; j < a; j++)
                {
                    dt.Rows.Add();
                    for (int k = 0; k < b; k++)
                    {
                        dt.Rows[j][k] = ScoreMatrix[i, j];

                    }
                }
            }
            dt.AcceptChanges();
            return dt;
        }
        public DataTable ConvertArrayToDataTable2(char[,] ScoreMatrix, int a, int b)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < b; i++)
            {
                dt.Columns.Add(i.ToString());
            }
            for (int i = 0; i < a; i++)
            {
                dt.Rows.Add();
                for (int j = 0; j < a; j++)
                {
                    dt.Rows.Add();
                    for (int k = 0; k < b; k++)
                    {
                        dt.Rows[j][k] = ScoreMatrix[i, j];

                    }
                }
            }
            dt.AcceptChanges();
            return dt;
        }
        //public void TraceBack(char[,] tracebackMatrix,string sequenzA,string sequenzB)
        //{
        //    int i = tracebackMatrix.GetLength(0) - 1;
        //    int j = tracebackMatrix.GetLength(1) - 1;
        //    string alignedSeqA = "";
        //    string alignedSeqB = "";
        //    while(i!=0 || j != 0)
        //    {
        //        switch(tracebackMatrix[i,j])
        //        {
        //            case 'D':
        //                alignedSeqA += sequenzA[i - 1];

        //        }
        //    }
        //}

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int refSeqCnt = karakterDizi.Length + 1;
            //int alineSeqCnt = karakterDizi2.Length + 1;
            //string karakterSt = new string(karakterDizi);
            //string karakterSt2 = new string(karakterDizi2);
            //int[,] scoringMatrix = new int[alineSeqCnt, refSeqCnt];

            ////Initialization Step - filled with 0 for the first row and the first column of matrix
            //for (int i = 0; i < alineSeqCnt; i++)
            //{
            //    scoringMatrix[i, 0] = 0;
            //}

            //for (int j = 0; j < refSeqCnt; j++)
            //{
            //    scoringMatrix[0, j] = 0;
            //}
            ////Matrix Fill Step
            //for (int i = 1; i < alineSeqCnt; i++)
            //{
            //    for (int j = 1; j < refSeqCnt; j++)
            //    {
            //        int scroeDiag = 0;
            //        if (karakterSt.Substring(j - 1, 1) == karakterSt2.Substring(i - 1, 1))
            //            scroeDiag = scoringMatrix[i - 1, j - 1] + 2;
            //        else
            //            scroeDiag = scoringMatrix[i - 1, j - 1] + -1;

            //        int scroeLeft = scoringMatrix[i, j - 1] - 2;
            //        int scroeUp = scoringMatrix[i - 1, j] - 2;

            //        int maxScore = Math.Max(Math.Max(scroeDiag, scroeLeft), scroeUp);

            //        scoringMatrix[i, j] = maxScore;
            //    }
            //}
            ////Traceback Step
            //char[] alineSeqArray = karakterSt.ToCharArray();
            //char[] refSeqArray = karakterSt2.ToCharArray();

            //string AlignmentA = string.Empty;
            //string AlignmentB = string.Empty;
            //int m = alineSeqCnt - 1;
            //int n = refSeqCnt - 1;
            //while (m > 0 && n > 0)
            //{
            //    int scroeDiag = 0;

            //    //Remembering that the scoring scheme is +2 for a match, -1 for a mismatch and -2 for a gap
            //    if (alineSeqArray[m - 1] == refSeqArray[n - 1])
            //        scroeDiag = 2;
            //    else
            //        scroeDiag = -1;

            //    if (m > 0 && n > 0 && scoringMatrix[m, n] == scoringMatrix[m - 1, n - 1] + scroeDiag)
            //    {
            //        AlignmentA = refSeqArray[n - 1] + AlignmentA;
            //        AlignmentB = alineSeqArray[m - 1] + AlignmentB;
            //        m = m - 1;
            //        n = n - 1;
            //    }
            //    else if (n > 0 && scoringMatrix[m, n] == scoringMatrix[m, n - 1] - 2)
            //    {
            //        AlignmentA = refSeqArray[n - 1] + AlignmentA;
            //        AlignmentB = "-" + AlignmentB;
            //        n = n - 1;
            //    }
            //    else //if (m > 0 && scoringMatrix[m, n] == scoringMatrix[m - 1, n] + -2)
            //    {
            //        AlignmentA = "-" + AlignmentA;
            //        AlignmentB = alineSeqArray[m - 1] + AlignmentB;
            //        m = m - 1;
            //    }
            //}
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
