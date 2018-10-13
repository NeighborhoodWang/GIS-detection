using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MapWinGIS;
using AxMapWinGIS;

namespace CalProfileAndDataView
{
    
    public partial class frmViewProfile : Form
    {
        private double beyondHeightView = 0;
        private Series AddBasedOriginalProfileSeries = new Series();
        private Series ForwardProfileSeries = new Series();
        private Series BackwardProfileSeries = new Series();
        private Series ForwardProfileSeriesBackup = new Series();
        private Series BackwardProfileSeriesBackup = new Series();
        private List<MaxHeightResult> maxProfileResults = new List<MaxHeightResult>();
        FrmShiftPad ShiftPad;
        

        public frmViewProfile()
        {
            InitializeComponent();
            toolStripComboBoxXUnit.SelectedItem = "M";
            toolStripComboBoxYUnit.SelectedItem = "M";
            this.chartProfile.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartProfile_GetToolTipText);
        }

        public frmViewProfile(List<MaxHeightResult> maxHeightResults)
        {
            InitializeComponent();
            toolStripComboBoxXUnit.SelectedItem = "M";
            toolStripComboBoxYUnit.SelectedItem = "M";
            this.maxProfileResults = maxHeightResults;
            this.chartProfile.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartProfile_GetToolTipText);
            double temDistance = 0;
            foreach (MaxHeightResult maxHeightResult in maxHeightResults)
            {
                
                if ((maxHeightResult.DistanceFromInit == 0) &&
                    (maxHeightResults.IndexOf(maxHeightResult) != 0))
                {
                    temDistance = maxHeightResults[(maxHeightResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                }
                chartProfile.Series["SeriesOriginal"].Points.AddXY(maxHeightResult.DistanceFromInit + temDistance,
                    maxHeightResult.Height);
            }
        }

        private void chartProfile_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if ((maxProfileResults == null) || (maxProfileResults.Count == 0))
            {
                return;
            }
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    if ((string)toolStripComboBoxXUnit.SelectedItem == "M")
                    {
                        if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 1000 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 0.3048 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                    }
                    else if ((string)toolStripComboBoxXUnit.SelectedItem == "KM")
                    {
                        if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1000 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1000 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 1000 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1000 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 0.3048 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                    }
                    else if ((string)toolStripComboBoxXUnit.SelectedItem == "NM")
                    {
                        if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1852 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1852 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 1000 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                        else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                        {
                            e.Text = "Distance to original point:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceFromInit / 1852 + (string)toolStripComboBoxXUnit.SelectedItem + "\n"
                       + "Height:" + maxProfileResults[e.HitTestResult.PointIndex].Height / 0.3048 + (string)toolStripComboBoxYUnit.SelectedItem + "\n"
                       + "Distance offset the main line:" + maxProfileResults[e.HitTestResult.PointIndex].DistanceToMainLine + "M\n"
                       + "Latitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.y + "\n"
                       + "Longitude:" + maxProfileResults[e.HitTestResult.PointIndex].Point.x + "\n";
                        }
                    }

                   break;
            }
        }

        public void UpdateProfileChart(List<MaxHeightResult> maxHeightResults)
        {
            double temDistance = 0;
            this.maxProfileResults = maxHeightResults;
            chartProfile.Series["SeriesOriginal"].Points.Clear();
            foreach (MaxHeightResult maxHeightResult in maxHeightResults)
            {
                
                if ((maxHeightResult.DistanceFromInit == 0) &&
                    (maxHeightResults.IndexOf(maxHeightResult) != 0))
                {
                    temDistance = maxHeightResults[(maxHeightResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                }
                chartProfile.Series["SeriesOriginal"].Points.AddXY(maxHeightResult.DistanceFromInit + temDistance,
                    maxHeightResult.Height);
            }
        }

        private void toolStripComboBoxXUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChartUnit("SeriesOriginal", 0);
            if (chartProfile.Series.Contains(AddBasedOriginalProfileSeries))
            {
                UpdateChartUnit("BasedOriginalProfile", beyondHeightView);
            }
            if (chartProfile.Series.Contains(ForwardProfileSeries))
            {
                UpdateEntirelyNewProfile("Forward");
            }
            if (chartProfile.Series.Contains(BackwardProfileSeries))
            {
                UpdateEntirelyNewProfile("Backward");
            }
        }

        private void toolStripComboBoxYUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChartUnit("SeriesOriginal", 0);
            if (chartProfile.Series.Contains(AddBasedOriginalProfileSeries))
            {
                UpdateChartUnit("BasedOriginalProfile", beyondHeightView);
            }
            if (chartProfile.Series.Contains(ForwardProfileSeries))
            {
                UpdateEntirelyNewProfile("Forward");
            }
            if (chartProfile.Series.Contains(BackwardProfileSeries))
            {
                UpdateEntirelyNewProfile("Backward");
            }
            
        }

        private void addBasedOnOriginalProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBasedOriginal AddBasedOriginalProfile = new frmBasedOriginal();
            AddBasedOriginalProfile.Owner = this;
            AddBasedOriginalProfile.AddBasedOriginalProfileEvent += new AddBasedOriginalProfileDelegrate(AddBasedOriginalProfile_AddBasedOriginalProfileEvent);
            AddBasedOriginalProfile.Show();
        }

        void AddBasedOriginalProfile_AddBasedOriginalProfileEvent(double beyondHeight)
        {

            if (!(chartProfile.Series.Contains(AddBasedOriginalProfileSeries)))
            {
                AddBasedOriginalProfileSeries = chartProfile.Series.Add("BasedOriginalProfile");
            }

            beyondHeightView = beyondHeight;
            AddBasedOriginalProfileSeries.ChartArea = "ChartAreaProfile";
            AddBasedOriginalProfileSeries.ChartType = SeriesChartType.FastLine;

            UpdateChartUnit("BasedOriginalProfile", beyondHeight);
            
        }

        private void UpdateChartUnit(string seriesName, double beyondHeight)
        {
            chartProfile.Series[seriesName].Points.Clear();

            if ((string)toolStripComboBoxXUnit.SelectedItem == "M")
            {
                if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY(maxHeightResult.DistanceFromInit + temDistance,
                            maxHeightResult.Height + beyondHeight);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY(maxHeightResult.DistanceFromInit + temDistance,
                            (maxHeightResult.Height + beyondHeight) / 1000);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY(maxHeightResult.DistanceFromInit + temDistance,
                            (maxHeightResult.Height + beyondHeight) / 0.3048);
                    }
                }
            }
            else if ((string)toolStripComboBoxXUnit.SelectedItem == "KM")
            {
                if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1000,
                            maxHeightResult.Height + beyondHeight);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1000,
                            (maxHeightResult.Height + beyondHeight) / 1000);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1000,
                            (maxHeightResult.Height + beyondHeight) / 0.3048);
                    }
                }
            }
            else if ((string)toolStripComboBoxXUnit.SelectedItem == "NM")
            {
                if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1852,
                            maxHeightResult.Height + beyondHeight);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1852,
                            (maxHeightResult.Height + beyondHeight) / 1000);
                    }
                }
                else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                {
                    double temDistance = 0;
                    foreach (MaxHeightResult maxHeightResult in maxProfileResults)
                    {

                        if ((maxHeightResult.DistanceFromInit == 0) &&
                            (maxProfileResults.IndexOf(maxHeightResult) != 0))
                        {
                            temDistance = maxProfileResults[(maxProfileResults.IndexOf(maxHeightResult) - 1)].DistanceFromInit + temDistance;
                        }
                        chartProfile.Series[seriesName].Points.AddXY((maxHeightResult.DistanceFromInit + temDistance) / 1852,
                            (maxHeightResult.Height + beyondHeight) / 0.3048);
                    }
                }
            }
        }

        private void removeTheLastCustomProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartProfile.Series.Count > 1)
            {
                chartProfile.Series.RemoveAt(chartProfile.Series.Count - 1);
            }
            
        }

        private void addAAbosulotelyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEntirelyNewProfile AddEntirelyNewProfile = new frmAddEntirelyNewProfile();
            AddEntirelyNewProfile.Owner = this;
            AddEntirelyNewProfile.AddEntirelyNewProfileEvent += new AddEntirelyNewProfileDelegate(AddEntirelyNewProfile_AddEntirelyNewProfileEvent);
            AddEntirelyNewProfile.Show();


        }

        void AddEntirelyNewProfile_AddEntirelyNewProfileEvent(string direction, Series EntirelyNewProfile)
        {
            if (direction == "Forward")
            {
                chartProfile.Series.Remove(ForwardProfileSeries);
                ForwardProfileSeries = EntirelyNewProfile;
                ForwardProfileSeriesBackup.Points.Clear();
                for (int i = 0; i < EntirelyNewProfile.Points.Count; i++)
                { 
                    ForwardProfileSeriesBackup.Points.AddXY(EntirelyNewProfile.Points[i].XValue,EntirelyNewProfile.Points[i].YValues[0]);
                }


                chartProfile.Series.Add(ForwardProfileSeries);
                chartProfile.Series[chartProfile.Series.IndexOf(ForwardProfileSeries)].Name = "ForwardSeries";

                ForwardProfileSeries.ChartArea = "ChartAreaProfile";
                ForwardProfileSeries.ChartType = SeriesChartType.FastLine;
                UpdateEntirelyNewProfile(direction);
            }
            else if (direction == "Backward")
            {
                chartProfile.Series.Remove(BackwardProfileSeries);
                BackwardProfileSeries = EntirelyNewProfile;
                BackwardProfileSeriesBackup.Points.Clear();
                for (int i = 0; i < EntirelyNewProfile.Points.Count; i++)
                {
                    BackwardProfileSeriesBackup.Points.AddXY(EntirelyNewProfile.Points[i].XValue, EntirelyNewProfile.Points[i].YValues[0]);
                }

                chartProfile.Series.Add(BackwardProfileSeries);
                chartProfile.Series[chartProfile.Series.IndexOf(BackwardProfileSeries)].Name = "BackwardSeries";

                BackwardProfileSeries.ChartArea = "ChartAreaProfile";
                BackwardProfileSeries.ChartType = SeriesChartType.FastLine;
                UpdateEntirelyNewProfile(direction);
            }
        }

        private void UpdateEntirelyNewProfile(string seriesName)
        {
            if (seriesName == "Backward")
            {
                BackwardProfileSeries.Points.Clear();
                if ((string)toolStripComboBoxXUnit.SelectedItem == "M")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue, BackwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue, BackwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue, BackwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
                else if ((string)toolStripComboBoxXUnit.SelectedItem == "KM")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1000, BackwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1000, BackwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1000, BackwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
                else if ((string)toolStripComboBoxXUnit.SelectedItem == "NM")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1852, BackwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1852, BackwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < BackwardProfileSeriesBackup.Points.Count; i++)
                        {
                            BackwardProfileSeries.Points.AddXY(BackwardProfileSeriesBackup.Points[i].XValue / 1852, BackwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
            }
            else if (seriesName == "Forward")
            {
                ForwardProfileSeries.Points.Clear();
                if ((string)toolStripComboBoxXUnit.SelectedItem == "M")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue, ForwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue, ForwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue, ForwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
                else if ((string)toolStripComboBoxXUnit.SelectedItem == "KM")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1000, ForwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1000, ForwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1000, ForwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
                else if ((string)toolStripComboBoxXUnit.SelectedItem == "NM")
                {
                    if ((string)toolStripComboBoxYUnit.SelectedItem == "M")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1852, ForwardProfileSeriesBackup.Points[i].YValues[0]);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "KM")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1852, ForwardProfileSeriesBackup.Points[i].YValues[0] / 1000);
                        }
                    }
                    else if ((string)toolStripComboBoxYUnit.SelectedItem == "FEET")
                    {
                        for (int i = 0; i < ForwardProfileSeriesBackup.Points.Count; i++)
                        {
                            ForwardProfileSeries.Points.AddXY(ForwardProfileSeriesBackup.Points[i].XValue / 1852, ForwardProfileSeriesBackup.Points[i].YValues[0] / 0.3048);
                        }
                    }
                }
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewAProfileControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShiftPad == null || ShiftPad.IsDisposed)
            {
                ShiftPad = new FrmShiftPad();
                ShiftPad.Owner = this;
                ShiftPad.ShiftProfileEvent += new ShiftProfileDelegrate(ShiftPad_ShiftProfileEvent);
                ShiftPad.Show();
            }
            else
            {
                ShiftPad.Show();
                ShiftPad.Focus();
            }

            
        }

        void ShiftPad_ShiftProfileEvent(double step, string direction, string SelProfile)
        {
            

            switch (SelProfile)
            {
                case "Forward":
                    if (ForwardProfileSeries == null)
                    {
                        return;
                    }

                    {
                        switch (direction)
                        {
                            case "right":
                                {
                                    for (int i = 0; i < ForwardProfileSeries.Points.Count; i++)
                                    {
                                        ForwardProfileSeries.Points[i].XValue = ForwardProfileSeries.Points[i].XValue + step;
                                    }

                                    ForwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < ForwardProfileSeries.Points.Count; j++)
                                    {
                                        ForwardProfileSeriesBackup.Points.AddXY(ForwardProfileSeries.Points[j].XValue, ForwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(ForwardProfileSeries);

                                    chartProfile.Series.Add(ForwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(ForwardProfileSeries)].Name = "ForwardSeries";
                                        break;
                                }
                            case "left":
                                {
                                    for (int i = 0; i < ForwardProfileSeries.Points.Count; i++)
                                    {
                                        ForwardProfileSeries.Points[i].XValue = ForwardProfileSeries.Points[i].XValue - step;
                                    }
                                    ForwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < ForwardProfileSeries.Points.Count; j++)
                                    {
                                        ForwardProfileSeriesBackup.Points.AddXY(ForwardProfileSeries.Points[j].XValue, ForwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(ForwardProfileSeries);

                                    chartProfile.Series.Add(ForwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(ForwardProfileSeries)].Name = "ForwardSeries";

                                    break;
                                }
                            case "down":
                                {
                                    for (int i = 0; i < ForwardProfileSeries.Points.Count; i++)
                                    {
                                        ForwardProfileSeries.Points[i].YValues[0] = ForwardProfileSeries.Points[i].YValues[0] - step;
                                    }
                                    ForwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < ForwardProfileSeries.Points.Count; j++)
                                    {
                                        ForwardProfileSeriesBackup.Points.AddXY(ForwardProfileSeries.Points[j].XValue, ForwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(ForwardProfileSeries);

                                    chartProfile.Series.Add(ForwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(ForwardProfileSeries)].Name = "ForwardSeries";

                                    break;
                                }
                            case "up":
                                {
                                    for (int i = 0; i < ForwardProfileSeries.Points.Count; i++)
                                    {
                                        ForwardProfileSeries.Points[i].YValues[0] = ForwardProfileSeries.Points[i].YValues[0] + step;
                                        
                                    }
                                    ForwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < ForwardProfileSeries.Points.Count; j++)
                                    {
                                        ForwardProfileSeriesBackup.Points.AddXY(ForwardProfileSeries.Points[j].XValue, ForwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(ForwardProfileSeries);
                                    
                                    chartProfile.Series.Add(ForwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(ForwardProfileSeries)].Name = "ForwardSeries";

                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Serious Problem,please contact me!");
                                    break;
                                }
                        }
                        break;
                    }
                case "Backward":
                    if (BackwardProfileSeries == null)
                    {
                        return;
                    }
                    {
                        switch (direction)
                        {
                            case "right":
                                {
                                    for (int i = 0; i < BackwardProfileSeries.Points.Count; i++)
                                    {
                                        BackwardProfileSeries.Points[i].XValue = BackwardProfileSeries.Points[i].XValue + step;
                                    }
                                    BackwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < BackwardProfileSeries.Points.Count; j++)
                                    {
                                        BackwardProfileSeriesBackup.Points.AddXY(BackwardProfileSeries.Points[j].XValue, BackwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(BackwardProfileSeries);

                                    chartProfile.Series.Add(BackwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(BackwardProfileSeries)].Name = "BackwardSeries";

                                    break;
                                }
                            case "left":
                                {
                                    for (int i = 0; i < BackwardProfileSeries.Points.Count; i++)
                                    {
                                        BackwardProfileSeries.Points[i].XValue = BackwardProfileSeries.Points[i].XValue - step;
                                    }
                                    BackwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < BackwardProfileSeries.Points.Count; j++)
                                    {
                                        BackwardProfileSeriesBackup.Points.AddXY(BackwardProfileSeries.Points[j].XValue, BackwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(BackwardProfileSeries);

                                    chartProfile.Series.Add(BackwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(BackwardProfileSeries)].Name = "BackwardSeries";

                                    break;
                                }
                            case "down":
                                {
                                    for (int i = 0; i < BackwardProfileSeries.Points.Count; i++)
                                    {
                                        BackwardProfileSeries.Points[i].YValues[0] = BackwardProfileSeries.Points[i].YValues[0] - step;
                                    }
                                    BackwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < BackwardProfileSeries.Points.Count; j++)
                                    {
                                        BackwardProfileSeriesBackup.Points.AddXY(BackwardProfileSeries.Points[j].XValue, BackwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(BackwardProfileSeries);

                                    chartProfile.Series.Add(BackwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(BackwardProfileSeries)].Name = "BackwardSeries";

                                    break;
                                }
                            case "up":
                                {
                                    for (int i = 0; i < BackwardProfileSeries.Points.Count; i++)
                                    {
                                        BackwardProfileSeries.Points[i].YValues[0] = BackwardProfileSeries.Points[i].YValues[0] + step;
                                    }
                                    BackwardProfileSeriesBackup.Points.Clear();
                                    for (int j = 0; j < BackwardProfileSeries.Points.Count; j++)
                                    {
                                        BackwardProfileSeriesBackup.Points.AddXY(BackwardProfileSeries.Points[j].XValue, BackwardProfileSeries.Points[j].YValues[0]);
                                    }

                                    chartProfile.Series.Remove(BackwardProfileSeries);

                                    chartProfile.Series.Add(BackwardProfileSeries);
                                    chartProfile.Series[chartProfile.Series.IndexOf(BackwardProfileSeries)].Name = "BackwardSeries";

                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Serious Problem,please contact me!");
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Serious Problem,please contact me!");
                        break;
                    }
            }
        }

    }
}
