using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    public static class ImportFromM3U
    {
        public static List<Group> importM3U(string path, bool GroupYes, out List<Channel> channels)
        {
            List<Group> result = new List<Group>();
            string line = null;
            //StreamReader playlistFile;
            List<string> data = new List<string>();
            channels = new List<Channel>();
            int channelNum = 0;


            using (StreamReader playlistFile = new StreamReader(path))
            {
                string group = "--";
                while ((line = playlistFile.ReadLine()) != null)
                {

                    if (line.StartsWith("#EXTINF"))
                    {
                        string lastPart = line.Split(',').Last();
                        if (lastPart.StartsWith("---") && GroupYes)
                        {
                            group = lastPart;
                            playlistFile.ReadLine();
                            continue;
                        }
                        else if (lastPart.StartsWith("---") && !GroupYes)
                        {
                            group = string.Empty;
                            playlistFile.ReadLine();
                            continue;
                        }

                        data.Add("EPG N/A");
                        data.Add("Logo N/A");
                        data.Add("Group N/A");
                        data.Add("EPG N/A");
                        data.Add("Logo N/A");
                        data.Add("Group N/A");
                        data.Add("Title N/A");
                        //tvg-id used for epg data[0]


                        string between2 = textoperations.Between(line, "tvg-id=\"", "\"");
                        data[0] = between2;
                        if (data[0] == "")
                        {
                            data[0] = "";
                        }

                        //tvg-logo used for logo data[1]

                        string between3 = textoperations.Between(line, "tvg-logo=\"", "\"");
                        data[1] = between3;
                        if (data[1] == "")
                        {
                            data[1] = "Logo N/A";
                        }
                        //this one is for getting group-title data[2]

                        string between = textoperations.Between(line, "group-title=\"", "\"");
                        group = group.Replace("-", "");
                        data[2] = group;
                        if (data[2] == "")
                        {
                            data[2] = between;
                        }
                        //this is the name of the channel... data[3 && 4]= rubbish data[5]=channel name 
                        lastPart = line.Split(',').Last();
                        data[6] = lastPart;
                        if (data[6] == "")
                        {
                            data[6] = "Title N/A";
                        }

                        continue;

                    }


                    else if (line.Contains("//"))
                    {
                        //this is the url ...data[6]
                        data[5] = line;

                    }
                    // here comes the bit that adds the channels, and defines what goes where



                    if (data.Count > 0)
                    {

                        try
                        {
                            //data count should be 7
                            //if (data[2].Trim().ToLower() == "sky cinema")
                            //{
                            //    if (!data[6].ToLower().StartsWith("sky"))
                            //    {
                            //        data[6] = "Sky " + data[6];
                            //    }
                            //} 
                            //if (data[2].Trim().ToLower() == "calcio")
                            //{
                            //    if (!data[6].ToLower().StartsWith("sky"))
                            //    {
                            //        data[6] = "Sky " + data[6];
                            //    }
                            //}

                            //channels.Add(new Channel(id: channelNum, Name: data[6].Trim(), ip: data[5].Trim(), Group: data[2].Trim(), logo: data[1].Trim(), tvid: data[0].Trim()));//, data[4].Trim(),data[6].Trim(), data[5].Trim()* 
                            channelNum++;
                            Channel ch = new Channel();
                            ch.Name = data[6].Trim();
                            ch.Bouquet = data[2].Trim();
                            ch.channelType = 7;
                            ch.NumeroCanale = channelNum;
                            ch.Frequenza = "0";
                            ch.countryId = 31;
                            ch.isRadio = 0;
                            ch.isTV = 1;
                            ch.NID = "1";
                            ch.TID = "1";
                            ch.Sid = "1";
                            ch.Pmt = "0";
                            ch.FreeToAir = true;
                            ch.Modulation = 0;
                            ch.Polarizzazione = "0";
                            ch.SymbolRate = "0";
                            ch.Diseqc = 0;
                            ch.switchingFrequency = 0;
                            ch.bandwidth = 8;
                            ch.majorChannel = -1;
                            ch.minorChannel = -1;
                            ch.VideoSource = 0;
                            ch.tuningSource = 0;
                            ch.Band = 0;
                            ch.satIndex = -1;
                            ch.Fec = MPTVSettingsAdmin.Classes.DVBSChannel.BinaryConvolutionCodeRate.RateNotSet;
                            ch.Pilot = "-1";
                            ch.Roloff = "-1";
                            ch.Url = data[5].Trim();
                            ch.bitrate = 0;
                            ch.AudioSource = 0;
                            ch.isVCRSignal = 0;

                            if ((from g in result where g.Name == data[2].Trim() select g).Count() > 0)
                            {
                                Group _temp = (from g in result where g.Name == data[2].Trim() select g).First();
                                _temp.Channels.Add(ch);
                                channels.Add(new Channel(ch));
                            }
                            else
                            {
                                Group _temp = new Group();
                                _temp.Name = data[2].Trim();
                                _temp.Channels = new List<Channel>();
                                _temp.Channels.Add(ch);
                                result.Add(_temp);
                                channels.Add(new Channel(ch));
                            }
                            
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            //MessageBox.Show("A channel has been omitted due to its incorrect format");
                            continue;
                        }
                    }


                    data.Clear();
                }
                playlistFile.Close();

                //if (channels.Count == 0)
                //{
                //    MessageBox.Show("Selected file has incorrect structure! Please open an appropriate file.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    splitContainer1.Panel2Collapsed = false; enableEditing();

                //}
                return result;
            }
        }
    }
}
