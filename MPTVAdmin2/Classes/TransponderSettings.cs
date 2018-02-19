using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    class TransponderSettings
    {
        public String frequenza { get; set; }
        public Int32 SymbolRate { get; set; }
        public String Polarizzazione { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.BinaryConvolutionCodeRate Fec { get; set; }
        public String Gradi { get; set; }
        public Int32 TranspordId { get; set; }
        public Int32 NetworkId { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.ModulationType Modulation { get; set; }
        public String Pilot { get; set; }
        public String RollOff { get; set; }
        public String Standard { get; set; }
        public String Satellite { get; set; }

    }
}
