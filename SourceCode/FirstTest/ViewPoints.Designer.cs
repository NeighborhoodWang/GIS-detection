namespace CalProfileAndDataView
{
    partial class frmViewPoints
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
            this.PointsGridView = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Points = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelPoint = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBoxSequenceView = new System.Windows.Forms.TextBox();
            this.lblSequenceView = new System.Windows.Forms.Label();
            this.btnSavePointsShapefile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PointsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Points)).BeginInit();
            this.SuspendLayout();
            // 
            // PointsGridView
            // 
            this.PointsGridView.AllowUserToAddRows = false;
            this.PointsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PointsGridView.AutoGenerateColumns = false;
            this.PointsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PointsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnLatitude,
            this.ColumnLongitude,
            this.ColumnName,
            this.ColumnMark});
            this.PointsGridView.DataSource = this.Points;
            this.PointsGridView.Location = new System.Drawing.Point(12, 12);
            this.PointsGridView.Name = "PointsGridView";
            this.PointsGridView.RowTemplate.Height = 23;
            this.PointsGridView.Size = new System.Drawing.Size(546, 233);
            this.PointsGridView.TabIndex = 0;
            this.PointsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PointsGridView_CellContentClick);
            this.PointsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PointsGridView_CellValueChanged);
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
            this.ColumnLatitude.HeaderText = "latitude";
            this.ColumnLatitude.Name = "ColumnLatitude";
            // 
            // ColumnLongitude
            // 
            this.ColumnLongitude.DataPropertyName = "longitude";
            this.ColumnLongitude.HeaderText = "longitude";
            this.ColumnLongitude.Name = "ColumnLongitude";
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.HeaderText = "name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnMark
            // 
            this.ColumnMark.FalseValue = "false";
            this.ColumnMark.HeaderText = "Mark";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.TrueValue = "true";
            // 
            // btnDelPoint
            // 
            this.btnDelPoint.Location = new System.Drawing.Point(163, 281);
            this.btnDelPoint.Name = "btnDelPoint";
            this.btnDelPoint.Size = new System.Drawing.Size(147, 32);
            this.btnDelPoint.TabIndex = 1;
            this.btnDelPoint.Text = "Delete Point";
            this.btnDelPoint.UseVisualStyleBackColor = true;
            this.btnDelPoint.Click += new System.EventHandler(this.btnDelPoint_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 282);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(136, 31);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textBoxSequenceView
            // 
            this.textBoxSequenceView.Location = new System.Drawing.Point(95, 252);
            this.textBoxSequenceView.Name = "textBoxSequenceView";
            this.textBoxSequenceView.ReadOnly = true;
            this.textBoxSequenceView.Size = new System.Drawing.Size(362, 21);
            this.textBoxSequenceView.TabIndex = 3;
            // 
            // lblSequenceView
            // 
            this.lblSequenceView.AutoSize = true;
            this.lblSequenceView.Location = new System.Drawing.Point(12, 255);
            this.lblSequenceView.Name = "lblSequenceView";
            this.lblSequenceView.Size = new System.Drawing.Size(83, 12);
            this.lblSequenceView.TabIndex = 4;
            this.lblSequenceView.Text = "SequenceView:";
            // 
            // btnSavePointsShapefile
            // 
            this.btnSavePointsShapefile.Location = new System.Drawing.Point(326, 282);
            this.btnSavePointsShapefile.Name = "btnSavePointsShapefile";
            this.btnSavePointsShapefile.Size = new System.Drawing.Size(122, 31);
            this.btnSavePointsShapefile.TabIndex = 5;
            this.btnSavePointsShapefile.Text = "Save Points";
            this.btnSavePointsShapefile.UseVisualStyleBackColor = true;
            this.btnSavePointsShapefile.Click += new System.EventHandler(this.btnSavePointsShapefile_Click);
            // 
            // frmViewPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 335);
            this.Controls.Add(this.btnSavePointsShapefile);
            this.Controls.Add(this.lblSequenceView);
            this.Controls.Add(this.textBoxSequenceView);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDelPoint);
            this.Controls.Add(this.PointsGridView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(577, 373);
            this.MinimumSize = new System.Drawing.Size(577, 373);
            this.Name = "frmViewPoints";
            this.Text = "ViewPoints";
            this.Load += new System.EventHandler(this.ViewPoints_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PointsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Points)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PointsGridView;
        private System.Windows.Forms.BindingSource Points;
        private System.Windows.Forms.Button btnDelPoint;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBoxSequenceView;
        private System.Windows.Forms.Label lblSequenceView;
        private System.Windows.Forms.Button btnSavePointsShapefile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMark;
    }
}