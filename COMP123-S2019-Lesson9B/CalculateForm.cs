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

            int buttonValue;
            bool resultCondition = int.TryParse(TheButton.Text, out buttonValue);

            if (resultCondition)
            {
                ResultLabel.Text += buttonValue;
            }
            else
            {
                ResultLabel.Text = "Not a Number(NAN)";
            }
        }
    }
}
