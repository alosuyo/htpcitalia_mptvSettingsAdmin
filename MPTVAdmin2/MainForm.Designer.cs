namespace MPTVSettingsAdmin
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpDBSettings = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.lblDBUserName = new System.Windows.Forms.Label();
            this.grdMPAllChannels = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.radProvider = new System.Windows.Forms.RadioButton();
            this.radName = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblKeyWord = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTVRadio = new System.Windows.Forms.TabPage();
            this.btnGrpDown = new System.Windows.Forms.Button();
            this.btnGrpUp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNephGuide = new System.Windows.Forms.Button();
            this.btnImportfromUserboquet = new System.Windows.Forms.Button();
            this.btnImportFromLamedb = new System.Windows.Forms.Button();
            this.btnExportToMediaPortal = new System.Windows.Forms.Button();
            this.btnImportFromDreamBox = new System.Windows.Forms.Button();
            this.btnClearAllTV = new System.Windows.Forms.Button();
            this.btnImportFromMediaportal = new System.Windows.Forms.Button();
            this.grpChannels = new System.Windows.Forms.GroupBox();
            this.btnChDown = new System.Windows.Forms.Button();
            this.lstChannels = new System.Windows.Forms.ListBox();
            this.cntMenuChannels = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntMenuChannelsMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMenuChannelsMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMenuChannelsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.channelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnChUp = new System.Windows.Forms.Button();
            this.grpGroups = new System.Windows.Forms.GroupBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.cntMenuGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntMenuGroupsMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMenuGroupsMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMenuGroupsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMenuGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbWorking = new System.Windows.Forms.ComboBox();
            this.grpExportSettings = new System.Windows.Forms.GroupBox();
            this.chkDeleteExistingGroups = new System.Windows.Forms.CheckBox();
            this.grpImportSettings = new System.Windows.Forms.GroupBox();
            this.chkDeleteEmptyGroups = new System.Windows.Forms.CheckBox();
            this.chkDeleteEmptyNames = new System.Windows.Forms.CheckBox();
            this.chkDeleteUnknown = new System.Windows.Forms.CheckBox();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnImportM3U = new System.Windows.Forms.Button();
            this.grpDBSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMPAllChannels)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTVRadio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpChannels.SuspendLayout();
            this.cntMenuChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelBindingSource)).BeginInit();
            this.grpGroups.SuspendLayout();
            this.cntMenuGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpExportSettings.SuspendLayout();
            this.grpImportSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDBSettings
            // 
            this.grpDBSettings.Controls.Add(this.btnTestConnection);
            this.grpDBSettings.Controls.Add(this.txtDBServer);
            this.grpDBSettings.Controls.Add(this.txtDBPassword);
            this.grpDBSettings.Controls.Add(this.txtDBUserName);
            this.grpDBSettings.Controls.Add(this.lblDBServer);
            this.grpDBSettings.Controls.Add(this.lblDBPassword);
            this.grpDBSettings.Controls.Add(this.lblDBUserName);
            this.grpDBSettings.Location = new System.Drawing.Point(6, 6);
            this.grpDBSettings.Name = "grpDBSettings";
            this.grpDBSettings.Size = new System.Drawing.Size(267, 126);
            this.grpDBSettings.TabIndex = 1;
            this.grpDBSettings.TabStop = false;
            this.grpDBSettings.Text = "Database settings:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(156, 94);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(99, 23);
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(88, 68);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(167, 20);
            this.txtDBServer.TabIndex = 5;
            this.txtDBServer.Text = "localhost";
            this.txtDBServer.TextChanged += new System.EventHandler(this.txtDBServer_TextChanged);
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(88, 44);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(167, 20);
            this.txtDBPassword.TabIndex = 4;
            this.txtDBPassword.TextChanged += new System.EventHandler(this.txtDBPassword_TextChanged);
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(88, 19);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(167, 20);
            this.txtDBUserName.TabIndex = 3;
            this.txtDBUserName.Text = "root";
            this.txtDBUserName.TextChanged += new System.EventHandler(this.txtDBUserName_TextChanged);
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.Location = new System.Drawing.Point(8, 75);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(41, 13);
            this.lblDBServer.TabIndex = 2;
            this.lblDBServer.Text = "Server:";
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.AutoSize = true;
            this.lblDBPassword.Location = new System.Drawing.Point(8, 51);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(56, 13);
            this.lblDBPassword.TabIndex = 1;
            this.lblDBPassword.Text = "Password:";
            // 
            // lblDBUserName
            // 
            this.lblDBUserName.AutoSize = true;
            this.lblDBUserName.Location = new System.Drawing.Point(6, 27);
            this.lblDBUserName.Name = "lblDBUserName";
            this.lblDBUserName.Size = new System.Drawing.Size(58, 13);
            this.lblDBUserName.TabIndex = 0;
            this.lblDBUserName.Text = "Username:";
            // 
            // grdMPAllChannels
            // 
            this.grdMPAllChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMPAllChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.providerDataGridViewTextBoxColumn});
            this.grdMPAllChannels.Location = new System.Drawing.Point(814, 87);
            this.grdMPAllChannels.Name = "grdMPAllChannels";
            this.grdMPAllChannels.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdMPAllChannels.RowHeadersVisible = false;
            this.grdMPAllChannels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMPAllChannels.Size = new System.Drawing.Size(285, 414);
            this.grdMPAllChannels.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // providerDataGridViewTextBoxColumn
            // 
            this.providerDataGridViewTextBoxColumn.DataPropertyName = "Provider";
            this.providerDataGridViewTextBoxColumn.HeaderText = "Provider";
            this.providerDataGridViewTextBoxColumn.Name = "providerDataGridViewTextBoxColumn";
            this.providerDataGridViewTextBoxColumn.Width = 70;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.radProvider);
            this.grpSearch.Controls.Add(this.radName);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblKeyWord);
            this.grpSearch.Location = new System.Drawing.Point(814, 16);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(285, 64);
            this.grpSearch.TabIndex = 3;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // radProvider
            // 
            this.radProvider.AutoSize = true;
            this.radProvider.Location = new System.Drawing.Point(136, 41);
            this.radProvider.Name = "radProvider";
            this.radProvider.Size = new System.Drawing.Size(64, 17);
            this.radProvider.TabIndex = 5;
            this.radProvider.Text = "Provider";
            this.radProvider.UseVisualStyleBackColor = true;
            this.radProvider.CheckedChanged += new System.EventHandler(this.radProvider_CheckedChanged);
            // 
            // radName
            // 
            this.radName.AutoSize = true;
            this.radName.Checked = true;
            this.radName.Location = new System.Drawing.Point(77, 41);
            this.radName.Name = "radName";
            this.radName.Size = new System.Drawing.Size(53, 17);
            this.radName.TabIndex = 1;
            this.radName.TabStop = true;
            this.radName.Text = "Name";
            this.radName.UseVisualStyleBackColor = true;
            this.radName.CheckedChanged += new System.EventHandler(this.radName_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(77, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblKeyWord
            // 
            this.lblKeyWord.AutoSize = true;
            this.lblKeyWord.Location = new System.Drawing.Point(6, 22);
            this.lblKeyWord.Name = "lblKeyWord";
            this.lblKeyWord.Size = new System.Drawing.Size(51, 13);
            this.lblKeyWord.TabIndex = 4;
            this.lblKeyWord.Text = "Keyword:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(722, 89);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "<< Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTVRadio);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(704, 533);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabTVRadio
            // 
            this.tabTVRadio.Controls.Add(this.btnGrpDown);
            this.tabTVRadio.Controls.Add(this.btnGrpUp);
            this.tabTVRadio.Controls.Add(this.groupBox2);
            this.tabTVRadio.Controls.Add(this.grpChannels);
            this.tabTVRadio.Controls.Add(this.grpGroups);
            this.tabTVRadio.Location = new System.Drawing.Point(4, 22);
            this.tabTVRadio.Name = "tabTVRadio";
            this.tabTVRadio.Padding = new System.Windows.Forms.Padding(3);
            this.tabTVRadio.Size = new System.Drawing.Size(696, 507);
            this.tabTVRadio.TabIndex = 0;
            this.tabTVRadio.Text = "TV / Radio";
            this.tabTVRadio.UseVisualStyleBackColor = true;
            // 
            // btnGrpDown
            // 
            this.btnGrpDown.Image = global::MPTVSettingsAdmin.Properties.Resources.icon_down;
            this.btnGrpDown.Location = new System.Drawing.Point(219, 228);
            this.btnGrpDown.Name = "btnGrpDown";
            this.btnGrpDown.Size = new System.Drawing.Size(34, 34);
            this.btnGrpDown.TabIndex = 7;
            this.btnGrpDown.UseVisualStyleBackColor = true;
            this.btnGrpDown.Click += new System.EventHandler(this.cntMenuGroupsMoveDown_Click);
            // 
            // btnGrpUp
            // 
            this.btnGrpUp.Image = global::MPTVSettingsAdmin.Properties.Resources.icon_up;
            this.btnGrpUp.Location = new System.Drawing.Point(219, 188);
            this.btnGrpUp.Name = "btnGrpUp";
            this.btnGrpUp.Size = new System.Drawing.Size(34, 34);
            this.btnGrpUp.TabIndex = 6;
            this.btnGrpUp.UseVisualStyleBackColor = true;
            this.btnGrpUp.Click += new System.EventHandler(this.cntMenuGroupsMoveUp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportM3U);
            this.groupBox2.Controls.Add(this.btnNephGuide);
            this.groupBox2.Controls.Add(this.btnImportfromUserboquet);
            this.groupBox2.Controls.Add(this.btnImportFromLamedb);
            this.groupBox2.Controls.Add(this.btnExportToMediaPortal);
            this.groupBox2.Controls.Add(this.btnImportFromDreamBox);
            this.groupBox2.Controls.Add(this.btnClearAllTV);
            this.groupBox2.Controls.Add(this.btnImportFromMediaportal);
            this.groupBox2.Location = new System.Drawing.Point(281, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 149);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // btnNephGuide
            // 
            this.btnNephGuide.Location = new System.Drawing.Point(6, 102);
            this.btnNephGuide.Name = "btnNephGuide";
            this.btnNephGuide.Size = new System.Drawing.Size(184, 23);
            this.btnNephGuide.TabIndex = 13;
            this.btnNephGuide.Text = "Import from Neph Guide";
            this.btnNephGuide.UseVisualStyleBackColor = true;
            this.btnNephGuide.Click += new System.EventHandler(this.btnNephGuide_Click);
            // 
            // btnImportfromUserboquet
            // 
            this.btnImportfromUserboquet.Location = new System.Drawing.Point(6, 76);
            this.btnImportfromUserboquet.Name = "btnImportfromUserboquet";
            this.btnImportfromUserboquet.Size = new System.Drawing.Size(184, 23);
            this.btnImportfromUserboquet.TabIndex = 12;
            this.btnImportfromUserboquet.Text = "Import one userboquet.tv";
            this.btnImportfromUserboquet.UseVisualStyleBackColor = true;
            this.btnImportfromUserboquet.Click += new System.EventHandler(this.btnImportfromUserboquet_Click);
            // 
            // btnImportFromLamedb
            // 
            this.btnImportFromLamedb.Location = new System.Drawing.Point(6, 48);
            this.btnImportFromLamedb.Name = "btnImportFromLamedb";
            this.btnImportFromLamedb.Size = new System.Drawing.Size(184, 23);
            this.btnImportFromLamedb.TabIndex = 11;
            this.btnImportFromLamedb.Text = "Import only channels from lamedb";
            this.btnImportFromLamedb.UseVisualStyleBackColor = true;
            this.btnImportFromLamedb.Click += new System.EventHandler(this.btnImportFromLamedb_Click);
            // 
            // btnExportToMediaPortal
            // 
            this.btnExportToMediaPortal.Location = new System.Drawing.Point(229, 80);
            this.btnExportToMediaPortal.Name = "btnExportToMediaPortal";
            this.btnExportToMediaPortal.Size = new System.Drawing.Size(146, 23);
            this.btnExportToMediaPortal.TabIndex = 10;
            this.btnExportToMediaPortal.Text = "Export to MediaPortal DB";
            this.btnExportToMediaPortal.UseVisualStyleBackColor = true;
            this.btnExportToMediaPortal.Click += new System.EventHandler(this.btnExportToMediaPortal_Click);
            // 
            // btnImportFromDreamBox
            // 
            this.btnImportFromDreamBox.Location = new System.Drawing.Point(6, 19);
            this.btnImportFromDreamBox.Name = "btnImportFromDreamBox";
            this.btnImportFromDreamBox.Size = new System.Drawing.Size(184, 23);
            this.btnImportFromDreamBox.TabIndex = 8;
            this.btnImportFromDreamBox.Text = "Import all from Dreambox";
            this.btnImportFromDreamBox.UseVisualStyleBackColor = true;
            this.btnImportFromDreamBox.Click += new System.EventHandler(this.btnImportFromDreamBox_Click);
            // 
            // btnClearAllTV
            // 
            this.btnClearAllTV.Location = new System.Drawing.Point(229, 19);
            this.btnClearAllTV.Name = "btnClearAllTV";
            this.btnClearAllTV.Size = new System.Drawing.Size(146, 23);
            this.btnClearAllTV.TabIndex = 9;
            this.btnClearAllTV.Text = "Clear All";
            this.btnClearAllTV.UseVisualStyleBackColor = true;
            this.btnClearAllTV.Click += new System.EventHandler(this.btnClearAllTV_Click);
            // 
            // btnImportFromMediaportal
            // 
            this.btnImportFromMediaportal.Location = new System.Drawing.Point(229, 51);
            this.btnImportFromMediaportal.Name = "btnImportFromMediaportal";
            this.btnImportFromMediaportal.Size = new System.Drawing.Size(146, 23);
            this.btnImportFromMediaportal.TabIndex = 7;
            this.btnImportFromMediaportal.Text = "Import from Mediaportal DB";
            this.btnImportFromMediaportal.UseVisualStyleBackColor = true;
            this.btnImportFromMediaportal.Visible = false;
            this.btnImportFromMediaportal.Click += new System.EventHandler(this.btnImportFromMediaportal_Click);
            // 
            // grpChannels
            // 
            this.grpChannels.Controls.Add(this.btnChDown);
            this.grpChannels.Controls.Add(this.lstChannels);
            this.grpChannels.Controls.Add(this.btnChUp);
            this.grpChannels.Location = new System.Drawing.Point(281, 6);
            this.grpChannels.Name = "grpChannels";
            this.grpChannels.Size = new System.Drawing.Size(381, 340);
            this.grpChannels.TabIndex = 1;
            this.grpChannels.TabStop = false;
            this.grpChannels.Text = "Channels";
            // 
            // btnChDown
            // 
            this.btnChDown.Image = global::MPTVSettingsAdmin.Properties.Resources.icon_down;
            this.btnChDown.Location = new System.Drawing.Point(341, 222);
            this.btnChDown.Name = "btnChDown";
            this.btnChDown.Size = new System.Drawing.Size(34, 34);
            this.btnChDown.TabIndex = 5;
            this.btnChDown.UseVisualStyleBackColor = true;
            this.btnChDown.Click += new System.EventHandler(this.cntMenuChannelsMoveDown_Click);
            // 
            // lstChannels
            // 
            this.lstChannels.ContextMenuStrip = this.cntMenuChannels;
            this.lstChannels.DataSource = this.channelBindingSource;
            this.lstChannels.DisplayMember = "Name";
            this.lstChannels.FormattingEnabled = true;
            this.lstChannels.Location = new System.Drawing.Point(6, 19);
            this.lstChannels.Name = "lstChannels";
            this.lstChannels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstChannels.Size = new System.Drawing.Size(329, 303);
            this.lstChannels.TabIndex = 0;
            this.lstChannels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstChannels_KeyDown);
            // 
            // cntMenuChannels
            // 
            this.cntMenuChannels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntMenuChannelsMoveUp,
            this.cntMenuChannelsMoveDown,
            this.cntMenuChannelsDelete});
            this.cntMenuChannels.Name = "cntMenuChannels";
            this.cntMenuChannels.Size = new System.Drawing.Size(139, 70);
            // 
            // cntMenuChannelsMoveUp
            // 
            this.cntMenuChannelsMoveUp.Name = "cntMenuChannelsMoveUp";
            this.cntMenuChannelsMoveUp.Size = new System.Drawing.Size(138, 22);
            this.cntMenuChannelsMoveUp.Text = "Move Up";
            this.cntMenuChannelsMoveUp.Click += new System.EventHandler(this.cntMenuChannelsMoveUp_Click);
            // 
            // cntMenuChannelsMoveDown
            // 
            this.cntMenuChannelsMoveDown.Name = "cntMenuChannelsMoveDown";
            this.cntMenuChannelsMoveDown.Size = new System.Drawing.Size(138, 22);
            this.cntMenuChannelsMoveDown.Text = "Move Down";
            this.cntMenuChannelsMoveDown.Click += new System.EventHandler(this.cntMenuChannelsMoveDown_Click);
            // 
            // cntMenuChannelsDelete
            // 
            this.cntMenuChannelsDelete.Name = "cntMenuChannelsDelete";
            this.cntMenuChannelsDelete.Size = new System.Drawing.Size(138, 22);
            this.cntMenuChannelsDelete.Text = "Delete";
            this.cntMenuChannelsDelete.Click += new System.EventHandler(this.cntMenuChannelsDelete_Click);
            // 
            // channelBindingSource
            // 
            this.channelBindingSource.DataSource = typeof(MPTVSettingsAdmin.Classes.Channel);
            // 
            // btnChUp
            // 
            this.btnChUp.Image = global::MPTVSettingsAdmin.Properties.Resources.icon_up;
            this.btnChUp.Location = new System.Drawing.Point(341, 182);
            this.btnChUp.Name = "btnChUp";
            this.btnChUp.Size = new System.Drawing.Size(34, 34);
            this.btnChUp.TabIndex = 4;
            this.btnChUp.UseVisualStyleBackColor = true;
            this.btnChUp.Click += new System.EventHandler(this.cntMenuChannelsMoveUp_Click);
            // 
            // grpGroups
            // 
            this.grpGroups.Controls.Add(this.txtGroupName);
            this.grpGroups.Controls.Add(this.lstGroups);
            this.grpGroups.Location = new System.Drawing.Point(6, 6);
            this.grpGroups.Name = "grpGroups";
            this.grpGroups.Size = new System.Drawing.Size(207, 455);
            this.grpGroups.TabIndex = 0;
            this.grpGroups.TabStop = false;
            this.grpGroups.Text = "Groups / Bouquets";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(7, 20);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(194, 20);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // lstGroups
            // 
            this.lstGroups.ContextMenuStrip = this.cntMenuGroups;
            this.lstGroups.DataSource = this.groupBindingSource;
            this.lstGroups.DisplayMember = "NameAndCount";
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.Location = new System.Drawing.Point(6, 45);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstGroups.Size = new System.Drawing.Size(195, 394);
            this.lstGroups.TabIndex = 0;
            this.lstGroups.SelectedIndexChanged += new System.EventHandler(this.lstGroups_SelectedIndexChanged);
            this.lstGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstGroups_KeyDown);
            // 
            // cntMenuGroups
            // 
            this.cntMenuGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntMenuGroupsMoveUp,
            this.cntMenuGroupsMoveDown,
            this.cntMenuGroupsAdd,
            this.cntMenuGroupDelete});
            this.cntMenuGroups.Name = "cntMenuGroups";
            this.cntMenuGroups.Size = new System.Drawing.Size(144, 92);
            // 
            // cntMenuGroupsMoveUp
            // 
            this.cntMenuGroupsMoveUp.Name = "cntMenuGroupsMoveUp";
            this.cntMenuGroupsMoveUp.Size = new System.Drawing.Size(143, 22);
            this.cntMenuGroupsMoveUp.Text = "Move Up";
            this.cntMenuGroupsMoveUp.Click += new System.EventHandler(this.cntMenuGroupsMoveUp_Click);
            // 
            // cntMenuGroupsMoveDown
            // 
            this.cntMenuGroupsMoveDown.Name = "cntMenuGroupsMoveDown";
            this.cntMenuGroupsMoveDown.Size = new System.Drawing.Size(143, 22);
            this.cntMenuGroupsMoveDown.Text = "Move Down";
            this.cntMenuGroupsMoveDown.Click += new System.EventHandler(this.cntMenuGroupsMoveDown_Click);
            // 
            // cntMenuGroupsAdd
            // 
            this.cntMenuGroupsAdd.Name = "cntMenuGroupsAdd";
            this.cntMenuGroupsAdd.Size = new System.Drawing.Size(143, 22);
            this.cntMenuGroupsAdd.Text = "Add Group";
            this.cntMenuGroupsAdd.Click += new System.EventHandler(this.cntMenuGroupsAdd_Click);
            // 
            // cntMenuGroupDelete
            // 
            this.cntMenuGroupDelete.Name = "cntMenuGroupDelete";
            this.cntMenuGroupDelete.Size = new System.Drawing.Size(143, 22);
            this.cntMenuGroupDelete.Text = "Delete Group";
            this.cntMenuGroupDelete.Click += new System.EventHandler(this.cntMenuGroupDelete_Click);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(MPTVSettingsAdmin.Classes.Channel);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.grpExportSettings);
            this.tabSettings.Controls.Add(this.grpImportSettings);
            this.tabSettings.Controls.Add(this.grpDBSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(696, 507);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbWorking);
            this.groupBox1.Location = new System.Drawing.Point(280, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Working with:";
            this.groupBox1.Visible = false;
            // 
            // cmbWorking
            // 
            this.cmbWorking.AutoCompleteCustomSource.AddRange(new string[] {
            "TV",
            "Radio"});
            this.cmbWorking.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbWorking.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWorking.Items.AddRange(new object[] {
            "TV",
            "Radio"});
            this.cmbWorking.Location = new System.Drawing.Point(6, 16);
            this.cmbWorking.Name = "cmbWorking";
            this.cmbWorking.Size = new System.Drawing.Size(268, 21);
            this.cmbWorking.TabIndex = 5;
            this.cmbWorking.Text = "TV";
            this.cmbWorking.SelectedIndexChanged += new System.EventHandler(this.cmbWorking_SelectedIndexChanged);
            // 
            // grpExportSettings
            // 
            this.grpExportSettings.Controls.Add(this.chkDeleteExistingGroups);
            this.grpExportSettings.Location = new System.Drawing.Point(6, 230);
            this.grpExportSettings.Name = "grpExportSettings";
            this.grpExportSettings.Size = new System.Drawing.Size(267, 46);
            this.grpExportSettings.TabIndex = 3;
            this.grpExportSettings.TabStop = false;
            this.grpExportSettings.Text = "Export settings:";
            this.grpExportSettings.Visible = false;
            // 
            // chkDeleteExistingGroups
            // 
            this.chkDeleteExistingGroups.AutoSize = true;
            this.chkDeleteExistingGroups.Location = new System.Drawing.Point(9, 20);
            this.chkDeleteExistingGroups.Name = "chkDeleteExistingGroups";
            this.chkDeleteExistingGroups.Size = new System.Drawing.Size(191, 17);
            this.chkDeleteExistingGroups.TabIndex = 0;
            this.chkDeleteExistingGroups.Text = "Delete exisiting MediaPortal groups";
            this.chkDeleteExistingGroups.UseVisualStyleBackColor = true;
            // 
            // grpImportSettings
            // 
            this.grpImportSettings.Controls.Add(this.chkDeleteEmptyGroups);
            this.grpImportSettings.Controls.Add(this.chkDeleteEmptyNames);
            this.grpImportSettings.Controls.Add(this.chkDeleteUnknown);
            this.grpImportSettings.Location = new System.Drawing.Point(6, 138);
            this.grpImportSettings.Name = "grpImportSettings";
            this.grpImportSettings.Size = new System.Drawing.Size(267, 86);
            this.grpImportSettings.TabIndex = 2;
            this.grpImportSettings.TabStop = false;
            this.grpImportSettings.Text = "Import settings:";
            // 
            // chkDeleteEmptyGroups
            // 
            this.chkDeleteEmptyGroups.AutoSize = true;
            this.chkDeleteEmptyGroups.Checked = true;
            this.chkDeleteEmptyGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteEmptyGroups.Location = new System.Drawing.Point(11, 63);
            this.chkDeleteEmptyGroups.Name = "chkDeleteEmptyGroups";
            this.chkDeleteEmptyGroups.Size = new System.Drawing.Size(186, 17);
            this.chkDeleteEmptyGroups.TabIndex = 2;
            this.chkDeleteEmptyGroups.Text = "Automatically delete empty groups";
            this.chkDeleteEmptyGroups.UseVisualStyleBackColor = true;
            // 
            // chkDeleteEmptyNames
            // 
            this.chkDeleteEmptyNames.AutoSize = true;
            this.chkDeleteEmptyNames.Checked = true;
            this.chkDeleteEmptyNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteEmptyNames.Location = new System.Drawing.Point(11, 40);
            this.chkDeleteEmptyNames.Name = "chkDeleteEmptyNames";
            this.chkDeleteEmptyNames.Size = new System.Drawing.Size(260, 17);
            this.chkDeleteEmptyNames.TabIndex = 1;
            this.chkDeleteEmptyNames.Text = "Automatically delete empty or non-names i.e. \"(1)\"";
            this.chkDeleteEmptyNames.UseVisualStyleBackColor = true;
            // 
            // chkDeleteUnknown
            // 
            this.chkDeleteUnknown.AutoSize = true;
            this.chkDeleteUnknown.Checked = true;
            this.chkDeleteUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteUnknown.Location = new System.Drawing.Point(11, 20);
            this.chkDeleteUnknown.Name = "chkDeleteUnknown";
            this.chkDeleteUnknown.Size = new System.Drawing.Size(172, 17);
            this.chkDeleteUnknown.TabIndex = 0;
            this.chkDeleteUnknown.Text = "Automatically delete unknowns";
            this.chkDeleteUnknown.UseVisualStyleBackColor = true;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "dlgOpenFile";
            // 
            // btnImportM3U
            // 
            this.btnImportM3U.Location = new System.Drawing.Point(6, 126);
            this.btnImportM3U.Name = "btnImportM3U";
            this.btnImportM3U.Size = new System.Drawing.Size(184, 23);
            this.btnImportM3U.TabIndex = 14;
            this.btnImportM3U.Text = "Import from M3U file";
            this.btnImportM3U.UseVisualStyleBackColor = true;
            this.btnImportM3U.Click += new System.EventHandler(this.btnImportM3U_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 557);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grdMPAllChannels);
            this.Name = "frmMain";
            this.Text = "MPTVSettingsAdmin";
            this.grpDBSettings.ResumeLayout(false);
            this.grpDBSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMPAllChannels)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabTVRadio.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpChannels.ResumeLayout(false);
            this.cntMenuChannels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channelBindingSource)).EndInit();
            this.grpGroups.ResumeLayout(false);
            this.grpGroups.PerformLayout();
            this.cntMenuGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpExportSettings.ResumeLayout(false);
            this.grpExportSettings.PerformLayout();
            this.grpImportSettings.ResumeLayout(false);
            this.grpImportSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDBSettings;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.Label lblDBUserName;
        private System.Windows.Forms.DataGridView grdMPAllChannels;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblKeyWord;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTVRadio;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox grpGroups;
        private System.Windows.Forms.GroupBox grpChannels;
        private System.Windows.Forms.RadioButton radProvider;
        private System.Windows.Forms.RadioButton radName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportToMediaPortal;
        private System.Windows.Forms.Button btnImportFromDreamBox;
        private System.Windows.Forms.Button btnClearAllTV;
        private System.Windows.Forms.Button btnImportFromMediaportal;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.BindingSource channelBindingSource;
        private System.Windows.Forms.ListBox lstChannels;
        private System.Windows.Forms.GroupBox grpImportSettings;
        private System.Windows.Forms.CheckBox chkDeleteEmptyNames;
        private System.Windows.Forms.CheckBox chkDeleteUnknown;
        private System.Windows.Forms.CheckBox chkDeleteEmptyGroups;
        private System.Windows.Forms.ContextMenuStrip cntMenuGroups;
        private System.Windows.Forms.ToolStripMenuItem cntMenuGroupsAdd;
        private System.Windows.Forms.ToolStripMenuItem cntMenuGroupDelete;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.ToolStripMenuItem cntMenuGroupsMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cntMenuGroupsMoveDown;
        private System.Windows.Forms.ContextMenuStrip cntMenuChannels;
        private System.Windows.Forms.ToolStripMenuItem cntMenuChannelsMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cntMenuChannelsMoveDown;
        private System.Windows.Forms.ToolStripMenuItem cntMenuChannelsDelete;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.GroupBox grpExportSettings;
        private System.Windows.Forms.CheckBox chkDeleteExistingGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbWorking;
        private System.Windows.Forms.Button btnChDown;
        private System.Windows.Forms.Button btnChUp;
        private System.Windows.Forms.Button btnGrpDown;
        private System.Windows.Forms.Button btnGrpUp;
        private System.Windows.Forms.Button btnImportFromLamedb;
        private System.Windows.Forms.Button btnImportfromUserboquet;
        private System.Windows.Forms.Button btnNephGuide;
        private System.Windows.Forms.Button btnImportM3U;
    }
}

