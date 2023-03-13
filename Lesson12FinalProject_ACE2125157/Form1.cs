using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson12FinalProject_ACE2125157;

namespace Lesson12FinalProject_ACE2125157
{
    public partial class Form1 : Form
    {
        private enum DISPLAY_MODE { CURRENT_VALUE, ACCUMULATOR, FRAC }
        private enum OPERATION { ADD, SUB, MUL, DIV }

        private int accumulator = 0;
        private OPERATION currentOperation = OPERATION.ADD;
        private int currentValue = 0;
        private DISPLAY_MODE displayMode = DISPLAY_MODE.CURRENT_VALUE;
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            switch (displayMode)
            {
                case DISPLAY_MODE.ACCUMULATOR:
                    textBox1.Text = accumulator.ToString();
                    break;

                case DISPLAY_MODE.CURRENT_VALUE:
                    textBox1.Text = currentValue.ToString();
                    GETFracNum(currentValue);
                    break;
            }

        }

        //get and store fraction value one
        //operator
        //get and store fraction value two
        // perform operation on fraction
        //display new fraction

        private void GETFracNum(int num)
        {
            Fraction myFrac = new Fraction();
            myFrac.SETFracNum(num);

        }

        private void NumberKeyHit(int number)
        {
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            currentValue = currentValue * 10 + number;
            UpdateDisplay();
        }

        private void FracKeyHit(string a)
        {
            displayMode = DISPLAY_MODE.FRAC;
            UpdateDisplay();
        }
        private void button0_Click(object sender, EventArgs e)
        {
            NumberKeyHit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberKeyHit(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberKeyHit(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumberKeyHit(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumberKeyHit(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumberKeyHit(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumberKeyHit(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumberKeyHit(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumberKeyHit(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumberKeyHit(9);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void OperationKeyHit(OPERATION op)
        {
            PerformOperation();
            currentOperation = op;
            currentValue = 0;
            UpdateDisplay();
        }

        private void PerformOperation()
        {
            switch (currentOperation)
            {
                case OPERATION.ADD:
                    accumulator += currentValue;
                    break;

                case OPERATION.SUB:
                    accumulator -= currentValue;
                    break;

                case OPERATION.MUL:
                    accumulator *= currentValue;
                    break;

                case OPERATION.DIV:
                    accumulator /= currentValue;
                    break;
            }
            currentValue = 0;
            displayMode = DISPLAY_MODE.ACCUMULATOR;
            UpdateDisplay();
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            OperationKeyHit(OPERATION.ADD);
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            PerformOperation();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            OperationKeyHit(OPERATION.SUB);

        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            OperationKeyHit(OPERATION.MUL);

        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            OperationKeyHit(OPERATION.DIV);

        }

        private void buttonFrac_Click(object sender, EventArgs e)
        {
             FracKeyHit("/");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            currentValue = 0;
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            UpdateDisplay();
        }
        private void buttonALLClear_Click(object sender, EventArgs e)
        {
            currentValue = 0;
            accumulator = 0;
            displayMode = DISPLAY_MODE.CURRENT_VALUE;
            currentOperation = OPERATION.ADD;
            UpdateDisplay();
        }

        
    }
}
