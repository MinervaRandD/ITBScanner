using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Source of how location in effect is determined.
    /// </summary>
    /// <remarks>
    /// This is needed in business logic to determine whether the current location
    /// entry can be overriden by GPS data, which is volatile. 
    /// The rule of thumb is:
    /// If current location is set from barcode scan, new location from GPS can override it, 
    /// but lack of GPS would not clear it.
    /// If current location is set from GPS data, it can be overriden by GPS/barcode scan/Override screen, 
    /// and be cleared by lack of GPS.
    /// If current location is set from override screen, it can be overriden by barcode scan/overide screen,
    /// but no affected by GPS data or lack of it.
    /// </remarks>
    public enum LocationSource
    {
        BarcodeScan,
        GPS,
        OverrideForm
    }
}
