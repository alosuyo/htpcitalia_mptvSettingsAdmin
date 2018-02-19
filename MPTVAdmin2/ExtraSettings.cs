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
    public partial class ExtraSettings : Form
    {
        private Dictionary<string, string> satelliteNames;
        private List<Channel> channels;
        List<Group> groups;
        public ExtraSettings(Dictionary<string,string> satelliteNames, List<Channel> channels, List<Group> groups)
        {
            InitializeComponent();
            this.channels = channels;
            this.satelliteNames = satelliteNames;
            this.groups = groups;

            
            cboModulation.DataSource = Enum.GetValues(typeof(DVBSChannel.ModulationType));
            cboModulation.SelectedItem = DVBSChannel.ModulationType.Mod8Vsb;

            if (satelliteNames != null)
            {
                switch (satelliteNames.Count)
                {
                    case 1:
                        cboDiseqc1.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboBand1.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboSat1.DataSource = satelliteNames.Values.ToList();
                        cboBand2.Enabled = cboBand3.Enabled = cboBand4.Enabled = cboDiseqc2.Enabled = cboDiseqc3.Enabled = cboDiseqc4.Enabled = cboSat2.Enabled = cboSat3.Enabled = cboSat4.Enabled = false;
                        break;
                    case 2:
                        cboDiseqc1.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc2.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboBand1.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand2.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboSat1.DataSource = satelliteNames.Values.ToList();
                        cboSat2.DataSource = satelliteNames.Values.ToList();
                        cboBand3.Enabled = cboBand4.Enabled = cboDiseqc3.Enabled = cboDiseqc4.Enabled = cboSat3.Enabled = cboSat4.Enabled = false;
                        break;
                    case 3:
                        cboDiseqc1.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc2.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc3.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboBand1.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand2.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand3.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboSat1.DataSource = satelliteNames.Values.ToList();
                        cboSat2.DataSource = satelliteNames.Values.ToList();
                        cboSat3.DataSource = satelliteNames.Values.ToList();
                        cboBand4.Enabled = cboDiseqc4.Enabled = cboSat4.Enabled = false;
                        break;
                    case 4:
                        cboDiseqc1.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc2.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc3.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboDiseqc4.DataSource = Enum.GetValues(typeof(DVBSChannel.DisEqcType));
                        cboBand1.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand2.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand3.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboBand4.DataSource = Enum.GetValues(typeof(DVBSChannel.BandType));
                        cboSat1.DataSource = satelliteNames.Values.ToList();
                        cboSat2.DataSource = satelliteNames.Values.ToList();
                        cboSat4.DataSource = satelliteNames.Values.ToList();
                        break;

                }

            }
            else cboSat1.Enabled = false;

            cmbCards.DataSource = MPDataWorker.GetInstance().GetCardFromMp();
        }

        private void ExtraSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Please ATTENTION, all Channels/Groups will be delete. Are you sure?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                long numCan = 0;

                foreach (var item in channels)
                {
                    numCan++;
                    if (item.NumeroCanale == 0)
                    {
                        item.NumeroCanale = numCan;
                    }
                    item.idCard = ((Card)cmbCards.SelectedValue).idCard;
                    
                    if (item.Standard == "DVB-S2")
                    {
                        item.Modulation = (DVBSChannel.ModulationType)cboModulation.SelectedValue;
                    }

                    if (cboDiseqc1.SelectedIndex != -1 && cboBand1.SelectedIndex != -1 && cboSat1.SelectedIndex != -1)
                    {
                        string sat = cboSat1.SelectedValue.ToString();

                        if (item.Satellite == sat)
                        {
                            item.Band = (DVBSChannel.BandType)cboBand1.SelectedValue;
                            item.Diseqc = (DVBSChannel.DisEqcType)cboDiseqc1.SelectedValue;
                        }

                    }

                    if (cboDiseqc2.SelectedIndex != -1 && cboBand2.SelectedIndex != -1 && cboSat2.SelectedIndex != -1)
                    {
                        string sat = cboSat2.SelectedValue.ToString();
                        if (item.Satellite == sat)
                        {
                            item.Band = (DVBSChannel.BandType)cboBand2.SelectedValue;
                            item.Diseqc = (DVBSChannel.DisEqcType)cboDiseqc2.SelectedValue;
                        }

                    }

                    if (cboDiseqc3.SelectedIndex != -1 && cboBand3.SelectedIndex != -1 && cboSat3.SelectedIndex != -1)
                    {
                        string sat = cboSat3.SelectedValue.ToString();

                        if (item.Satellite == sat)
                        {
                            item.Band = (DVBSChannel.BandType)cboBand3.SelectedValue;
                            item.Diseqc = (DVBSChannel.DisEqcType)cboDiseqc3.SelectedValue;
                        }

                    }

                    if (cboDiseqc4.SelectedIndex != -1 && cboBand4.SelectedIndex != -1 && cboSat4.SelectedIndex != -1)
                    {
                        string sat = cboSat1.SelectedValue.ToString();

                        if (item.Satellite == sat)
                        {
                            item.Band = (DVBSChannel.BandType)cboBand4.SelectedValue;
                            item.Diseqc = (DVBSChannel.DisEqcType)cboDiseqc4.SelectedValue;
                        }

                    }
                }
                List<Channel> temp = (from c in channels where c.Name == "Cinema 1 HD" select c).ToList(); //Cinema 1 HD
                MPDataWorker.GetInstance().ExportChannelsToMP(channels, true);
                MPDataWorker.GetInstance().ExportChannelsToMP(groups, true, true);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Done!");
            }
        }
    }
}
