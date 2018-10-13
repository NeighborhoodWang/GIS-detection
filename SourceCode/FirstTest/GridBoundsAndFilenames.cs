using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalProfileAndDataView
{
    public struct GridBoundsAndFilenames
    {
        private double xMin;
        public double XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        private double yMin;
        public double YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }
        private double xMax;
        public double XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }
        private double yMax;
        public double YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }
        private string gridFileNames;
        public string GridFileNames
        {
            get { return gridFileNames; }
            set { gridFileNames = value; }
        }
    }


}