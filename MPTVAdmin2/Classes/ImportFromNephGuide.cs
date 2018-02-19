using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MPTVSettingsAdmin.Classes
{
    public static class ImportFromNephGuide
    {
        public static List<Channel> getChannelsFromNephGuide(String path, out List<Group> groupToEx)
        {
            List<Channel> result = new List<Channel>();
            Dictionary<string, Group> group = new Dictionary<string, Group>();
            groupToEx = new List<Group>();
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.ToLower() == "bouquet")
                            {
                                reader.Read();
                                if (!group.ContainsKey(reader.Value))
                                {
                                    Group g = new Group(reader.Value);
                                    group.Add(reader.Value, g);
                                }

                            }
                            break;
                    }
                }
            }
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                Channel ch = new Channel();
                while (reader.Read())
                {
                    
                    switch (reader.NodeType)
                    {
                        
                        case XmlNodeType.Element:
                            if (reader.Name.ToLower() == "channel")
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    reader.Read();
                                }
                                ch.Name = reader.Value;
                            }

                            if (reader.Name.ToLower() == "bouquet")
                            {
                                reader.Read();
                                ch.Bouquet = reader.Value;
                                
                            }
                            if (reader.Name.ToLower() == "idsky")
                            {
                                reader.Read();
                                ch.IdChannel = reader.Value;
                                ch.NumeroCanale = long.Parse(reader.Value);
                                ch.channelType = 0;
                                ch.Frequenza = "0";
                                ch.countryId = 98;
                                ch.NID = "-1";
                                ch.TID = "-1";
                                ch.Sid = "-1";
                                ch.Pmt = "-1";
                                ch.FreeToAir = true;
                                ch.Modulation = DVBSChannel.ModulationType.ModNotDefined;
                                ch.Polarizzazione = "0";
                                ch.SymbolRate = "0";
                                ch.Diseqc = DVBSChannel.DisEqcType.None;
                                ch.Band = DVBSChannel.BandType.NaLegacy;
                                ch.VideoSource = 13;
                                ch.Fec = DVBSChannel.BinaryConvolutionCodeRate.RateNotDefined;
                                ch.Pilot = "-1";
                                ch.Roloff = "-1";
                                ch.AudioSource = 0;
                                ch.Url = "";
                                ch.switchingFrequency = 11700000;
                                ch.bandwidth = 8;
                                ch.majorChannel = -1;
                                ch.minorChannel = -1;
                                ch.satIndex = -1;
                                ch.bitrate = 0;
                                ch.tuningSource = 0;
                                ch.isVCRSignal = 0;
                                ch.isRadio = 0;
                                ch.isTV = 1;

                                Channel t = new Channel(ch);
                                group[t.Bouquet].Channels.Add(t);
                                result.Add(t);
                            }

                            break;

                       
                        case XmlNodeType.Text:
                            break;
                       
                    }
                }
            }
            foreach (var item in group)
            {
                groupToEx.Add(item.Value);
            }
            return result;
        }
    }
}
