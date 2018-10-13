using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MapWinGIS;
using AxMapWinGIS;
using System.Diagnostics;

namespace CalProfileAndDataView
{
   

    public partial class frmDataView : Form
    {
        
        private Grid grd = new Grid();//珊格对象用于获取map上确定点的高度
        private List<int> gridLayerHandlers = new List<int>();//显示的各个高程图的图的标号
        private int PointShapefileLayerHandle = -1;
        private int lineShapefileLayerHandle = -1;
        private List<GridBoundsAndFilenames> grdBndFilenames = new List<GridBoundsAndFilenames>();//自定义的一个类用于保存在某一经纬度范围内的grid文件的filename信息
        private List<MapWinGIS.Point> points = new List<MapWinGIS.Point>();
        frmViewPoints ViewPoint = new frmViewPoints();
        //frmViewLine ViewLine = new frmViewLine();
        frmViewLine ViewLine;
        frmViewProfile ViewProfile;
        private Line line;
        private AxMapWinGIS.AxMap temMap = new AxMap();

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
        
        public frmDataView()
        {
            InitializeComponent();
            this.Map.PreviewKeyDown += delegate(object sender, PreviewKeyDownEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Down:
                        e.IsInputKey = true;
                        return;
                }
            };
            this.Map.Measuring.DisplayAngles = true;
            this.Map.SendMouseDown = true;
            this.Map.Tiles.Visible = false;

            Shapefile sf = new Shapefile();
            sf.Open(Application.StartupPath + "\\Resources\\World_region.shp");
            sf.DefaultDrawingOptions.FillColor = 16777215;  //填充色为白色
            this.Map.AddLayer(sf, true);
            this.Map.ZoomToMaxExtents();
        }

        private void BtnAddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*|" + "DEM格式" + "|" + "*.asc";// + "|" + img.CdlgFilter;
            //dlg.Filter = "All Files (*.*)|*.*|" + "矢量格式" + "|" + "*.shp" + "|" + "DEM格式" + "|" + "*.asc";// + "|" + img.CdlgFilter;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String extention = Path.GetExtension(dlg.FileName).ToLower();
                Map.Tag = dlg.FileName;
                /*if (extention == ".shp")
                {
                    Shapefile sf = new Shapefile();

                    sf.Open((string)Map.Tag);

                    sf.DefaultDrawingOptions.FillColor = 16777215;  //填充色为白色
                    Map.AddLayer(sf, true);
                    Map.ZoomToMaxExtents();
                    return;
                }*/
                if (extention == ".asc")
                {
                    #region Direct rendering for grid
                    /*
                    MapWinGIS.Image gridimage = new MapWinGIS.Image();
                    if (gridimage.Open(dlg.FileName,ImageType.USE_FILE_EXTENSION,false,null))
                    {
                        if (!gridimage.IsRgb)
                        {
                            grd = gridimage.OpenAsGrid();
                            if (grd != null)
                            {
                                GridColorScheme sch = new GridColorScheme();
                                sch.UsePredefined(-200, 9000, PredefinedColorScheme.ReversedRainbow);
                                sch.ApplyColoringType(ColoringType.Hillshade);
                                gridimage.CustomColorScheme = sch;
                                Map.AddLayer(gridimage, true);
                                Map.ZoomToMaxExtents();
                                //grd.Close();
                            }
                        }
                    }
                    */
                    #endregion
                    

                    Thread ViewGridfileThread = new Thread(this.ViewGridfile);
                    ViewGridfileThread.SetApartmentState(ApartmentState.STA);
                    ViewGridfileThread.Start();

                    UpdateGridToMap();
                    return;

                }
                else
                {
                    MessageBox.Show("不能识别此种文件哦亲~只能识别.asc后缀名的高程文件");
                    return;
                }
                /*else if (img.CdlgFilter.ToLower().Contains(extention))
                {
                    img.Open(dlg.FileName);
                    Map.AddLayer(img, true);
                    Map.ZoomToMaxExtents();
                    return;
                }*/
            }
        }

        private void rdZoomIn_CheckedChanged(object sender, EventArgs e)
        {
            Map.CursorMode = tkCursorMode.cmZoomIn;
        }

        private void rdZoomOut_CheckedChanged(object sender, EventArgs e)
        {
            Map.CursorMode = tkCursorMode.cmZoomOut;
        }

        private void rdPan_CheckedChanged(object sender, EventArgs e)
        {
            Map.CursorMode = tkCursorMode.cmPan;
        }

        private void rdSelection_CheckedChanged(object sender, EventArgs e)
        {
            Map.CursorMode = tkCursorMode.cmSelection;
        }


        private void btnCalHeight_Click(object sender, EventArgs e)
        {
            double lat = 0.0;
            double lng = 0.0;
            double height;
            int column = 0;
            int row = 0;

            lat = Convert.ToDouble(tbLat.Text);
            lng = Convert.ToDouble(tbLng.Text);

            if (grd.Filename != "")
            {
                grd.ProjToCell(lng, lat, out column, out row);
                height = (double)grd.get_Value(column, row);
                tbHeight.Text = height.ToString();
            }
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            double lat = 0.0;
            double lng = 0.0;
            string pointName = "";

            lat = Convert.ToDouble(tbLat.Text);
            lng = Convert.ToDouble(tbLng.Text);
            pointName = tbName.Text;

            AddPoint(Map, lng, lat, pointName);
        }

        private void vSclbTransparent_ValueChanged(object sender, EventArgs e)
        {
            foreach (int layerHandler in gridLayerHandlers)
            {
                Map.set_ImageLayerPercentTransparent(layerHandler, ((float)vSclbTransparent.Value) / 100);
            }
        }





        private void UpdateProgressBarToMarquee()
        {
            pgbAllView.Style = ProgressBarStyle.Marquee;
        }

        private void UpdateProgressBarToBlocks()
        {
            pgbAllView.Style = ProgressBarStyle.Blocks;
        }

        private delegate void UpdateProgressBarDelegate();


        private void ViewGridfile()
        {
            this.BeginInvoke(new UpdateProgressBarDelegate(UpdateProgressBarToMarquee));
            MessageBox.Show("即将导入大数据，可能会出现界面无响应的情况，请耐心等待,点击确定键继续");
            GridBoundsAndFilenames temGrid = new GridBoundsAndFilenames();
            grd.Open((string)Map.Tag);

            temGrid.XMin = grd.Extents.xMin;
            temGrid.XMax = grd.Extents.xMax;
            temGrid.YMin = grd.Extents.yMin;
            temGrid.YMax = grd.Extents.yMax;
            temGrid.GridFileNames = grd.Filename;
            grdBndFilenames.Add(temGrid);
            Utils u = new Utils();
            GridColorScheme sch = new GridColorScheme();
            sch.UsePredefined(-200, 9000, PredefinedColorScheme.ReversedRainbow);
            sch.ApplyColoringType(ColoringType.Hillshade);
            

            
            //MessageBox.Show("即将导入大数据，可能会出现界面无响应的情况，请耐心等待,点击确定键继续");
            //GridImage = u.GridToImage(temThreadGrid, sch);
            //gridImages.Add(GridImage);
            this.BeginInvoke(new UpdateProgressBarDelegate(UpdateProgressBarToBlocks));
            MessageBox.Show("导入完成");
        }

        private void UpdateGridToMap()
        {
            int layerHandler;
            /*
            foreach (MapWinGIS.Image UpdateMapGridImage in gridImages)
            {
                layerHandler = Map.AddLayer(GridImage, true);
                gridLayerHandlers.Add(layerHandler);
                Map.set_ImageLayerPercentTransparent(layerHandler, ((float)vSclbTransparent.Value) / 100);
            }
            
            Map.ZoomToMaxExtents();
            */
            MapWinGIS.Image img = new MapWinGIS.Image();
            img.Open((string)Map.Tag);
            layerHandler = Map.AddLayer(img, true);
            gridLayerHandlers.Add(layerHandler);
            Map.set_ImageLayerPercentTransparent(layerHandler, ((float)vSclbTransparent.Value) / 100);
            Map.ZoomToMaxExtents();
        }


        private void AddPoint(AxMap Map, double lng, double lat,string pointName)
        {
            var sf = new Shapefile();
            if (PointShapefileLayerHandle != -1)
            {
                sf = Map.get_Shapefile(PointShapefileLayerHandle);
            }
                
            if (PointShapefileLayerHandle == -1)
            {
                if (!sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT))
                {
                    MessageBox.Show("Failed to create shapefile: " + sf.ErrorMsg[sf.LastErrorCode]);
                    return;
                }
                PointShapefileLayerHandle = Map.AddLayer(sf, true);
            }

            var utils = new Utils();
            ShapeDrawingOptions options = sf.DefaultDrawingOptions;
            options.PointType = tkPointSymbolType.ptSymbolStandard;
            options.PointShape = tkPointShapeType.ptShapeCross;
            options.FillColor = utils.ColorByName(tkMapColor.Black);
            sf.DefaultDrawingOptions = options;
            sf.CollisionMode = tkCollisionMode.AllowCollisions;

            
            Shape shp = new Shape();


            //shp = sf.get_Shape(shapeIndex);
            shp.Create(ShpfileType.SHP_POINT);

                

            MapWinGIS.Point pnt = new MapWinGIS.Point();
            pnt.x = lng;
            pnt.y = lat;
            pnt.Key = pointName;

            int Index;
            Index = shp.NumPoints;

            shp.InsertPoint(pnt, ref Index);

            Index = sf.NumShapes;

            if (!sf.EditInsertShape(shp, Index))
            {
                MessageBox.Show("Failed to insert shape: " + sf.ErrorMsg[sf.LastErrorCode]);
                return;
            }

            points.Add(pnt);
            Map.Redraw();
        }

        private void UpdatePoint(AxMap Map, List<MapWinGIS.Point> PointsToUpdate)
        {
            var sf = new Shapefile();
            if (PointShapefileLayerHandle != -1)
            {
                sf = Map.get_Shapefile(PointShapefileLayerHandle);
            }

            if (PointShapefileLayerHandle == -1)
            {
                if (!sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT))
                {
                    MessageBox.Show("Failed to create shapefile: " + sf.ErrorMsg[sf.LastErrorCode]);
                    return;
                }
                PointShapefileLayerHandle = Map.AddLayer(sf, true);
            }
            ShapeDrawingOptions options = sf.DefaultDrawingOptions;
            options.PointType = tkPointSymbolType.ptSymbolStandard;
            options.PointShape = tkPointShapeType.ptShapeCross;
            sf.DefaultDrawingOptions = options;
            sf.CollisionMode = tkCollisionMode.AllowCollisions;
            sf.EditClear();

            foreach (MapWinGIS.Point PointToUpdate in PointsToUpdate)
            {
                Shape shp = new Shape();
                shp.Create(ShpfileType.SHP_POINT);
                MapWinGIS.Point pnt = PointToUpdate;

                int Index;
                Index = shp.NumPoints;

                shp.InsertPoint(pnt, ref Index);

                Index = sf.NumShapes;

                if (!sf.EditInsertShape(shp, Index))
                {
                    MessageBox.Show("Failed to insert shape: " + sf.ErrorMsg[sf.LastErrorCode]);
                    return;
                }

                Map.Redraw();
            }
            if (PointsToUpdate.Count == 0)
            {
                Map.Redraw();
            }
        }

        private void btnViewPoints_Click(object sender, EventArgs e)
        {
            if (ViewPoint == null || ViewPoint.IsDisposed)
            {
                ViewPoint = new frmViewPoints();
            }
            else
            {
                ViewPoint.Show();
                ViewPoint.Focus();
            }

            int ID = 0;
            foreach(MapWinGIS.Point point in points)
            {
                ID++;
                ViewPoint.DataTablePointsList.Rows.Add(new string[] { Convert.ToString(ID), Convert.ToString(point.y), Convert.ToString(point.x),point.Key });
            }
            ViewPoint.DeletePointsEvent += new DeletePointsDelegate(frmViewPointsDeletePointsEvent);
            ViewPoint.SavePointsShapefileEvent += new SavePointsShapefileDelegate(ViewPoint_SavePointsShapefileEvent);
            ViewPoint.ConnectPointsEvent += new ConnectPointsDelegate(ViewPoint_ConnectPointsEvent);
            ViewPoint.PointContentChangedEvent += new PointContentChangedDelegate(ViewPoint_PointContentChangedEvent);
            ViewPoint.Show();
            //ViewPoint.Owner = this;
        }

        void ViewPoint_PointContentChangedEvent(int ID, double latitude, double longtitude, string name)
        {
            points[ID - 1].y = latitude;
            points[ID - 1].x = longtitude;
            points[ID - 1].Key = name;

            UpdatePoint(Map, points);
            if (!(ViewLine == null || ViewLine.IsDisposed))
            {
                ViewLine.Close();
            }
        }

        void ViewPoint_ConnectPointsEvent(List<int> ConnectedPointIndexes)
        {
            List<MapWinGIS.Point> ConnectedPoints = new List<MapWinGIS.Point>();

            foreach (int ConnectedPointIndex in ConnectedPointIndexes)
            {
                ConnectedPoints.Add(points[ConnectedPointIndex - 1]);
            }

            if (line == null)
            {
                line = new Line(ref Map, ConnectedPoints);
            }
            else
            {
                line.DrawLine(ref Map, ConnectedPoints);
            }
            lineShapefileLayerHandle = line.LayerHandle;
        }

        void ViewPoint_SavePointsShapefileEvent()
        {
            //SaveFileDialog saveDlg = new SaveFileDialog();
            var sf = new Shapefile();
            if (PointShapefileLayerHandle != -1)
            {
                sf = Map.get_Shapefile(PointShapefileLayerHandle);
                sf.SaveAs("PntShapeFile", null);
            }
        }


        void frmViewPointsDeletePointsEvent(List<int> DeletedPointIndexes)
        {
            if (ViewPoint == null || ViewPoint.IsDisposed)
            {
                ViewPoint = new frmViewPoints();
            }
            else
            {
                ViewPoint.Show();
                ViewPoint.Focus();
            }

            List<MapWinGIS.Point> DeletedPoints = new List<MapWinGIS.Point>();
           
            foreach (int DeletedPointIndex in DeletedPointIndexes)
            {
                DeletedPoints.Add(points[DeletedPointIndex - 1]);
            }
            foreach (MapWinGIS.Point DeletedPoint in DeletedPoints)
            {
                points.Remove(DeletedPoint);
            }

            ViewPoint.DataTablePointsList.Clear();
            int ID = 0;
            foreach (MapWinGIS.Point point in points)
            {
                ID++;
                ViewPoint.DataTablePointsList.Rows.Add(new string[] { Convert.ToString(ID), Convert.ToString(point.y), Convert.ToString(point.x) });
            }

            UpdatePoint(Map, points);
        }

        private void buttonViewLine_Click(object sender, EventArgs e)
        {
            if (ViewLine == null || ViewLine.IsDisposed)
            {
                if (line != null)
                {
                    line.UpdateLineTrack();
                    ViewLine = new frmViewLine(line.LineTrack);
                    int ID = 0;
                    foreach (MapWinGIS.Point point in line.Points)
                    {
                        ID++;
                        ViewLine.DataTableLine.Rows.Add(new string[] { Convert.ToString(ID), Convert.ToString(point.y), Convert.ToString(point.x), point.Key });
                    }
                }
                else
                {
                    ViewLine = new frmViewLine();
                    //MessageBox.Show("宝贝~你还没划线呢~");
                    //return;
                }
            }
            else
            {
                ViewLine.Linetrack = line.LineTrack;
                ViewLine.UpdateTexeboxLinetrack();
                ViewLine.Show();
                ViewLine.Focus();
            }
            
            
            
            ViewLine.AddLineEvent += new AddLineDelegate(ViewLine_AddLineEvent);
            ViewLine.SaveLineEvent += new SaveLineDelegate(ViewLine_SaveLineEvent);
            ViewLine.CalculateProfileEvent += new CalculateProfileDelegate(ViewLine_CalculateProfileEvent);

            ViewLine.Show();
        }

        void ViewLine_CalculateProfileEvent(double tolerance)
        {
            if (line == null)
            {
                MessageBox.Show("亲~俺们还没画出线咧~");
            }
            else
            {
                //line.CalculateProfile(grdBndFilenames,tolerance);

                Thread CalculateProfileThread = new Thread(this.CalculateProfileForThread);
                CalculateProfileThread.SetApartmentState(ApartmentState.STA);
                CalculateProfileThread.Start(tolerance);
            }
        }

        private void CalculateProfileForThread(object tolerance)
        {
            this.BeginInvoke(new UpdateProgressBarDelegate(UpdateProgressBarToMarquee));
            MessageBox.Show("即将开始计算剖面，点击确定继续");
            double temTolerance = (double)tolerance;
            line.CalculateProfile(grdBndFilenames, temTolerance);
            this.BeginInvoke(new UpdateProgressBarDelegate(UpdateProgressBarToBlocks));
            MessageBox.Show("剖面计算完成！");
        }

        void ViewLine_SaveLineEvent()
        {
            if (line == null)
            {
                MessageBox.Show("亲~俺们还没画出线咧~");
            }
            else
            {
                line.SaveLineShapefile();
            }
        }

        void ViewLine_AddLineEvent()
        {
            OpenFileDialog openLineDlg = new OpenFileDialog();
            openLineDlg.Filter = "矢量格式" + "|" + "*.shp";// + "|" + img.CdlgFilter;
            if (openLineDlg.ShowDialog() == DialogResult.OK)
            {
                String extention = Path.GetExtension(openLineDlg.FileName).ToLower();
                if (extention == ".shp")
                {
                    Shapefile lineShapefile = new Shapefile();
                    lineShapefile.Open(openLineDlg.FileName);
                    if (lineShapefile.ShapefileType != ShpfileType.SHP_POLYLINE)
                    {
                        return;
                    }

                    line = new Line(ref Map, lineShapefile, lineShapefileLayerHandle);
                    lineShapefileLayerHandle = line.LayerHandle;

                    var sf = new Shapefile();
                    if (PointShapefileLayerHandle != -1)
                    {
                        sf = Map.get_Shapefile(PointShapefileLayerHandle);
                        sf.EditClear();
                    }
                    foreach (MapWinGIS.Point pointFromLine in line.Points)
                    {
                        AddPoint(Map, pointFromLine.x, pointFromLine.y, pointFromLine.Key);
                    }

                    points = line.Points;

                    if (!(ViewLine == null || ViewLine.IsDisposed))
                    {
                        ViewLine.Close();
                    }
                    if (!(ViewPoint == null || ViewPoint.IsDisposed))
                    {
                        ViewPoint.Close();
                    }
                }
                else
                {
                    MessageBox.Show("罢工啦，亲~我只能识别.shp格式的线文件哦");
                }
            }

            
        }

        private void Map_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
            if (e.button == 1)          // left button
            {
                double lat = 0.0;
                double lng = 0.0;
                double height;
                int column = 0;
                int row = 0;

                Map.PixelToProj(e.x, e.y, ref lng, ref lat);

                if (grd.Filename != "")
                {
                    if (!(grd.Extents.PointIsWithin(lng, lat)))
                    {
                        foreach (GridBoundsAndFilenames GrdBndFilename in grdBndFilenames)
                        {
                            if (IsInThisBounds(GrdBndFilename, lng, lat))
                            {
                                grd.Close();
                                grd.Open(GrdBndFilename.GridFileNames);
                                break;
                            }
                        }
                    }
                    grd.ProjToCell(lng, lat, out column, out row);
                    height = (double)grd.get_Value(column, row);
                    tbHeight.Text = height.ToString();
                }

                tbLat.Text = lat.ToString();
                tbLng.Text = lng.ToString();
            }

            
        }

        private void tbLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                MessageBox.Show("Only numbers here!");
            }
        }

        private void tbLng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                MessageBox.Show("Only numbers here!");
            }
        }

        private void DoViewProfile()
        {
            if (ViewProfile == null || ViewProfile.IsDisposed)
            {
                if (line != null)
                {
                    ViewProfile = new frmViewProfile(line.MaxHeightResults);
                }
                else
                {
                    ViewProfile = new frmViewProfile();
                    //MessageBox.Show("宝贝~你还没划线呢~");
                    //return;
                }
                ViewProfile.Show();
            }
            else
            {
                if (line != null)
                {
                    ViewProfile.UpdateProfileChart(line.MaxHeightResults);
                }
                
                ViewProfile.Show();
                ViewProfile.Focus();
            }
        }

        private void buttonViewProfile_Click(object sender, EventArgs e)
        {
            DoViewProfile();
        }


    }
}
