using System;
using System.Windows.Forms;

/*
 *      3.	Letter Frequency Counter (String Array):
 *      
 *          Analyze a textbox contents and count the 
 *          frequency of each letter (a - z) in it.
 *          
 *          Write a C# program that takes a string input and
 *          stores each letter in the string in a 1D array.
 *          
 *          Then, count the frequency of each letter and 
 *          display the results.
 */

namespace Practice08_03
{
    public partial class frmLetterCount : Form
    {
        //  Declare and initialize constant
        const int SIZE = 26;

        //  Declare and initialize class variables
        string[]     phrase = new string[100];
        int[] numEachLetter = new int[SIZE];

        int aCount = 0;
        int bCount = 0;
        int cCount = 0;
        int dCount = 0;
        int eCount = 0;
        int fCount = 0;
        int gCount = 0;
        int hCount = 0;
        int iCount = 0;
        int jCount = 0;
        int kCount = 0;
        int lCount = 0;
        int mCount = 0;
        int nCount = 0;
        int oCount = 0;
        int pCount = 0;
        int qCount = 0;
        int rCount = 0;
        int sCount = 0;
        int tCount = 0;
        int uCount = 0;
        int vCount = 0;
        int wCount = 0;
        int xCount = 0;
        int yCount = 0;
        int zCount = 0;


        public frmLetterCount()
        {
            InitializeComponent();
        }

        private void btnLetterSearch_Click(object sender, EventArgs e)
        {
            ValidateTextBoxIsNotEmpty();
        }

        private void ValidateTextBoxIsNotEmpty()
        {
            string input = txtResults.Text.Trim();

            if (input == "")
            {
                ShowErrorMessage("You Must Input Some Text In The Box",
                                 "TEXTBOX LEFT EMPTY");
                txtResults.Focus();
                return;
            }

            PerformLetterSearchCount();
        }

        private void PerformLetterSearchCount()
        {
            string input = txtResults.Text.Trim();

            var phrase = input.ToLower();

            for (int lcv = 0; lcv < phrase.Length; lcv++)
            {
                switch (phrase[lcv])
                {
                    case 'a':
                        ++aCount;
                        break;

                    case 'b':
                        ++bCount;
                        break;

                    case 'c':
                        ++cCount;
                        break;

                    case 'd':
                        ++dCount;
                        break;

                    case 'e':
                        ++eCount;
                        break;

                    case 'f':
                        ++fCount;
                        break;

                    case 'g':
                        ++gCount;
                        break;

                    case 'h':
                        ++hCount;
                        break;

                    case 'i':
                        ++iCount;
                        break;

                    case 'j':
                        ++jCount;
                        break;

                    case 'k':
                        ++kCount;
                        break;

                    case 'l':
                        ++lCount;
                        break;

                    case 'm':
                        ++mCount;
                        break;

                    case 'n':
                        ++nCount;
                        break;

                    case 'o':
                        ++oCount;
                        break;

                    case 'p':
                        ++pCount;
                        break;

                    case 'q':
                        ++qCount;
                        break;

                    case 'r':
                        ++rCount;
                        break;

                    case 's':
                        ++sCount;
                        break;

                    case 't':
                        ++tCount;
                        break;

                    case 'u':
                        ++uCount;
                        break;

                    case 'v':
                        ++vCount;
                        break;

                    case 'w':
                        ++wCount;
                        break;

                    case 'x':
                        ++xCount;
                        break;

                    case 'y':
                        ++yCount;
                        break;

                    case 'z':
                        ++zCount;
                        break;

                    default:
                        break;
                }

                DisplayLetterCount();
            }
        }

        private void DisplayLetterCount()
        {
            ClearForm();
            string outputStr = "";

            outputStr += ($"a - {aCount}\r\t");
            outputStr += ($"b - {bCount}\r\t");
            outputStr += ($"c - {cCount}\r\t");
            outputStr += ($"d - {dCount}\r\t");
            outputStr += ($"e - {eCount}\r\t");
            outputStr += ($"f - {fCount}\r\t\r\n");
            outputStr += ($"g - {gCount}\r\t");
            outputStr += ($"h - {hCount}\r\t");
            outputStr += ($"i - {iCount}\r\t");
            outputStr += ($"j - {jCount}\r\t");
            outputStr += ($"k - {kCount}\r\t");
            outputStr += ($"l - {lCount}\r\t\r\n");
            outputStr += ($"m - {mCount}\r\t");
            outputStr += ($"n - {nCount}\r\t");
            outputStr += ($"o - {oCount}\r\t");
            outputStr += ($"p - {pCount}\r\t");
            outputStr += ($"q - {qCount}\r\t");
            outputStr += ($"r - {rCount}\r\t\r\n");
            outputStr += ($"s - {sCount}\r\t");
            outputStr += ($"t - {tCount}\r\t");
            outputStr += ($"u - {uCount}\r\t");
            outputStr += ($"v - {vCount}\r\t");
            outputStr += ($"w - {wCount}\r\t");
            outputStr += ($"x - {xCount}\r\t\r\n");
            outputStr += ($"y - {yCount}\r\t");
            outputStr += ($"z - {zCount}\r\t");

            txtResults.Text = outputStr;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtResults.Text = "";
            txtResults.Focus();
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

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
