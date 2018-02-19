using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using MPTVSettingsAdmin.Classes;

namespace MPTVSettingsAdmin
{
    class MPDataWorker
    {
        private static MPDataWorker instance = null;
        
        private String _server;
        private String _username;
        private String _password;

        public String Server {
            set {
                _server = value;
            }
            get {
                return _server;
            }
        }

        public String Username {
            set {
                _username = value;
            }
            get {
                return _username;
            }
        }

        public String Password {
            set {
                _password = value;
            }
            get {
                return _password;
            }
        }

        private MPDataWorker() { 
            //Singleton (make sure you can't initiate more then 1)
        }

        public static MPDataWorker GetInstance() {
            if (instance == null)
            {
                instance = new MPDataWorker();
            }
            return instance;
        }

        public bool TestConnection() {
            String connString = "server=" + _server + ";database=mptvdb;uid=" + _username + ";password=" + _password + ";";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch {
                return false;
            }
            conn.Close();
            return true;
        }

        private MySqlConnection CreateConnection(){
            //Create a connection
            String connString = "server=" + _server + ";database=mptvdb;uid=" + _username + ";password=" + _password + ";";

            MySqlConnection conn = new MySqlConnection(connString);

            conn.Open();

            return conn;
        }

        //Removes the groups
        private void CleanGroups(bool TVGroups = true) {
            MySqlConnection conn;
            conn = CreateConnection();

            String query, query2;

            if (TVGroups)
            {
                //Query to delete TV Groups
                query = "DELETE mptvdb.groupmap, mptvdb.channelgroup " +
                        "FROM `mptvdb`.`groupmap`, mptvdb.channelgroup " +
                        "WHERE channelgroup.idGroup = groupmap.idGroup " +
                        "AND channelgroup.idGroup > 1";

                query2 = "DELETE FROM mptvdb.channelgroup WHERE idGroup > 1";
            }
            else { 
                //Query to delete Radio Groups
                query = "DELETE mptvdb.radiogroupmap, mptvdb.radiochannelgroup " +
                        "FROM `mptvdb`.`radiogroupmap`, mptvdb.radiochannelgroup " +
                        "WHERE radiochannelgroup.idGroup = radiogroupmap.idGroup " +
                        "AND radiochannelgroup.idGroup > 1";

                query2 = "DELETE FROM mptvdb.radiochannelgroup WHERE idGroup > 1";
            }

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();

            comm = new MySqlCommand(query2, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }

        #region commenti
        //public List<Channel> GetChannels(bool TVChannels = true) { 
        //    //Create a list of all channels within the MP DB.
        //    List<Channel> channels = new List<Channel>();
            
        //    MySqlConnection conn;
        //    conn = CreateConnection();

        //    String query;

        //    if (TVChannels){
        //        query = "SELECT idChannel, name, serviceId, transportId, networkId, frequency, countryId, provider FROM `mptvdb`.`tuningdetail` WHERE isTv = true GROUP BY idChannel;";
        //    }
        //    else {
        //        query = "SELECT idChannel, name, serviceId, transportId, networkId, frequency, countryId, provider FROM `mptvdb`.`tuningdetail` WHERE isRadio = true GROUP BY idChannel;";
        //    }

        //    MySqlCommand comm = new MySqlCommand(query, conn);
            
        //    MySqlDataReader reader = comm.ExecuteReader();

        //    while (reader.Read()) {
        //        Channel channel = new Channel();
        //        channel.ChannelID = (int) reader["idChannel"];
        //        channel.Name = reader["name"].ToString();
        //        channel.ServiceID = (int) reader["serviceId"];
        //        channel.TransponderID = (int) reader["transportId"];
        //        channel.NetworkID = (int) reader["networkId"];
        //        channel.Frequency = (int) reader["frequency"];
        //        channel.CountryID = (int) reader["countryId"];
        //        channel.Provider = (string)reader["provider"];
                
        //        channels.Add(channel);
        //    }

        //    reader.Close();           

        //    conn.Close();

        //    return channels;
        //}

        //public List<Group> GetGroups(bool TVChannels = true)
        //{
        //    List<Group> groups = new List<Group>();
        //    MySqlConnection conn;
        //    conn = CreateConnection();

        //    String query;

        //    if (TVChannels)
        //    {
        //        query = "SELECT channelgroup.idGroup, groupName, tuningdetail.idChannel, name, provider, transportId, serviceId, networkId, frequency, countryId " +
        //                "FROM `mptvdb`.`groupmap`, `mptvdb`.`channelgroup`, `mptvdb`.`tuningdetail` " +
        //                "WHERE channelgroup.idGroup = groupmap.idGroup " +
        //                "AND tuningdetail.idChannel = groupmap.idChannel " +
        //                "AND NOT channelgroup.idGroup = 1;";
        //    }
        //    else
        //    {
        //        query = "SELECT radiochannelgroup.idGroup, groupName, tuningdetail.idChannel, name, provider, transportId, serviceId, networkId, frequency, countryId " +
        //                "FROM `mptvdb`.`radiogroupmap`, `mptvdb`.`radiochannelgroup`, `mptvdb`.`tuningdetail` " +
        //                "WHERE radiochannelgroup.idGroup = radiogroupmap.idGroup " +
        //                "AND tuningdetail.idChannel = radiogroupmap.idChannel " +
        //                "AND NOT radiochannelgroup.idGroup = 1;";                
        //    }

        //    MySqlCommand comm = new MySqlCommand(query, conn);

        //    MySqlDataReader reader = comm.ExecuteReader();

        //    int lastGroupId = -1;
        //    Group group = new Group();

        //    //TODO: bit messy: Importcode channels from MP
        //    while (reader.Read())
        //    {
        //        if (lastGroupId != (int)reader["idGroup"])
        //        {
        //            if (lastGroupId != -1) {
        //                groups.Add(group);
        //            }
        //            group = new Group(reader["groupName"].ToString());
        //            lastGroupId = (int)reader["idGroup"];
        //        }

        //        Channel channel = new Channel();
        //        channel.ChannelID = (int)reader["idChannel"];
        //        channel.Name = reader["name"].ToString();
        //        channel.ServiceID = (int)reader["serviceId"];
        //        channel.TransponderID = (int)reader["transportId"];
        //        channel.NetworkID = (int)reader["networkId"];
        //        channel.Frequency = (int)reader["frequency"];
        //        channel.CountryID = (int)reader["countryId"];
        //        channel.Provider = (string)reader["provider"];

        //        group.Channels.Add(channel);
        //    }
        //    groups.Add(group);

        //    reader.Close();

        //    conn.Close();

        //    return groups;
        //}
        #endregion

        public List<Card> GetCardFromMp()
        {
            List<Card> result = new List<Card>();
            MySqlConnection conn = CreateConnection();
            string queryCard = "Select idCard, name From card";
            MySqlCommand sqlCmdGetCard = new MySqlCommand(queryCard, conn);
            MySqlDataReader reader;
            reader = sqlCmdGetCard.ExecuteReader();
            while (reader.Read())
            {
                Card c = new Card();
                c.idCard = int.Parse(reader["idCard"].ToString());
                c.cardName = reader["name"].ToString();
                result.Add(c);
            }
            return result;
        }


        public void ExportChannelsToMP(List<Channel> channels, Boolean isTv)
        {
            MySqlConnection conn = CreateConnection();

            if (isTv)
            {

                string qryDeleteChannel = "Delete FROM mptvdb.channel";
                string qryDeleteTunerDetail = "Delete FROM mptvdb.tuningdetail";
                string qryDeleteChMap = "Delete FROM mptvdb.channelmap";

                MySqlCommand cmdDelChannel = new MySqlCommand(qryDeleteChannel,conn);
                MySqlCommand cmdDelTunerDet = new MySqlCommand(qryDeleteTunerDetail, conn);
                MySqlCommand cmdDelChMap = new MySqlCommand(qryDeleteChMap, conn);

                cmdDelChannel.ExecuteNonQuery();
                cmdDelTunerDet.ExecuteNonQuery();
                cmdDelChMap.ExecuteNonQuery();

                string qryAddChannel = "INSERT INTO mptvdb.channel (idchannel, isRadio, isTv, timesWatched, totalTimeWatched, grabEpg, lastGrabTime, sortOrder, visibleInGuide, externalId, displayName, epgHasGaps, channelNumber) " +
                    "VALUES (@idchannel, @isradio, @istv, '0', '2000-01-01 00:00:00', 0, '2000-01-01 00:00:00', @ordine, 1, @externalid, @displayname, 0, @channelNumber);";

                
                string qryAddTunerDetail = "INSERT INTO mptvdb.tuningdetail (idtuning,idChannel, name, provider, channelType, channelNumber, frequency, countryId, isRadio, isTv, networkId, transportId, serviceId, pmtPid, freeToAir, modulation, polarisation, symbolrate, diseqc, switchingFrequency, bandwidth, majorChannel, minorChannel, videoSource, tuningSource, band, satIndex, innerFecRate, pilot, rollOff, url, bitrate, audioSource, isVCRSignal)"+
                                            "VALUES (@idtuning, @idChannel, @name, @provider, @channelType, @channelNumber, @frequency, @countryId, @isRadio, @isTv, @networkId, @transportId, @serviceId, @pmtPid, @freeToAir, @modulation," + 
                                            "@polarisation, @symbolrate, @diseqc, @switchingFrequency, @bandwidth, @majorChannel, @minorChannel, @videoSource, @tuningSource, @band, @satIndex, @innerFecRate, @pilot, @rollOff, @url, @bitrate, @audioSource, @isVCRSignal);";

                string qryAddChanMap = "INSERT INTO mptvdb.channelmap (idchannelmap, idChannel, idCard, epgOnly) VALUES (@idchannelmap, @idchannel, @idcard, 0)";
                    
                MySqlCommand cmdAddChannel = new MySqlCommand(qryAddChannel, conn);
                MySqlCommand cmdAddTunerDetail = new MySqlCommand(qryAddTunerDetail, conn);
                MySqlCommand cmdAddChanMap = new MySqlCommand(qryAddChanMap, conn);

                foreach (Channel ch in channels)
                {
                    

                    cmdAddChannel.Parameters.AddWithValue("@idchannel", ch.NumeroCanale);
                    cmdAddChannel.Parameters.AddWithValue("@isradio", 0);
                    cmdAddChannel.Parameters.AddWithValue("@istv", 1);
                    cmdAddChannel.Parameters.AddWithValue("@ordine", ch.NumeroCanale);
                    cmdAddChannel.Parameters.AddWithValue("@externalid", "");
                    cmdAddChannel.Parameters.AddWithValue("@displayname", ch.Name);
                    cmdAddChannel.Parameters.AddWithValue("@channelNumber", ch.NumeroCanale);
                    //cmdAddChannel = new MySqlCommand(qryAddChannel, conn);

                    cmdAddChannel.ExecuteNonQuery();
                    cmdAddChannel.Parameters.Clear();

                    cmdAddTunerDetail.Parameters.AddWithValue("@idtuning", ch.NumeroCanale);
                    cmdAddTunerDetail.Parameters.AddWithValue("@idChannel", ch.NumeroCanale);
                    cmdAddTunerDetail.Parameters.AddWithValue("@name", ch.Name);
                    cmdAddTunerDetail.Parameters.AddWithValue("@provider", ch.Bouquet);
                    cmdAddTunerDetail.Parameters.AddWithValue("@channelType", ch.channelType);
                    cmdAddTunerDetail.Parameters.AddWithValue("@channelNumber", ch.NumeroCanale);
                    cmdAddTunerDetail.Parameters.AddWithValue("@frequency", getFreq(ch.Frequenza));
                    cmdAddTunerDetail.Parameters.AddWithValue("@countryId", ch.countryId);
                    cmdAddTunerDetail.Parameters.AddWithValue("@isRadio", ch.isRadio);
                    cmdAddTunerDetail.Parameters.AddWithValue("@isTv", ch.isTV);
                    cmdAddTunerDetail.Parameters.AddWithValue("@networkId", int.Parse(ch.NID));
                    cmdAddTunerDetail.Parameters.AddWithValue("@transportId", int.Parse(ch.TID));
                    cmdAddTunerDetail.Parameters.AddWithValue("@serviceId", int.Parse(ch.Sid));
                    cmdAddTunerDetail.Parameters.AddWithValue("@pmtPid", int.Parse(ch.Pmt));
                    cmdAddTunerDetail.Parameters.AddWithValue("@freeToAir", ch.FreeToAir);
                    cmdAddTunerDetail.Parameters.AddWithValue("@modulation", (int)ch.Modulation);
                    cmdAddTunerDetail.Parameters.AddWithValue("@polarisation", getPolar(ch.Polarizzazione));
                    cmdAddTunerDetail.Parameters.AddWithValue("@symbolrate", int.Parse(ch.SymbolRate));
                    cmdAddTunerDetail.Parameters.AddWithValue("@diseqc", (int)ch.Diseqc);
                    cmdAddTunerDetail.Parameters.AddWithValue("@switchingFrequency", ch.switchingFrequency);
                    cmdAddTunerDetail.Parameters.AddWithValue("@bandwidth", ch.bandwidth);
                    cmdAddTunerDetail.Parameters.AddWithValue("@majorChannel", ch.majorChannel);
                    cmdAddTunerDetail.Parameters.AddWithValue("@minorChannel", ch.minorChannel);
                    cmdAddTunerDetail.Parameters.AddWithValue("@videoSource", ch.VideoSource);
                    cmdAddTunerDetail.Parameters.AddWithValue("@tuningSource", ch.tuningSource);
                    cmdAddTunerDetail.Parameters.AddWithValue("@band", (int)ch.Band);
                    cmdAddTunerDetail.Parameters.AddWithValue("@satIndex", ch.satIndex);
                    cmdAddTunerDetail.Parameters.AddWithValue("@innerFecRate", (int)ch.Fec); 
                    cmdAddTunerDetail.Parameters.AddWithValue("@pilot", int.Parse(ch.Pilot));
                    cmdAddTunerDetail.Parameters.AddWithValue("@rollOff", int.Parse(ch.Roloff)); 
                    cmdAddTunerDetail.Parameters.AddWithValue("@url", ch.Url);
                    cmdAddTunerDetail.Parameters.AddWithValue("@bitrate", ch.bitrate);
                    cmdAddTunerDetail.Parameters.AddWithValue("@audioSource", ch.AudioSource);
                    cmdAddTunerDetail.Parameters.AddWithValue("@isVCRSignal", ch.isVCRSignal);
                    cmdAddTunerDetail.ExecuteNonQuery();
                    cmdAddTunerDetail.Parameters.Clear();

                    cmdAddChanMap.Parameters.AddWithValue("@idchannelmap", ch.NumeroCanale);
                    cmdAddChanMap.Parameters.AddWithValue("@idchannel", ch.NumeroCanale);
                    cmdAddChanMap.Parameters.AddWithValue("@idcard", ch.idCard);
                    cmdAddChanMap.ExecuteNonQuery();
                    cmdAddChanMap.Parameters.Clear();
                    
                }
            }
        }

        private int getFreq(String freq)
        {
            Double frequenza = Double.Parse(freq);
            //frequenza = frequenza * 100;
            freq = frequenza.ToString();
            String s = "12169000";
            int diff;
            if (freq.Length < s.Length)
            {
                diff = s.Length - freq.Length;
                for (int i = 0; i < diff; i++)
                {
                    freq += "0";
                }
            }
            return int.Parse(freq);
        }

        private int getPolar(String polarizzazione)
        {
            String ritorno = "";
            if (polarizzazione.ToLower() == "v")
            {
                ritorno = "2";
            }
            else
            {
                ritorno = "1";
            }
            return int.Parse(ritorno);

        }

        public void ExportChannelsToMP(List<Group> groups, bool deleteExisting, bool TVChannels = true){//, List<Channel> mpChannels) { 
            if (deleteExisting){
                CleanGroups(TVChannels);
            }
            String idGroup;
            int sortCount;
            int sortOrd;

            MySqlConnection conn = CreateConnection();

            String qryAddGroups;
            String qryAddChannels;
            String qryLatestGroup;

            String qryLatestSortOrder = "SELECT MAX(sortOrder) FROM radiochannelgroup WHERE idGroup > 1";
            
            if (TVChannels)
            {
                qryAddGroups = "INSERT INTO channelgroup(GroupName, sortOrder) VALUES (@groupname, @sortOrd)";
                qryAddChannels = "INSERT INTO groupmap(idGroup, idChannel, SortOrder) VALUES (@groupId, @channelId, @SortOrder)";
                qryLatestGroup = "SELECT idGroup FROM `mptvdb`.`channelgroup` ORDER BY idGroup DESC LIMIT 1";
            }
            else {
                qryAddGroups = "INSERT INTO radiochannelgroup(GroupName, sortOrder) VALUES (@groupname, @sortOrd)";
                qryAddChannels = "INSERT INTO radiogroupmap(idGroup, idChannel, SortOrder) VALUES (@groupId, @channelId, @SortOrder)";
                qryLatestGroup = "SELECT idGroup FROM `mptvdb`.`radiochannelgroup` ORDER BY idGroup DESC LIMIT 1";            
            }

            MySqlCommand sqlCmdAddGroups = new MySqlCommand(qryAddGroups, conn);
            MySqlCommand sqlCmdGetLatestGrp = new MySqlCommand(qryLatestGroup, conn);
            MySqlCommand sqlCmdAddChannels = new MySqlCommand(qryAddChannels, conn);
            MySqlCommand sqlCmdgetLatestSortOrder = new MySqlCommand(qryLatestSortOrder, conn);

            MySqlDataReader reader;

            reader = sqlCmdgetLatestSortOrder.ExecuteReader();
            reader.Read();
            if (reader[0].ToString() != "")
            {
                sortOrd = (int)(reader[0]);
            }
            else {
                sortOrd = 1;
            }
            reader.Close();

            for (int i = 0; i < groups.Count; i++){
                if (groups[i].Wanted){
                    //Add group
                    sqlCmdAddGroups.Parameters.AddWithValue("@groupname", groups[i].Name);
                    sqlCmdAddGroups.Parameters.AddWithValue("@sortOrd", sortOrd++);
                    sqlCmdAddGroups.ExecuteNonQuery();
                    sqlCmdAddGroups.Parameters.Clear();
                    
                    //Get latest groupID and add channels to it.
                    reader = sqlCmdGetLatestGrp.ExecuteReader();
                    reader.Read();
                    idGroup = reader["idGroup"].ToString();
                    reader.Close();
                    reader.Dispose();

                    //Add Channels to group
                    //TODO optimize!! get rid off the dirt.     
                    sortCount = 0;
                    foreach (Channel chn in groups[i].Channels){                        
                        sqlCmdAddChannels.Parameters.AddWithValue("@groupId", idGroup);
                        sqlCmdAddChannels.Parameters.AddWithValue("@channelId", chn.NumeroCanale);
                        sqlCmdAddChannels.Parameters.AddWithValue("@SortOrder", sortCount++);
                        sqlCmdAddChannels.ExecuteNonQuery();
                        sqlCmdAddChannels.Parameters.Clear(); 
                    }                    
                }
            }

            sqlCmdAddChannels.Parameters.Clear();
            sqlCmdAddChannels.Dispose();

            sqlCmdAddGroups.Parameters.Clear();
            sqlCmdAddGroups.Dispose();
            
            conn.Close();
            conn.Dispose();

        }
    }

}
