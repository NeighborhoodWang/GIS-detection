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

    public delegate void ShiftProfileDelegrate(double step, string direction, string SelProfile);
    public partial class FrmShiftPad : Form
    {

        public event ShiftProfileDelegrate ShiftProfileEvent;
        public FrmShiftPad()
        {
            InitializeComponent();
        }

        private void FrmShiftPad_Load(object sender, EventArgs e)
        {
            comboBoxSelProfile.SelectedItem = "Forward";
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            ShiftProfileEvent((double)numericUpDownStep.Value, "up", (string)comboBoxSelProfile.SelectedItem);
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            ShiftProfileEvent((double)numericUpDownStep.Value, "left", (string)comboBoxSelProfile.SelectedItem);
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            ShiftProfileEvent((double)numericUpDownStep.Value, "right", (string)comboBoxSelProfile.SelectedItem);
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            ShiftProfileEvent((double)numericUpDownStep.Value, "down", (string)comboBoxSelProfile.SelectedItem);
        }

    }
}
