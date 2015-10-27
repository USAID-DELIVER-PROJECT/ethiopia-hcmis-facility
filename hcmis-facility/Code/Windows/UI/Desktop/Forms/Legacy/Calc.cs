using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PharmInventory
{
    public partial class Calc : UserControl
    {
        public Calc()
        {
            InitializeComponent();
        }

        decimal operand1 = 0;
        decimal operand2 = 0;
        string ope = "";
        decimal result = 0;

        private void Calc_Load(object sender, EventArgs e)
        {

        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            
            txtCalcResult.Text = (txtCalcResult.Text != "0")? txtCalcResult.Text + "3": "3";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "2" : "2";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "1" : "1";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "0" : "0";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "4" : "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "5" : "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "6" : "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "7" : "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "8" : "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = (txtCalcResult.Text != "0") ? txtCalcResult.Text + "9" : "9";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ope = "+";
            if (operand1 != 0 && operand2 == 0)
            {
                operand2 = Convert.ToDecimal(txtCalcResult.Text);
                result = operand1 + operand2;
                operand2 = 0;
            }
            else if (operand1 != 0 && operand2 != 0)
            {
                result = operand1 + operand2;
                operand2 = 0;
                txtCalcResult.Text = "";
            }
            else
            {
                operand1 = Convert.ToDecimal(txtCalcResult.Text);
                txtCalcResult.Text = "";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            operand2 = Convert.ToDecimal(txtCalcResult.Text);
            if (operand1 != 0 && operand2 != 0)
            {
                if (ope == "+")
                    result = operand1 + operand2;
                else if(ope == "-")
                    result = operand1 - operand2;
                else if(ope == "*")
                    result = operand1 * operand2;
                else if(ope == "/")
                    result = operand1 / operand2;
            }
            txtCalcResult.Text = result.ToString();
            operand1 = result;
            operand2 = 0;

        }

        private void btnMinius_Click(object sender, EventArgs e)
        {
            ope = "-";
            if (operand1 != 0)
            {
                operand2 = Convert.ToDecimal(txtCalcResult.Text);
                result = operand1 - operand2;
                txtCalcResult.Text = result.ToString();
                operand2 = 0;
            }
            else
            {
                operand1 = Convert.ToDecimal(txtCalcResult.Text);
                txtCalcResult.Text = "";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            ope = "*";
            if (operand1 != 0)
            {
                operand2 = Convert.ToDecimal(txtCalcResult.Text);
                result = operand1 * operand2;
                txtCalcResult.Text = result.ToString();
                operand2 = 0;
            }
            else
            {
                operand1 = Convert.ToDecimal(txtCalcResult.Text);
                txtCalcResult.Text = "";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            ope = "/";
            if (operand1 != 0)
            {
                operand2 = Convert.ToDecimal(txtCalcResult.Text);
                result = operand1 / operand2;
                txtCalcResult.Text = result.ToString();
                operand2 = 0;
            }
            else
            {
                operand1 = Convert.ToDecimal(txtCalcResult.Text);
                txtCalcResult.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCalcResult.Text = "0";
            operand1 = 0;
            operand2 = 0;
            ope = "";
            result = 0;
        }
    }
}
