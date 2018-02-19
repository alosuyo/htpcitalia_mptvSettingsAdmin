//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Xml;

//namespace MPTVSettingsAdmin.Classes
//{
//    public class MediaPortalExporter
//    {
//        private const string separatore = "=";
//        private XmlDocument xmlDoc;
//        private XmlNode rootElement;
//        private XmlNode nodeServers;
//        private XmlNode nodeServer;
//        private XmlNode nodeCards;
//        private XmlNode nodeCard;
//        private XmlNode nodechannels;


//        public MediaPortalExporter()
//        {

//            initXmlDoc();
//        }

//        private static void AddAttribute(XmlNode node, string tagName, string tagValue)
//        {
//            XmlAttribute attr = node.OwnerDocument.CreateAttribute(tagName);
//            attr.InnerText = tagValue;
//            node.Attributes.Append(attr);
//        }

//        private static void AddAttribute(XmlNode node, string tagName, int tagValue)
//        {
//            AddAttribute(node, tagName, tagValue.ToString());
//        }

//        private string getPolar(String polarizzazione)
//        {
//            String ritorno = "";
//            if (polarizzazione.ToLower() == "v")
//            {
//                ritorno = "2";
//            }
//            else
//            {
//                ritorno = "1";
//            }
//            return ritorno;

//        }

//        private string getFreq(String freq)
//        {
//            Double frequenza = Double.Parse(freq);
//            //frequenza = frequenza * 100;
//            freq = frequenza.ToString();
//            String s = "12169000";
//            int diff;
//            if (freq.Length < s.Length)
//            {
//                diff = s.Length - freq.Length;
//                for (int i = 0; i < diff; i++)
//                {
//                    freq += "0";
//                }
//            }
//            return freq;
//        }

//        public void Export(String Filename, List<Channel> canali, Boolean exportGruppo, List<Group> gruppi, String lnbSwitch, MyEnumeration.Diseq Hotb, MyEnumeration.Diseq Astra)
//        {
//            int idChannel = 0;
//            foreach (Channel channel in canali)
//            {
//                if (channel.Sid != "" && channel.NID != "" && channel.Frequenza != "" && channel.TID != "" &&
//                    channel.Sid != null && channel.NID != null && channel.Frequenza != null && channel.TID != null)
//                {
//                    if (channel.DaEsportare)
//                    {

//                        idChannel++;
//                        XmlNode nodechannel = xmlDoc.CreateElement("channel");
//                        AddAttribute(nodechannel, "Name", channel.Name.Trim());
//                        AddAttribute(nodechannel, "GrabEpg", "False");
//                        AddAttribute(nodechannel, "IdChannel", channel.NumeroCanale.ToString());
//                        if (channel.Vpid != String.Empty)
//                        {
//                            AddAttribute(nodechannel, "IsRadio", "False");
//                            AddAttribute(nodechannel, "IsTv", "True");
//                        }
//                        else
//                        {
//                            AddAttribute(nodechannel, "IsRadio", "True");
//                            AddAttribute(nodechannel, "IsTv", "False");
//                        }

//                        AddAttribute(nodechannel, "LastGrabTime", "2000-1-1 0:0:0");
//                        AddAttribute(nodechannel, "SortOrder", channel.NumeroCanale.ToString());
//                        AddAttribute(nodechannel, "TimesWatched", "0");
//                        AddAttribute(nodechannel, "TotalTimeWatched", "2000-1-1 0:0:0");
//                        AddAttribute(nodechannel, "VisibleInGuide", "True");
//                        AddAttribute(nodechannel, "FreeToAir", channel.FreeToAir.ToString());
//                        AddAttribute(nodechannel, "DisplayName", channel.Name.Trim());

//                        ////node map
//                        XmlNode nodeMaps = xmlDoc.CreateElement("mappings");
//                        XmlNode nodeMap = xmlDoc.CreateElement("map");
//                        AddAttribute(nodeMap, "IdCard", "4");
//                        AddAttribute(nodeMap, "IdChannel", channel.NumeroCanale.ToString());
//                        AddAttribute(nodeMap, "IdChannelMap", channel.NumeroCanale.ToString());
//                        nodeMaps.AppendChild(nodeMap);
//                        nodechannel.AppendChild(nodeMaps);
//                        XmlNode nodeTuningDetails = xmlDoc.CreateElement("TuningDetails");
//                        XmlNode nodeTune = xmlDoc.CreateElement("tune");

//                        AddAttribute(nodeTune, "IdChannel", channel.NumeroCanale.ToString());
//                        AddAttribute(nodeTune, "IdTuning", channel.NumeroCanale.ToString());
//                        AddAttribute(nodeTune, "AudioPid", channel.Audio);
//                        AddAttribute(nodeTune, "Bandwidth", "8"); //Bandwidth metto a tutti 8
//                        AddAttribute(nodeTune, "ChannelNumber", channel.NumeroCanale.ToString()); //metto l'ordine di parsing
//                        AddAttribute(nodeTune, "ChannelType", "3"); // imposto a tutti 3, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "CountryId", "31"); // imposto a tutti 31, dovrebbe fungere lo stesso
//                        MyEnumeration.Satelliti s = (MyEnumeration.Satelliti)Enum.Parse(typeof(MyEnumeration.Satelliti), channel.Satellite, true);
//                        switch (s)
//                        {
//                            case MyEnumeration.Satelliti.HotBird:
//                                AddAttribute(nodeTune, "Diseqc", ((int)Hotb).ToString());
//                                break;
//                            case MyEnumeration.Satelliti.Astra:
//                                AddAttribute(nodeTune, "Diseqc", ((int)Astra).ToString());
//                                break;
//                            default:
//                                AddAttribute(nodeTune, "Diseqc", "0");
//                                break;
//                        }
//                        // imposto a tutti 31, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "FreeToAir", channel.FreeToAir.ToString());
//                        AddAttribute(nodeTune, "Frequency", getFreq(channel.Frequenza));
//                        AddAttribute(nodeTune, "MajorChannel", "-1"); // imposto a tutti -1, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "MinorChannel", "-1"); // imposto a tutti -1, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "Modulation", (int)channel.Modulation);
//                        AddAttribute(nodeTune, "Name", channel.Name.Trim());
//                        AddAttribute(nodeTune, "NetworkId", channel.NID);
//                        AddAttribute(nodeTune, "PcrPid", channel.Pcr);
//                        AddAttribute(nodeTune, "PmtPid", channel.Pmt);
//                        AddAttribute(nodeTune, "Polarisation", getPolar(channel.Polarizzazione));
//                        AddAttribute(nodeTune, "Provider", channel.Bouquet);
//                        AddAttribute(nodeTune, "ServiceId", channel.Sid);
//                        AddAttribute(nodeTune, "SwitchingFrequency", lnbSwitch);
//                        AddAttribute(nodeTune, "Symbolrate", channel.SymbolRate); // imposto a tutti 0, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "TransportId", channel.TID);
//                        AddAttribute(nodeTune, "TuningSource", "0");
//                        if (channel.Vpid != String.Empty)
//                        {
//                            AddAttribute(nodeTune, "VideoPid", channel.Vpid);
//                        }
//                        else
//                        {
//                            AddAttribute(nodeTune, "VideoPid", "0");
//                        }
//                        AddAttribute(nodeTune, "VideoSource", "0");  // imposto a tutti 0, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "AudioSource", "0"); // imposto a tutti 0, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "IsVCRSignal", "False"); // imposto a tutti False, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "SatIndex", "-1"); // imposto a tutti -1, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "InnerFecRate", "2");



//                        AddAttribute(nodeTune, "Band", (int)channel.Band); 
                        
//                        AddAttribute(nodeTune, "Pilot", "2");
//                        AddAttribute(nodeTune, "RollOff", "3");
                        
//                        //AddAttribute(nodeTune, "Pilot", "-1"); // imposto a tutti -1, dovrebbe fungere lo stesso
//                        //AddAttribute(nodeTune, "RollOff", "-1"); // imposto a tutti -1, dovrebbe fungere lo stesso
//                        AddAttribute(nodeTune, "Url", "");
//                        AddAttribute(nodeTune, "Bitrate", "0"); // imposto a tutti 0, dovrebbe fungere lo stesso
//                        nodeTuningDetails.AppendChild(nodeTune);
//                        nodechannel.AppendChild(nodeTuningDetails);
//                        nodechannels.AppendChild(nodechannel);
//                        rootElement.AppendChild(nodechannels);
//                    }
//                }
//            }
//            //todo gruppi
//            int grSorter = 0;
//            int chSorter = 0;
//            if (exportGruppo && gruppi != null && gruppi.Count > 0)
//            {
//                XmlNode nodeChannelGroups = xmlDoc.CreateElement("channelgroups");

//                foreach (Group gr in gruppi)
//                {
//                    grSorter++;
//                    XmlNode nodeChannelGroup = xmlDoc.CreateElement("channelgroup");
//                    AddAttribute(nodeChannelGroup, "GroupName", gr.Name);
//                    AddAttribute(nodeChannelGroup, "SortOrder", grSorter.ToString());
//                    XmlNode nodeGroupMap = xmlDoc.CreateElement("mappings");
//                    chSorter = 0;
//                    foreach (Channel chan in gr.Channels)
//                    {
//                        chSorter++;
//                        XmlNode nodeMap = xmlDoc.CreateElement("map");
//                        AddAttribute(nodeMap, "ChannelName", chan.Name.Trim());
//                        AddAttribute(nodeMap, "SortOrder", chSorter);
//                        nodeGroupMap.AppendChild(nodeMap);
//                    }
//                    nodeChannelGroup.AppendChild(nodeGroupMap);
//                    nodeChannelGroups.AppendChild(nodeChannelGroup);
//                }
//                rootElement.AppendChild(nodeChannelGroups);
//            }
//            xmlDoc.AppendChild(rootElement);
//            try
//            {
//                XmlTextWriter tw = new XmlTextWriter(Filename, System.Text.Encoding.Default);
//                tw.Formatting = Formatting.Indented;
//                xmlDoc.Save(tw);
//            }
//            catch (Exception ex)
//            {

//                System.Windows.Forms.MessageBox.Show(ex.Message);
//            }
//        }

//        private void initXmlDoc()
//        {
//            xmlDoc = new XmlDocument();
//            rootElement = xmlDoc.CreateElement("tvserver");
//            AddAttribute(rootElement, "version", "1.0");

//            nodeServers = xmlDoc.CreateElement("servers");
//            //creo il server
//            nodeServer = xmlDoc.CreateElement("server");
//            AddAttribute(nodeServer, "HostName", "192.168.2.25");
//            AddAttribute(nodeServer, "IdServer", "1");
//            AddAttribute(nodeServer, "IsMaster", "True");

//            //creo il nodo scheda
//            nodeCards = xmlDoc.CreateElement("cards");

//            nodeCard = xmlDoc.CreateElement("card");
//            AddAttribute(nodeCard, "IdCard", "1");
//            AddAttribute(nodeCard, "DevicePath", @"@device:pnp:\\?\pci#ven_1822&dev_4e35&subsys_00031ae4&rev_01#4&2966ab86&0&30a4#{71985f48-1ca1-11d3-9cc8-00c04f7971e0}\{acec2d03-bdec-44c0-9a97-c577f6ee2602}");
//            AddAttribute(nodeCard, "Enabled", "True");
//            AddAttribute(nodeCard, "CamType", "0");
//            AddAttribute(nodeCard, "GrabEPG", "True");
//            AddAttribute(nodeCard, "LastEpgGrab", "2000-1-1 0:0:0");
//            AddAttribute(nodeCard, "Name", "TechniSat Mantis DVBS BDA Receiver");
//            AddAttribute(nodeCard, "Priority", "3");
//            AddAttribute(nodeCard, "RecordingFolder", "D:\\GuidaTv");
//            nodeCards.AppendChild(nodeCard);

//            nodeCard = xmlDoc.CreateElement("card");
//            AddAttribute(nodeCard, "IdCard", "2");
//            AddAttribute(nodeCard, "DevicePath", @"@device:pnp:\\?\usb#vid_8086&pid_9500#______#{71985f48-1ca1-11d3-9cc8-00c04f7971e0}\{91b0cc87-9905-4d65-a0d1-5861c6f22cc0}");
//            AddAttribute(nodeCard, "Enabled", "True");
//            AddAttribute(nodeCard, "CamType", "0");
//            AddAttribute(nodeCard, "GrabEPG", "True");
//            AddAttribute(nodeCard, "LastEpgGrab", "2000-1-1 0:0:0");
//            AddAttribute(nodeCard, "Name", "Ce6230 BDA Tuner Filter");
//            AddAttribute(nodeCard, "Priority", "2");
//            AddAttribute(nodeCard, "RecordingFolder", "D:\\GuidaTv");
//            nodeCards.AppendChild(nodeCard);

//            nodeCard = xmlDoc.CreateElement("card");
//            AddAttribute(nodeCard, "IdCard", "3");
//            AddAttribute(nodeCard, "DevicePath", @"(builtin)");
//            AddAttribute(nodeCard, "Enabled", "True");
//            AddAttribute(nodeCard, "CamType", "0");
//            AddAttribute(nodeCard, "GrabEPG", "True");
//            AddAttribute(nodeCard, "LastEpgGrab", "2000-1-1 0:0:0");
//            AddAttribute(nodeCard, "Name", "RadioWebStream Card (builtin)");
//            AddAttribute(nodeCard, "Priority", "1");
//            AddAttribute(nodeCard, "RecordingFolder", "D:\\GuidaTv");
//            nodeCards.AppendChild(nodeCard);

//            nodeCard = xmlDoc.CreateElement("card");
//            AddAttribute(nodeCard, "IdCard", "4");
//            AddAttribute(nodeCard, "DevicePath", @"@device:pnp:\\?\pci#ven_1822&dev_4e35&subsys_00031ae4&rev_01#4&7d0aeea&0&5040#{71985f48-1ca1-11d3-9cc8-00c04f7971e0}\{acec2d03-bdec-44c0-9a97-c577f6ee2602}");
//            AddAttribute(nodeCard, "Enabled", "True");
//            AddAttribute(nodeCard, "CamType", "0");
//            AddAttribute(nodeCard, "GrabEPG", "True");
//            AddAttribute(nodeCard, "LastEpgGrab", "2000-1-1 0:0:0");
//            AddAttribute(nodeCard, "Name", "TechniSat Mantis DVBS BDA Receiver)");
//            AddAttribute(nodeCard, "Priority", "1");
//            AddAttribute(nodeCard, "RecordingFolder", "D:\\GuidaTv");
//            nodeCards.AppendChild(nodeCard);

//            nodeServer.AppendChild(nodeCards);
//            nodeServers.AppendChild(nodeServer);
//            rootElement.AppendChild(nodeServers);
//            nodechannels = xmlDoc.CreateElement("channels");

//        }

//    }
//}
