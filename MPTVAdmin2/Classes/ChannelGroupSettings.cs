using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    /// <summary>
    /// Oggetto canale letto dai file userBoquet dei settings dei dream
    /// </summary>
    public class ChannelGroupSettings
    {
        public String TID { get; set; }
        public String SID { get; set; }
        public String Category { get; set; }
        public int ChannelNumber { get; set; }
    }
}
