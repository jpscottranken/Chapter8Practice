using System;
using System.Diagnostics.Eventing.Reader;
using System.Web;
using System.Windows.Forms;

/*
 *      2.	Use a single-subscripted array to solve the
 *			following problem: A company pays its salespeople
 *			on a commission basis.
 *			
 *			The salespeople receive $200 per week, plus 10% of
 *			their gross sales for that week. For example, a
 *			salesperson who grosses $5000 in sales in a week
 *			receives $200 plus 10% of $5000, or total of $700.
 *			
 *			Write a program (using an array of counters) that
 *			determines how many of the salespeople earned 
 *			salaries in each of the following ranges (assume 
 *			that each salesperson's salary is truncated to an
 *			integer amount):
 *			
 *			a) $200–$299
 *			b) $300–$399
 *			c) $400–$499
 *			d) $500–$599
 *			e) $600–$699
 *			f) $700–$799
 *			g) $800–$899
 *			h) $900–$999
 *			i) $1000 and over
 */

namespace Practice08_02
{
    public partial class frmCommissionRates : Form
    {
        //  Declare and initialize program constants
        const int SIZE = 100;

        //  Declare and initialize class variable
        int[] commissions = new int[SIZE];

        public frmCommissionRates()
        {
            InitializeComponent();
        }

        private void btnFillArray_Click(object sender, EventArgs e)
        {
            FillTheArray();
        }

        private void FillTheArray()
        {
            Random rand = new Random();

            txtResults.Text = "";

            commissions[SIZE - 1] = 0;

            for (int lcv = 0; lcv < SIZE; ++lcv)
            {
                commissions[lcv] = rand.Next(0, 9);
            }

            ShowMessage("The Array Has Been Filled", "ARRAY FILLED");
        }

        private void btnShowCommRateTotals_Click(object sender, EventArgs e)
        {
            CalculateCommTotals();
        }

        private void CalculateCommTotals()
        {
            int twoLessThanThree    = 0;
            int threeLessThanFour   = 0;
            int fourLessThanFive    = 0;
            int fiveLessThanSix     = 0;
            int sixLessThanSeven    = 0;
            int sevenLessThanEight  = 0;
            int eightLessThanNine   = 0;
            int nineLessThanThou    = 0;
            int oneThouAndAbove     = 0;

            for (int lcv = 0; lcv < SIZE; ++lcv)
            {
                if (commissions[lcv] == 8)
                {
                    ++oneThouAndAbove;
                }
                else if (commissions[lcv] == 7)
                {
                    ++nineLessThanThou;
                }
                else if (commissions[lcv] == 6)
                {
                    ++eightLessThanNine;
                }
                else if (commissions[lcv] == 5)
                {
                    ++sevenLessThanEight;
                }
                else if (commissions[lcv] == 4)
                {
                    ++sixLessThanSeven;
                }
                else if (commissions[lcv] == 3)
                {
                    ++fiveLessThanSix;
                }
                else if (commissions[lcv] == 2)
                {
                    ++fourLessThanFive;
                }
                else if (commissions[lcv] == 1)
                {
                    ++threeLessThanFour;
                }
                else if (commissions[lcv] == 0)
                {
                    ++twoLessThanThree;
                }
            }

            DisplayTotals(twoLessThanThree, threeLessThanFour,
                          fourLessThanFive, fiveLessThanSix,
                          sixLessThanSeven, sevenLessThanEight,
                          eightLessThanNine, nineLessThanThou,
                          oneThouAndAbove);
        }

        private void DisplayTotals(int two, int three, int four,  int five,
                                   int six, int seven, int eight, int nine, int thou)
        {
            string outputStr = "";

            outputStr += ($"#Comms $200 - $299: {two}\t");
            outputStr += ($"#Comms $300 - $399: {three}\r\n");
            outputStr += ($"#Comms $400 - $499: {four}\t");
            outputStr += ($"#Comms $500 - $599: {five}\r\n");
            outputStr += ($"#Comms $600 - $699: {six}\t");
            outputStr += ($"#Comms $700 - $799: {seven}\r\n");
            outputStr += ($"#Comms $800 - $899: {eight}\t");
            outputStr += ($"#Comms $900 - $999: {nine}\r\n");
            outputStr += ($"#Comms $1000 & UP: {thou}");

            txtResults.Text = outputStr;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtResults.Text = "";
            FillTheArray();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
                        "Do You Really Want To Exit The Program?",
                        "EXIT NOW?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void frmCommissionRates_Load(object sender, EventArgs e)
        {
            FillTheArray();
        }
    }
}
