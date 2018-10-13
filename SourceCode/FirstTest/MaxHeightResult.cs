using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapWinGIS;
using AxMapWinGIS;

namespace CalProfileAndDataView
{
    public struct MaxHeightResult
    {
        private double distanceToMainLine;

        public double DistanceToMainLine
        {
            get { return distanceToMainLine; }
            set { distanceToMainLine = value; }
        }
        private double distanceFromInit;

        public double DistanceFromInit
        {
            get { return distanceFromInit; }
            set { distanceFromInit = value; }
        }
        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private MyPoint point;

        public MyPoint Point
        {
            get { return point; }
            set { point = value; }
        }
    }
}