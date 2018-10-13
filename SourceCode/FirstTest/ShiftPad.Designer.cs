namespace CalProfileAndDataView
{
    partial class FrmShiftPad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.labelNote = new System.Windows.Forms.Label();
            this.labelNoteAppend = new System.Windows.Forms.Label();
            this.LabelSelect = new System.Windows.Forms.Label();
            this.comboBoxSelProfile = new System.Windows.Forms.ComboBox();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.labelSelStep = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(103, 78);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(75, 65);
            this.ButtonUp.TabIndex = 0;
            this.ButtonUp.Text = "Up";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.Location = new System.Drawing.Point(9, 157);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(75, 65);
            this.ButtonLeft.TabIndex = 1;
            this.ButtonLeft.Text = "Left";
            this.ButtonLeft.UseVisualStyleBackColor = true;
            this.ButtonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
            // 
            // ButtonRight
            // 
            this.ButtonRight.Location = new System.Drawing.Point(194, 157);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(75, 65);
            this.ButtonRight.TabIndex = 2;
            this.ButtonRight.Text = "Right";
            this.ButtonRight.UseVisualStyleBackColor = true;
            this.ButtonRight.Click += new System.EventHandler(this.ButtonRight_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(103, 236);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(75, 67);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.Text = "Down\r\n";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(25, 9);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(233, 12);
            this.labelNote.TabIndex = 4;
            this.labelNote.Text = "You can shift the entirely new profile";
            // 
            // labelNoteAppend
            // 
            this.labelNoteAppend.AutoSize = true;
            this.labelNoteAppend.Location = new System.Drawing.Point(25, 21);
            this.labelNoteAppend.Name = "labelNoteAppend";
            this.labelNoteAppend.Size = new System.Drawing.Size(71, 12);
            this.labelNoteAppend.TabIndex = 5;
            this.labelNoteAppend.Text = "up or down!";
            // 
            // LabelSelect
            // 
            this.LabelSelect.AutoSize = true;
            this.LabelSelect.Location = new System.Drawing.Point(25, 35);
            this.LabelSelect.Name = "LabelSelect";
            this.LabelSelect.Size = new System.Drawing.Size(227, 12);
            this.LabelSelect.TabIndex = 7;
            this.LabelSelect.Text = "Select the profile you want to shift!";
            // 
            // comboBoxSelProfile
            // 
            this.comboBoxSelProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelProfile.FormattingEnabled = true;
            this.comboBoxSelProfile.Items.AddRange(new object[] {
            "Backward",
            "Forward"});
            this.comboBoxSelProfile.Location = new System.Drawing.Point(27, 51);
            this.comboBoxSelProfile.Name = "comboBoxSelProfile";
            this.comboBoxSelProfile.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSelProfile.TabIndex = 8;
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.DecimalPlaces = 2;
            this.numericUpDownStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownStep.Location = new System.Drawing.Point(103, 181);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(75, 21);
            this.numericUpDownStep.TabIndex = 9;
            // 
            // labelSelStep
            // 
            this.labelSelStep.AutoSize = true;
            this.labelSelStep.Location = new System.Drawing.Point(90, 166);
            this.labelSelStep.Name = "labelSelStep";
            this.labelSelStep.Size = new System.Drawing.Size(95, 12);
            this.labelSelStep.TabIndex = 10;
            this.labelSelStep.Text = "Select the step";
            // 
            // FrmShiftPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 321);
            this.Controls.Add(this.labelSelStep);
            this.Controls.Add(this.numericUpDownStep);
            this.Controls.Add(this.comboBoxSelProfile);
            this.Controls.Add(this.LabelSelect);
            this.Controls.Add(this.labelNoteAppend);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.ButtonRight);
            this.Controls.Add(this.ButtonLeft);
            this.Controls.Add(this.ButtonUp);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(299, 359);
            this.MinimumSize = new System.Drawing.Size(299, 359);
            this.Name = "FrmShiftPad";
            this.Text = "ShiftPad";
            this.Load += new System.EventHandler(this.FrmShiftPad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label labelNoteAppend;
        private System.Windows.Forms.Label LabelSelect;
        private System.Windows.Forms.ComboBox comboBoxSelProfile;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.Label labelSelStep;
    }
}