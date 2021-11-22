
namespace RSI_X_Desktop
{
    partial class LangSelectDlg
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
            ReaLTaiizor.ControlRenderer controlRenderer1 = new ReaLTaiizor.ControlRenderer();
            ReaLTaiizor.MSColorTable msColorTable1 = new ReaLTaiizor.MSColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LangSelectDlg));
            this._ = new ReaLTaiizor.Forms.FormTheme();
            this.controlBox1 = new ReaLTaiizor.Controls.ControlBox();
            this.MidPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ConfigLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RadioBtnsTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckBoxCam = new ReaLTaiizor.Controls.FoxCheckBoxEdit();
            this.CheckBoxName = new ReaLTaiizor.Controls.FoxCheckBoxEdit();
            this.CheckBoxMic = new ReaLTaiizor.Controls.FoxCheckBoxEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
            this.comboBoxInterpreterRoom = new ReaLTaiizor.Controls.DungeonComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.textBoxNickName = new ReaLTaiizor.Controls.DungeonTextBox();
            this.tableRelayButtons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelSrc = new ReaLTaiizor.Controls.BigLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRelayButtons = new System.Windows.Forms.Panel();
            this.tableTargetButtons = new System.Windows.Forms.TableLayoutPanel();
            this.LabelTrg = new ReaLTaiizor.Controls.BigLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTargetButtons = new System.Windows.Forms.Panel();
            this.CloseAppButton = new ReaLTaiizor.Controls.SpaceButton();
            this.HideButton = new ReaLTaiizor.Controls.SpaceButton();
            this.BottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOk = new ReaLTaiizor.Controls.Button();
            this.separator3 = new ReaLTaiizor.Controls.Separator();
            this.buttonSettings = new ReaLTaiizor.Controls.Button();
            this.VersionLabel = new ReaLTaiizor.Controls.MoonLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelControlButtons = new System.Windows.Forms.Panel();
            this.panelMicCameraSetting = new System.Windows.Forms.Panel();
            this.materialCheckboxCameraSet = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckboxMicSet = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialCheckboxName = new MaterialSkin.Controls.MaterialCheckbox();
            this.formContextMenuStrip1 = new ReaLTaiizor.Controls.FormContextMenuStrip();
            this._.SuspendLayout();
            this.MidPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ConfigLayout.SuspendLayout();
            this.RadioBtnsTable.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableRelayButtons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableTargetButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelMicCameraSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // _
            // 
            this._.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this._.Controls.Add(this.controlBox1);
            this._.Controls.Add(this.MidPanel);
            this._.Controls.Add(this.CloseAppButton);
            this._.Controls.Add(this.HideButton);
            this._.Controls.Add(this.BottomPanel);
            this._.Dock = System.Windows.Forms.DockStyle.Fill;
            this._.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this._.Location = new System.Drawing.Point(0, 0);
            this._.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._.Name = "_";
            this._.Padding = new System.Windows.Forms.Padding(5, 43, 5, 43);
            this._.Sizable = false;
            this._.Size = new System.Drawing.Size(914, 563);
            this._.SmartBounds = false;
            this._.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this._.TabIndex = 0;
            this._.Text = "Conference configuration";
            // 
            // controlBox1
            // 
            this.controlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.controlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.controlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlBox1.DefaultLocation = false;
            this.controlBox1.EnableHoverHighlight = true;
            this.controlBox1.EnableMaximizeButton = false;
            this.controlBox1.EnableMinimizeButton = true;
            this.controlBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.controlBox1.Location = new System.Drawing.Point(824, 0);
            this.controlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.controlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.controlBox1.Name = "controlBox1";
            this.controlBox1.Size = new System.Drawing.Size(90, 25);
            this.controlBox1.TabIndex = 91;
            this.controlBox1.Text = "controlBox1";
            // 
            // MidPanel
            // 
            this.MidPanel.ColumnCount = 3;
            this.MidPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.MidPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MidPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.MidPanel.Controls.Add(this.panel3, 1, 2);
            this.MidPanel.Controls.Add(this.tableRelayButtons, 1, 0);
            this.MidPanel.Controls.Add(this.tableTargetButtons, 1, 1);
            this.MidPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MidPanel.Location = new System.Drawing.Point(5, 43);
            this.MidPanel.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MidPanel.Name = "MidPanel";
            this.MidPanel.RowCount = 3;
            this.MidPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.MidPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.MidPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MidPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MidPanel.Size = new System.Drawing.Size(904, 416);
            this.MidPanel.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.Controls.Add(this.ConfigLayout);
            this.panel3.Location = new System.Drawing.Point(208, 188);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 224);
            this.panel3.TabIndex = 1;
            // 
            // ConfigLayout
            // 
            this.ConfigLayout.ColumnCount = 1;
            this.ConfigLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfigLayout.Controls.Add(this.RadioBtnsTable, 0, 1);
            this.ConfigLayout.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.ConfigLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigLayout.Location = new System.Drawing.Point(0, 0);
            this.ConfigLayout.Name = "ConfigLayout";
            this.ConfigLayout.RowCount = 2;
            this.ConfigLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.83367F));
            this.ConfigLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.16633F));
            this.ConfigLayout.Size = new System.Drawing.Size(488, 224);
            this.ConfigLayout.TabIndex = 0;
            // 
            // RadioBtnsTable
            // 
            this.RadioBtnsTable.ColumnCount = 1;
            this.RadioBtnsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RadioBtnsTable.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.RadioBtnsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioBtnsTable.Location = new System.Drawing.Point(3, 96);
            this.RadioBtnsTable.Name = "RadioBtnsTable";
            this.RadioBtnsTable.RowCount = 3;
            this.RadioBtnsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioBtnsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioBtnsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioBtnsTable.Size = new System.Drawing.Size(482, 125);
            this.RadioBtnsTable.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.91603F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.16794F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.91603F));
            this.tableLayoutPanel6.Controls.Add(this.CheckBoxCam, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.CheckBoxName, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.CheckBoxMic, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(476, 35);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // CheckBoxCam
            // 
            this.CheckBoxCam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CheckBoxCam.Checked = true;
            this.CheckBoxCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxCam.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CheckBoxCam.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.CheckBoxCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxCam.EnabledCalc = true;
            this.CheckBoxCam.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxCam.ForeColor = System.Drawing.Color.White;
            this.CheckBoxCam.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.CheckBoxCam.Location = new System.Drawing.Point(333, 4);
            this.CheckBoxCam.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CheckBoxCam.Name = "CheckBoxCam";
            this.CheckBoxCam.Size = new System.Drawing.Size(138, 27);
            this.CheckBoxCam.TabIndex = 13;
            this.CheckBoxCam.Text = "Enable camera";
            // 
            // CheckBoxName
            // 
            this.CheckBoxName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CheckBoxName.Checked = false;
            this.CheckBoxName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxName.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CheckBoxName.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.CheckBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxName.EnabledCalc = true;
            this.CheckBoxName.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxName.ForeColor = System.Drawing.Color.White;
            this.CheckBoxName.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.CheckBoxName.Location = new System.Drawing.Point(5, 4);
            this.CheckBoxName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CheckBoxName.Name = "CheckBoxName";
            this.CheckBoxName.Size = new System.Drawing.Size(137, 27);
            this.CheckBoxName.TabIndex = 11;
            this.CheckBoxName.Text = "Remember me";
            // 
            // CheckBoxMic
            // 
            this.CheckBoxMic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CheckBoxMic.Checked = true;
            this.CheckBoxMic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxMic.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CheckBoxMic.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.CheckBoxMic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxMic.EnabledCalc = true;
            this.CheckBoxMic.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxMic.ForeColor = System.Drawing.Color.White;
            this.CheckBoxMic.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.CheckBoxMic.Location = new System.Drawing.Point(152, 4);
            this.CheckBoxMic.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CheckBoxMic.Name = "CheckBoxMic";
            this.CheckBoxMic.Size = new System.Drawing.Size(171, 27);
            this.CheckBoxMic.TabIndex = 12;
            this.CheckBoxMic.Text = "Enable microphone";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(482, 87);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.foxLabel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxInterpreterRoom, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(244, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(235, 81);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // foxLabel3
            // 
            this.foxLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.foxLabel3.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel3.ForeColor = System.Drawing.Color.White;
            this.foxLabel3.Location = new System.Drawing.Point(35, 4);
            this.foxLabel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.foxLabel3.Name = "foxLabel3";
            this.foxLabel3.Size = new System.Drawing.Size(164, 32);
            this.foxLabel3.TabIndex = 7;
            this.foxLabel3.Text = "Select your booth";
            // 
            // comboBoxInterpreterRoom
            // 
            this.comboBoxInterpreterRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboBoxInterpreterRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboBoxInterpreterRoom.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.comboBoxInterpreterRoom.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.comboBoxInterpreterRoom.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.comboBoxInterpreterRoom.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.comboBoxInterpreterRoom.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.comboBoxInterpreterRoom.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.comboBoxInterpreterRoom.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.comboBoxInterpreterRoom.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.comboBoxInterpreterRoom.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.comboBoxInterpreterRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxInterpreterRoom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxInterpreterRoom.DropDownHeight = 100;
            this.comboBoxInterpreterRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterpreterRoom.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBoxInterpreterRoom.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxInterpreterRoom.FormattingEnabled = true;
            this.comboBoxInterpreterRoom.HoverSelectionColor = System.Drawing.Color.Empty;
            this.comboBoxInterpreterRoom.IntegralHeight = false;
            this.comboBoxInterpreterRoom.ItemHeight = 20;
            this.comboBoxInterpreterRoom.Location = new System.Drawing.Point(47, 48);
            this.comboBoxInterpreterRoom.Margin = new System.Windows.Forms.Padding(5, 8, 5, 4);
            this.comboBoxInterpreterRoom.MaxDropDownItems = 16;
            this.comboBoxInterpreterRoom.Name = "comboBoxInterpreterRoom";
            this.comboBoxInterpreterRoom.Size = new System.Drawing.Size(140, 26);
            this.comboBoxInterpreterRoom.StartIndex = 0;
            this.comboBoxInterpreterRoom.TabIndex = 10;
            this.comboBoxInterpreterRoom.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterpreterRoom_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.foxLabel1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxNickName, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(235, 81);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // foxLabel1
            // 
            this.foxLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.foxLabel1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel1.ForeColor = System.Drawing.Color.White;
            this.foxLabel1.Location = new System.Drawing.Point(38, 4);
            this.foxLabel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(159, 32);
            this.foxLabel1.TabIndex = 8;
            this.foxLabel1.Text = "Enter your name";
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.BackColor = System.Drawing.Color.Transparent;
            this.textBoxNickName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxNickName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNickName.EdgeColor = System.Drawing.Color.White;
            this.textBoxNickName.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxNickName.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNickName.Location = new System.Drawing.Point(3, 43);
            this.textBoxNickName.MaxLength = 16;
            this.textBoxNickName.Multiline = false;
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.ReadOnly = false;
            this.textBoxNickName.Size = new System.Drawing.Size(229, 36);
            this.textBoxNickName.TabIndex = 0;
            this.textBoxNickName.Text = "Your name";
            this.textBoxNickName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNickName.UseSystemPasswordChar = false;
            this.textBoxNickName.Enter += new System.EventHandler(this.textBoxNickName_Enter);
            this.textBoxNickName.Leave += new System.EventHandler(this.textBoxNickName_Leave);
            // 
            // tableRelayButtons
            // 
            this.tableRelayButtons.ColumnCount = 1;
            this.tableRelayButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRelayButtons.Controls.Add(this.LabelSrc, 0, 0);
            this.tableRelayButtons.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableRelayButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRelayButtons.Location = new System.Drawing.Point(29, 3);
            this.tableRelayButtons.Name = "tableRelayButtons";
            this.tableRelayButtons.RowCount = 2;
            this.tableRelayButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.65031F));
            this.tableRelayButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.34969F));
            this.tableRelayButtons.Size = new System.Drawing.Size(846, 86);
            this.tableRelayButtons.TabIndex = 2;
            // 
            // LabelSrc
            // 
            this.LabelSrc.BackColor = System.Drawing.Color.Transparent;
            this.LabelSrc.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelSrc.ForeColor = System.Drawing.Color.White;
            this.LabelSrc.Location = new System.Drawing.Point(5, 0);
            this.LabelSrc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LabelSrc.Name = "LabelSrc";
            this.LabelSrc.Size = new System.Drawing.Size(836, 33);
            this.LabelSrc.TabIndex = 11;
            this.LabelSrc.Text = "Incoming channels";
            this.LabelSrc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panelRelayButtons, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 47);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // panelRelayButtons
            // 
            this.panelRelayButtons.AutoSize = true;
            this.panelRelayButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRelayButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRelayButtons.Location = new System.Drawing.Point(420, 3);
            this.panelRelayButtons.Name = "panelRelayButtons";
            this.panelRelayButtons.Size = new System.Drawing.Size(1, 41);
            this.panelRelayButtons.TabIndex = 0;
            // 
            // tableTargetButtons
            // 
            this.tableTargetButtons.ColumnCount = 1;
            this.tableTargetButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTargetButtons.Controls.Add(this.LabelTrg, 0, 0);
            this.tableTargetButtons.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableTargetButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTargetButtons.Location = new System.Drawing.Point(29, 95);
            this.tableTargetButtons.Name = "tableTargetButtons";
            this.tableTargetButtons.RowCount = 2;
            this.tableTargetButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.30197F));
            this.tableTargetButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.69802F));
            this.tableTargetButtons.Size = new System.Drawing.Size(846, 86);
            this.tableTargetButtons.TabIndex = 3;
            // 
            // LabelTrg
            // 
            this.LabelTrg.BackColor = System.Drawing.Color.Transparent;
            this.LabelTrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTrg.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTrg.ForeColor = System.Drawing.Color.White;
            this.LabelTrg.Location = new System.Drawing.Point(5, 0);
            this.LabelTrg.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LabelTrg.Name = "LabelTrg";
            this.LabelTrg.Size = new System.Drawing.Size(836, 33);
            this.LabelTrg.TabIndex = 10;
            this.LabelTrg.Text = "Outgoing channels";
            this.LabelTrg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelTargetButtons, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 47);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panelTargetButtons
            // 
            this.panelTargetButtons.AutoSize = true;
            this.panelTargetButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTargetButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTargetButtons.Location = new System.Drawing.Point(420, 3);
            this.panelTargetButtons.Name = "panelTargetButtons";
            this.panelTargetButtons.Size = new System.Drawing.Size(1, 41);
            this.panelTargetButtons.TabIndex = 0;
            // 
            // CloseAppButton
            // 
            this.CloseAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseAppButton.Customization = "Kioq/zIyMv8yMjL/Kioq/y8vL/8nJyf//v7+/yMjI/8qKir/";
            this.CloseAppButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseAppButton.Image = null;
            this.CloseAppButton.Location = new System.Drawing.Point(1663, 0);
            this.CloseAppButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CloseAppButton.Name = "CloseAppButton";
            this.CloseAppButton.NoRounding = false;
            this.CloseAppButton.Size = new System.Drawing.Size(35, 31);
            this.CloseAppButton.TabIndex = 90;
            this.CloseAppButton.Text = "X";
            this.CloseAppButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.CloseAppButton.Transparent = false;
            this.CloseAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
            // 
            // HideButton
            // 
            this.HideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HideButton.Customization = "Kioq/zIyMv8yMjL/Kioq/y8vL/8nJyf//v7+/yMjI/8qKir/";
            this.HideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HideButton.Image = null;
            this.HideButton.Location = new System.Drawing.Point(1618, 0);
            this.HideButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.HideButton.Name = "HideButton";
            this.HideButton.NoRounding = false;
            this.HideButton.Size = new System.Drawing.Size(35, 31);
            this.HideButton.TabIndex = 89;
            this.HideButton.Text = "-";
            this.HideButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.HideButton.Transparent = false;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.ColumnCount = 5;
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.BottomPanel.Controls.Add(this.panel1, 2, 0);
            this.BottomPanel.Controls.Add(this.VersionLabel, 1, 0);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(5, 463);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.RowCount = 1;
            this.BottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomPanel.Size = new System.Drawing.Size(904, 57);
            this.BottomPanel.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.separator3);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(297, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 49);
            this.panel1.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackColor = System.Drawing.Color.Transparent;
            this.buttonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOk.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.buttonOk.Font = new System.Drawing.Font("Bahnschrift Condensed", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOk.Image = null;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.buttonOk.Location = new System.Drawing.Point(179, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonOk.MaximumSize = new System.Drawing.Size(97, 0);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.buttonOk.Size = new System.Drawing.Size(97, 49);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Continue";
            this.buttonOk.TextAlignment = System.Drawing.StringAlignment.Center;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // separator3
            // 
            this.separator3.Dock = System.Windows.Forms.DockStyle.Right;
            this.separator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.separator3.Location = new System.Drawing.Point(302, 0);
            this.separator3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(8, 49);
            this.separator3.TabIndex = 6;
            this.separator3.Text = "separator3";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSettings.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.buttonSettings.Font = new System.Drawing.Font("Bahnschrift Condensed", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSettings.Image = null;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.buttonSettings.Location = new System.Drawing.Point(49, 0);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.buttonSettings.Size = new System.Drawing.Size(100, 49);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlignment = System.Drawing.StringAlignment.Center;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersionLabel.ForeColor = System.Drawing.Color.Gray;
            this.VersionLabel.Location = new System.Drawing.Point(31, 40);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(142, 17);
            this.VersionLabel.TabIndex = 95;
            this.VersionLabel.Text = "RSI X Software (NET.CORE 5.0)";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.241758F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.75824F));
            this.tableLayoutPanelMain.Controls.Add(this.panelControlButtons, 1, 5);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 6;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelControlButtons
            // 
            this.panelControlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControlButtons.Location = new System.Drawing.Point(19, 103);
            this.panelControlButtons.Name = "panelControlButtons";
            this.panelControlButtons.Size = new System.Drawing.Size(178, 14);
            this.panelControlButtons.TabIndex = 3;
            // 
            // panelMicCameraSetting
            // 
            this.panelMicCameraSetting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMicCameraSetting.Controls.Add(this.materialCheckboxCameraSet);
            this.panelMicCameraSetting.Controls.Add(this.materialCheckboxMicSet);
            this.panelMicCameraSetting.Controls.Add(this.materialCheckboxName);
            this.panelMicCameraSetting.Location = new System.Drawing.Point(19, 3);
            this.panelMicCameraSetting.Name = "panelMicCameraSetting";
            this.panelMicCameraSetting.Size = new System.Drawing.Size(178, 153);
            this.panelMicCameraSetting.TabIndex = 4;
            // 
            // materialCheckboxCameraSet
            // 
            this.materialCheckboxCameraSet.AutoSize = true;
            this.materialCheckboxCameraSet.Checked = true;
            this.materialCheckboxCameraSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckboxCameraSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialCheckboxCameraSet.Depth = 0;
            this.materialCheckboxCameraSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCheckboxCameraSet.Location = new System.Drawing.Point(0, 74);
            this.materialCheckboxCameraSet.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckboxCameraSet.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckboxCameraSet.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckboxCameraSet.Name = "materialCheckboxCameraSet";
            this.materialCheckboxCameraSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialCheckboxCameraSet.Ripple = true;
            this.materialCheckboxCameraSet.Size = new System.Drawing.Size(178, 37);
            this.materialCheckboxCameraSet.TabIndex = 5;
            this.materialCheckboxCameraSet.Text = "���������� ������";
            this.materialCheckboxCameraSet.UseVisualStyleBackColor = true;
            // 
            // materialCheckboxMicSet
            // 
            this.materialCheckboxMicSet.AutoSize = true;
            this.materialCheckboxMicSet.Checked = true;
            this.materialCheckboxMicSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckboxMicSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialCheckboxMicSet.Depth = 0;
            this.materialCheckboxMicSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCheckboxMicSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.materialCheckboxMicSet.Location = new System.Drawing.Point(0, 37);
            this.materialCheckboxMicSet.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckboxMicSet.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckboxMicSet.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckboxMicSet.Name = "materialCheckboxMicSet";
            this.materialCheckboxMicSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialCheckboxMicSet.Ripple = true;
            this.materialCheckboxMicSet.Size = new System.Drawing.Size(178, 37);
            this.materialCheckboxMicSet.TabIndex = 4;
            this.materialCheckboxMicSet.Text = "���������� ��������";
            this.materialCheckboxMicSet.UseVisualStyleBackColor = true;
            // 
            // materialCheckboxName
            // 
            this.materialCheckboxName.AutoSize = true;
            this.materialCheckboxName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialCheckboxName.Depth = 0;
            this.materialCheckboxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCheckboxName.Location = new System.Drawing.Point(0, 0);
            this.materialCheckboxName.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckboxName.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckboxName.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckboxName.Name = "materialCheckboxName";
            this.materialCheckboxName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialCheckboxName.Ripple = true;
            this.materialCheckboxName.Size = new System.Drawing.Size(178, 37);
            this.materialCheckboxName.TabIndex = 3;
            this.materialCheckboxName.Text = "��������� ���";
            this.materialCheckboxName.UseVisualStyleBackColor = true;
            // 
            // formContextMenuStrip1
            // 
            this.formContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.formContextMenuStrip1.Name = "formContextMenuStrip1";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.formContextMenuStrip1.Renderer = controlRenderer1;
            this.formContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LangSelectDlg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(914, 563);
            this.Controls.Add(this._);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(126, 50);
            this.Name = "LangSelectDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conference configuration";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this._.ResumeLayout(false);
            this.MidPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ConfigLayout.ResumeLayout(false);
            this.RadioBtnsTable.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableRelayButtons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableTargetButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelMicCameraSetting.ResumeLayout(false);
            this.panelMicCameraSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.FormTheme _;
        private System.Windows.Forms.TableLayoutPanel MidPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelControlButtons;
        private System.Windows.Forms.Panel panelMicCameraSetting;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckboxCameraSet;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckboxMicSet;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckboxName;
        private ReaLTaiizor.Controls.FormContextMenuStrip formContextMenuStrip1;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.FoxLabel foxLabel3;
        private ReaLTaiizor.Controls.DungeonComboBox comboBoxInterpreterRoom;
        private ReaLTaiizor.Controls.FoxCheckBoxEdit CheckBoxCam;
        private ReaLTaiizor.Controls.FoxCheckBoxEdit CheckBoxMic;
        private ReaLTaiizor.Controls.FoxCheckBoxEdit CheckBoxName;
        private ReaLTaiizor.Controls.SpaceButton CloseAppButton;
        private ReaLTaiizor.Controls.SpaceButton HideButton;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.Button buttonOk;
        private ReaLTaiizor.Controls.BigLabel LabelTrg;
        private ReaLTaiizor.Controls.BigLabel LabelSrc;
        private ReaLTaiizor.Controls.Button buttonSettings;
        private System.Windows.Forms.TableLayoutPanel BottomPanel;
        private ReaLTaiizor.Controls.Separator separator3;
        private System.Windows.Forms.TableLayoutPanel tableRelayButtons;
        private System.Windows.Forms.TableLayoutPanel tableTargetButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTargetButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelRelayButtons;
        private System.Windows.Forms.TableLayoutPanel ConfigLayout;
        private System.Windows.Forms.TableLayoutPanel RadioBtnsTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.DungeonTextBox textBoxNickName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private ReaLTaiizor.Controls.ControlBox controlBox1;
        private ReaLTaiizor.Controls.MoonLabel VersionLabel;
    }
}