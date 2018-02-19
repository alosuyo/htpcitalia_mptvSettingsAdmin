using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    public static class  UtilityClass
    {
        public static String getFecFromSettings(Int32 fecValue)
        {
            if (fecValue == 2)
            {
                return "2/3";
            }
            if (fecValue == 3)
            {
                return "3/4";
            }
            return "0";
        }

        public static MPTVSettingsAdmin.Classes.DVBSChannel.BinaryConvolutionCodeRate getFecFromSettings1(int fecValue)
        {
            return (MPTVSettingsAdmin.Classes.DVBSChannel.BinaryConvolutionCodeRate)fecValue;
        }
            

        public static String getFecForDvbViewer(String fecValue)
        {
            switch (fecValue)
            {
                case "1/2":
                    return "1";
                case "2/3":
                    return "2";
                case "3/4":
                    return "3";
                case "4/5":
                    return "4";
                default:
                    break;
            }
            return "2";
        }

        public static String getSatModulation(string value)
        {
            switch (value.ToLower())
            {
                case "dvb-s":
                    return "0";
                case "dvb-s2":
                    return "1";
            }
            return "0";
        }

        public static String getPolarizzazioneFromSettings(String polValue)
        {
            Int32 temp = 0;
            Int32.TryParse(polValue, out temp);
            if (temp == 0)
            {
                return "H";
            }
            else
            {
                return "V";
            }
        }

        public static string getNomeSatFromSettings(String gradiValue, Dictionary<string,string> satelliteName)
        {
            if (satelliteName.ContainsKey(gradiValue))
            {
                return satelliteName[gradiValue];
            }
            return "";
            //Int32 temp = 0;
            //Int32.TryParse(gradiValue, out temp);
            //if (temp == 130)
            //{
            //    return "Hotbird";
            //}
            //if (temp == 192)
            //{
            //    return "Astra";
            //}
            //return "";
        }

        public static string getGradiFromSettings(String gradiValue)
        {
            Int32 temp = 0;
            Int32.TryParse(gradiValue, out temp);
            float val = temp / 10;
            return val.ToString();

        }

        public static Channel retCanale(ref Channel chan)
        {
            Channel c = new Channel();
            c.Audio = chan.Audio;
            c.NumeroCanale = chan.NumeroCanale;
            c.Bouquet = chan.Bouquet;
            c.Codifica = chan.Codifica;
            c.DaEsportare = chan.DaEsportare;
            c.Fec = chan.Fec;
            c.FreeToAir = chan.FreeToAir;
            c.Frequenza = chan.Frequenza;
            c.Modulation = chan.Modulation;
            c.Name = chan.Name;
            c.NID = chan.NID;
            c.Pcr = chan.Pcr;
            c.Pmt = chan.Pmt;
            c.Polarizzazione = chan.Polarizzazione;
            c.Satellite = chan.Satellite;
            c.Sid = chan.Sid;
            c.Standard = chan.Standard;
            c.SymbolRate = chan.SymbolRate;
            c.TID = chan.TID;
            c.Transponder = chan.Transponder;
            c.Vpid = chan.Vpid;
            c.IdChannel = chan.IdChannel;
            c.DataAggiornamento = chan.DataAggiornamento;
            c.Satellite = chan.Satellite;
            c.DaAggiornare = chan.DaAggiornare;
            c.BouquetSep = chan.BouquetSep;
            c.Categoria = chan.Categoria;
            c.Paese = chan.Paese;
            return c;
        }
    }
}
