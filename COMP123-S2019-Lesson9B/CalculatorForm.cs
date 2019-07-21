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
    public partial class CalculatorForm : Form
    {
        // Class properties
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }
        public Label ActiveLabel { get; set; }


        /// <summary>
        /// this is the constructor for the CalculatorForm
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this is the event handler for the form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            clearNumericKeyboard();
            ActiveLabel = null;
            CalculatorButtonTableLayoutPanel.Visible = false;
        }

        /// <summary>
        /// this is the event handler for the CalculatorForm Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Click(object sender, EventArgs e)
        {
            clearNumericKeyboard();
            ActiveLabel = null;
            if (ActiveLabel != null)
            {
                ActiveLabel.BackColor = Color.White;
            }
            CalculatorButtonTableLayoutPanel.Visible = false;
        }

        /// <summary>
        /// this is the shared event handler for all the calculator buttons - click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button;
            var tag = TheButton.Tag.ToString();

            int buttonValue;
            bool numericResult = int.TryParse(tag, out buttonValue);

            //If the user pressed a number button 
            if (numericResult)
            {
                int maxSize = 3;
                if (decimalExists)
                {
                    maxSize = 5;
                }
                //int maxSize = (decimalExists) ? 5 : 3;

                //if (outputString == "0")
                //{
                //    outputString = tag;
                //}

                if ((outputString != "0") && (ResultLabel.Text.Count() < maxSize))
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }
            }

            // if the user pressed a button that is not a number
            else
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
        /// this method adds a decimal point  to the resultLabel
         /// </summary>
        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }

        /// <summary>
        /// this method finalizes and converts the outputString to a floating point value
        /// </summary>
        private void finalizeOutput()
        {
            if (outputString == string.Empty)
            {
                outputString = "0";
            }

            if (outputValue < 0.1f)
            { 
                outputValue = 0.1f;
            }
            outputValue = float.Parse(outputString);

            outputValue = (float)(Math.Round(outputValue, 1));
            ActiveLabel.Text = outputValue.ToString();
            clearNumericKeyboard();

            ActiveLabel.BackColor = Color.White;
            ActiveLabel = null;
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
            if (outputString.Length == 0)
            {
                outputString = "0";
            }
            ResultLabel.Text = outputString;
        }
         /// <summary>
         /// this method resets the numeric keyboard and related variables 
         /// </summary>
        private void clearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = String.Empty;
            decimalExists = false;
            outputValue = 0.0f;
        }

        /// <summary>
        /// this is the event handler for the HeightLabel click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveLabel_Click(object sender, EventArgs e)
        {
            if (ActiveLabel != null)
            {
                ActiveLabel.BackColor = Color.White;
                ActiveLabel = null;
            }

            ActiveLabel = sender as Label;

            ActiveLabel.BackColor = Color.LightBlue;

            CalculatorButtonTableLayoutPanel.Visible = true;

            if (ActiveLabel.Text != "0")
            {
                ResultLabel.Text = ActiveLabel.Text;
                outputString = ActiveLabel.Text;
            }
        }

      
    }
}
