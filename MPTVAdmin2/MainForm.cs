using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPTVSettingsAdmin.Classes;

namespace MPTVSettingsAdmin
{
    public partial class frmMain : Form
    {        
        //TODO: connAvailable really necessary
        private bool connAvailable = false;
        private List<Group> channelGroups = new List<Group>();       
        private List<Channel> mpTVAllChannels;
        private List<Channel> mpRadioAllChannels;
        private List<Channel> mpChannelsSelection;
        private MPDataWorker mpDataWorker;
        private bool activeTypeTV = true;
        private bool activeSearchName = true;
        private Dictionary<string, string> satteliteName;

        private void Initialize() { 
            //Load MediaPortal Channels                                    
            mpDataWorker = MPDataWorker.GetInstance();
            
            //TODO: Ask for user/pass/server (in the beginning?)
            mpDataWorker.Username = txtDBUserName.Text;
            mpDataWorker.Password = txtDBPassword.Text;
            mpDataWorker.Server =txtDBServer.Text;
            
            if (mpDataWorker.TestConnection())
            {
                connAvailable = true;
                btnAdd.Enabled = true;
                btnImportFromMediaportal.Enabled = true;
                btnExportToMediaPortal.Enabled = true;
                btnImportFromDreamBox.Enabled = true;
                
                //Two unique instances!
                //Load Channels
                //mpTVAllChannels = mpDataWorker.GetChannels();
                //mpRadioAllChannels = mpDataWorker.GetChannels(false);

                //Map channels
                //mpChannelsSelection = mpDataWorker.GetChannels(activeTypeTV ? true : false);

                grdMPAllChannels.DataSource = mpChannelsSelection;
            }
            else {
                connAvailable = false;
                //btnAdd.Enabled = false;
                btnImportFromMediaportal.Enabled = false;
                //
                btnExportToMediaPortal.Enabled = false;
                //btnExportToMediaPortal.Enabled = false;
                //btnImportFromDreamBox.Enabled = false;

                //grdMPAllChannels.DataSource = null;
            }
        }

        public frmMain()
        {
            InitializeComponent();            
            Initialize();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Refill the selection
            grdMPAllChannels.DataSource = null;
            mpChannelsSelection.Clear();
            
            foreach (Channel channel in (activeTypeTV ? mpTVAllChannels : mpRadioAllChannels)){
                if ((activeSearchName ? channel.Name : channel.Bouquet).ToUpper().Contains(txtSearch.Text.ToUpper())){
                    mpChannelsSelection.Add(channel);
                }
            }
           
            grdMPAllChannels.DataSource = mpChannelsSelection;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            
            if (lstGroups.SelectedIndex != -1)
            {
                int index = lstGroups.SelectedIndex;
                for (int i = 0; i < grdMPAllChannels.SelectedRows.Count; i++)
                {
                    //Walk through the selected rows                    
                    Channel channel = (Channel)grdMPAllChannels.SelectedRows[i].DataBoundItem;
                    //Check if channel isn't already a member of the group
                    if (!channelGroups[lstGroups.SelectedIndex].Channels.Contains(channel))
                    {
                        channelGroups[lstGroups.SelectedIndex].Channels.Add(channel);
                    }
                }
                RefreshLists();
                lstGroups.SelectedIndex = index;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialize();
        }

        private void radProvider_CheckedChanged(object sender, EventArgs e)
        {
            activeSearchName = false;
        }

        private void radName_CheckedChanged(object sender, EventArgs e)
        {
            activeSearchName = true;
        }

        private void btnImportFromDreamBox_Click(object sender, EventArgs e)
        {
            String filter = (activeTypeTV ? "bouquets.tv |bouquets.tv" : "bouquets.radio |bouquets.radio");
            dlgOpenFile.FileName = "";
            dlgOpenFile.Filter = filter;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK) {
                mpTVAllChannels = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace("bouquets.tv","lamedb"), out satteliteName);
                List<Channel> temp = (from c in mpTVAllChannels where c.Name == "Cinema 1 HD" select c).ToList(); //Cinema 1 HD
                mpChannelsSelection = new List<Channel>();
                foreach (var item in mpTVAllChannels)
                {
                    mpChannelsSelection.Add(new Channel(item));
                }
                //mpChannelsSelection = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace("bouquets.tv", "lamedb"), out satteliteName);
                grdMPAllChannels.DataSource = mpChannelsSelection;
                channelGroups = Importer.readBouqetsTV(dlgOpenFile.FileName);
            }

            //activeTypeTV decides to map on Radio/TV
            channelGroups = Importer.mapChannels(channelGroups, activeTypeTV ? mpTVAllChannels : mpRadioAllChannels, 
                               chkDeleteUnknown.Checked, chkDeleteEmptyNames.Checked, chkDeleteEmptyGroups.Checked);
            RefreshLists();
            
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check if the list isn't empty          
            if (channelGroups.Count != 0 && lstGroups.SelectedItem != null)
            {
                lstChannels.DataSource = ((Group)lstGroups.SelectedItem).Channels;
                txtGroupName.Text = ((Group)lstGroups.SelectedItem).Name;
            }
        }

        private void btnClearAllTV_Click(object sender, EventArgs e)
        {
            ClearLists();
        }

        private void ClearLists(){            
            channelGroups.Clear();
            lstGroups.DataSource = null;
            lstChannels.DataSource = null;
            txtGroupName.Text = "";
        }

        private void cntMenuGroupDelete_Click(object sender, EventArgs e)
        {
            //Delete selected item(s).
            if (lstGroups.SelectedItems.Count < 1)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete selected Groups", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var item in lstGroups.SelectedItems)
                {
                    channelGroups.Remove((Group)item);   
                }

                if (channelGroups.Count == 0)
                {
                    ClearLists();
                }
                RefreshLists(); 
            }               
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            if (lstGroups.SelectedIndex != -1)
            {
                channelGroups[lstGroups.SelectedIndex].Name = txtGroupName.Text;
                RefreshLists();
            }
        }


        private void RefreshLists(){
            lstChannels.DataSource = null;
            lstChannels.DisplayMember = "Name";
            lstGroups.DataSource = null;
            lstGroups.DataSource = channelGroups;
            lstGroups.DisplayMember = "NameAndCount";
        }

        private void cntMenuGroupsAdd_Click(object sender, EventArgs e)
        {
            Group newGrp = new Group("New Group");
            channelGroups.Add(newGrp);
            RefreshLists();
        }

        private void cntMenuGroupsMoveUp_Click(object sender, EventArgs e)
        {
            //Move UP            
            //int index = lstGroups.SelectedIndex;
            //if (index != 0 && index != -1)
            //{                
            //    Group grp = (Group)channelGroups[index];
            //    channelGroups.RemoveAt(index);
            //    channelGroups.Insert(index - 1, grp);
            //    RefreshLists();
            //    lstGroups.SelectedIndex = index - 1;
            //}
            ListBox.SelectedIndexCollection indexes = lstGroups.SelectedIndices; // = lstChannels.SelectedIndices;
            List<int> indexes1 = new List<int>();
            foreach (var item in lstGroups.SelectedIndices)
            {
                indexes1.Add((int)item);
            }
            if (indexes.Count == 0)
                return;
            for (int i = 0; i < indexes.Count; ++i)
            {
                int index = indexes[i];
                if (indexes[0] > 0)
                {
                    Group item = (Group)lstGroups.Items[index];
                    channelGroups.RemoveAt(index);
                    channelGroups.Insert(index - 1, item);
                }
            }

            //ReOrder();
            RefreshLists();
            lstGroups.ClearSelected();
            foreach (var item in indexes1)
            {
                if (item > 0)
                {
                    lstGroups.SetSelected((int)item - 1, true);
                }
            }
        }

        private void cntMenuGroupsMoveDown_Click(object sender, EventArgs e)
        {
            //Move Down
            //int index = lstGroups.SelectedIndex;
            //if (index != channelGroups.Count - 1 && index != -1)
            //{
            //    Group grp = (Group)channelGroups[index];
            //    channelGroups.RemoveAt(index);
            //    channelGroups.Insert(index + 1, grp);
            //    RefreshLists();
            //    lstGroups.SelectedIndex = index + 1;
            //}
            ListBox.SelectedIndexCollection indexes = lstGroups.SelectedIndices;
            List<int> indexes1 = new List<int>();
            foreach (var item in lstGroups.SelectedIndices)
            {
                indexes1.Add((int)item);
            }

            if (indexes.Count == 0)
                return;
            if (lstChannels.Items.Count < 2)
                return;
            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                int index = indexes[i];
                Group item = (Group)lstGroups.Items[index];
                channelGroups.RemoveAt(index);
                if (index + 1 < lstGroups.Items.Count)
                    channelGroups.Insert(index + 1, item);
                else
                    channelGroups.Add(item);
            }

            RefreshLists();
            lstGroups.ClearSelected();
            foreach (var item in indexes1)
            {
                if (item < lstGroups.Items.Count - 1)
                {
                    lstGroups.SetSelected(item + 1, true);
                }
            }

        }

        private void cntMenuChannelsDelete_Click(object sender, EventArgs e)
        {
            //Delete selected item(s).
            //channelGroups[lstGroups.SelectedIndex].Channels.Remove((Channel) lstChannels.SelectedItem);
            if (lstChannels.SelectedItems.Count < 1)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete selected channels","Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var item in lstChannels.SelectedItems)
                {
                    channelGroups[lstGroups.SelectedIndex].Channels.Remove((Channel)item);
                }
                RefreshLists(); 
            }
        }

        private void btnImportFromMediaportal_Click(object sender, EventArgs e)
        {
            //channelGroups = mpDataWorker.GetGroups(activeTypeTV);
            RefreshLists();
        }

        private void cntMenuChannelsMoveDown_Click(object sender, EventArgs e)
        {
            //Move Down           
            //int index = lstChannels.SelectedIndex;
            //if (index != channelGroups[lstGroups.SelectedIndex].Channels.Count - 1 && index != -1)
            //{
            //    Channel chnl = (Channel)channelGroups[lstGroups.SelectedIndex].Channels[index];
            //    channelGroups[lstGroups.SelectedIndex].Channels.RemoveAt(index);
            //    channelGroups[lstGroups.SelectedIndex].Channels.Insert(index + 1, chnl);
            //    RefreshLists();
            //    lstChannels.SelectedIndex = index + 1;
            //}

            //lstGroups.BeginUpdate();
            //try
            //{
                ListBox.SelectedIndexCollection indexes = lstChannels.SelectedIndices;
                List<int> indexes1 = new List<int>();
                foreach (var item in lstChannels.SelectedIndices)
                {
                    indexes1.Add((int)item);
                }

                if (indexes.Count == 0)
                    return;
                if (lstChannels.Items.Count < 2)
                    return;
                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    int index = indexes[i];
                    Channel item = (Channel)lstChannels.Items[index];
                    channelGroups[lstGroups.SelectedIndex].Channels.RemoveAt(index);
                    if (index + 1 < lstChannels.Items.Count)
                        channelGroups[lstGroups.SelectedIndex].Channels.Insert(index + 1, item); 
                    else
                        channelGroups[lstGroups.SelectedIndex].Channels.Add(item);
                }
                
                RefreshLists();
                lstChannels.ClearSelected();
                foreach (var item in indexes1)
                {
                    if (item < lstChannels.Items.Count - 1)
                    {
                        lstChannels.SetSelected(item + 1, true);
                    }
                }
            //}
            //finally
            //{
            //    lstChannels.EndUpdate();
            //}
        }

        private void cntMenuChannelsMoveUp_Click(object sender, EventArgs e)
        {
            //Move UP            
            //int index = lstChannels.SelectedIndex;
            //if (index != 0 && index != -1)
            //{
            //    Channel chnl = (Channel)channelGroups[lstGroups.SelectedIndex].Channels[index];
            //    channelGroups[lstGroups.SelectedIndex].Channels.RemoveAt(index);
            //    channelGroups[lstGroups.SelectedIndex].Channels.Insert(index - 1, chnl);
            //    RefreshLists();
            //    lstChannels.SelectedIndex = index - 1;
            //}
            //lstChannels.BeginUpdate();
            //try
            //{
                ListBox.SelectedIndexCollection indexes = lstChannels.SelectedIndices; // = lstChannels.SelectedIndices;
                List<int> indexes1 = new List<int>();
                foreach (var item in lstChannels.SelectedIndices)
                {
                    indexes1.Add((int)item);
                }
                if (indexes.Count == 0)
                    return;
                for (int i = 0; i < indexes.Count; ++i)
                {
                    int index = indexes[i];
                    if (index > 0)
                    {
                        Channel item = (Channel)lstChannels.Items[index];
                        channelGroups[lstGroups.SelectedIndex].Channels.RemoveAt(index);
                        channelGroups[lstGroups.SelectedIndex].Channels.Insert(index - 1, item);
                    }
                }

                //ReOrder();
                RefreshLists();
                lstChannels.ClearSelected();
                foreach (var item in indexes1)
                {
                    if (item > 0)
                    {
                        lstChannels.SetSelected((int)item - 1, true);
                    }
                }
            
            //}
            //finally
            //{
            //    lstChannels.EndUpdate();
            //}
        }

        private void btnExportToMediaPortal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want export all channels or only the channels in the groups?\nYes = All channels\nNo = Only channels in the Groups", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            List<Group> groups = lstGroups.DataSource as List<Group>;
            List<Channel> temp = (from c in mpTVAllChannels where c.Name == "Cinema 1 HD" select c).ToList();
            if (mpTVAllChannels != null && mpTVAllChannels.Count > 0 && groups != null && groups.Count > 0)
            {
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    List<Channel> channels = new List<Channel>();

                    foreach (var item in groups)
                    {
                        foreach (var ch in item.Channels)
                        {
                            if (!channels.Contains(ch))
                            {
                                channels.Add(ch);
                            }
                        }
                    }
                    if (channels.Count > 0 && groups.Count > 0)
                    {
                        ExtraSettings extra = new ExtraSettings(satteliteName, channels, groups);
                        extra.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not enough groups/channels", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (mpTVAllChannels.Count > 0 && groups.Count > 0)
                    {
                        List<Channel> temp1 = (from c in mpTVAllChannels where c.Name == "Cinema 1 HD" select c).ToList();
                        ExtraSettings extra = new ExtraSettings(satteliteName, mpTVAllChannels, groups);
                        extra.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not enough groups/channels", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Not enough groups/channels", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
            //mpDataWorker.ExportChannelsToMP(channelGroups, chkDeleteExistingGroups.Checked, activeTypeTV);
            //MessageBox.Show("Done!");
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            mpDataWorker.Username = txtDBUserName.Text;
            mpDataWorker.Password = txtDBPassword.Text;
            mpDataWorker.Server = txtDBServer.Text;
            if (mpDataWorker.TestConnection())
            {
                //Jippie
                MessageBox.Show("Connection succesfull");
                connAvailable = true;
                Initialize();
            }
            else { 
                //Error
                MessageBox.Show("Connection failed");
                connAvailable = false;
                Initialize();
            }
        }

        private void txtDBUserName_TextChanged(object sender, EventArgs e)
        {
            mpDataWorker.Username = txtDBUserName.Text;
        }

        private void txtDBPassword_TextChanged(object sender, EventArgs e)
        {
            mpDataWorker.Password = txtDBPassword.Text;
        }

        private void txtDBServer_TextChanged(object sender, EventArgs e)
        {
            mpDataWorker.Server = txtDBServer.Text;
        }

        private void cmbWorking_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TV or Radio
            if (cmbWorking.SelectedItem.ToString() == "Radio")
            {
                activeTypeTV = false;
                if (mpDataWorker.TestConnection())
                {
                    //mpChannelsSelection = mpDataWorker.GetChannels(false);
                    grdMPAllChannels.DataSource = mpChannelsSelection;
                }
            }
            else
            {
                activeTypeTV = true;                
                if (mpDataWorker.TestConnection())
                {
                    //mpChannelsSelection = mpDataWorker.GetChannels();
                    grdMPAllChannels.DataSource = mpChannelsSelection;
                }
            }
            ClearLists();
        }

        private void lstChannels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cntMenuChannelsDelete_Click(sender, e);
            }
            if (e.KeyCode == Keys.U){
                cntMenuChannelsMoveUp_Click(sender, e);                
            }
            if (e.KeyCode == Keys.D){
                cntMenuChannelsMoveDown_Click(sender, e);
            }
        }

        private void lstGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
               cntMenuGroupDelete_Click(sender, e);
            }
            if (e.KeyCode == Keys.U){
                cntMenuGroupsMoveUp_Click(sender, e);
            }
            if (e.KeyCode == Keys.D){
                cntMenuGroupsMoveDown_Click(sender, e);
            }        
        }

        private void btnImportFromLamedb_Click(object sender, EventArgs e)
        {
            String filter = (activeTypeTV ? "lamedb |lamedb" : "bouquets.radio |bouquets.radio");
            dlgOpenFile.FileName = "";
            dlgOpenFile.Filter = filter;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                //mpTVAllChannels = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace("bouquets.tv", "lamedb"));
                mpChannelsSelection = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace("bouquets.tv", "lamedb"), out satteliteName);
                grdMPAllChannels.DataSource = mpChannelsSelection;
                //channelGroups = Importer.readBouqetsTV(dlgOpenFile.FileName);
            }
            RefreshLists();
        }

        private void btnImportfromUserboquet_Click(object sender, EventArgs e)
        {
            String filter = (activeTypeTV ? "File tv |*.tv" : "bouquets.radio |bouquets.radio");
            dlgOpenFile.FileName = "";
            dlgOpenFile.Filter = filter;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                string file = dlgOpenFile.FileName.Split(char.Parse("\\"))[dlgOpenFile.FileName.Split(char.Parse("\\")).Length - 1];
                mpTVAllChannels = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace(file, "lamedb"), out satteliteName);
                mpChannelsSelection = new List<Channel>();
                foreach (var item in mpTVAllChannels)
                {
                    mpChannelsSelection.Add(new Channel(item));
                }
                //mpChannelsSelection = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace(file, "lamedb"), out satteliteName);
                grdMPAllChannels.DataSource = mpChannelsSelection;
                channelGroups = ImportFromSettings.getGroupFromSettings(dlgOpenFile.FileName, mpChannelsSelection);
            }
            RefreshLists();
        }

        private void btnNephGuide_Click(object sender, EventArgs e)
        {
            String filter = (activeTypeTV ? "File xml |*.xml" : "bouquets.radio |bouquets.radio");
            dlgOpenFile.FileName = "";
            dlgOpenFile.Filter = filter;
            List<Group> groups;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                mpTVAllChannels = ImportFromNephGuide.getChannelsFromNephGuide(dlgOpenFile.FileName, out groups);
                mpChannelsSelection = new List<Channel>();
                foreach (var item in mpTVAllChannels)
                {
                    mpChannelsSelection.Add(new Channel(item));
                }
                grdMPAllChannels.DataSource = mpChannelsSelection;
                channelGroups = groups;
            }
            RefreshLists();
        }

        private void btnImportM3U_Click(object sender, EventArgs e)
        {
            String filter = ("File m3u |*.m3u");
            dlgOpenFile.FileName = "";
            dlgOpenFile.Filter = filter;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Vuoi associare in automatico i gruppi presenti nel file m3u?", "Associazione", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    channelGroups = ImportFromM3U.importM3U(dlgOpenFile.FileName, true, out mpTVAllChannels); //Importer.GetInstance().importM3U(dlgOpenFile.FileName, true);
                    RefreshLists();
                }
                else
                {
                    ImportFromM3U.importM3U(dlgOpenFile.FileName, true, out mpTVAllChannels);
                }
                mpChannelsSelection = new List<Channel>();
                foreach (var item in mpTVAllChannels)
                {
                    mpChannelsSelection.Add(new Channel(item));
                }
                //mpChannelsSelection = ImportFromSettings.getChannelsFromSetting(dlgOpenFile.FileName.Replace(file, "lamedb"), out satteliteName);
                grdMPAllChannels.DataSource = mpChannelsSelection;
                //enableButtons();
                //selectGroup();
            }
        }
    }
}
