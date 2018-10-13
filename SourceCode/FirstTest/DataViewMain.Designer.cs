namespace CalProfileAndDataView
{
    partial class frmDataView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataView));
            this.Map = new AxMapWinGIS.AxMap();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSelection = new System.Windows.Forms.RadioButton();
            this.rdPan = new System.Windows.Forms.RadioButton();
            this.rdZoomOut = new System.Windows.Forms.RadioButton();
            this.rdZoomIn = new System.Windows.Forms.RadioButton();
            this.btnAddData = new System.Windows.Forms.Button();
            this.tbLat = new System.Windows.Forms.TextBox();
            this.tbLng = new System.Windows.Forms.TextBox();
            this.lbLat = new System.Windows.Forms.Label();
            this.lbLng = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.btnCalHeight = new System.Windows.Forms.Button();
            this.vSclbTransparent = new System.Windows.Forms.VScrollBar();
            this.pgbAllView = new System.Windows.Forms.ProgressBar();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnViewPoints = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.buttonViewLine = new System.Windows.Forms.Button();
            this.buttonViewProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.Enabled = true;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Name = "Map";
            this.Map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Map.OcxState")));
            this.Map.Size = new System.Drawing.Size(762, 330);
            this.Map.TabIndex = 0;
            this.Map.MouseDownEvent += new AxMapWinGIS._DMapEvents_MouseDownEventHandler(this.Map_MouseDownEvent);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdSelection);
            this.groupBox1.Controls.Add(this.rdPan);
            this.groupBox1.Controls.Add(this.rdZoomOut);
            this.groupBox1.Controls.Add(this.rdZoomIn);
            this.groupBox1.Location = new System.Drawing.Point(483, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mouse Cursor Mode";
            // 
            // rdSelection
            // 
            this.rdSelection.AutoSize = true;
            this.rdSelection.Location = new System.Drawing.Point(202, 21);
            this.rdSelection.Name = "rdSelection";
            this.rdSelection.Size = new System.Drawing.Size(77, 16);
            this.rdSelection.TabIndex = 3;
            this.rdSelection.TabStop = true;
            this.rdSelection.Text = "Selection";
            this.rdSelection.UseVisualStyleBackColor = true;
            this.rdSelection.CheckedChanged += new System.EventHandler(this.rdSelection_CheckedChanged);
            // 
            // rdPan
            // 
            this.rdPan.AutoSize = true;
            this.rdPan.Location = new System.Drawing.Point(155, 20);
            this.rdPan.Name = "rdPan";
            this.rdPan.Size = new System.Drawing.Size(41, 16);
            this.rdPan.TabIndex = 2;
            this.rdPan.Text = "Pan";
            this.rdPan.UseVisualStyleBackColor = true;
            this.rdPan.CheckedChanged += new System.EventHandler(this.rdPan_CheckedChanged);
            // 
            // rdZoomOut
            // 
            this.rdZoomOut.AutoSize = true;
            this.rdZoomOut.Location = new System.Drawing.Point(78, 20);
            this.rdZoomOut.Name = "rdZoomOut";
            this.rdZoomOut.Size = new System.Drawing.Size(71, 16);
            this.rdZoomOut.TabIndex = 1;
            this.rdZoomOut.Text = "Zoom Out";
            this.rdZoomOut.UseVisualStyleBackColor = true;
            this.rdZoomOut.CheckedChanged += new System.EventHandler(this.rdZoomOut_CheckedChanged);
            // 
            // rdZoomIn
            // 
            this.rdZoomIn.AutoSize = true;
            this.rdZoomIn.Checked = true;
            this.rdZoomIn.Location = new System.Drawing.Point(7, 21);
            this.rdZoomIn.Name = "rdZoomIn";
            this.rdZoomIn.Size = new System.Drawing.Size(65, 16);
            this.rdZoomIn.TabIndex = 0;
            this.rdZoomIn.TabStop = true;
            this.rdZoomIn.Text = "Zoom In";
            this.rdZoomIn.UseVisualStyleBackColor = true;
            this.rdZoomIn.CheckedChanged += new System.EventHandler(this.rdZoomIn_CheckedChanged);
            // 
            // btnAddData
            // 
            this.btnAddData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddData.Location = new System.Drawing.Point(12, 340);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(87, 23);
            this.btnAddData.TabIndex = 2;
            this.btnAddData.Text = "Add Data...";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.BtnAddData_Click);
            // 
            // tbLat
            // 
            this.tbLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLat.Location = new System.Drawing.Point(12, 381);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(82, 21);
            this.tbLat.TabIndex = 3;
            this.tbLat.Text = "0";
            this.tbLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLat_KeyPress);
            // 
            // tbLng
            // 
            this.tbLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLng.Location = new System.Drawing.Point(113, 381);
            this.tbLng.Name = "tbLng";
            this.tbLng.Size = new System.Drawing.Size(80, 21);
            this.tbLng.TabIndex = 4;
            this.tbLng.Text = "0";
            this.tbLng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLng_KeyPress);
            // 
            // lbLat
            // 
            this.lbLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLat.AutoSize = true;
            this.lbLat.Location = new System.Drawing.Point(42, 366);
            this.lbLat.Name = "lbLat";
            this.lbLat.Size = new System.Drawing.Size(23, 12);
            this.lbLat.TabIndex = 5;
            this.lbLat.Text = "Lat";
            // 
            // lbLng
            // 
            this.lbLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLng.AutoSize = true;
            this.lbLng.Location = new System.Drawing.Point(139, 368);
            this.lbLng.Name = "lbLng";
            this.lbLng.Size = new System.Drawing.Size(23, 12);
            this.lbLng.TabIndex = 6;
            this.lbLng.Text = "Lng";
            // 
            // tbHeight
            // 
            this.tbHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbHeight.Location = new System.Drawing.Point(211, 381);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.ReadOnly = true;
            this.tbHeight.Size = new System.Drawing.Size(84, 21);
            this.tbHeight.TabIndex = 7;
            // 
            // lbHeight
            // 
            this.lbHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(232, 368);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(41, 12);
            this.lbHeight.TabIndex = 8;
            this.lbHeight.Text = "Height";
            // 
            // btnCalHeight
            // 
            this.btnCalHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalHeight.Location = new System.Drawing.Point(301, 381);
            this.btnCalHeight.Name = "btnCalHeight";
            this.btnCalHeight.Size = new System.Drawing.Size(75, 21);
            this.btnCalHeight.TabIndex = 9;
            this.btnCalHeight.Text = "CalHeight";
            this.btnCalHeight.UseVisualStyleBackColor = true;
            this.btnCalHeight.Click += new System.EventHandler(this.btnCalHeight_Click);
            // 
            // vSclbTransparent
            // 
            this.vSclbTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vSclbTransparent.Location = new System.Drawing.Point(765, 9);
            this.vSclbTransparent.Name = "vSclbTransparent";
            this.vSclbTransparent.Size = new System.Drawing.Size(25, 321);
            this.vSclbTransparent.TabIndex = 10;
            this.vSclbTransparent.Value = 50;
            this.vSclbTransparent.ValueChanged += new System.EventHandler(this.vSclbTransparent_ValueChanged);
            // 
            // pgbAllView
            // 
            this.pgbAllView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbAllView.Location = new System.Drawing.Point(0, 410);
            this.pgbAllView.Name = "pgbAllView";
            this.pgbAllView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgbAllView.Size = new System.Drawing.Size(802, 23);
            this.pgbAllView.TabIndex = 11;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPoint.Location = new System.Drawing.Point(116, 340);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(76, 22);
            this.btnAddPoint.TabIndex = 12;
            this.btnAddPoint.Text = "Add Point";
            this.btnAddPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnViewPoints
            // 
            this.btnViewPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewPoints.Location = new System.Drawing.Point(301, 340);
            this.btnViewPoints.Name = "btnViewPoints";
            this.btnViewPoints.Size = new System.Drawing.Size(75, 23);
            this.btnViewPoints.TabIndex = 13;
            this.btnViewPoints.Text = "View Point";
            this.btnViewPoints.UseVisualStyleBackColor = true;
            this.btnViewPoints.Click += new System.EventHandler(this.btnViewPoints_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbName.Location = new System.Drawing.Point(211, 340);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(84, 21);
            this.tbName.TabIndex = 14;
            // 
            // buttonViewLine
            // 
            this.buttonViewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonViewLine.Location = new System.Drawing.Point(393, 340);
            this.buttonViewLine.Name = "buttonViewLine";
            this.buttonViewLine.Size = new System.Drawing.Size(75, 23);
            this.buttonViewLine.TabIndex = 15;
            this.buttonViewLine.Text = "View Line";
            this.buttonViewLine.UseVisualStyleBackColor = true;
            this.buttonViewLine.Click += new System.EventHandler(this.buttonViewLine_Click);
            // 
            // buttonViewProfile
            // 
            this.buttonViewProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonViewProfile.Location = new System.Drawing.Point(393, 381);
            this.buttonViewProfile.Name = "buttonViewProfile";
            this.buttonViewProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonViewProfile.TabIndex = 16;
            this.buttonViewProfile.Text = "View Prof";
            this.buttonViewProfile.UseVisualStyleBackColor = true;
            this.buttonViewProfile.Click += new System.EventHandler(this.buttonViewProfile_Click);
            // 
            // frmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 433);
            this.Controls.Add(this.buttonViewProfile);
            this.Controls.Add(this.buttonViewLine);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnViewPoints);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.pgbAllView);
            this.Controls.Add(this.vSclbTransparent);
            this.Controls.Add(this.btnCalHeight);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.lbLng);
            this.Controls.Add(this.lbLat);
            this.Controls.Add(this.tbLng);
            this.Controls.Add(this.tbLat);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Map);
            this.Name = "frmDataView";
            this.Text = "Data Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMapWinGIS.AxMap Map;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdPan;
        private System.Windows.Forms.RadioButton rdZoomOut;
        private System.Windows.Forms.RadioButton rdZoomIn;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.RadioButton rdSelection;
        private System.Windows.Forms.TextBox tbLat;
        private System.Windows.Forms.TextBox tbLng;
        private System.Windows.Forms.Label lbLat;
        private System.Windows.Forms.Label lbLng;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Button btnCalHeight;
        private System.Windows.Forms.VScrollBar vSclbTransparent;
        private System.Windows.Forms.ProgressBar pgbAllView;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnViewPoints;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button buttonViewLine;
        private System.Windows.Forms.Button buttonViewProfile;
    }
}

