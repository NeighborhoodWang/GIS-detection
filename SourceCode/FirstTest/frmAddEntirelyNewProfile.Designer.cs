namespace CalProfileAndDataView
{
    partial class frmAddEntirelyNewProfile
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
            this.dataGridViewHeightDistance = new System.Windows.Forms.DataGridView();
            this.ColumnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNote = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHeightUnit = new System.Windows.Forms.ComboBox();
            this.comboBoxDistanceUnit = new System.Windows.Forms.ComboBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.buttonDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeightDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHeightDistance
            // 
            this.dataGridViewHeightDistance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHeightDistance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHeight,
            this.ColumnDistance});
            this.dataGridViewHeightDistance.Location = new System.Drawing.Point(21, 128);
            this.dataGridViewHeightDistance.Name = "dataGridViewHeightDistance";
            this.dataGridViewHeightDistance.RowTemplate.Height = 23;
            this.dataGridViewHeightDistance.Size = new System.Drawing.Size(245, 150);
            this.dataGridViewHeightDistance.TabIndex = 0;
            this.dataGridViewHeightDistance.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewHeightDistance_EditingControlShowing);
            // 
            // ColumnHeight
            // 
            this.ColumnHeight.HeaderText = "Height";
            this.ColumnHeight.Name = "ColumnHeight";
            // 
            // ColumnDistance
            // 
            this.ColumnDistance.HeaderText = "Distance";
            this.ColumnDistance.Name = "ColumnDistance";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(11, 9);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(269, 12);
            this.labelNote.TabIndex = 1;
            this.labelNote.Text = "Set The point in this new profile one by one";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select the unit of every direction";
            // 
            // comboBoxHeightUnit
            // 
            this.comboBoxHeightUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHeightUnit.FormattingEnabled = true;
            this.comboBoxHeightUnit.Items.AddRange(new object[] {
            "M",
            "KM",
            "FEET"});
            this.comboBoxHeightUnit.Location = new System.Drawing.Point(64, 102);
            this.comboBoxHeightUnit.Name = "comboBoxHeightUnit";
            this.comboBoxHeightUnit.Size = new System.Drawing.Size(66, 20);
            this.comboBoxHeightUnit.TabIndex = 3;
            // 
            // comboBoxDistanceUnit
            // 
            this.comboBoxDistanceUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDistanceUnit.FormattingEnabled = true;
            this.comboBoxDistanceUnit.Items.AddRange(new object[] {
            "M",
            "KM",
            "NM"});
            this.comboBoxDistanceUnit.Location = new System.Drawing.Point(161, 102);
            this.comboBoxDistanceUnit.Name = "comboBoxDistanceUnit";
            this.comboBoxDistanceUnit.Size = new System.Drawing.Size(66, 20);
            this.comboBoxDistanceUnit.TabIndex = 4;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(21, 285);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(83, 23);
            this.buttonSubmit.TabIndex = 5;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(186, 285);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Please Select The Direction";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Backward",
            "Forward"});
            this.comboBoxDirection.Location = new System.Drawing.Point(186, 35);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(94, 20);
            this.comboBoxDirection.TabIndex = 8;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(108, 285);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 9;
            this.buttonDel.Text = "Delete Row";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // frmAddEntirelyNewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 331);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.comboBoxDirection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxDistanceUnit);
            this.Controls.Add(this.comboBoxHeightUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.dataGridViewHeightDistance);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(308, 369);
            this.MinimumSize = new System.Drawing.Size(308, 369);
            this.Name = "frmAddEntirelyNewProfile";
            this.Text = "AddEntirelyNewProfile";
            this.Load += new System.EventHandler(this.frmAddEntirelyNewProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeightDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHeightDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDistance;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHeightUnit;
        private System.Windows.Forms.ComboBox comboBoxDistanceUnit;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.Button buttonDel;
    }
}