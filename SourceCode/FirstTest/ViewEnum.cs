using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalProfileAndDataView
{

    public enum LatLonStyle
    { 
        LatUpLonUp = 0,
        LatUpLonDown = 1,
        LatDownLonDown = 2,
        LatDownLonUp = 3,
        Wrong = 4
    }
}