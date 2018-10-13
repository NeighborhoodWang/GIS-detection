namespace CalProfileAndDataView
{
    partial class frmViewProfile
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBasedOnOriginalProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAAbosulotelyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTheLastCustomProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xAxisUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxXUnit = new System.Windows.Forms.ToolStripComboBox();
            this.yAxisUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxYUnit = new System.Windows.Forms.ToolStripComboBox();
            this.viewAProfileControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartProfile
            // 
            this.chartProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Maroon;
            chartArea2.AxisX.Title = "Distance";
            chartArea2.AxisY.Title = "Height";
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartAreaProfile";
            this.chartProfile.ChartAreas.Add(chartArea2);
            legend2.Name = "LegendOriginal";
            this.chartProfile.Legends.Add(legend2);
            this.chartProfile.Location = new System.Drawing.Point(12, 25);
            this.chartProfile.Name = "chartProfile";
            series2.ChartArea = "ChartAreaProfile";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "LegendOriginal";
            series2.Name = "SeriesOriginal";
            this.chartProfile.Series.Add(series2);
            this.chartProfile.Size = new System.Drawing.Size(836, 535);
            this.chartProfile.TabIndex = 0;
            this.chartProfile.Text = "chartProfile";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeTheLastCustomProfileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBasedOnOriginalProfileToolStripMenuItem,
            this.addAAbosulotelyToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.addToolStripMenuItem.Text = "&Add Custom Profile";
            // 
            // addBasedOnOriginalProfileToolStripMenuItem
            // 
            this.addBasedOnOriginalProfileToolStripMenuItem.Name = "addBasedOnOriginalProfileToolStripMenuItem";
            this.addBasedOnOriginalProfileToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.addBasedOnOriginalProfileToolStripMenuItem.Text = "Add &Based On Original Profile";
            this.addBasedOnOriginalProfileToolStripMenuItem.Click += new System.EventHandler(this.addBasedOnOriginalProfileToolStripMenuItem_Click);
            // 
            // addAAbosulotelyToolStripMenuItem
            // 
            this.addAAbosulotelyToolStripMenuItem.Name = "addAAbosulotelyToolStripMenuItem";
            this.addAAbosulotelyToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.addAAbosulotelyToolStripMenuItem.Text = "Add A &Entirely New Profile";
            this.addAAbosulotelyToolStripMenuItem.Click += new System.EventHandler(this.addAAbosulotelyToolStripMenuItem_Click);
            // 
            // removeTheLastCustomProfileToolStripMenuItem
            // 
            this.removeTheLastCustomProfileToolStripMenuItem.Name = "removeTheLastCustomProfileToolStripMenuItem";
            this.removeTheLastCustomProfileToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.removeTheLastCustomProfileToolStripMenuItem.Text = "&Remove The Last Custom Profile";
            this.removeTheLastCustomProfileToolStripMenuItem.Click += new System.EventHandler(this.removeTheLastCustomProfileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xAxisUnitToolStripMenuItem,
            this.yAxisUnitToolStripMenuItem,
            this.viewAProfileControllerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // xAxisUnitToolStripMenuItem
            // 
            this.xAxisUnitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxXUnit});
            this.xAxisUnitToolStripMenuItem.Name = "xAxisUnitToolStripMenuItem";
            this.xAxisUnitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.xAxisUnitToolStripMenuItem.Text = "&X Axis Unit";
            // 
            // toolStripComboBoxXUnit
            // 
            this.toolStripComboBoxXUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxXUnit.Items.AddRange(new object[] {
            "M",
            "KM",
            "NM"});
            this.toolStripComboBoxXUnit.Name = "toolStripComboBoxXUnit";
            this.toolStripComboBoxXUnit.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxXUnit.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxXUnit_SelectedIndexChanged);
            // 
            // yAxisUnitToolStripMenuItem
            // 
            this.yAxisUnitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxYUnit});
            this.yAxisUnitToolStripMenuItem.Name = "yAxisUnitToolStripMenuItem";
            this.yAxisUnitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.yAxisUnitToolStripMenuItem.Text = "&Y Axis Unit";
            // 
            // toolStripComboBoxYUnit
            // 
            this.toolStripComboBoxYUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxYUnit.Items.AddRange(new object[] {
            "M",
            "KM",
            "FEET"});
            this.toolStripComboBoxYUnit.Name = "toolStripComboBoxYUnit";
            this.toolStripComboBoxYUnit.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxYUnit.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxYUnit_SelectedIndexChanged);
            // 
            // viewAProfileControllerToolStripMenuItem
            // 
            this.viewAProfileControllerToolStripMenuItem.Name = "viewAProfileControllerToolStripMenuItem";
            this.viewAProfileControllerToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.viewAProfileControllerToolStripMenuItem.Text = "View A Profile &Controller";
            this.viewAProfileControllerToolStripMenuItem.Click += new System.EventHandler(this.viewAProfileControllerToolStripMenuItem_Click);
            // 
            // frmViewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 572);
            this.Controls.Add(this.chartProfile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmViewProfile";
            this.Text = "ViewProfile";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBasedOnOriginalProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAAbosulotelyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xAxisUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAxisUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAProfileControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxXUnit;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxYUnit;
        private System.Windows.Forms.ToolStripMenuItem removeTheLastCustomProfileToolStripMenuItem;
    }
}