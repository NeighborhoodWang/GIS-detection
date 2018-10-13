namespace CalProfileAndDataView
{
    partial class frmViewLine
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceLine = new System.Windows.Forms.BindingSource(this.components);
            this.labelTrack = new System.Windows.Forms.Label();
            this.textBoxTrackView = new System.Windows.Forms.TextBox();
            this.labelTolerance = new System.Windows.Forms.Label();
            this.textBoxTolerance = new System.Windows.Forms.TextBox();
            this.comboBoxMeasureUnit = new System.Windows.Forms.ComboBox();
            this.buttonAddLineFromFile = new System.Windows.Forms.Button();
            this.buttonCalProfile = new System.Windows.Forms.Button();
            this.buttonSaveLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLine)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnLatitude,
            this.ColumnLongitude,
            this.ColumnName});
            this.dataGridView1.DataSource = this.bindingSourceLine;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(444, 228);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ID";
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnLatitude
            // 
            this.ColumnLatitude.DataPropertyName = "latitude";
            this.ColumnLatitude.HeaderText = "Latitude";
            this.ColumnLatitude.Name = "ColumnLatitude";
            this.ColumnLatitude.ReadOnly = true;
            // 
            // ColumnLongitude
            // 
            this.ColumnLongitude.DataPropertyName = "longitude";
            this.ColumnLongitude.HeaderText = "Longitude";
            this.ColumnLongitude.Name = "ColumnLongitude";
            this.ColumnLongitude.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // labelTrack
            // 
            this.labelTrack.AutoSize = true;
            this.labelTrack.Location = new System.Drawing.Point(13, 235);
            this.labelTrack.Name = "labelTrack";
            this.labelTrack.Size = new System.Drawing.Size(41, 12);
            this.labelTrack.TabIndex = 1;
            this.labelTrack.Text = "Track:";
            // 
            // textBoxTrackView
            // 
            this.textBoxTrackView.Location = new System.Drawing.Point(54, 232);
            this.textBoxTrackView.Name = "textBoxTrackView";
            this.textBoxTrackView.ReadOnly = true;
            this.textBoxTrackView.Size = new System.Drawing.Size(392, 21);
            this.textBoxTrackView.TabIndex = 2;
            // 
            // labelTolerance
            // 
            this.labelTolerance.AutoSize = true;
            this.labelTolerance.Location = new System.Drawing.Point(13, 263);
            this.labelTolerance.Name = "labelTolerance";
            this.labelTolerance.Size = new System.Drawing.Size(65, 12);
            this.labelTolerance.TabIndex = 3;
            this.labelTolerance.Text = "Tolerance:";
            // 
            // textBoxTolerance
            // 
            this.textBoxTolerance.Location = new System.Drawing.Point(79, 260);
            this.textBoxTolerance.Name = "textBoxTolerance";
            this.textBoxTolerance.Size = new System.Drawing.Size(100, 21);
            this.textBoxTolerance.TabIndex = 4;
            this.textBoxTolerance.Text = "0";
            this.textBoxTolerance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTolerance_KeyPress);
            // 
            // comboBoxMeasureUnit
            // 
            this.comboBoxMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMeasureUnit.FormattingEnabled = true;
            this.comboBoxMeasureUnit.Location = new System.Drawing.Point(185, 259);
            this.comboBoxMeasureUnit.Name = "comboBoxMeasureUnit";
            this.comboBoxMeasureUnit.Size = new System.Drawing.Size(56, 20);
            this.comboBoxMeasureUnit.TabIndex = 5;
            // 
            // buttonAddLineFromFile
            // 
            this.buttonAddLineFromFile.Location = new System.Drawing.Point(15, 290);
            this.buttonAddLineFromFile.Name = "buttonAddLineFromFile";
            this.buttonAddLineFromFile.Size = new System.Drawing.Size(128, 23);
            this.buttonAddLineFromFile.TabIndex = 6;
            this.buttonAddLineFromFile.Text = "Add Line from file";
            this.buttonAddLineFromFile.UseVisualStyleBackColor = true;
            this.buttonAddLineFromFile.Click += new System.EventHandler(this.buttonAddLineFromFile_Click);
            // 
            // buttonCalProfile
            // 
            this.buttonCalProfile.Location = new System.Drawing.Point(302, 290);
            this.buttonCalProfile.Name = "buttonCalProfile";
            this.buttonCalProfile.Size = new System.Drawing.Size(115, 23);
            this.buttonCalProfile.TabIndex = 7;
            this.buttonCalProfile.Text = "Caculate Profile";
            this.buttonCalProfile.UseVisualStyleBackColor = true;
            this.buttonCalProfile.Click += new System.EventHandler(this.buttonCalProfile_Click);
            // 
            // buttonSaveLine
            // 
            this.buttonSaveLine.Location = new System.Drawing.Point(161, 290);
            this.buttonSaveLine.Name = "buttonSaveLine";
            this.buttonSaveLine.Size = new System.Drawing.Size(122, 23);
            this.buttonSaveLine.TabIndex = 8;
            this.buttonSaveLine.Text = "Save Line";
            this.buttonSaveLine.UseVisualStyleBackColor = true;
            this.buttonSaveLine.Click += new System.EventHandler(this.buttonSaveLine_Click);
            // 
            // frmViewLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 339);
            this.Controls.Add(this.buttonSaveLine);
            this.Controls.Add(this.buttonCalProfile);
            this.Controls.Add(this.buttonAddLineFromFile);
            this.Controls.Add(this.comboBoxMeasureUnit);
            this.Controls.Add(this.textBoxTolerance);
            this.Controls.Add(this.labelTolerance);
            this.Controls.Add(this.textBoxTrackView);
            this.Controls.Add(this.labelTrack);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(463, 377);
            this.MinimumSize = new System.Drawing.Size(463, 377);
            this.Name = "frmViewLine";
            this.Text = "ViewLine";
            this.Load += new System.EventHandler(this.ViewLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSourceLine;
        private System.Windows.Forms.Label labelTrack;
        private System.Windows.Forms.TextBox textBoxTrackView;
        private System.Windows.Forms.Label labelTolerance;
        private System.Windows.Forms.TextBox textBoxTolerance;
        private System.Windows.Forms.ComboBox comboBoxMeasureUnit;
        private System.Windows.Forms.Button buttonAddLineFromFile;
        private System.Windows.Forms.Button buttonCalProfile;
        private System.Windows.Forms.Button buttonSaveLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
    }
}