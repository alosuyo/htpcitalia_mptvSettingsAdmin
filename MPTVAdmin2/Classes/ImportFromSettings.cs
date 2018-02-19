using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPTVSettingsAdmin.Classes
{
    public static class ImportFromSettings
    {

        public static List<Channel> getChannelsFromSetting(String Path, out Dictionary<string, string> satteliteName)
        {
            List<Channel> result = new List<Channel>();
            
            satteliteName = readSatelliteXml(Path.Replace("lamedb","satellites.xml"));
            
            using (StreamReader reader = new StreamReader(Path))
            {
                String line;
                Dictionary<string, TransponderSettings> transponders = new Dictionary<string, TransponderSettings>();
                reader.ReadLine();
                Boolean semaforoTransponders = false;
                Boolean semaforoCanali = false;
                Char splitter = char.Parse(":");
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        if (line == "transponders")
                        {
                            semaforoTransponders = true;
                            //continue;
                            line = reader.ReadLine();
                        }

                        if (line == "end")
                        {
                            semaforoTransponders = false;
                            semaforoCanali = false;
                        }

                        if (line == "services")
                        {
                            semaforoTransponders = false;
                            semaforoCanali = true;
                            continue;
                        }
                        i++;

                        if (semaforoTransponders)
                        {
                            if (line.StartsWith("eeee"))
                            {
                                reader.ReadLine();
                                reader.ReadLine();
                                continue;
                            }
                            String t = line + ":" + reader.ReadLine().Replace("s", "").Trim();
                            String[] valori = t.Split(splitter);
                            TransponderSettings temp = new TransponderSettings();
                            string tid = valori[1] + ":" + valori[2];
                            temp.TranspordId = Int32.Parse(valori[1], System.Globalization.NumberStyles.HexNumber);
                            temp.NetworkId = Int32.Parse(valori[2], System.Globalization.NumberStyles.HexNumber);
                            temp.frequenza = (Int32.Parse(valori[3]) / 1000).ToString();
                            temp.SymbolRate = (Int32.Parse(valori[4]) / 1000);
                            temp.Polarizzazione = UtilityClass.getPolarizzazioneFromSettings(valori[5]);
                            temp.Fec = UtilityClass.getFecFromSettings1(Int32.Parse(valori[6]));
                            temp.Satellite = UtilityClass.getNomeSatFromSettings(valori[7],satteliteName);
                            temp.Gradi = UtilityClass.getGradiFromSettings(valori[7]);
                            temp.Modulation = DVBSChannel.ModulationType.ModNotSet;
                            temp.Standard = "DVB-S";
                            temp.Pilot = "-1";
                            temp.RollOff = "-1";                            
                            if (valori.Length > 10)
                            {
                                temp.Pilot = "2";
                                temp.RollOff = "3";
                                temp.Modulation = DVBSChannel.ModulationType.Mod8Vsb;//"8PSK";
                                temp.Standard = "DVB-S2";
                            }

                            try
                            {
                                if (!transponders.ContainsKey(tid))
                                {
                                    transponders.Add(tid, temp);
                                }
                            }
                            catch (Exception ex)
                            {
                                
                                throw;
                            }
                            //continue;
                            reader.ReadLine();
                        }
                        if (semaforoCanali)
                        {
                            
                            String[] valori = line.Split(splitter);
                            Channel c = new Channel();
                            c.Sid = Int32.Parse(valori[0], System.Globalization.NumberStyles.HexNumber).ToString();
                            Int32 trId = Int32.Parse(valori[2], System.Globalization.NumberStyles.HexNumber);
                            string trIds = valori[2] + ":" + valori[3];
                            if (!transponders.ContainsKey(trIds))
                            {
                                reader.ReadLine();
                                reader.ReadLine();
                                continue;
                            }
                            c.TID = trId.ToString();
                            c.Fec = transponders[trIds].Fec;
                            c.Pilot = transponders[trIds].Pilot;
                            c.Roloff = transponders[trIds].RollOff;
                            c.Audio = "0";
                            c.Pcr = "0";
                            c.Pmt = "0";
                            c.Vpid = "0";
                            c.Frequenza = transponders[trIds].frequenza;
                            c.Modulation = transponders[trIds].Modulation;
                            c.NID = transponders[trIds].NetworkId.ToString();
                            c.Polarizzazione = transponders[trIds].Polarizzazione;
                            c.Standard = transponders[trIds].Standard;
                            c.SymbolRate = transponders[trIds].SymbolRate.ToString();
                            c.Satellite = transponders[trIds].Satellite;
                            c.Pilot = transponders[trIds].Pilot;
                            c.Roloff = transponders[trIds].RollOff;
                            c.channelType = 3;
                            c.countryId = 31;
                            c.VideoSource = 0;
                            c.AudioSource = 0;
                            c.Url = "";
                            c.switchingFrequency = 11700000;
                            c.bandwidth = 8;
                            c.minorChannel = -1;
                            c.majorChannel = -1;
                            c.satIndex = -1;
                            c.bitrate = 0;
                            c.tuningSource = 0;
                            c.isVCRSignal = 0;
                            c.isTV = 1;
                            c.isRadio = 0;

                            if ((line = reader.ReadLine()) != null)
                            {
                                if (line.ToLower().StartsWith("nat"))
                                {
                                }
                                c.Name = line;
                                c.IdChannel = line;
                            }

                            if ((line = reader.ReadLine()) != null)
                            {
                                String[] boq = line.Split(splitter);
                                c.Bouquet = boq[1];
                                c.Boquets = new List<string>();
                                c.Boquets.Add(c.Bouquet);
                            }
                            result.Add(c);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                   
                }
            }
            return result;
        }
        public static Dictionary<String, List<ChannelGroupSettings>> readSettings(String pathSett)
        {
            Dictionary<String, List<ChannelGroupSettings>> dictChannelsResult;
            dictChannelsResult = new Dictionary<string, List<ChannelGroupSettings>>();

            List<ChannelGroupSettings> temp = new List<ChannelGroupSettings>();
            try
            {
                String line = "";
                Char splitter = Char.Parse(":");
                String groupName = "";
                int chanNumber = 0;
                using (StreamReader reader = new StreamReader(pathSett))
                {
                    groupName = reader.ReadLine().Replace("#NAME", "").Trim();
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Replace(" ", "").Replace("#", "");

                        if (line.Length > 7)
                        {
                            if (line.Substring(0, 7).ToLower() == "service" && line.Substring(0, 8).ToLower() != "service:")
                            {
                                line = line.Replace(line.Substring(0, 7), line.Substring(0, 7) + ":");
                            }
                        }
                        if (line.Length > 11)
                        {
                            if (line.Substring(0, 11).ToLower() == "description" && line.Substring(0, 12).ToLower() != "description:")
                            {
                                line = line.Replace(line.Substring(0, 11), line.Substring(0, 11) + ":");
                            }
                        }

                        String[] linea = line.Split(splitter);
                        if (linea[0].ToLower() == "SERVICE".ToLower())
                        {
                            chanNumber++;
                            ChannelGroupSettings chSky = new ChannelGroupSettings();
                            //converto tid e sid da hex a decimale
                            Int32 sid = Int32.Parse(linea[4], System.Globalization.NumberStyles.HexNumber);
                            Int32 tid = Int32.Parse(linea[5], System.Globalization.NumberStyles.HexNumber);
                            if (tid != 0 && sid != 0)
                            {
                                chSky.SID = sid.ToString();
                                chSky.TID = tid.ToString();
                                //assegno numero canale in base a come me lo ritrovo nel settings
                                chSky.ChannelNumber = chanNumber;
                                temp.Add(chSky);
                            }
                        }
                        //in caso di descrizione mi salvo il nome del gruppo
                        else if (linea[0].ToLower() == "DESCRIPTION".ToLower())
                        {
                            dictChannelsResult.Add(groupName, temp);
                            line = line.Replace("-", "");
                            linea = line.Split(splitter);
                            groupName = linea[1];
                            temp = new List<ChannelGroupSettings>();
                        }
                    }
                    dictChannelsResult.Add(groupName, temp);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }

            return dictChannelsResult;
        }
        public static List<Group> getGroupFromSettings(string Path, List<Channel> channels)
        {
            List<Group>  result = new List<Group>();
            int i = 0;
            Dictionary<String, List<ChannelGroupSettings>> _gruppiTemp;
            _gruppiTemp = readSettings(Path);
            foreach (List<ChannelGroupSettings> itemGroup in _gruppiTemp.Values)
            {
                List<ChannelGroupSettings> listTempChannel = itemGroup;
                Group _gruppo = new Group();
                _gruppo.Name = _gruppiTemp.ToList()[i].Key;
                _gruppo.Channels = new List<Channel>();
                i++;

                listTempChannel = (from l in itemGroup orderby l.ChannelNumber select l).ToList();

                foreach (ChannelGroupSettings sett in listTempChannel)
                {
                    if ((from c in channels where c.Sid == sett.SID && c.TID == sett.TID select c).Count() > 0)
                    {
                        Channel chan = (from c in channels where c.Sid == sett.SID && c.TID == sett.TID select c).First();
                        _gruppo.Channels.Add(chan);
                    }

                }
                result.Add(_gruppo);
            }
            return result;
        }
        private static Dictionary<string, string> readSatelliteXml(string Path)
        {
            Dictionary<string, string> satelliteName = new Dictionary<string, string>();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(Path);
            foreach (System.Data.DataRow item in ds.Tables["sat"].Rows)
            {
                satelliteName.Add(item.ItemArray[3].ToString(), item.ItemArray[1].ToString());
            }
            return satelliteName;
        }
    }
}
