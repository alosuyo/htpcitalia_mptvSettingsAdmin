using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    public static class DVBSChannel
    {
        /// <summary>
        /// From BinaryConvolutionCodeRate
        /// </summary>
        public enum BinaryConvolutionCodeRate
        {
            RateNotSet = -1,
            RateNotDefined = 0,
            Rate1_2 = 1, // 1/2
            Rate2_3, // 2/3
            Rate3_4, // 3/4
            Rate3_5,
            Rate4_5,
            Rate5_6, // 5/6
            Rate5_11,
            Rate7_8, // 7/8
            Rate1_4,
            Rate1_3,
            Rate2_5,
            Rate6_7,
            Rate8_9,
            Rate9_10,
            RateMax
        }

        /// <summary>
        /// From Polarisation
        /// </summary>
        public enum Polarisation
        {
            NotSet = -1,
            NotDefined = 0,
            LinearH = 1, // Linear horizontal polarisation
            LinearV, // Linear vertical polarisation
            CircularL, // Circular left polarisation
            CircularR, // Circular right polarisation
            Max,
        }

        
        /// <summary>
        /// enum describing the different DisEqc type
        /// </summary>
        public enum DisEqcType
        {
            /// <summary>
            /// diseqc not used
            /// </summary>
            None = 0,
            /// <summary>
            /// Simple A
            /// </summary>
            SimpleA = 1,
            /// <summary>
            /// Simple B
            /// </summary>
            SimpleB = 2,
            /// <summary>
            /// Level 1 A/A
            /// </summary>
            Level1AA = 3,
            /// <summary>
            /// Level 1 A/B
            /// </summary>
            Level1AB = 4,
            /// <summary>
            /// Level 1 B/A
            /// </summary>
            Level1BA = 5,
            /// <summary>
            /// Level 1 B/B
            /// </summary>
            Level1BB = 6,
        } ;

        public enum BandType
        {
            /// <summary>
            /// Ku-Linear - LOF1 9750, LOF2 10600, SW 11700
            /// Universal LNB - common in Europe
            /// </summary>
            Universal = 0,
            /// <summary>
            /// Ku-Circular - LOF1 10750
            /// </summary>
            Circular = 1,
            /// <summary>
            /// C-Band - LOF1 5150
            /// </summary>
            CBand = 2,
            /// <summary>
            /// North American Bandstacked
            /// DishPro Ku-Linear Hi(DBS) - LOF1 11250, LOF2 14350
            /// </summary>
            NaBandStackedDpKuHi = 3,
            /// <summary>
            /// North American Bandstacked
            /// DishPro Ku-Linear Lo(FSS) - LOF1 10750, LOF2 13850
            /// </summary>
            NaBandStackedDpKuLo = 4,
            /// <summary>
            /// North American Bandstacked
            /// Ku-Linear Hi(DBS) - LOF1 11250, LOF2 10675
            /// </summary>
            NaBandStackedKuHi = 5,
            /// <summary>
            /// North American Bandstacked
            /// Ku-Linear Lo(FSS) - LOF1 10750, LOF2 10175
            /// </summary>
            NaBandStackedKuLo = 6,
            /// <summary>
            /// North American Bandstacked
            /// C-Band LOF1 5150, LOF2 5750
            /// </summary>
            NaBandStackedC = 7,
            /// <summary>
            /// North American Legacy
            /// LOF1 11250
            /// </summary>
            NaLegacy = 8,
            /// <summary>
            /// North American Custom1
            /// LOF1 11250, LOF2 11250, SW 12700
            /// </summary>
            NaCustom1 = 9,
            /// <summary>
            /// North American Custom2
            /// LOF1 11250, LOF2 11250, SW 12200
            /// </summary>
            NaCustom2 = 10,
        }

        public enum ModulationType
        {
            ModNotSet = -1,
            ModNotDefined = 0,
            Mod16Qam = 1,
            Mod32Qam,
            Mod64Qam,
            Mod80Qam,
            Mod96Qam,
            Mod112Qam,
            Mod128Qam,
            Mod160Qam,
            Mod192Qam,
            Mod224Qam,
            Mod256Qam,
            Mod320Qam,
            Mod384Qam,
            Mod448Qam,
            Mod512Qam,
            Mod640Qam,
            Mod768Qam,
            Mod896Qam,
            Mod1024Qam,
            ModQpsk,
            ModBpsk,
            ModOqpsk,
            Mod8Vsb,
            Mod16Vsb,
            ModAnalogAmplitude, // std am
            ModAnalogFrequency, // std fm
            Mod8Psk,
            ModRF,
            Mod16Apsk,
            Mod32Apsk,
            ModNbcQpsk,
            ModNbc8Psk,
            ModDirectTv,
            ModMax
        }
    }
}
