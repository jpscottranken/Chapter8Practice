using System;
using System.Windows.Forms;

/*
 *      1.	Write a program in C# Sharp to create an array
 *          with 100 random integers between 1 - 100. Then,
 *          separate the odd and even integers into separate
 *          arrays. Allow the use to print the contents of
 *          either array using an associated button.
 */

namespace Practice08_01
{
    public partial class frmOddsAndEvens : Form
    {
        //  Declare and initialize program constant
        const int SIZE = 100;

        //  Declare and initialize class variable
        int[] numbers = new int[SIZE];

        public frmOddsAndEvens()
        {
            InitializeComponent();
        }

        private void btnFillArray_Click(object sender, EventArgs e)
        {
            FillTheArray();
        }

        private void FillTheArray()
        {
            Random random = new Random();

            numbers[SIZE - 1] = 0;

            for (int lcv = 0; lcv < SIZE; lcv++) 
            {
                numbers[lcv] = random.Next(1, 101);
            }

            ShowMessage("The Array Has Been Filled",
                        "ARRAY FILLED");
        }

        private void btnShowOdds_Click(object sender, EventArgs e)
        {
            ShowOdds();
        }

        private void ShowOdds()
        {
            string outputStr = "";

            txtResults.Text = "";

            foreach (var number in numbers )
            {
                if (number % 2 != 0)
                {
                    outputStr += number + " ";
                }

                txtResults.Text = "Here Are The Odd #s In The Array\r\n" + outputStr;
            }
        }

        private void btnSHowEvens_Click(object sender, EventArgs e)
        {
            ShowEvens();
        }

        private void ShowEvens()
        {
            string outputStr = "";

            txtResults.Text = "";

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    outputStr += number + " ";
                }
            }

            txtResults.Text = "Here Are The Even #s In The Array\r\n" + outputStr;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtResults.Text = "";
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
    }
}
