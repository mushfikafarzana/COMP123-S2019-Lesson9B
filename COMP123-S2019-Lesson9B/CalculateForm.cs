using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson9B
{
    public partial class CalculateForm : Form
    {
        // Class properties
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }


        /// <summary>
        /// this is the constructor for the calculator form
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this is the shared event handler for all the calculator buttons - click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button;

            //int buttonValue;
            //bool resultCondition = int.TryParse(TheButton.Text, out buttonValue);

            //if (resultCondition)
            //{
            //    ResultLabel.Text += buttonValue;
            //}
            //else
            //{
            //    ResultLabel.Text = "Not a Number(NAN)";
            //}

            var tag = TheButton.Tag.ToString();
            int buttonValue;
            bool resultCondition = int.TryParse(tag, out buttonValue);

            //If the user pressed a number button 
            if (resultCondition)
            {
                int maxSize = 3;
                if (decimalExists)
                {
                    maxSize = 5;
                }
                if ((ResultLabel.Text.Count() < maxSize) && (outputString != "0"))
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }
                
            }

            if (!resultCondition)
            {
                switch (tag)
                {
                    case "clear":
                        clearNumericKeyboard();
                        break;
                    case "back":
                        removeLastCharacterFromResultLabel();
                        break;
                    case "done":
                        finalizeOutput();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }
        }

        /// <summary>
        /// this method adds decimal to the resultLabel
        /// </summary>
        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                if (ResultLabel.Text == "0")
                {
                    outputString += "0";
                }
                outputString += ".";
                decimalExists = true;
            }
        }

        /// <summary>
        /// this method finalizes the output for the result label
        /// </summary>
        private void finalizeOutput()
        {
            if (outputString == string.Empty)
            {
                outputString = "0";
            }
            outputValue = float.Parse(outputString);
            HeightLabel.Text = outputValue.ToString();
        }

        /// <summary>
        /// this method removes the last character from the resultLabel
        /// </summary>
        private void removeLastCharacterFromResultLabel()
            
        {
            var lastChar = outputString.Substring(outputString.Length - 1);
            if (lastChar == ".")
            {
                decimalExists = false;
            }
            outputString = outputString.Remove(outputString.Length - 1);
            ResultLabel.Text = outputString;
        }

        private void clearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = String.Empty;
            decimalExists = false;
            outputValue = 0.0f;
            CalculatorButtonTableLayoutPanel.Visible = false;
        }

        private void CalculateForm_Load(object sender, EventArgs e)
        {
            clearNumericKeyboard();
        }

        private void HeightLabel_Click(object sender, EventArgs e)
        {
            CalculatorButtonTableLayoutPanel.Visible = true;
        }
    }
}
