using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalProfileAndDataView
{
    public delegate void AddBasedOriginalProfileDelegrate(double beyondHeight);
    public partial class frmBasedOriginal : Form
    {
        public event AddBasedOriginalProfileDelegrate AddBasedOriginalProfileEvent;

        public frmBasedOriginal()
        {
            InitializeComponent();
            comboBoxHeightUnit.SelectedItem = "M";
        }

        private void textBoxBeyondHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                MessageBox.Show("Only Number Here!");
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if ((string)comboBoxHeightUnit.SelectedItem == "M")
            {
                AddBasedOriginalProfileEvent(Convert.ToDouble(textBoxBeyondHeight.Text));
                this.Close();
            }
            else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
            {
                AddBasedOriginalProfileEvent((Convert.ToDouble(textBoxBeyondHeight.Text)) * 1000);
                this.Close();
            }
            else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
            {
                AddBasedOriginalProfileEvent((Convert.ToDouble(textBoxBeyondHeight.Text)) * 0.3048);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Select A Unit");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
