using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CalProfileAndDataView
{
    public delegate void AddEntirelyNewProfileDelegate(string direction, Series EntirelyNewProfile);

    public partial class frmAddEntirelyNewProfile : Form
    {
        private Series EntirelyNewProfile = new Series();
        public event AddEntirelyNewProfileDelegate AddEntirelyNewProfileEvent;

        public frmAddEntirelyNewProfile()
        {
            InitializeComponent();
        }

        private void frmAddEntirelyNewProfile_Load(object sender, EventArgs e)
        {
            comboBoxHeightUnit.SelectedItem = "FEET";
            comboBoxDistanceUnit.SelectedItem = "NM";
            comboBoxDirection.SelectedItem = "Forward";
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if ((string)comboBoxDirection.SelectedItem == "Backward")
            {
                CreateBackwardNewProfile();
            }
            else if ((string)comboBoxDirection.SelectedItem == "Forward")
            {
                CreateForwardNewProfile();
            }

            AddEntirelyNewProfileEvent((string)comboBoxDirection.SelectedItem, EntirelyNewProfile);
            this.Close();
        }

        private void CreateForwardNewProfile()
        {
            EntirelyNewProfile.Points.Clear();
            DataGridViewTextBoxCell DistanceCell;
            DataGridViewTextBoxCell HeightCell;

            if ((string)comboBoxDistanceUnit.SelectedItem == "M")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for(int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)),
                            (Convert.ToDouble(HeightCell.EditedFormattedValue)));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)),
                            (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 1000);
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)),
                           (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 0.3048);
                    }
                }
            }
            else if ((string)comboBoxDistanceUnit.SelectedItem == "KM")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                            (Convert.ToDouble(HeightCell.EditedFormattedValue)));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                             (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 1000);
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {

                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                           (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 0.3048);
                    }
                }
            }
            else if ((string)comboBoxDistanceUnit.SelectedItem == "NM")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                           (Convert.ToDouble(HeightCell.EditedFormattedValue)));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                            (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 1000);
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                            (Convert.ToDouble(HeightCell.EditedFormattedValue)) * 0.3048);
                    }
                }
            }
        }

        private void CreateBackwardNewProfile()
        {
            EntirelyNewProfile.Points.Clear();
            DataGridViewTextBoxCell DistanceCell;
            DataGridViewTextBoxCell HeightCell;
            DataGridViewTextBoxCell LastCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[dataGridViewHeightDistance.Rows.Count - 2].Cells["ColumnDistance"];

            double lastDistance = Convert.ToDouble(LastCell.EditedFormattedValue);

            if ((string)comboBoxDistanceUnit.SelectedItem == "M")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY(lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue),
                          Convert.ToDouble(HeightCell.EditedFormattedValue));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY(lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue),
                           (Convert.ToDouble(HeightCell.EditedFormattedValue) * 1000));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY(lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue),
                           (Convert.ToDouble(HeightCell.EditedFormattedValue) * 0.3048));
                    }
                }
            }
            else if ((string)comboBoxDistanceUnit.SelectedItem == "KM")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                            Convert.ToDouble(HeightCell.EditedFormattedValue));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                            Convert.ToDouble(HeightCell.EditedFormattedValue) * 1000);
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1000,
                            Convert.ToDouble(HeightCell.EditedFormattedValue) * 0.3048);
                    }
                }
            }
            else if ((string)comboBoxDistanceUnit.SelectedItem == "NM")
            {
                if ((string)comboBoxHeightUnit.SelectedItem == "M")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                            Convert.ToDouble(HeightCell.EditedFormattedValue));
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "KM")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                            Convert.ToDouble(HeightCell.EditedFormattedValue) * 1000);
                    }
                }
                else if ((string)comboBoxHeightUnit.SelectedItem == "FEET")
                {
                    for (int i = 0; i < dataGridViewHeightDistance.Rows.Count - 1; i++)
                    {
                        DistanceCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnDistance"];
                        HeightCell = (DataGridViewTextBoxCell)dataGridViewHeightDistance.Rows[i].Cells["ColumnHeight"];

                        EntirelyNewProfile.Points.AddXY((lastDistance - Convert.ToDouble(DistanceCell.EditedFormattedValue)) * 1852,
                            Convert.ToDouble(HeightCell.EditedFormattedValue) * 0.3048);
                    }
                }
            }
        }

        private void dataGridViewHeightDistance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tx = e.Control as TextBox;
            tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
            tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
        }

        private void tx_KeyPress(object sender, KeyPressEventArgs e)  
        {  
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                MessageBox.Show("Only numbers here!");
            } 
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHeightDistance.Rows.Count > 1)
            {
                int deleteIndex = dataGridViewHeightDistance.Rows.GetLastRow(DataGridViewElementStates.Selected);
                if (deleteIndex >= 0)
                {
                    if (deleteIndex == (dataGridViewHeightDistance.Rows.Count - 1))
                    {
                        dataGridViewHeightDistance.Rows.RemoveAt(dataGridViewHeightDistance.Rows.Count - 2);
                    }
                    else
                    {
                        dataGridViewHeightDistance.Rows.RemoveAt(deleteIndex);
                    }                 
                }
                
            } 
        } 
    }
}
