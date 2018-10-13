namespace CalProfileAndDataView
{
    partial class frmBasedOriginal
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
            this.labelNote = new System.Windows.Forms.Label();
            this.textBoxBeyondHeight = new System.Windows.Forms.TextBox();
            this.comboBoxHeightUnit = new System.Windows.Forms.ComboBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(12, 9);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(263, 12);
            this.labelNote.TabIndex = 0;
            this.labelNote.Text = "Set the length beyond the original profile!";
            // 
            // textBoxBeyondHeight
            // 
            this.textBoxBeyondHeight.Location = new System.Drawing.Point(40, 48);
            this.textBoxBeyondHeight.Name = "textBoxBeyondHeight";
            this.textBoxBeyondHeight.Size = new System.Drawing.Size(96, 21);
            this.textBoxBeyondHeight.TabIndex = 1;
            this.textBoxBeyondHeight.Text = "0";
            this.textBoxBeyondHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBeyondHeight_KeyPress);
            // 
            // comboBoxHeightUnit
            // 
            this.comboBoxHeightUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHeightUnit.FormattingEnabled = true;
            this.comboBoxHeightUnit.Items.AddRange(new object[] {
            "M",
            "KM",
            "FEET"});
            this.comboBoxHeightUnit.Location = new System.Drawing.Point(142, 48);
            this.comboBoxHeightUnit.Name = "comboBoxHeightUnit";
            this.comboBoxHeightUnit.Size = new System.Drawing.Size(79, 20);
            this.comboBoxHeightUnit.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(25, 96);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(111, 23);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(142, 96);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // frmBasedOriginal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxHeightUnit);
            this.Controls.Add(this.textBoxBeyondHeight);
            this.Controls.Add(this.labelNote);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 196);
            this.MinimumSize = new System.Drawing.Size(300, 196);
            this.Name = "frmBasedOriginal";
            this.Text = "BasedOriginal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox textBoxBeyondHeight;
        private System.Windows.Forms.ComboBox comboBoxHeightUnit;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
    }
}