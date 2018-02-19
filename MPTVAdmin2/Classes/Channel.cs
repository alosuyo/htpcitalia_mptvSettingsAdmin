using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    public class Channel
    {
        public Boolean DaEsportare { get; set; }
        public String Name { get; set; }
        public Boolean FreeToAir { get; set; }
        public Int64 NumeroCanale { get; set; }
        public String Frequenza { get; set; }
        public Boolean DaAggiornare { get; set; }
        public String Polarizzazione { get; set; }
        public String Transponder { get; set; }
        public String Standard { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.ModulationType Modulation { get; set; }
        public String SymbolRate { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.BinaryConvolutionCodeRate Fec { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.DisEqcType Diseqc { get; set; }
        public MPTVSettingsAdmin.Classes.DVBSChannel.BandType Band { get; set; }
        public String NID { get; set; }
        public String TID { get; set; }        
        public String Bouquet { get; set; }        
        public List<String> Boquets { get; set; }
        public String Codifica { get; set; }
        public String Sid { get; set; }
        public String Vpid { get; set; }
        public String Audio { get; set; }
        public String Pmt { get; set; }
        public String Pcr { get; set; }
        public String Satellite { get; set; }
        public String IdChannel { get; set; }
        public DateTime DataAggiornamento { get; set; }        
        public String BouquetSep { get; set; }
        public String Categoria { get; set; }
        public String Paese { get; set; }
        public String Pilot { get; set; }
        public String Roloff { get; set; }
        public int VideoSource { get; set; }
        public int AudioSource { get; set; }
        public int channelType { get; set; }
        public int countryId { get; set; }
        public int idCard { get; set; }
        public String Url { get; set; }
        public int switchingFrequency { get; set; }
        public int bandwidth { get; set; }
        public int majorChannel { get; set; }
        public int minorChannel { get; set; }
        public int satIndex { get; set; }
        public int bitrate { get; set; }
        public int tuningSource { get; set; }
        public int isVCRSignal { get; set; }
        public int isRadio { get; set; }
        public int isTV { get; set; }

        public Channel(Channel chCpy)
        {
             DaEsportare  = chCpy.DaEsportare;
             Name  = chCpy.Name;
             FreeToAir  = chCpy.FreeToAir;
             NumeroCanale  = chCpy.NumeroCanale;
             Frequenza  = chCpy.Frequenza;
             DaAggiornare  = chCpy.DaAggiornare;
             Polarizzazione  = chCpy.Polarizzazione;
             Transponder  = chCpy.Transponder;
             Standard  = chCpy.Standard;
             Modulation  = chCpy.Modulation;
             SymbolRate  = chCpy.SymbolRate;
             Fec  = chCpy.Fec;
             NID  = chCpy.NID;
             TID  = chCpy.TID;       
             Bouquet  = chCpy.Bouquet;       
             Boquets  = chCpy.Boquets;
             Codifica  = chCpy.Codifica;
             Sid  = chCpy.Sid;
             Vpid  = chCpy.Vpid;
             Audio  = chCpy.Audio;
             Pmt  = chCpy.Pmt;
             Pcr  = chCpy.Pcr;
             Satellite  = chCpy.Satellite;
             IdChannel = chCpy.IdChannel;
             DataAggiornamento  = chCpy.DataAggiornamento;        
             BouquetSep  = chCpy.BouquetSep;
             Categoria  = chCpy.Categoria;
             Paese  = chCpy.Paese;
             Pilot = chCpy.Pilot;
             Roloff = chCpy.Roloff;
             channelType = chCpy.channelType;
             countryId = chCpy.countryId;
             VideoSource = chCpy.VideoSource;
             AudioSource = chCpy.AudioSource;
             Url = chCpy.Url;
            switchingFrequency = chCpy.switchingFrequency;
            bandwidth = chCpy.bandwidth;
            majorChannel = chCpy.majorChannel;
            minorChannel = chCpy.minorChannel;
            satIndex = chCpy.satIndex;
            bitrate = chCpy.bitrate;
            tuningSource = chCpy.tuningSource;
            isVCRSignal = chCpy.isVCRSignal;
            isTV = chCpy.isTV;
            isRadio = chCpy.isRadio;

        }
        public Channel()
        {
        }

    }
}
