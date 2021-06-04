using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Regex dayRegex = new Regex("[0-9]+");
        public Form1()
        {
            InitializeComponent();
        }

        public int DaysInMonth(int year, int month)
        {
            int dim = year / month;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (year % 400 == 0)
                    {
                        return 29;
                    }
                    else
                    {
                        if (year % 100 == 0)
                        {
                            return 28;
                        }
                        else
                        {
                            if (year % 4 == 0)
                            {
                                return 29;
                            }
                            else
                            {
                                return 28;
                            }
                        }
                    }
                default:
                    return 0;
            }
        }

        public Boolean IsValidDate(int year, int month, int day)
        {
            if (month >= 1 && month <= 12)
            {
                if (day >= 1)
                {
                    if (day <= DaysInMonth(year, month))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            day.Text = "";
            month.Text = "";
            year.Text = "";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int y = int.Parse(year.Text);
            int m = int.Parse(month.Text);
            int d = int.Parse(day.Text);
            try
            {
                if (!dayRegex.IsMatch(day.Text))
                {
                    MessageBox.Show("Input data for Day is incorrect format!");
                }
                if (!dayRegex.IsMatch(month.Text))
                {
                    MessageBox.Show("Input data for Month is incorrect format!");
                }
                if (!dayRegex.IsMatch(year.Text))
                {
                    MessageBox.Show("Input data for Year is incorrect format!");
                }
                if (d < 1 && d > 31)
                {
                    MessageBox.Show("Input data for Day is out of range!");
                }
                if (m < 1 && d > 12)
                {
                    MessageBox.Show("Input data for Month is out of range!");
                }
                if (y < 1000 && y > 3000)
                {
                    MessageBox.Show("Input data for Year is out of range!");
                }
                if (IsValidDate(y, m, d))
                {
                    MessageBox.Show(day.Text + "/" + month.Text + "/" + year.Text + " is correct day time!");
                }
                else
                {
                    MessageBox.Show(day.Text + "/" + month.Text + "/" + year.Text + " is NOT correct day time!");
                }
            }
            catch (Exception) { }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "My Application",
            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
