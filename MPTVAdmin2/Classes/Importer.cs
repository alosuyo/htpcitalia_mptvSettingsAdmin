using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;

namespace MPTVSettingsAdmin.Classes
{
    class Importer
    {
        private static Importer instance = null;

        private Importer() { }

        public static Importer getInstance() {
            if (instance == null) {
                instance = new Importer();
            }
            return instance;
        }

        public static List<Group> readBouqetsTV(String filePathAndName) { 
            //Read the "bouquets.tv" file and import the listing "bouquets (=groups)"

            String line;
            int start;
            int stop;
            String bouquet;
            String filePath;
            List<Group> groups = new List<Group>();

            //StreamReader reader = new StreamReader(filePath + "bouquets.tv");
            //TODO: try except??
            StreamReader reader = new StreamReader(filePathAndName);
            //TODO: bit risky
            filePath = filePathAndName;
            filePath = filePath.Replace("bouquets.tv", "");
            filePath = filePath.Replace("bouquets.radio", "");

            while (!reader.EndOfStream) { 
                //Read each line and search for a matching pattern (SERVICE)
                line = reader.ReadLine();
                if (line.Contains("SERVICE")) {
                    //Look for the file between "BOUQUET" and "ORDER"
                    start = line.IndexOf("u") - 1 ; // + length Bouquet
                    stop = line.Length;
                    
                    bouquet = ((line.Substring(start, stop - start)).Trim()).Replace("\"", "");
                    bouquet = bouquet.Replace(" ORDER BY bouquet", "");
                    Group group = new Group();
                    group.FileName = bouquet;
                    group.Name = bouquet.Replace("userbouquet.", "");
                    group.Name = group.Name.Replace(".tv", "");
                    //userbouquet.allsats.tv

                    StreamReader rdrName = new StreamReader(filePath + "/" + bouquet);
                    String firstLine = rdrName.ReadLine();
                    if (firstLine.Contains("NAME")){
                        firstLine = firstLine.Replace("#NAME", "");
                        firstLine = firstLine.Trim();
                        group.Name = firstLine;
                    }
                    rdrName.Close();
                    rdrName.Dispose();

                    //TODO Read the channels within the bouquet file
                    group.Channels = importBouquet(filePath + "/" + bouquet);

                    groups.Add(group);
                }
            }

            //Cleaning up
            reader.Close();
            reader.Dispose();

            return groups;
        }

        //Map imported channels to mpChannels
        public static List<Group> mapChannels(List<Group> groups, List<Channel> mpChannels, bool delUnknowns = false, bool delEmptyName = true, bool delEmptyGroups = false)
        {
            List<Group> newGroupList = new List<Group>();

            //Loop through all the groups
            foreach (Group grp in groups)
            {
                //Create a new group
                Group newGrp = new Group(grp.Name);
                //Loop through all the channels in this group               
                foreach (Channel chnl in grp.Channels)
                {
                    //Match each channel with a MediaPortal channel
                    foreach (Channel mpChnl in mpChannels)
                    {
                        if (chnl.Sid == mpChnl.Sid &&   //Not entirely sure if this is enough
                            chnl.NID == mpChnl.NID)
                        {
                            //Check if unknown/non-name channels should be imported
                            if (delUnknowns && mpChnl.Name.ToUpper().Contains("UNKNOWN"))
                            {
                                continue;
                            }
                            if (delEmptyName)
                            {
                                Regex regTest = new Regex("\\([0-9]*\\)");
                                if (regTest.IsMatch(mpChnl.Name))
                                {
                                    continue;
                                }
                            }
                            //Create new channel and add to the new group
                            Channel newChnl = new Channel(mpChnl);
                            newGrp.Channels.Add(mpChnl);
                        }
                    }
                }
                //Delete empty groups if necessary
                if (delEmptyGroups && newGrp.Channels.Count == 0)
                {
                    newGrp = null;
                }
                else
                {
                    newGroupList.Add(newGrp);
                }

            }

            return newGroupList;
        }
        
        private static List<Channel> importBouquet(String file) { 
            //Read "bouquet" files and create groups of them

            String line;
            int start;
            String service;
            String[] servicesplit;
            List<Channel> group = new List<Channel>();
            //TODO: try except??
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream) {
                //Create group

                //Read bouquet and add channels to group
                line = reader.ReadLine();
                if (line.Contains("SERVICE")) {
                    start = line.IndexOf("SERVICE") + 7;

                    service = line.Substring(start, line.Length - start);
                    //serviceline: 1:0:19:1b7b:c88:3:eb0000:0:0:0:                                     
                    servicesplit = service.Split(':');
                    
                    //Create channel and add to group
                    if (int.Parse(servicesplit[3],System.Globalization.NumberStyles.HexNumber) != 0)
                    {
                        Channel channel = new Channel();
                        channel.Sid = Int32.Parse(servicesplit[3], System.Globalization.NumberStyles.HexNumber).ToString();
                        channel.TID = Int32.Parse(servicesplit[4], System.Globalization.NumberStyles.HexNumber).ToString();
                        channel.NID = Int32.Parse(servicesplit[5], System.Globalization.NumberStyles.HexNumber).ToString(); 
                        group.Add(channel);
                    }
                    
                }
            }

            reader.Close();
            reader.Dispose();

            return group;
        }

    }
}
