using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NETGeographicLib;
using MapWinGIS;
using AxMapWinGIS;
using System.Windows.Forms;

namespace CalProfileAndDataView
{
    class Line
    {
        Grid temGrd = new Grid();

        private Shapefile sf = new Shapefile();

        private int layerHandle = -1;

        public int LayerHandle
        {
            get { return layerHandle; }
            set { layerHandle = value; }
        }

        private bool isSelected = false;

        private string lineTrack = "";
        public string LineTrack
        {
            get { return lineTrack; }
            private set { lineTrack = value; }
        }

        private List<Point> points = new List<Point>();

        public List<Point> Points
        {
            get { return points; }
            private set { points = value; }
        }

        private List<double> azimuth = new List<double>();

        public List<double> Azimuth
        {
            get { return azimuth; }
           private set { azimuth = value; }
        }

        private List<MaxHeightResult> maxHeightResults = new List<MaxHeightResult>();

        public List<MaxHeightResult> MaxHeightResults
        {
            get { return maxHeightResults; }
            private set { maxHeightResults = value; }
        }

        private Line()
        { 
        
        }

        public Line(ref AxMap Map, List<Point> PointsToConnect)
        {
            this.points = PointsToConnect;
            this.lineTrack = CreateLineTrack(PointsToConnect);
            if (!CreateLine(PointsToConnect))
            {
                MessageBox.Show("Failed to create line");
            }
            
             this.layerHandle = Map.AddLayer(sf, true);

            
            int layerPosition = Map.get_LayerPosition(layerHandle);
            Map.MoveLayerTop(layerPosition);
            Map.Redraw();
        }

        public Line(ref AxMap Map, Shapefile initShapefile,int mapLayerHandle)
        {
            AddLineFromShapefile(ref Map, initShapefile, mapLayerHandle);
            if (mapLayerHandle == -1)
            {
                CreateLine(this.points);
            }
            else
            {
                DrawLine(ref Map, this.points);
            }
            Map.Redraw();
        }

        public bool DrawLine(ref AxMap Map, List<Point> PointsToConnect)
        {
            this.points = PointsToConnect;
            this.lineTrack = CreateLineTrack(PointsToConnect);
            if (layerHandle != -1)
            {
                sf = Map.get_Shapefile(layerHandle);
                sf.EditClear();
                if (!CreateLine(PointsToConnect))
                {
                    MessageBox.Show("Failed to create line");
                    return false;
                }
                int layerPosition = Map.get_LayerPosition(layerHandle);
                Map.MoveLayerTop(layerPosition);
                Map.Redraw();
            }
            return true;
        }

        private bool CreateLine(List<Point> PointsToConnect)
        {
            sf.CreateNew("", ShpfileType.SHP_POLYLINE);
            Shape shp = new Shape();
            shp.Create(ShpfileType.SHP_POLYLINE);

            foreach (Point point in PointsToConnect)
            {
                int index = shp.NumPoints;
                shp.InsertPoint(point, ref index);
            }

            int shapeIndex = sf.NumShapes;
            bool isCreated = sf.EditInsertShape(shp, ref shapeIndex);

            // road with direction
            LinePattern pattern = new LinePattern();
            var utils = new Utils();
            pattern.AddLine(utils.ColorByName(tkMapColor.Gray), 8.0f, tkDashStyle.dsSolid);
            pattern.AddLine(utils.ColorByName(tkMapColor.Yellow), 7.0f, tkDashStyle.dsSolid);
            LineSegment segm = pattern.AddMarker(tkDefaultPointSymbol.dpsArrowDown);
            segm.Color = utils.ColorByName(tkMapColor.Orange);
            segm.MarkerSize = 10;
            segm.MarkerInterval = 32;

            ShapefileCategory ct;
            ct = sf.Categories.Add("Direction");
            ct.DrawingOptions.LinePattern = pattern;
            ct.DrawingOptions.UseLinePattern = true;
            sf.set_ShapeCategory(shapeIndex, 0);

            return isCreated;
        }

        private bool Selected()
        {
            return true;
        }

        private bool Unselected()
        {
            return true;
        }

        public void SaveLineShapefile()
        {
            if (layerHandle != -1)
            {
                sf.SaveAs("LineShapeFile", null);
            }
        }

        private void AddLineFromShapefile(ref AxMap Map, Shapefile initShapefile, int mapLayerHandle)
        {
            this.sf = initShapefile;
            if (sf.ShapefileType != ShpfileType.SHP_POLYLINE)
            {
                MessageBox.Show("亲~这个文件不是路径文件哦~");
                return;
            }
            Shape lineShape = sf.get_Shape(0);
            int pointsCount = lineShape.NumPoints;

            for (int i = 0; i < pointsCount; i++)
            {
                this.points.Add(lineShape.get_Point(i));
            }
            this.lineTrack = CreateLineTrack(points);

            if (mapLayerHandle == -1)
            {
                this.layerHandle = Map.AddLayer(sf, true);
            }
            else
            {
                this.layerHandle = mapLayerHandle;
            }

            int layerPosition = Map.get_LayerPosition(layerHandle);
            Map.MoveLayerTop(layerPosition);
            Map.Redraw();
        }

       /* public void CalculateProfile(List<GridBoundsAndFilenames> calGrdBndFilename, double tolerance)
        {
            distance = new List<double>();
            maxHeight = new List<double>();
            if (calGrdBndFilename.Count == 0)
            {
                return;
            }
            List<double> temHeight = new List<double>();
            Grid temGrd = new Grid();
            temGrd.Open(calGrdBndFilename[0].GridFileNames);
            GridHeader temGrdHeader = temGrd.Header;
            Rhumb calculateMaxRhumb = new Rhumb(Constants.WGS84.MajorRadius, Constants.WGS84.Flattening, true);
            double temTrueAzimuth;
            double temCalAzimuthUp;
            double temCalAzimuthDown;
            double delta = temGrdHeader.dX;

            for(int i = 0; i < (points.Count - 1); i++)
            {
                double temdistance;
                int initPointIndex = i;
                int nextPointIndex = i + 1;
                Point initPoint = points[initPointIndex];
                Point nextPoint = points[nextPointIndex];
                double initLat = initPoint.y;
                double initlon = initPoint.x;
                double nextlat = nextPoint.y;
                double nextlon = nextPoint.x;
                double temLat = initLat;
                double temlon = initlon;

                double toleranceLatUp;
                double toleranceLonUp;
                double toleranceLatDown;
                double tolerancelonDown;
                double temDeltaLatMain;
                double temDeltaLonMain;
                double temDeltaLatTolerance;
                double temDeltaLonTolerance;
                int column, row;

                calculateMaxRhumb.Inverse(initLat, initlon, nextlat, nextlon, out temdistance, out temTrueAzimuth);

                temCalAzimuthUp = temTrueAzimuth - 90;
                temCalAzimuthDown = temTrueAzimuth + 90;
                if (temCalAzimuthUp >= 180)
                {
                    temCalAzimuthUp = temCalAzimuthUp - 360;
                }
                else if (temCalAzimuthUp < -180)
                {
                    temCalAzimuthUp = temCalAzimuthUp + 360;
                }

                if (temCalAzimuthDown >= 180)
                {
                    temCalAzimuthDown = temCalAzimuthDown - 360;
                }
                else if (temCalAzimuthDown < -180)
                {
                    temCalAzimuthDown = temCalAzimuthDown + 360;
                }

                
                JudgeDelta(temTrueAzimuth, delta, out temDeltaLatMain, out temDeltaLonMain);
                JudgeDelta(temCalAzimuthUp, delta, out temDeltaLatTolerance, out temDeltaLonTolerance);



                #region Calculate
                if ((temTrueAzimuth > 0) && (temTrueAzimuth < 180))
                {
                    for (double lon = temlon; lon <= nextlon; lon = lon + temDeltaLonMain)
                    {
                        #region Calculate Tolerance
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthUp, tolerance, out toleranceLatUp, out toleranceLonUp);
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthDown, tolerance, out toleranceLatDown, out tolerancelonDown);
                        double calDistance = 0;

                        if ((temCalAzimuthUp > 0) && (temCalAzimuthUp < 180))
                        {
                            double calLat = toleranceLatDown;
                            
                            for (double calLon = tolerancelonDown; calLon <= toleranceLonUp; calLon = calLon + temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }
                                
                            }
                            maxHeight.Add(temHeight.Max());
                            
                        }
                        else if ((temCalAzimuthUp > -180) && (temCalAzimuthUp < 0))
                        {
                            
                            double calLat = toleranceLatDown;
                            for (double calLon = tolerancelonDown; calLon >= toleranceLonUp; calLon = calLon - temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }
                                
                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == 0)
                        {
                            
                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat <= toleranceLatUp; calLat = calLat + temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }
                                
                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == -180)
                        {
                            
                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat >= toleranceLatUp; calLat = calLat - temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }
                                
                            }
                            maxHeight.Add(temHeight.Max());
                        }

                        #endregion
                        
                        if (temTrueAzimuth <= 90)
                        {
                            calculateMaxRhumb.Inverse(temLat, temlon, temLat + temDeltaLatMain, temlon + temDeltaLonMain, out calDistance, out temTrueAzimuth);
                            temLat = temLat + temDeltaLatMain;
                        }
                        else
                        {
                            calculateMaxRhumb.Inverse(temLat, temlon, temLat - temDeltaLatMain, temlon + temDeltaLonMain, out calDistance, out temTrueAzimuth);
                            temLat = temLat - temDeltaLatMain;
                        }
                        distance.Add(calDistance);
                        temlon = temlon + temDeltaLonMain;
                        temHeight.Clear();
                    }
                }
                else if ((temTrueAzimuth > -180) && (temTrueAzimuth < 0))
                {
                    for (double lon = temlon; lon >= nextlon; lon = lon - temDeltaLonMain)
                    {
                        #region Calculate Tolerance
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthUp, tolerance, out toleranceLatUp, out toleranceLonUp);
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthDown, tolerance, out toleranceLatDown, out tolerancelonDown);
                        double calDistance = 0;

                        if ((temCalAzimuthUp > 0) && (temCalAzimuthUp < 180))
                        {
                            double calLat = toleranceLatDown;

                            for (double calLon = tolerancelonDown; calLon <= toleranceLonUp; calLon = calLon + temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());

                        }
                        else if ((temCalAzimuthUp > -180) && (temCalAzimuthUp < 0))
                        {

                            double calLat = toleranceLatDown;
                            for (double calLon = tolerancelonDown; calLon >= toleranceLonUp; calLon = calLon - temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == 0)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat <= toleranceLatUp; calLat = calLat + temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == -180)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat >= toleranceLatUp; calLat = calLat - temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }

                        #endregion
                        
                        
                        if (temTrueAzimuth >= -90)
                        {
                            calculateMaxRhumb.Inverse(temLat, temlon, temLat + temDeltaLatMain, temlon - temDeltaLonMain, out calDistance, out temTrueAzimuth);
                            temLat = temLat + temDeltaLatMain;
                        }
                        else
                        {
                            calculateMaxRhumb.Inverse(temLat, temlon, temLat - temDeltaLatMain, temlon - temDeltaLonMain, out calDistance, out temTrueAzimuth);
                            temLat = temLat - temDeltaLatMain;
                        }
                        distance.Add(calDistance);
                        temlon = temlon - temDeltaLonMain;
                        temHeight.Clear();
                    }
                }
                else if (temTrueAzimuth == 0)
                {
                    for (double Lat = temLat; Lat <= nextlat; Lat = Lat + temDeltaLatMain)
                    {
                        #region Calculate Tolerance
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthUp, tolerance, out toleranceLatUp, out toleranceLonUp);
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthDown, tolerance, out toleranceLatDown, out tolerancelonDown);
                        double calDistance = 0;

                        if ((temCalAzimuthUp > 0) && (temCalAzimuthUp < 180))
                        {
                            double calLat = toleranceLatDown;

                            for (double calLon = tolerancelonDown; calLon <= toleranceLonUp; calLon = calLon + temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());

                        }
                        else if ((temCalAzimuthUp > -180) && (temCalAzimuthUp < 0))
                        {

                            double calLat = toleranceLatDown;
                            for (double calLon = tolerancelonDown; calLon >= toleranceLonUp; calLon = calLon - temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == 0)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat <= toleranceLatUp; calLat = calLat + temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == -180)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat >= toleranceLatUp; calLat = calLat - temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }

                        #endregion
                        
                        calculateMaxRhumb.Inverse(temLat, temlon, temLat + temDeltaLatMain, temlon, out calDistance, out temTrueAzimuth);
                        distance.Add(calDistance);
                        temLat = temLat + temDeltaLatMain;
                        temHeight.Clear();
                    }
                }
                else if (temTrueAzimuth == -180)
                {
                    for (double Lat = temLat; Lat >= nextlat; Lat = Lat - temDeltaLatMain)
                    {
                        #region Calculate Tolerance
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthUp, tolerance, out toleranceLatUp, out toleranceLonUp);
                        calculateMaxRhumb.Direct(temLat, temlon, temCalAzimuthDown, tolerance, out toleranceLatDown, out tolerancelonDown);
                        double calDistance = 0;

                        if ((temCalAzimuthUp > 0) && (temCalAzimuthUp < 180))
                        {
                            double calLat = toleranceLatDown;

                            for (double calLon = tolerancelonDown; calLon <= toleranceLonUp; calLon = calLon + temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());

                        }
                        else if ((temCalAzimuthUp > -180) && (temCalAzimuthUp < 0))
                        {

                            double calLat = toleranceLatDown;
                            for (double calLon = tolerancelonDown; calLon >= toleranceLonUp; calLon = calLon - temDeltaLonTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == 0)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat <= toleranceLatUp; calLat = calLat + temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }
                        else if (temCalAzimuthUp == -180)
                        {

                            double calLon = tolerancelonDown;
                            for (double calLat = toleranceLatDown; calLat >= toleranceLatUp; calLat = calLat - temDeltaLatTolerance)
                            {
                                if (temGrd.Filename != "")
                                {
                                    if (!(temGrd.Extents.PointIsWithin(calLon, calLat)))
                                    {
                                        foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                                        {
                                            if (IsInThisBounds(GrdBndFilename, calLon, calLat))
                                            {
                                                temGrd.Close();
                                                temGrd.Open(GrdBndFilename.GridFileNames);
                                                break;
                                            }
                                        }
                                    }
                                    temGrd.ProjToCell(calLon, calLat, out column, out row);
                                    if ((double)temGrd.get_Value(column, row) == -9999)
                                    {
                                        MessageBox.Show("亲,你的保护区超过数据边界啦!");
                                        return;
                                    }
                                    else
                                    {
                                        temHeight.Add((double)temGrd.get_Value(column, row));
                                    }
                                }

                            }
                            maxHeight.Add(temHeight.Max());
                        }

                        #endregion

                        calculateMaxRhumb.Inverse(temLat, temlon, temLat - temDeltaLatMain, temlon, out calDistance, out temTrueAzimuth);
                        distance.Add(calDistance);
                        temLat = temLat - temDeltaLatMain;
                        temHeight.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Baby,What are you doing!?");
                }
                #endregion

            }

        }
        */
        /*private void JudgeDelta(double azimuth, double delta,out double deltaLat, out double deltaLon)
        {
            double radians = azimuth * (Math.PI / 180);
            double absAzimuth = Math.Abs(azimuth);

            if (((azimuth >= -45) && (azimuth < 0)) || ((azimuth > 0) && (azimuth <= 45)) || ((azimuth > -180) && (azimuth <= -135)) || ((azimuth >= 135) && (azimuth < 180)))
            {
                deltaLat = delta;
                deltaLon = delta * Math.Tan(radians);
                deltaLon = Math.Abs(deltaLon);
            }
            else if ((azimuth >= -135) && (azimuth < -90) || (azimuth > -90) && (azimuth < -45) || (azimuth > 45) && (azimuth < 90) || (azimuth > 90) && (azimuth <= 135))
            {
                deltaLon = delta;
                deltaLat = delta / Math.Tan(radians);
                deltaLat = Math.Abs(deltaLat);
            }
            else if ((azimuth == 180) || (azimuth == -180) || (azimuth == 0))
            {
                deltaLat = delta;
                deltaLon = 0;
            }
            else if (azimuth == 90)
            {
                deltaLon = delta;
                deltaLat = 0;
            }
            else
            {
                deltaLon = -1;
                deltaLat = -1;
            }
            
        }
        */
        public void CalculateProfile(List<GridBoundsAndFilenames> calGrdBndFilename, double tolerance)
        {
            if (calGrdBndFilename.Count != 0)
            {
                temGrd.Open(calGrdBndFilename[0].GridFileNames);

            }
            else
            {
                MessageBox.Show("还未加载高程文件哦");
                return;
            }
            
            maxHeightResults.Clear();
            if (azimuth.Count != 0)
            {
                azimuth.Clear();
            }
            
            Rhumb CalcualteProfileRhumb = new Rhumb(Constants.WGS84.MajorRadius, Constants.WGS84.Flattening, true);
            double mainAzimuth, virtualDistance, deltaAngle, virtualAzimuth;
            if (calGrdBndFilename.Count == 0)
            {
                MessageBox.Show("还未加载高程文件!");
                return;
            }
            else
            {
                Grid temGrdForDelta = new Grid();
                temGrdForDelta.Open(calGrdBndFilename[0].GridFileNames);
                GridHeader temGrdHeader = temGrdForDelta.Header;
                deltaAngle = temGrdHeader.dX;
                temGrdForDelta.Close();
                
            }

            for (int i = 0; i < (points.Count - 1); i++)
            {
                int initPointIndex = i;
                int nextPointIndex = i + 1;
                Point initPoint = points[initPointIndex];
                Point nextPoint = points[nextPointIndex];
                double initLat = initPoint.y;
                double initlon = initPoint.x;
                double nextlat = nextPoint.y;
                double nextlon = nextPoint.x;
                double toleranceTemMinusLat, toleranceTemMinusLon, toleranceTemPlusLat, toleranceTemPlusLon;
                CalProfileAndDataView.LatLonStyle latLonStyleMain,latlonStyleTolerance;
                double maxHeightLat, maxHeightLon, maxHeight, maxHeightDistanceToMainLine;
                double maxHeightDistanceFromInit,temLat,temLon;
                MyPoint maxHeightPoint = new MyPoint();
                MaxHeightResult maxHeightResult = new MaxHeightResult();
                temGrd.Open(calGrdBndFilename[0].GridFileNames);

                temLat = initLat;
                temLon = initlon;
                CalcualteProfileRhumb.Inverse(initLat, initlon, nextlat, nextlon, out virtualDistance, out mainAzimuth);
                latLonStyleMain = JudgeLatLonStyle(mainAzimuth);
                azimuth.Add(mainAzimuth);

                switch (latLonStyleMain)
                {
                    case LatLonStyle.LatUpLonUp:
                        {
                            while ((temLat <= nextlat) && (temLon <= nextlon))
                            {
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth - 90, tolerance,
                                    out toleranceTemMinusLat, out toleranceTemMinusLon);
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth + 90, tolerance,
                                    out toleranceTemPlusLat, out toleranceTemPlusLon);
                                latlonStyleTolerance = JudgeLatLonStyle(mainAzimuth + 90);

                                GetMaxHeight(toleranceTemMinusLat, toleranceTemMinusLon, toleranceTemPlusLat, toleranceTemPlusLon,
                    calGrdBndFilename, deltaAngle, latlonStyleTolerance, mainAzimuth + 90,
                    out maxHeightLat, out maxHeightLon, out maxHeight, out maxHeightDistanceToMainLine);
                                maxHeightPoint.y = maxHeightLat;
                                maxHeightPoint.x = maxHeightLon;
                                CalcualteProfileRhumb.Inverse(initLat, initlon, temLat, temLon,
                                    out maxHeightDistanceFromInit, out virtualAzimuth);
                                maxHeightResult.DistanceFromInit = maxHeightDistanceFromInit;
                                maxHeightResult.Height = maxHeight;
                                maxHeightResult.Point = maxHeightPoint;
                                maxHeightResult.DistanceToMainLine = maxHeightDistanceToMainLine - tolerance;
                                maxHeightResults.Add(maxHeightResult);

                                GetNextPoint(temLat, temLon, deltaAngle, nextlat, nextlon, mainAzimuth, latLonStyleMain,
                                    out temLat, out temLon);
                            }
                            temGrd.Close();
                            GC.Collect();
                            break;
                        }
                    case LatLonStyle.LatUpLonDown:
                        {
                            while ((temLat <= nextlat) && (temLon >= nextlon))
                            {
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth - 90, tolerance,
                                    out toleranceTemMinusLat, out toleranceTemMinusLon);
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth + 90, tolerance,
                                    out toleranceTemPlusLat, out toleranceTemPlusLon);
                                latlonStyleTolerance = JudgeLatLonStyle(mainAzimuth + 90);

                                GetMaxHeight(toleranceTemMinusLat, toleranceTemMinusLon, toleranceTemPlusLat, toleranceTemPlusLon,
                    calGrdBndFilename, deltaAngle, latlonStyleTolerance, mainAzimuth + 90,
                    out maxHeightLat, out maxHeightLon, out maxHeight, out maxHeightDistanceToMainLine);
                                maxHeightPoint.y = maxHeightLat;
                                maxHeightPoint.x = maxHeightLon;
                                CalcualteProfileRhumb.Inverse(initLat, initlon, temLat, temLon,
                                    out maxHeightDistanceFromInit, out virtualAzimuth);
                                maxHeightResult.DistanceFromInit = maxHeightDistanceFromInit;
                                maxHeightResult.Height = maxHeight;
                                maxHeightResult.Point = maxHeightPoint;
                                maxHeightResult.DistanceToMainLine = maxHeightDistanceToMainLine - tolerance;
                                maxHeightResults.Add(maxHeightResult);

                                GetNextPoint(temLat, temLon, deltaAngle, nextlat, nextlon, mainAzimuth, latLonStyleMain,
                                    out temLat, out temLon);
                            }
                            temGrd.Close();
                            GC.Collect();
                            break;
                        }
                    case LatLonStyle.LatDownLonDown:
                        {
                            while ((temLat >= nextlat) && (temLon >= nextlon))
                            {
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth - 90, tolerance,
                                    out toleranceTemMinusLat, out toleranceTemMinusLon);
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth + 90, tolerance,
                                    out toleranceTemPlusLat, out toleranceTemPlusLon);
                                latlonStyleTolerance = JudgeLatLonStyle(mainAzimuth + 90);

                                GetMaxHeight(toleranceTemMinusLat, toleranceTemMinusLon, toleranceTemPlusLat, toleranceTemPlusLon,
                    calGrdBndFilename, deltaAngle, latlonStyleTolerance, mainAzimuth + 90,
                    out maxHeightLat, out maxHeightLon, out maxHeight, out maxHeightDistanceToMainLine);
                                maxHeightPoint.y = maxHeightLat;
                                maxHeightPoint.x = maxHeightLon;
                                CalcualteProfileRhumb.Inverse(initLat, initlon, temLat, temLon,
                                    out maxHeightDistanceFromInit, out virtualAzimuth);
                                maxHeightResult.DistanceFromInit = maxHeightDistanceFromInit;
                                maxHeightResult.Height = maxHeight;
                                maxHeightResult.Point = maxHeightPoint;
                                maxHeightResult.DistanceToMainLine = maxHeightDistanceToMainLine - tolerance;
                                maxHeightResults.Add(maxHeightResult);

                                GetNextPoint(temLat, temLon, deltaAngle, nextlat, nextlon, mainAzimuth, latLonStyleMain,
                                    out temLat, out temLon);
                            }
                            temGrd.Close();
                            GC.Collect();
                            break;
                        }
                    case LatLonStyle.LatDownLonUp:
                        {
                            while ((temLat >= nextlat) && (temLon <= nextlon))
                            {
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth - 90, tolerance,
                                    out toleranceTemMinusLat, out toleranceTemMinusLon);
                                CalcualteProfileRhumb.Direct(temLat, temLon, mainAzimuth + 90, tolerance,
                                    out toleranceTemPlusLat, out toleranceTemPlusLon);
                                latlonStyleTolerance = JudgeLatLonStyle(mainAzimuth + 90);

                                GetMaxHeight(toleranceTemMinusLat, toleranceTemMinusLon, toleranceTemPlusLat, toleranceTemPlusLon,
                    calGrdBndFilename, deltaAngle, latlonStyleTolerance, mainAzimuth + 90,
                    out maxHeightLat, out maxHeightLon, out maxHeight, out maxHeightDistanceToMainLine);
                                maxHeightPoint.y = maxHeightLat;
                                maxHeightPoint.x = maxHeightLon;
                                CalcualteProfileRhumb.Inverse(initLat, initlon, temLat, temLon,
                                    out maxHeightDistanceFromInit, out virtualAzimuth);
                                maxHeightResult.DistanceFromInit = maxHeightDistanceFromInit;
                                maxHeightResult.Height = maxHeight;
                                maxHeightResult.Point = maxHeightPoint;
                                maxHeightResult.DistanceToMainLine = maxHeightDistanceToMainLine - tolerance;
                                maxHeightResults.Add(maxHeightResult);

                                GetNextPoint(temLat, temLon, deltaAngle, nextlat, nextlon, mainAzimuth, latLonStyleMain,
                                    out temLat, out temLon);
                            }
                            temGrd.Close();
                            GC.Collect();
                            break;
                        }
                    case LatLonStyle.Wrong:
                        {
                            MessageBox.Show("Wrong!");
                            temGrd.Close();
                            GC.Collect();
                            break;
                        }
                    default:
                        {
                            temGrd.Close();
                            GC.Collect();
                            MessageBox.Show("Wrong!");
                            break;
                        }
                }
            }
        }
        /* private FirstTest.DeltaStyle JudgeDelta(double judgeAzimuth)
        private FirstTest.DeltaStyle JudgeDelta(double judgeAzimuth)
        {
            if (((judgeAzimuth >= 45) && (judgeAzimuth < 90)) || ((judgeAzimuth > 90) && (judgeAzimuth <= 135)) 
        || ((judgeAzimuth > -90) && (judgeAzimuth <= -45)) || ((judgeAzimuth >= 135) && (judgeAzimuth < -90)))
            {
                return DeltaStyle.ConstantDeltaDistance;
            }
            else if (((judgeAzimuth > 0) && (judgeAzimuth < 45)) || ((judgeAzimuth > -45) && (judgeAzimuth < 0))
        || ((judgeAzimuth > -180) && (judgeAzimuth < -135)) || ((judgeAzimuth > 135) && (judgeAzimuth < 180)))
            {
                return DeltaStyle.ChangedDeltaDistance;
            }
            else if ((judgeAzimuth == 0) || (judgeAzimuth == -180) || (judgeAzimuth == 180))
            {
                return DeltaStyle.VerticalDelta;
            }
            else if ((judgeAzimuth == 90) || (judgeAzimuth == -90))
            {
                return DeltaStyle.HorizontalDelta;
            }
            else
            {
                MessageBox.Show("未知的错误，请联系Assemble");
                return DeltaStyle.Wrong;
            }
        }
        */
        private CalProfileAndDataView.LatLonStyle JudgeLatLonStyle(double judgeAzimuth)
        {
            if (judgeAzimuth > 180)
            {
                judgeAzimuth = judgeAzimuth - 360;
            }
            else if (judgeAzimuth < -180)
            {
                judgeAzimuth = judgeAzimuth + 360;
            }

            if ((judgeAzimuth >= 0) && (judgeAzimuth < 90))
            {
                return LatLonStyle.LatUpLonUp;
            }
            else if ((judgeAzimuth >= 90) && (judgeAzimuth <= 180))
            {
                return LatLonStyle.LatDownLonUp;
            }
            else if ((judgeAzimuth >= -180) && (judgeAzimuth < -90))
            {
                return LatLonStyle.LatDownLonDown;
            }
            else if ((judgeAzimuth >= -90) && (judgeAzimuth < 0))
            {
                return LatLonStyle.LatUpLonDown;
            }
            else
            {
                MessageBox.Show("未知的错误，请联系Assemble");
                return LatLonStyle.Wrong;
            }
        }

        private void GetMaxHeight(double minusLat, double minusLon, double plusLat, double plusLon, List<GridBoundsAndFilenames> calGrdBndFilename,
                                  double deltaAngle, LatLonStyle latLonStyle,double toleranceAzimuth,
                                  out double maxHeightLat, out double maxHeightLon, out double maxHeight,
                                    out double maxHeightDistance)
        {
            Rhumb GetMaxHeightRhumb = new Rhumb(Constants.WGS84.MajorRadius, Constants.WGS84.Flattening, true);
            double temLat, temLon;
            temLat = minusLat;
            temLon = minusLon;
            maxHeightLat = minusLat;
            maxHeightLon = minusLon;
            double temHeight, virtualAzimuth;
            int maxNum;
            List<double> temHeightList = new List<double>();
            List<double> temDistanceList = new List<double>();

            temHeight = GetExactPointHeight(calGrdBndFilename, temLat, temLon);
            temHeightList.Add(temHeight);

            if (toleranceAzimuth > 180)
            {
                toleranceAzimuth = toleranceAzimuth - 360;
            }
            else if (toleranceAzimuth < -180)
            {
                toleranceAzimuth = toleranceAzimuth + 360;
            }

            GetNextPoint(temLat, temLon, deltaAngle, plusLat, plusLon,
                toleranceAzimuth, latLonStyle,
                out temLat, out temLon);

            switch (latLonStyle)
            {
                case LatLonStyle.LatUpLonUp:
                    {
                        while ((temLat <= plusLat) && (temLon <= plusLon))
                        {
                            GetNextPoint(temLat, temLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle,
                                out temLat, out temLon);
                            temHeight = GetExactPointHeight(calGrdBndFilename, temLat, temLon);
                            temHeightList.Add(temHeight);
                            
                        }
                        maxHeight = temHeightList.Max();
                        maxNum = temHeightList.IndexOf(maxHeight);
                        for (int i = 0; i <= maxNum; i++)
                        {
                            GetNextPoint(maxHeightLat, maxHeightLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle, out maxHeightLat, out maxHeightLon);
                        }
                        GetMaxHeightRhumb.Inverse(minusLat, minusLon, maxHeightLat, maxHeightLon,
                            out maxHeightDistance, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatUpLonDown:
                    {
                        while ((temLat <= plusLat) && (temLon >= plusLon))
                        {
                            GetNextPoint(temLat, temLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle,
                                out temLat, out temLon);
                            temHeight = GetExactPointHeight(calGrdBndFilename, temLat, temLon);
                            temHeightList.Add(temHeight);

                        }
                        maxHeight = temHeightList.Max();
                        maxNum = temHeightList.IndexOf(maxHeight);
                        for (int i = 0; i <= maxNum; i++)
                        {
                            GetNextPoint(maxHeightLat, maxHeightLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle, out maxHeightLat, out maxHeightLon);
                        }
                        GetMaxHeightRhumb.Inverse(minusLat, minusLon, maxHeightLat, maxHeightLon,
                            out maxHeightDistance, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatDownLonDown:
                    {
                        while ((temLat >= plusLat) && (temLon >= plusLon))
                        {
                            GetNextPoint(temLat, temLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle,
                                out temLat, out temLon);
                            temHeight = GetExactPointHeight(calGrdBndFilename, temLat, temLon);
                            temHeightList.Add(temHeight);

                        }
                        maxHeight = temHeightList.Max();
                        maxNum = temHeightList.IndexOf(maxHeight);
                        for (int i = 0; i <= maxNum; i++)
                        {
                            GetNextPoint(maxHeightLat, maxHeightLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle, out maxHeightLat, out maxHeightLon);
                        }
                        GetMaxHeightRhumb.Inverse(minusLat, minusLon, maxHeightLat, maxHeightLon,
                            out maxHeightDistance, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatDownLonUp:
                    {
                        while ((temLat >= plusLat) && (temLon <= plusLon))
                        {
                            GetNextPoint(temLat, temLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle,
                                out temLat, out temLon);
                            temHeight = GetExactPointHeight(calGrdBndFilename, temLat, temLon);
                            temHeightList.Add(temHeight);

                        }
                        maxHeight = temHeightList.Max();
                        maxNum = temHeightList.IndexOf(maxHeight);
                        for (int i = 0; i <= maxNum; i++)
                        {
                            GetNextPoint(maxHeightLat, maxHeightLon, deltaAngle, plusLat, plusLon,
                                toleranceAzimuth, latLonStyle, out maxHeightLat, out maxHeightLon);
                        }
                        GetMaxHeightRhumb.Inverse(minusLat, minusLon, maxHeightLat, maxHeightLon,
                            out maxHeightDistance, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.Wrong:
                    {
                        MessageBox.Show("Wrong!");
                        maxHeight = -9999;
                        maxHeightLat = -9999;
                        maxHeightLon = -9999;
                        maxHeightDistance = -9999;
                        break;
                    }
                default:
                    {
                        maxHeight = -9999;
                        maxHeightLat = -9999;
                        maxHeightLon = -9999;
                        maxHeightDistance = -9999;
                        MessageBox.Show("Wrong!");
                        break;
                    }
                    
            }
        }
        
        private void GetNextPoint(double temLat, double temLon,  double deltaAngle,
                              double nextLat, double nextLon, double anyAzimuth, LatLonStyle latLonStyle,
                              out double nextTemLat, out double nextTemLon)
        {
            double virtualAzimuth, deltaDistancePer, nextDeltaLonDistance, nextDeltaLonDistancePer;
            double lonCount, latCount, nextDeltaLatDistance, nextDeltaLatDistancePer;
            Rhumb GetNextPointRhumb = new Rhumb(Constants.WGS84.MajorRadius, Constants.WGS84.Flattening, true);

            if (anyAzimuth > 180)
            {
                anyAzimuth = anyAzimuth - 360;
            }
            else if (anyAzimuth < -180)
            {
                anyAzimuth = anyAzimuth + 360;
            }
            
            switch (latLonStyle)
            {
                case LatLonStyle.LatUpLonUp:
                    {
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, nextLon, out nextDeltaLonDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, temLon + deltaAngle, out nextDeltaLonDistancePer, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, nextLat, temLon, out nextDeltaLatDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat + deltaAngle, temLon, out nextDeltaLatDistancePer, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatUpLonDown:
                    {
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, nextLon, out nextDeltaLonDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, temLon - deltaAngle, out nextDeltaLonDistancePer, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, nextLat, temLon, out nextDeltaLatDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat + deltaAngle, temLon, out nextDeltaLatDistancePer, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatDownLonDown:
                    {
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, nextLon, out nextDeltaLonDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, temLon - deltaAngle, out nextDeltaLonDistancePer, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, nextLat, temLon, out nextDeltaLatDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat - deltaAngle, temLon, out nextDeltaLatDistancePer, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.LatDownLonUp:
                    {
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, nextLon, out nextDeltaLonDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat, temLon + deltaAngle, out nextDeltaLonDistancePer, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, nextLat, temLon, out nextDeltaLatDistance, out virtualAzimuth);
                        GetNextPointRhumb.Inverse(temLat, temLon, temLat - deltaAngle, temLon, out nextDeltaLatDistancePer, out virtualAzimuth);
                        break;
                    }
                case LatLonStyle.Wrong:
                    {
                        MessageBox.Show("Wrong!");
                        nextDeltaLonDistance = -9999;
                        nextDeltaLonDistancePer = -9999;
                        nextDeltaLatDistance = -9999;
                        nextDeltaLatDistancePer = -9999;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Wrong!");
                        nextDeltaLonDistance = -9999;
                        nextDeltaLonDistancePer = -9999;
                        nextDeltaLatDistance = -9999;
                        nextDeltaLatDistancePer = -9999;
                        break;
                    }
            }

            lonCount = nextDeltaLonDistance / nextDeltaLonDistancePer;
            latCount = nextDeltaLatDistance / nextDeltaLatDistancePer;
            if (lonCount > latCount)
            {
                deltaDistancePer = Math.Pow(Math.Pow(nextDeltaLonDistancePer, 2) + Math.Pow(nextDeltaLatDistance / lonCount, 2), 0.5);
            }
            else
            {
                deltaDistancePer = Math.Pow(Math.Pow(nextDeltaLonDistance / latCount, 2) + Math.Pow(nextDeltaLatDistancePer, 2), 0.5);
            }
            GetNextPointRhumb.Direct(temLat, temLon, anyAzimuth, deltaDistancePer, out nextTemLat, out nextTemLon);
        }

        private double GetExactPointHeight(List<GridBoundsAndFilenames> calGrdBndFilename,
                                    double exactPointLat, double exactPointLon)
        {
            int column, row;
            //temGrd.Open(calGrdBndFilename[0].GridFileNames);
            if (temGrd.Filename != "")
            {
                if (!(temGrd.Extents.PointIsWithin(exactPointLon, exactPointLat)))
                {
                    foreach (GridBoundsAndFilenames GrdBndFilename in calGrdBndFilename)
                    {
                        if (IsInThisBounds(GrdBndFilename, exactPointLon, exactPointLat))
                        {
                            temGrd.Close();
                            temGrd.Open(GrdBndFilename.GridFileNames);
                            break;
                        }
                    }
                }
                temGrd.ProjToCell(exactPointLon, exactPointLat, out column, out row);
                if ((double)temGrd.get_Value(column, row) == -9999)
                {
                    MessageBox.Show("亲,你的保护区超过数据边界啦!");
                    return -9999;
                }
                else
                {
                    return (double)temGrd.get_Value(column, row);
                }
            }
            else
            {
                MessageBox.Show("亲,还没加载高程数据呢!");
                return -9999;
            }
            
        }


        private string CreateLineTrack(List<Point> PointsToConnect)
        {
            string lineTrack = "";
            foreach (Point Point in PointsToConnect)
            {
                if (PointsToConnect.Count == 1)
                {
                    lineTrack = Convert.ToString(Point.Key);
                }
                if (PointsToConnect.Count > 1)
                {
                    if (PointsToConnect.IndexOf(Point) == 0)
                    {
                        lineTrack = Convert.ToString(Point.Key);
                    }
                    if (PointsToConnect.IndexOf(Point) > 0)
                    {
                        lineTrack = lineTrack + "->" + Convert.ToString(Point.Key); 
                    }
                }
            }
            if (PointsToConnect.Count == 0)
            {
                lineTrack = "";
            }
            return lineTrack;
        }

        public void UpdateLineTrack()
        {
            foreach (Point Point in points)
            {
                if (points.Count == 1)
                {
                    lineTrack = Convert.ToString(Point.Key);
                }
                if (points.Count > 1)
                {
                    if (points.IndexOf(Point) == 0)
                    {
                        lineTrack = Convert.ToString(Point.Key);
                    }
                    if (points.IndexOf(Point) > 0)
                    {
                        lineTrack = lineTrack + "->" + Convert.ToString(Point.Key);
                    }
                }
            }
            if (points.Count == 0)
            {
                lineTrack = "";
            }
        }

        private bool IsInThisBounds(GridBoundsAndFilenames grdBndFilename, double x, double y)
        {
            if ((x >= grdBndFilename.XMin) & (x <= grdBndFilename.XMax) & (y >= grdBndFilename.YMin) & (y <= grdBndFilename.YMax))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
