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
    public delegate void AddLineDelegate();
    public delegate void SaveLineDelegate();
    public delegate void CalculateProfileDelegate(double tolerance);

    public partial class frmViewLine : Form
    {
        public event AddLineDelegate AddLineEvent;
        public event SaveLineDelegate SaveLineEvent;
        public event CalculateProfileDelegate CalculateProfileEvent;
        public DataTable DataTableLine = new DataTable();
        private string linetrack = "";

        public string Linetrack
        {
            get { return linetrack; }
            set { linetrack = value; }
        }


        public frmViewLine()
        {
            InitializeComponent();
            this.DataTableLine.Columns.Add("ID", typeof(int));
            this.DataTableLine.Columns.Add("latitude", typeof(double));
            this.DataTableLine.Columns.Add("longitude", typeof(double));
            this.DataTableLine.Columns.Add("name", typeof(string));
            this.TopMost = true;
        }

        public frmViewLine(string track)
        {
            InitializeComponent();
            this.DataTableLine.Columns.Add("ID", typeof(int));
            this.DataTableLine.Columns.Add("latitude", typeof(double));
            this.DataTableLine.Columns.Add("longitude", typeof(double));
            this.DataTableLine.Columns.Add("name", typeof(string));
            this.textBoxTrackView.Text = track;
            this.linetrack = track;
            this.TopMost = true;
        }

        private void BindData()
        {
            //建立一个DataTable并填充数据，然后绑定到DataGridView控件上

            //DataTableLine.Rows.Add(new string[] { "1", "23", "24" });
            this.bindingSourceLine.DataSource = DataTableLine;
        }

        private void ViewLine_Load(object sender, EventArgs e)
        {
            comboBoxMeasureUnit.Items.Add("M");
            comboBoxMeasureUnit.Items.Add("KM");
            comboBoxMeasureUnit.Items.Add("NM");
            this.BindData();
        }

        public void UpdateTexeboxLinetrack()
        {
            this.textBoxTrackView.Text = linetrack;
        }

        private void buttonAddLineFromFile_Click(object sender, EventArgs e)
        {
            AddLineEvent();
        }

        private void buttonSaveLine_Click(object sender, EventArgs e)
        {
            SaveLineEvent();
            MessageBox.Show("不知道存哪了吧？文件运行在哪，线文件就存在哪，有三个文件哦");
        }

        private void buttonCalProfile_Click(object sender, EventArgs e)
        {
            double tolerance = 0;
            if ((string)comboBoxMeasureUnit.SelectedItem == "M")
            {
                tolerance = Convert.ToDouble(textBoxTolerance.Text);
                CalculateProfileEvent(tolerance);
            }
            else if ((string)comboBoxMeasureUnit.SelectedItem == "NM")
            {
                tolerance = Convert.ToDouble(textBoxTolerance.Text);
                tolerance = tolerance * 1852;
                CalculateProfileEvent(tolerance);
            }
            else if ((string)comboBoxMeasureUnit.SelectedItem == "KM")
            {
                tolerance = Convert.ToDouble(textBoxTolerance.Text);
                tolerance = tolerance * 1000;
                CalculateProfileEvent(tolerance);
            }
            else
            {
                MessageBox.Show("大哥，您得先选择计量单位呀");
            }
            
        }

        private void textBoxTolerance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                MessageBox.Show("这里只能输入数字哦，亲~");
            }
            
        }
    }
}
