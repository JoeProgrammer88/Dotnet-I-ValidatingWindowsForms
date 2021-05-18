using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotnet_I_ValidatingWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                MessageBox.Show("All data was valid");
            }
            else
            {
                MessageBox.Show("There is some invalid data");
            }
        }

        private void TxtAge_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToByte(txtAge.Text);
                errProvider.SetError(txtAge, string.Empty);
            }
            catch (FormatException)
            {
                errProvider.SetError(txtAge, "Age must be a number. Ex. 30");
                e.Cancel = true; // Setting the Cancel property to true, marks control as invalid
            }
            catch (OverflowException)
            {
                errProvider.SetError(txtAge, "Age must be between 0 - 255");
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // By default AutoValidate will prevent invalid controls from
            // losing focus. This can be disabled completely or changed to
            // allow focus to move to another control, as shown here.
            AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (!IsPresent(txtName))
            {
                e.Cancel = true;
                errProvider.SetError(txtName, "Name is required");
            }
            else
            {
                errProvider.SetError(txtName, string.Empty);
            }
        }

        /// <summary>
        /// Returns true if textbox text is not a null
        /// or whitespace
        /// </summary>
        /// <param name="box">The textbox to validate</param>
        private bool IsPresent(TextBox box)
        {
            if (!string.IsNullOrWhiteSpace(box.Text))
            {
                return true;
            }

            return false;
        }
    }
}
