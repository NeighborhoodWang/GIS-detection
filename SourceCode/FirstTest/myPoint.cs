using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalProfileAndDataView
{
    public struct MyPoint
    {
        private double _x;

        public double x
        {
            get { return _x; }
            set { _x = value; }
        }
        private double _y;

        public double y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}