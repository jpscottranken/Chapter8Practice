using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*
 *      4.	Employee Records (List):
 *          A company wants to keep track of its employees' info
 *          such as first name, last name, salary, and department.
 *          Write a C# program to create a different list for each
 *          of the 	four fields above, representing an employee.
 *          
 *          Allow the use to add new employees, modify existing
 *          employees, delete existing employees, and display
 *          all employees.
 */

namespace Practice08_04
{
    public partial class frmEmployees : Form
    {
        //  Declare and initialize program constants
        const decimal MINSALARY =       0m;
        const decimal MAXSALARY = 1000000m;

        //  Declare class variables
        List<string> firstNames   = new List<string>();
        List<string> lastNames    = new List<string>();
        List<decimal> salaries    = new List<decimal>();
        List<string> departments  = new List<string>();

        public frmEmployees()
        {
            InitializeComponent();

            lvEmployees.View = View.Details;
            lvEmployees.Columns.Add("First Name", 250);
            lvEmployees.Columns.Add("Last Name", 250);
            lvEmployees.Columns.Add("Salary", 250);
            lvEmployees.Columns.Add("Department", 250);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool keepGoing = ValidateEmployee();

            if (keepGoing)
            {
                AddNewEmployee();
            }
        }

        private void AddNewEmployee()
        {
            string firstName  = txtFirstName.Text;
            string lastName   = txtLastName.Text;
            decimal salary    = decimal.Parse(txtSalary.Text);
            string department = txtDepartment.Text;

            firstNames.Add(firstName);
            lastNames.Add(lastName);
            salaries.Add(salary);
            departments.Add(department);

            ClearForm();
            UpdateListView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (firstNames.Count <= 0)
            {
                ShowErrorMessage("No Employee To Update",
                                 "LIST IS EMPTY");
                btnUpdate.Enabled = false;
                return;
            }
            else
            {
                btnUpdate.Enabled = true;

                bool keepGoing = ValidateEmployee();
                if (keepGoing)
                {
                    UpdateExistingEmployee();
                }
            }
        }

        private void UpdateExistingEmployee()
        {
            int selectedIndex = lvEmployees.SelectedIndices[0];

            firstNames[selectedIndex]  = txtFirstName.Text;
            lastNames[selectedIndex]   = txtLastName.Text;
            salaries[selectedIndex]    = decimal.Parse(txtSalary.Text);
            departments[selectedIndex] = txtDepartment.Text;

            ClearForm();
            UpdateListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (firstNames.Count <= 0)
            {
                ShowErrorMessage("No Employee To Delete",
                                 "LIST IS EMPTY");
                btnDelete.Enabled = false;
                return;
            }
            else
            {
                btnDelete.Enabled = true;
                DeleteExistingEmployee();
            }
        }

        private void DeleteExistingEmployee()
        {
            int selectedIndex = lvEmployees.SelectedIndices[0];

            DialogResult dialog = MessageBox.Show(
                        "Do You Really Want To Delete Employee This Employee?",
                        "DELETE EMPLOYEE?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                firstNames.RemoveAt(selectedIndex);
                lastNames.RemoveAt(selectedIndex);
                salaries.RemoveAt(selectedIndex);
                departments.RemoveAt(selectedIndex);

                ClearForm();
                UpdateListView();
            }
        }

        private bool ValidateEmployee()
        {
            bool result;
            decimal salary = 0m;

            try
            {
                if (txtFirstName.Text.Trim() == "")
                {
                    throw new ArgumentNullException();
                }

                if (txtLastName.Text.Trim() == "")
                {
                    throw new ArgumentNullException();
                }

                if (txtSalary.Text.Trim() == "")
                {
                    throw new ArgumentNullException();
                }

                result = decimal.TryParse(txtSalary.Text.Trim(), out salary);
                if (!result)
                {
                    throw new FormatException();
                }

                if (salary < MINSALARY || salary > MAXSALARY)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (txtDepartment.Text.Trim() == "")
                {
                    throw new ArgumentNullException();
                }

                return true;
            }
            catch (ArgumentNullException ane)
            {
                ShowErrorMessage("System Message:\t" + "\n" +
                                 ane.Message + "\n\n" +
                                 "Field Cannot Be Left Empty",
                                 "ARGUMENTNULLEXCEPTION");
                return false;
            }

            catch (FormatException fe)
            {
                ShowErrorMessage("System Message:\t" + "\n" +
                                 fe.Message + "\n\n" +
                                 "Field Must Contain A Valid Salary (" +
                                 MINSALARY.ToString("c") + " - " +
                                 MAXSALARY.ToString("c") + ")",
                                 "FORMATEXCEPTION");
                return false;
            }

            catch (ArgumentOutOfRangeException aoore)
            {
                ShowErrorMessage("System Message:\t" + "\n" +
                                 aoore.Message + "\n\n" +
                                 "Field Must Contain A Valid Salary (" +
                                 MINSALARY.ToString("c") + " - " +
                                 MAXSALARY.ToString("c") + ")",
                                 "ARGUMENTOUTOFRANGEEXCEPTION");
                return false;
            }
        }

        private void UpdateListView()
        {
            lvEmployees.Items.Clear();

            for (int i = 0; i < firstNames.Count; i++)
            {
                ListViewItem item = new ListViewItem(firstNames[i]);
                item.SubItems.Add(lastNames[i]);
                item.SubItems.Add(salaries[i].ToString());
                item.SubItems.Add(departments[i]);
                lvEmployees.Items.Add(item);
            }

            if (firstNames.Count > 0)
            {
                EnableUpdateAndDeleteButtons();
            }
            else
            {
                DisableUpdateAndDeleteButtons();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSalary.Text = "";
            txtDepartment.Text = "";
            txtFirstName.Focus();
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

        private void lvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewChanged();
        }

        private void ListViewChanged()
        {
            if (lvEmployees.SelectedIndices.Count > 0)
            {
                int selectedIndex = lvEmployees.SelectedIndices[0];
                txtFirstName.Text = firstNames[selectedIndex];
                txtLastName.Text = lastNames[selectedIndex];
                txtSalary.Text = salaries[selectedIndex].ToString();
                txtDepartment.Text = departments[selectedIndex];
            }
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            UserMessage();
            DisableUpdateAndDeleteButtons();
        }

        private void DisableUpdateAndDeleteButtons()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void EnableUpdateAndDeleteButtons()
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void UserMessage()
        {
            ShowErrorMessage("To Update Or Delete An Existing Record\n" +
                             "Click On That Record's First Name To 'Activate'",
                             "PLEASE READ THIS CAREFULLY!");
        }
    }
}
