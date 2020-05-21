using System;
using System.Windows.Forms;

namespace Tema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isNewEntry = false, isRepeatLastOperation = false;
        double result = 0, operand = 0;
        char previousOperator = new char();

        public void disable()
        {
            txtBox.Enabled = false;
            btnOff.Hide();  
            btnOn.Show();
            btn0.Enabled = false;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btnPercent.Enabled = false;
            btnPow.Enabled = false;
            btnReverse.Enabled = false;
            btnSqrt.Enabled = false;
            btnAddition.Enabled = false;
            btnClear.Enabled = false;
            btnDelete.Enabled = false;
            btnDivison.Enabled = false;
            btnEqual.Enabled = false;
            btnMinus.Enabled = false;
            btnMultiplication.Enabled = false;
            btnNegative.Enabled = false;
            btnPoint.Enabled = false;
        }

        public void enable()
        {
            txtBox.Enabled = true;
            btnOff.Show();  
            btnOn.Hide();  
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnPercent.Enabled = true;
            btnPow.Enabled = true;
            btnReverse.Enabled = true;
            btnSqrt.Enabled = true;
            btnAddition.Enabled = true;
            btnClear.Enabled = true;
            btnDelete.Enabled = true;
            btnDivison.Enabled = true;
            btnEqual.Enabled = true;
            btnMinus.Enabled = true;
            btnMultiplication.Enabled = true;
            btnNegative.Enabled = true;
            btnPoint.Enabled = true;
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            enable();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            disable();
        }


        private void UpdateOperand(object sender, EventArgs e)
        {
            if (isNewEntry)
            {
                txtBox.Text = "0";
                isNewEntry = false;
            }
            if (isRepeatLastOperation)
            {
                previousOperator = '\0';
                result = 0;
            }
            if (!(txtBox.Text == "0" && (Button)sender == btn0) && !(((Button)sender) == btnPoint && txtBox.Text.Contains(".")))
                txtBox.Text = (txtBox.Text == "0" && ((Button)sender) == btnPoint) ? "0." : ((txtBox.Text == "0") ? ((Button)sender).Text : txtBox.Text + ((Button)sender).Text);
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!isRepeatLastOperation)
            {
                operand = double.Parse(txtBox.Text);
                isRepeatLastOperation = true;
            }
            operate(result, previousOperator, operand);
            isNewEntry = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            operand = result = 0; 
            txtBox.Text = "0";
            lbl.Text = "";
            isRepeatLastOperation = false;
            previousOperator = '\0';
            isNewEntry = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
            result = double.Parse(txtBox.Text);
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            txtBox.Text = (float.Parse(txtBox.Text) * -1).ToString();
            result = double.Parse(txtBox.Text);
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            lbl.Text = txtBox.Text + " ^ 2 = ";
            txtBox.Text = (result = Math.Pow(double.Parse(txtBox.Text), 2)).ToString();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            lbl.Text = "1 / " + txtBox.Text + " =";
            txtBox.Text = (result = 1 / double.Parse(txtBox.Text)).ToString();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            lbl.Text = "sqrt "+ txtBox.Text + " = ";
            txtBox.Text = (result = Math.Sqrt(double.Parse(txtBox.Text))).ToString();
        }

        private void OperatorFound(object sender, EventArgs e)
        {
            if (previousOperator == '\0')
            {
                previousOperator = ((Button)sender).Text[0];
                result = double.Parse(txtBox.Text);
            }

            else if (isNewEntry)                    //daca apas din greseala pe + de ex si vreau - atunci e ok
                previousOperator = ((Button)sender).Text[0];
            else
            {
                operate(result, previousOperator, double.Parse(txtBox.Text));
                previousOperator = ((Button)sender).Text[0];
            }
            isNewEntry = true;
            isRepeatLastOperation = false;

        }

        void operate(double dblPreviousResult, char chPreviousOperator, double dblOperand)
        {
            switch (chPreviousOperator)
            {
                case '+':
                    lbl.Text = dblPreviousResult + "+" +dblOperand + "=" ;
                    txtBox.Text = (result = (dblPreviousResult + dblOperand)).ToString();
                    break;

                case '-':
                    lbl.Text = dblPreviousResult + "-" + dblOperand + "=";
                    txtBox.Text = (result = (dblPreviousResult - dblOperand)).ToString();
                    break;

                case '*':
                    lbl.Text = dblPreviousResult + "*" + dblOperand + "=";
                    txtBox.Text = (result = (dblPreviousResult * dblOperand)).ToString();
                    break;

                case '%':
                    lbl.Text = dblPreviousResult + "%" + dblOperand + "=";
                    txtBox.Text = (result = (dblPreviousResult / 100 * dblOperand)).ToString();
                    break;

                case '/':
                    lbl.Text = dblPreviousResult + "/" + dblOperand + "=";
                    if (dblOperand == 0)
                    {
                        txtBox.Text = "Cannot divide by zero";
                        result = 0;
                    }
                    if(dblOperand != 0)
                        txtBox.Text = (result = (dblPreviousResult / dblOperand)).ToString();
                    break;
            }
        }
    }
}