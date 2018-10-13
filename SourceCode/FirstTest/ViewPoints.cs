using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CalProfileAndDataView
{
    public delegate void DeletePointsDelegate(List<int> DeletedPointIndexes);
    public delegate void SavePointsShapefileDelegate();
    public delegate void ConnectPointsDelegate(List<int> ConnectedPointIndexes);
    public delegate void PointContentChangedDelegate(int ID,double latitude,double longtitude,string name);

    public partial class frmViewPoints : Form
    {
        //定义两种行样式
        private DataGridViewCellStyle RowStyleNormal;
        private DataGridViewCellStyle RowStyleSelect;
        public DataTable DataTablePointsList = new DataTable();
        private List<int> PointIndexInSequence = new List<int>();
        public event DeletePointsDelegate DeletePointsEvent;
        public event SavePointsShapefileDelegate SavePointsShapefileEvent;
        public event ConnectPointsDelegate ConnectPointsEvent;
        public event PointContentChangedDelegate PointContentChangedEvent;

        public frmViewPoints()
        {
            InitializeComponent();
            this.DataTablePointsList.Columns.Add("ID", typeof(int));
            this.DataTablePointsList.Columns.Add("Latitude", typeof(double));
            this.DataTablePointsList.Columns.Add("Longitude", typeof(double));
            this.DataTablePointsList.Columns.Add("Name", typeof(string));
            this.TopMost = true;
        }

        private void ViewPoints_Load(object sender, EventArgs e)
        {
            this.PointsGridView.AutoGenerateColumns = false;
            this.SetRowStyle();
            this.BindData();
        }

        private void SetRowStyle()
        {
            this.RowStyleNormal = new DataGridViewCellStyle();
            this.RowStyleNormal.BackColor = Color.LightBlue;
            this.RowStyleNormal.SelectionBackColor = Color.LightSteelBlue;

            this.RowStyleSelect = new DataGridViewCellStyle();
            this.RowStyleSelect.BackColor = Color.LightGray;
            this.RowStyleSelect.SelectionBackColor = Color.LightSlateGray;
        }

        private void BindData()
        {
            //建立一个DataTable并填充数据，然后绑定到DataGridView控件上
            
            //DataTablePointsList.Rows.Add(new string[] { "1", "23", "24" });
            this.Points.DataSource = DataTablePointsList;
        }

        private void PointsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex > -1)
            {
                DataGridViewCheckBoxCell MarkCell = (DataGridViewCheckBoxCell)PointsGridView.Rows[e.RowIndex].Cells["ColumnMark"];

                if (Convert.ToBoolean(MarkCell.EditedFormattedValue))
                {
                    if (!(PointIndexInSequence.Contains(e.RowIndex + 1)))
                    {
                        PointIndexInSequence.Add(e.RowIndex + 1);
                    }
                }
                else
                {
                    PointIndexInSequence.Remove(e.RowIndex + 1);
                }
            }
            foreach (int PointIndex in PointIndexInSequence)
            {
                if (PointIndexInSequence.Count == 1)
                {
                        textBoxSequenceView.Text = Convert.ToString(PointIndex);
                }
                if (PointIndexInSequence.Count > 1)
                {
                    if (PointIndexInSequence.IndexOf(PointIndex) == 0)
                    {
                        textBoxSequenceView.Text = Convert.ToString(PointIndex);
                    }
                    if (PointIndexInSequence.IndexOf(PointIndex) > 0)
                    {
                        textBoxSequenceView.Text = textBoxSequenceView.Text + "->" + Convert.ToString(PointIndex); 
                    }
                }
            }
            if (PointIndexInSequence.Count == 0)
            {
                textBoxSequenceView.Text = "";
            }
            
        }

        private void btnDelPoint_Click(object sender, EventArgs e)
        {
            DeletePointsEvent(PointIndexInSequence);
            PointIndexInSequence.Clear();
        }

        private void btnSavePointsShapefile_Click(object sender, EventArgs e)
        {
            SavePointsShapefileEvent();
            MessageBox.Show("不知道存哪了吧？文件运行在哪，点文件就存在哪，有三个文件哦");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectPointsEvent(PointIndexInSequence);
        }

        private void PointsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewTextBoxCell IDCell = (DataGridViewTextBoxCell)PointsGridView.Rows[e.RowIndex].Cells["ColumnID"];
                DataGridViewTextBoxCell LatitudeCell = (DataGridViewTextBoxCell)PointsGridView.Rows[e.RowIndex].Cells["ColumnLatitude"];
                DataGridViewTextBoxCell LongitudeCell = (DataGridViewTextBoxCell)PointsGridView.Rows[e.RowIndex].Cells["ColumnLongitude"];
                DataGridViewTextBoxCell NameCell = (DataGridViewTextBoxCell)PointsGridView.Rows[e.RowIndex].Cells["ColumnName"];

                PointContentChangedEvent(Convert.ToInt32(IDCell.EditedFormattedValue), Convert.ToDouble(LatitudeCell.EditedFormattedValue), Convert.ToDouble(LongitudeCell.EditedFormattedValue), Convert.ToString(NameCell.EditedFormattedValue));
                
            }
        }

    }
}
