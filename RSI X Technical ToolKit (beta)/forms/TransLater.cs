using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using agorartc;
using System.Windows.Forms;
using RSI_X_Desktop.forms;
using System.Runtime.InteropServices;

namespace RSI_X_Desktop
{
    public partial class TransLater : Form, IFormHostHolder, IFormInterpreterHolder
    {
        private forms.HelpingClass.FireBaseReader GetFireBase = new();
        private NewDevices devices;
        private ChatWnd chat = new ChatWnd();

        private Region regWnd;
        private Size DefPanSize = new Size();
        private readonly Size DefSizeOnePanelButton = new(120, 35);

        private int m_intTar;
        private int m_intRel;
        private int m_intInterpr;

        private HashSet<int> m_intStreamLg = new HashSet<int>();
        public static bool IsAnyonePublishing = false;
        private string Publisher = "";
        //public int seconds=0;

        public IntPtr RemoteWnd { get; private set; }
        public IntPtr TranslWnd { get; private set; }

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume); //Контроль громкости

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume); //Контроль громкости

        private PictureBox intWnd_local = new();

        readonly Color ButtonPushColor = Color.BurlyWood;
        readonly Color ButtonStreamColor = Color.Red;

        List<_AGVIDEO_WNDINFO> agvideoWnd = new List<_AGVIDEO_WNDINFO>(); //8 as max for now

        private int CurrentPage = 0;
        private int MaxInPage = 2;

        private bool CamMute;
        private bool MicMute;

        public void SetCamState(bool mute) 
        { CamMute = mute; }

        public TransLater()
        {
            InitializeComponent();
            SetTrackBarVolume(NewDevices.Volume);
        }

        private void TransLater_Load(object sender, EventArgs e)
        {
            LiveIconShowInvoke(false);
            Design();

            LangSelectDlg dlg = new();
            RoomNameLabel.Text = AgoraObject.GetComplexToken().GetRoomName;
            chat.HandleCreated += Chat_HandleCreated;

            dlg.ShowDialog();
            m_intInterpr = dlg.RoomIndex;

            if (dlg.GetOutCode) 
            {
                Init(dlg.NickName, dlg.RoomIndex);
                MicMute = dlg.IsCheckBoxMicOn() == false;
                CamMute = dlg.IsCheckBoxCamOn() == false;

                MuteLocalAudio(MicMute);
                MuteLocalVideo(CamMute);
            }
            else
                Close();
        }
        private void Chat_HandleCreated(object sender, EventArgs e)
        {
            chat.UpdateFireBase(GetFireBase);
            GetFireBase.Connect();
        }
        public void Init(string nick, int iterprRoom)
        {
            AgoraObject.Rtc.EnableVideo();
            AgoraObject.MuteLocalAudioStream(false);
            AgoraObject.SetWndEventHandler(this);
            AgoraObject.UpdateNickName(nick);
            //DBReader.OnNewTargetRooms += Update ButtonsText;

            string iterprRoomName = UpdateInterpretersRoom(iterprRoom);
            GetFireBase.SetChannelName(iterprRoomName);

            this.DoubleBuffered = true;

            JoinChannel(0, 0);
            UpdateTargetLangs();
            UpdateRelayLangs();
            UpdateLocalVideoWindow();

            RebindVideoWnd();
        }
        public ERROR_CODE JoinChannel(CHANNEL_CHANGE typeChange, int channelParam)
        {
            ERROR_CODE res = 0;
            AgoraObject.Rtc.EnableLocalVideo(true);
            AgoraObject.Rtc.EnableLocalAudio(true);
            AgoraObject.Rtc.SetChannelProfile(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
            AgoraObject.Rtc.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

            RemoteWnd = pictureBoxRemoteVideo.Handle;

            langHolder Host = new
            (
                "Floor",
                AgoraObject.GetHostName(),
                AgoraObject.GetHostToken(),
                true
            );

            //GetSrcChannel(m_intRel);
            //UpdateInterpretersRoom(m_intTar);
            AgoraObject.TogglePublish(CHANNEL_TYPE.CHANNEL_TRANSL, langHolder.Empty);

            //DELETE
            //AgoraObject.EnableScreenCapture();
            //DELETE

            AgoraObject.JoinChannelHost(Host);
            AgoraObject.UpdateChannelRelayDict();

            MuteLocalAudio(false);
            MuteLocalVideo(false);
            AgoraObject.Rtc.EnableLocalVideo(true);
            SetLocalVideoPreview();
            return res;
        }
        public void RefreshLocalWnd()
        {
            pictureBoxRemoteVideo.Refresh();
        }

        private void UpdateLocalVideoWindow() 
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(1, 1, TranslPage.Width - 4, TranslPage.Height - 4);
            Region rgn = new Region(path);
            TranslPrevPage.Region = rgn;
            TranslPage.Region = rgn;

            int size = 30;
            Panel PanelLocalName;
            Label LabelLocalName;

            intWnd_local.Size = new Size(180, 130);
            intWnd_local.BackgroundImageLayout = ImageLayout.Stretch;
            intWnd_local.BackgroundImage = Properties.Resources.video_call_empty;
            intWnd_local.Anchor = AnchorStyles.Bottom;

            PanelLocalName = new Panel();
            PanelLocalName.Parent = intWnd_local;
            PanelLocalName.Size =new Size(180, size);
            PanelLocalName.BackColor = Color.Black;
            PanelLocalName.Location = new Point(intWnd_local.Left, intWnd_local.Bottom - size);

            LabelLocalName = new();
            LabelLocalName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            LabelLocalName.TextAlign = ContentAlignment.MiddleCenter;
            LabelLocalName.Size = new Size(100, size);
            LabelLocalName.Font = new Font(FontFamily.GenericSansSerif, 12);
            LabelLocalName.ForeColor = Color.White;
            LabelLocalName.BackColor = Color.Black;
            LabelLocalName.Text = AgoraObject.NickName;
            LabelLocalName.Dock = DockStyle.Bottom;
            LabelLocalName.Location = new Point(0, PanelLocalName.Bottom - size);
            LabelLocalName.Invalidate();

            PanelLocalName.Controls.Add(LabelLocalName);
            //Init wnd region
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, intWnd_local.Width, intWnd_local.Height);
            path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 25;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            path.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            path.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            regWnd = new Region(path);
        }

        private string UpdateInterpretersRoom(int interprIndex)
        {
            langHolder LangRelay = AgoraObject.GetComplexToken().GetInterpRoomsAt(interprIndex);

            AgoraObject.JoinChannelTransl(LangRelay);
            AgoraObject.MuteLocalAudioStream(AgoraObject.IsLocalAudioMute);
            return LangRelay.langFull;
        }

        private void UpdateTargetLangs()
        {
            var langs = AgoraObject.GetComplexToken();
            var controls = panelTargetButtons.Controls;
            int locOffset = 0;
            int index = 0;
            int defHeight = 90;
            int newIndex = 1;
            ReaLTaiizor.Controls.SkyButton btn = new();

            foreach (var lang in langs.GetTargetLangs)
            {
                if (lang.isActive == true && lang.langShort != "HOST")
                {
                    newIndex++;
                    continue;
                }

            }

            foreach (var lang in langs.GetTargetLangs)
            {
                // not EN_S
                if (lang.langShort == "HOST") continue;
                if (lang.isActive == false)
                {
                    index++;
                    continue;
                }

                newIndex--;
                string btnText = newIndex + ". " + lang.langShort;
                TableLayoutPanel tableLayout;

                btn = CreateButton(btnText, defHeight, 120);

                btn.Name = "TAR" + (index).ToString();
                btn.Height = 35;
                //btn.Font = new Font("Bahnschrift Condensed", 20);
                //btn.ForeColor = Color.Black;
                btn.Cursor = Cursors.Hand;
                btn.Dock = DockStyle.Top;
                btn.Click += ButtonTarget_Click;

                tableLayout = new TableLayoutPanel();
                tableLayout.RowCount = 1;
                tableLayout.ColumnCount = 1;
                tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayout.Name = "TAB" + (index).ToString();
                tableLayout.Size = DefSizeOnePanelButton;
                tableLayout.Dock = DockStyle.Top;
                btn.Margin = new Padding(0, 0, 0, 0);
                tableLayout.Controls.Add(btn, 0, 0);

                if (index == m_intTar)
                    SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                        Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.BurlyWood,
                        Color.BurlyWood);

                controls.Add(btn);
                locOffset++;
                index++;
                tableLayout.BackColor = Color.FromArgb(45, 45, 45);
            }
            Label OutgoingChan = new();

            OutgoingChan.Text = "Outgoing channel";
            OutgoingChan.TextAlign = ContentAlignment.MiddleCenter;
            OutgoingChan.Size = new Size(10, 35);
            OutgoingChan.Font = new Font("Bahnschrift Condensed", 16);
            OutgoingChan.Dock = DockStyle.Top;
            controls.Add(OutgoingChan);

            panelTargetButtons.Size = new Size(panelRelayButtons.Width, 35 * (locOffset + 1));

            ButtonTarget_Click(btn, new EventArgs());
        }
        private void UpdateRelayLangs()
        {
            var langs = AgoraObject.GetComplexToken();
            var controls = panelRelayButtons.Controls;
            panelRelayButtons.Controls.Clear();
            int defHeight = 35;

            int locOffset = 1;
            int index = 0;
            int newIndex = 1;

            ReaLTaiizor.Controls.SkyButton btn;
            TableLayoutPanel tableLayout;

            btn = CreateButton("Floor", defHeight, 120);
            btn.Name = "REL" + (index).ToString();
            btn.Height = 35;
            btn.Cursor = Cursors.Hand;
            btn.Dock = DockStyle.Top;
            btn.Click += ButtonRelay_Click;

            tableLayout = new TableLayoutPanel();
            tableLayout.RowCount = 1;
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayout.Name = "TAB" + (index).ToString();
            tableLayout.Size = DefSizeOnePanelButton;
            tableLayout.Dock = DockStyle.Top;
            btn.Margin = new Padding(0, 0, 0, 0);
            tableLayout.Controls.Add(btn, 0, 0);
            tableLayout.BackColor = Color.FromArgb(45, 45, 45);

            controls.Add(tableLayout);
            index++;
            foreach (var lang in langs.GetTranslLangs)
            {
                if (lang.isActive == true)
                {
                    newIndex++;
                    continue;
                }
                
            }

            foreach (var lang in langs.GetTranslLangs)
            {
                if (lang.isActive == false)
                {
                    index++;
                    continue;
                }
                newIndex--;
                string btnText = newIndex + ". " + lang.langShort;

                btn = CreateButton(btnText, defHeight, 120);
                btn.Name = "REL" + (index).ToString();
                btn.Height = 35;
                btn.Cursor = Cursors.Hand;
                btn.Dock = DockStyle.Top;
                btn.Click += ButtonRelay_Click;
                btn.Margin = new Padding(0, 0, 0, 0);

                Label label = new Label();
                label.Text = "";
                label.Name = "LAB";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Fill;

                tableLayout = new TableLayoutPanel();
                tableLayout.RowCount = 2;
                tableLayout.ColumnCount = 1;
                tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayout.Name = "TAB" + (index).ToString();
                tableLayout.Size = DefSizeOnePanelButton;
                tableLayout.Dock = DockStyle.Top;
                tableLayout.Controls.Add(label, 0, 1);
                tableLayout.Controls.Add(btn, 0, 0);
                tableLayout.BackColor = Color.FromArgb(45, 45, 45);

                controls.Add(tableLayout);

                btn.Show();

                locOffset++;
                index++;
            }
            Label IncomingChan = new();

            IncomingChan.Text = "Incoming channel";
            IncomingChan.TextAlign = ContentAlignment.MiddleCenter;
            IncomingChan.Size = new Size(10, 35);
            IncomingChan.Font = new Font("Bahnschrift Condensed", 16);
            IncomingChan.Dock = DockStyle.Top;
            controls.Add(IncomingChan);

            DefPanSize = new Size(panelRelayButtons.Width, 35 * (locOffset + 1));
            panelRelayButtons.Size = DefPanSize;


            ButtonRelay_Click(btn, new EventArgs());
            buttonColorUpdate();
        }
        private langHolder GetSrcChannel(int srcIndex)
        {
            langHolder lg = new ();
            if (srcIndex != 0)
            {
                lg = AgoraObject.GetComplexToken().GetTargetRoomsAt(srcIndex);
            }
            else
                AgoraObject.LeaveSrcChannel();

            return lg;
        }
        

        public void UpdateRemoteWnd()
        {
            pictureBoxRemoteVideo.Invalidate();
        }

        public void SetPublishName(Queue<string> names)
        {
            try
            {
                if (this.IsHandleCreated)
                {

                    string name = "";

                    if (names.Count != 0)
                        name = names.Peek();

                    Color color;
                    if (IsAnyonePublishing = name != "" && name != AgoraObject.NickName)
                        color = Color.Firebrick;
                    else if (name == AgoraObject.NickName)
                        color = Color.OrangeRed;
                    else 
                        color = Color.Transparent;

                    Invoke((MethodInvoker)delegate
                    {
                        //InsertNameHere.Text = name;
                        Publisher = name;
                        //InsertNameHere.BackColor = color;
                    });
                }
            }
            catch { }
        }

        public void SetLocalVideoPreview()
        {
            IntPtr lclView = intWnd_local.Handle;
            VideoCanvas canv = new VideoCanvas((ulong)lclView, 0);
            canv.renderMode = (int)RENDER_MODE_TYPE.RENDER_MODE_FIT;

            AgoraObject.Rtc.SetupLocalVideo(canv);
            AgoraObject.Rtc.EnableLocalVideo(true);
            AgoraObject.Rtc.StartPreview();
        }

        internal bool Publish()
        {
            bool changeStream = AgoraObject.IsPublish();

            //InsertNameHere.Text = AgoraObject.NickName;
            //Publisher = AgoraObject.NickName;
            ERROR_CODE ret;
            langHolder LangDest = GetSrcChannel(m_intTar + 1);

            AgoraObject.MuteAllTransLatersAudioStream(true);
            AgoraObject.UpdateTargRoom(LangDest.langFull); // update name of target room

            ret = AgoraObject.TogglePublish(CHANNEL_TYPE.CHANNEL_DEST, LangDest);

            if (ret == ERROR_CODE.ERR_OK)
            {
                MuteLocalAudio(false);
                CamMute = false;
                MuteLocalVideo(false);
                Invoke((MethodInvoker)delegate
                {  lostCancelPB.BackColor = Color.Red; });
                
                if (changeStream)
                    DBReader.ChangeStreaming();
                else
                    DBReader.StartStreaming();
            }
            return ret == 0;
        }

        internal bool UnPublish()
        {
            ERROR_CODE ret;

            AgoraObject.MuteAllTransLatersAudioStream(false);
            MuteLocalVideo(false);

            if (AgoraObject.IsPublish())
            {
                Invoke((MethodInvoker)delegate
                {
                    lostCancelPB.BackColor = Color.FromArgb(64, 64, 64); ;
                    Publisher = "";
                });
                IsAnyonePublishing = false;
                DBReader.StopStreaming();
            }

            ret = AgoraObject.TogglePublish(CHANNEL_TYPE.CHANNEL_TRANSL, langHolder.Empty);
            AgoraObject.UpdateTargRoom(string.Empty);  // update name of target room

            return ret == 0;
        }

        private void ButtonRelay_Click(object sender, EventArgs e)
        {
            var btn = (sender as ReaLTaiizor.Controls.SkyButton);

            if (btn.Name == "") return;

            // buttons with name REL#
            string s_index = ((ReaLTaiizor.Controls.SkyButton)sender).Name.Substring(3);
            m_intRel = Convert.ToInt32(s_index);


            relayPanelCheck(s_index);
            buttonColorUpdate();
            langHolder Src = AgoraObject.GetComplexToken().GetTargetRoomsAt(m_intRel);
            AgoraObject.JoinChannelSrc(Src);

            if (AgoraObject.IsPublish())
                Publish();
            else
                UnPublish();
        }

        private void relayPanelCheck(string s_index)
        {
            TableLayoutPanel pn;
            bool emptyLabel;

            pn = panelRelayButtons.Controls
            .Find("TAB" + Convert.ToString(s_index), false)
            .Last() as TableLayoutPanel;

            //m_intRel == 0 is floor
            emptyLabel = m_intRel != 0 &&
                (pn.Controls
                .Find("LAB", false)
                .Last() as Label).Text == String.Empty;

            foreach (var fpn in panelRelayButtons.Controls)
            {
                if (fpn is TableLayoutPanel)
                    (fpn as TableLayoutPanel).Size = DefSizeOnePanelButton;
            }
            panelRelayButtons.Size = DefPanSize;

            if (emptyLabel == false && m_intRel != 0)
            {
                pn.Size = new Size(DefSizeOnePanelButton.Width, DefSizeOnePanelButton.Height + 25);
                panelRelayButtons.Size = new Size(DefPanSize.Width, DefPanSize.Height + 25);
            }
        }

        private void ButtonTarget_Click(object sender, EventArgs e)
        {
            if (((ReaLTaiizor.Controls.SkyButton)sender).Name == "") return;

            // buttons with name TAR#
            string s_index = ((ReaLTaiizor.Controls.SkyButton)sender).Name.Substring(3);
            m_intTar = Convert.ToInt32(s_index);

            buttonColorUpdate();

            if (AgoraObject.IsPublish())
                Publish();
            else
                UnPublish();
        }

        private void MuteLocalAudio(bool mute)
        {
            AgoraObject.MuteLocalAudioStream(mute);
            labelMicrophone.ForeColor = AgoraObject.IsLocalAudioMute ?
                Color.White :
                Color.Red;

        }

        public void MuteLocalVideoInvoke(bool mute) 
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { MuteLocalVideo(mute); });
            else
                MuteLocalVideo(mute);
                
        }
        private void MuteLocalVideo(bool mute)
        {
            if (CamMute != mute) return;

            AgoraObject.MuteLocalVideoStream(mute);

            if (mute)
            {
                AgoraObject.Rtc.SetupLocalVideo(new VideoCanvas(0, 0));
                intWnd_local.BackgroundImage = Properties.Resources.video_call_empty;
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    SetLocalVideoPreview();
                    //AgoraObject.Rtc.SetupLocalVideo(new VideoCanvas((ulong)intWnd_local.Handle, 0));
                });
            }

            labelVideo.ForeColor = AgoraObject.IsLocalVideoMute ?
                Color.White :
                Color.Red;

        }

        private void TransLater_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AgoraObject.IsPublish())
                DBReader.StopStreaming();

            AgoraObject.LeaveHostChannel();
            AgoraObject.LeaveSrcChannel();
            AgoraObject.LeaveTranslChannel();
            AgoraObject.LeaveTargetChannel();
            AgoraObject.LeaveChannelsRelay();

            Owner.Show();
            Owner.Refresh();
        }

        internal ReaLTaiizor.Controls.SkyButton CreateButton(string text, int height, int width)
        {
            //return new ReaLTaiizor.Controls.RibbonButtonCenter()
            //{
            //    Text = text,
            //    Height = height,
            //    Width = width,
            //    BackColor = Color.WhiteSmoke,
            //    ForeColor = Color.DimGray
            //};
            return new ReaLTaiizor.Controls.SkyButton()
            {
                Text = text,
                Height = height,
                Width = width,
                Font = new Font("Bahnschrift Condensed", 14, FontStyle.Bold),
            };
        }

        internal void BuildBorder()
        {
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, panelRelayButtons.Width, this.Height);
            int d = 25;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.X - 100, r.Y, d, d, 180, 90);
            path.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            path.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            path.AddArc(r.X - 100, r.Y + r.Height - d, d, d, 90, 90);

            panelRelayButtons.Region = new Region(path);

            r = new System.Drawing.Rectangle(0, 0, panelRelayButtons.Width, this.Height);
            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.X + r.Width - d + 100, r.Y, d, d, 270, 90);
            path.AddArc(r.X + r.Width - d + 100, r.Y + r.Height - d, d, d, 0, 90);
            path.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);

            panelTargetButtons.Region = new Region(path);
        }
        private void UpdateButtonsText(object sender, EventArgs args)
        {

            if (args is EventArgsNewTargetRooms == false) return;
            var targetRooms = (args as EventArgsNewTargetRooms).targetRooms;

            if (targetRooms.Count == 0)
            {
                targetRooms.Add(string.Empty);
            }

            m_intStreamLg.Clear();


            foreach (var lg in targetRooms)
            {
                foreach (var ch in panelRelayButtons.Controls)
                {
                    if (ch is ReaLTaiizor.Controls.RibbonButtonCenter == false) continue;
                    var btn = ch as ReaLTaiizor.Controls.RibbonButtonCenter;

                    //REL1 -> REL# (REL0 is a Floor)
                    string btntext = btn.Text;
                    if (btn.Text == lg)
                        m_intStreamLg.Add(Convert.ToInt32(btn.Name.Substring(3)));
                }

                foreach (var ch in panelTargetButtons.Controls)
                {
                    if (ch is ReaLTaiizor.Controls.RibbonButtonCenter == false) continue;
                    var btn = ch as ReaLTaiizor.Controls.RibbonButtonCenter;

                    //TAR0 -> TAR#
                    if (btn.Text == lg)
                        m_intStreamLg.Add(Convert.ToInt32(btn.Name.Substring(3)) + 1);
                }
            }
            //buttonColorUpdate();
        }
        private void buttonColorUpdate()
        {
            bool IsStreaming = false;
            foreach (var ch in panelRelayButtons.Controls)
            {
                if (ch is TableLayoutPanel == false) continue;
                foreach (var bt in (ch as TableLayoutPanel).Controls)
                {
                    bool lbCheck = false;
                    if (bt is ReaLTaiizor.Controls.SkyButton == false && bt is Label == false) continue;
                    else if (bt is Label && ((Label)bt).Text != string.Empty) { lbCheck = true; continue; }
                    else if (bt is ReaLTaiizor.Controls.SkyButton == false) continue;
                    var btn = bt as ReaLTaiizor.Controls.SkyButton;//TableLayoutPanel

                    int btnLangInd = Convert.ToInt32(btn.Name.Substring(3));

                    SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                        Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.FromArgb(45, 45, 45),
                        Color.FromArgb(53, 53, 53));

                    if (m_intStreamLg.Contains(btnLangInd) == true || lbCheck)
                    {
                        SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                            Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.BurlyWood,
                            Color.BurlyWood);
                        IsStreaming = true;
                    }
                    if (m_intRel == btnLangInd)
                    {
                        SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                            Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.Red,
                            Color.DarkRed);
                    }
                    btn.Invalidate();
                }
            }
            if (IsStreaming)
            {
                //Invoke((MethodInvoker)delegate
                //{
                //    panelRelayButtons.Size = new Size(panelRelayButtons.Size.Width, panelRelayButtons.Size.Height + 25);
                //});
            }
            foreach (var ch in panelTargetButtons.Controls)
            {
                if (ch is ReaLTaiizor.Controls.SkyButton == false) continue;
                var btn = ch as ReaLTaiizor.Controls.SkyButton;

                int btnLangInd = Convert.ToInt32(btn.Name.Substring(3));

                SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                    Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.FromArgb(45, 45, 45),
                    Color.FromArgb(53, 53, 53));

                if (m_intStreamLg.Contains(btnLangInd + 1) == true)
                {
                    SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                        Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.BurlyWood,
                        Color.BurlyWood);
                }
                if (m_intTar == btnLangInd)
                {
                    //btn.BaseColorA = Color.PaleVioletRed;
                    //btn.BaseColorB = Color.OrangeRed;
                    SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                        Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.Red,
                        Color.DarkRed);
                }

                btn.Invalidate();
            }
        }

        private void SkyBtnUpdate(ReaLTaiizor.Controls.SkyButton btn, Color BorA, Color BorB, Color BorC, Color BorD, Color Fore, Color ForeShad,
            Color BackColor, Color NormA, Color NormB)
        {
            btn.NormalBorderColorA = BorA;
            btn.NormalBorderColorB = BorB;
            btn.NormalBorderColorC = BorC;
            btn.NormalBorderColorD = BorD;
            btn.NormalForeColor = Fore;
            btn.NormalShadowForeColor = ForeShad;
            btn.BackColor = BackColor;
            btn.NormalBGColorA = NormA;
            btn.NormalBGColorB = NormB;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnDevices_Click(object sender, EventArgs e)
        {
            labelChat.ForeColor = Color.White;

            if (chat.Visible == true){
                ChatClosed(chat);
                //Thread.Sleep(100);
            }

            if (devices == null || devices.IsDisposed)
            {
                devices = new NewDevices();
                CallSidePanel(devices);
                devices.typeOfAlligment(true);
                devices.SetAudienceSettings();
                labelSettings.ForeColor = Color.Red;
            }
            else
            {
                DevicesClosed(devices);
                labelSettings.ForeColor = Color.White;
            }

        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            labelChat.ForeColor = Color.White;
            if (chat.Visible == true)
            {
                ChatClosed(chat);
                //Thread.Sleep(100);
            }

            if (devices == null || devices.IsDisposed)
            {
                devices = new NewDevices();
                CallSidePanel(devices);
                devices.typeOfAlligment(true);
                //devices.SetAudienceSettings();
                labelSettings.ForeColor = Color.Red;
            }
            else
            {
                DevicesClosed(devices);
                labelSettings.ForeColor = Color.White;
            }
        }

        private void CallSidePanel(Form Wnd)
        {
            panel1.SuspendLayout();
            Wnd.Size = panel1.Size;
            Wnd.Location = panel1.Location;
            Wnd.TopLevel = false;
            Wnd.Dock = DockStyle.Fill;
            panel1.Controls.Add(Wnd);
            panel1.BringToFront();
            if (panel1.Visible == false || Wnd.Visible == false)
            {
                panel1.ResumeLayout();
                panel1.Location = new Point(Size.Width, panel1.Location.Y);
                panel1.Show();
                Animator(panel1, -9, 0, 50, 1);
                Wnd.Show();
            }
        }

        public void DevicesClosed(Form Wnd)
        {
            Wnd.Close();
            Animator(panel1, 9, 0, 50, 1);
            panel1.Hide();
            intWnd_local.Refresh();
            labelSettings.ForeColor = Color.White;
            GC.Collect();
        }

        internal void ChatClosed(Form Wnd)
        {
            Wnd.Hide();
            Animator(panel1, 9, 0, 50, 1);
            panel1.Hide();
            GC.Collect();
        }
        public void LiveIconShowInvoke(bool show) 
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate
                {
                    if (show) LiveIconShow();
                    else LiveIconHide();
                });
            else
            {
                if (show) LiveIconShow();
                else LiveIconHide();
            }
        }

        private void LiveIconShow()
        {
            LiveBox.Show();
            StreamTime.Show();
            timer1.Start();
        }

        private void LiveIconHide()
        {
            LiveBox.Hide();
            StreamTime.Hide();
            pictureBoxRemoteVideo.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string i = DateTime.Now.ToString("MM");
            string dm = "";
            switch (i)
            {
                case "01": dm = "January"; break;
                case "02": dm = "February"; break;
                case "03": dm = "March"; break;
                case "04": dm = "April"; break;
                case "05": dm = "May"; break;
                case "06": dm = "June"; break;
                case "07": dm = "July"; break;
                case "08": dm = "August"; break;
                case "09": dm = "September"; break;
                case "10": dm = "October"; break;
                case "11": dm = "November"; break;
                case "12": dm = "December"; break;
            }

            StreamTime.Text = DateTime.Now.ToString("HH:mm") + " "
                + DateTime.Now.DayOfWeek.ToString() + ", " + dm 
                + " " + DateTime.Now.ToString("dd, yyyy");
            //seconds++;
            //StreamTime.Text = Int2StringTime(seconds);
        }
        public void Design()
        {
            MaximumSize = new Size(1280, 800);
            MinimumSize = new Size(1280, 800);
            MaxInPage = pictureBoxRemoteVideo.Width / 425;

            panelRelayButtons.Parent = pictureBoxRemoteVideo;
            panelTargetButtons.Parent = pictureBoxRemoteVideo;
            LiveBox.Parent = this;
            StreamTime.Parent = this;
            TranslPage.Parent = pictureBoxRemoteVideo;
            TranslPrevPage.Parent = pictureBoxRemoteVideo;

            PlaceControl(StreamTime.Location.X - 90, StreamTime.Location.Y, 250, StreamTime.Height, LiveBox);
            
            //PlaceControl(1242, 1, 35, 25, CloseAppButton);
            //PlaceControl(1204, 1, 35, 25, NewFullScreenButton);
            //PlaceControl(1166, 1, 35, 25, HideButton);

            PlaceControl(pictureBoxRemoteVideo.Location.X + 31, pictureBoxRemoteVideo.Location.Y + 160, 140, 202, panelRelayButtons);
            PlaceControl(pictureBoxRemoteVideo.Width - 31 - 140, pictureBoxRemoteVideo.Location.Y + 160, 140, 202, panelTargetButtons);

            PlaceControl(25, 470, 54, 54, TranslPrevPage);
            PlaceControl(pictureBoxRemoteVideo.Width - 25 - TranslPage.Width, 470, 54, 54, TranslPage);
            PlaceControl(5, 108, 1270, 585, pictureBoxRemoteVideo);
            PlaceControl(965, pictureBoxRemoteVideo.Location.Y, 450, pictureBoxRemoteVideo.Height, panel1);

            StreamLayout.ColumnStyles[1].SizeType = SizeType.Absolute;
            StreamLayout.ColumnStyles[0].Width = 100;
            StreamLayout.ColumnStyles[1].Width = 0;

            panel1.BackColor = Color.WhiteSmoke;
            LiveBox.BringToFront();
            StreamTime.BringToFront();
            panelTargetButtons.BringToFront();
            panelRelayButtons.BringToFront();
            RoomNameLabel.Invalidate();
            chat.Hide();

            panelRelayButtons.BackColor = Color.FromArgb(45,45,45);
            panelTargetButtons.BackColor = Color.FromArgb(45,45,45);
        }

        internal void RebuildMaxInPage()
        {
            MaxInPage = pictureBoxRemoteVideo.Width / 425;
            RebindVideoWnd();
        }
        public void Animator(Panel panel, int offset_x, int offset_y, int itterations, int delay)
        {
            HideControls(pictureBoxRemoteVideo);
            pictureBoxRemoteVideo.Refresh();
            Thread.Sleep(delay);
            pictureBoxRemoteVideo.SuspendLayout();
            for (int ind = 0; ind < itterations; ind++)
            {
                //if (ind % 5 == 0)
                //{
                //    panel1.Invalidate();
                //    panel1.Update();
                //}
                StreamLayout.ColumnStyles[1].Width = StreamLayout.ColumnStyles[1].Width - offset_x;
                pictureBoxRemoteVideo.Size = new Size(pictureBoxRemoteVideo.Size.Width - offset_x, pictureBoxRemoteVideo.Size.Height);
                //Thread.Sleep(1);
            }
            TranslPrevPage.Hide();
            TranslPage.Hide();
            pictureBoxRemoteVideo.ResumeLayout();
            LiveBox.BringToFront();
            StreamTime.BringToFront();
            ShowControls(pictureBoxRemoteVideo);
            RebuildMaxInPage();
        }

        private void HideControls(PictureBox Element)
        {
            foreach (Control ctr in Element.Controls)
            {
                ctr.Hide();
            }
        }
        private void ShowControls(PictureBox Element)
        {
            foreach (Control ctr in Element.Controls)
            {
                ctr.Show();
            }
        }

        private void PlaceControl(int x, int y, int w, int h, Control wnd)
        {
            wnd.Size = new Size(w, h);
            wnd.Location = new Point(x, y);
        }
        public void RebuildChatPanel(Control panel)
        {
            chat.Chat_SizeChanged(panel, new EventArgs());
        }

        #region EventHandlers

        private void lostCancelPB_Click(object sender, EventArgs e)
        {
            if (AgoraObject.IsPublish())
                UnPublish();
            else
                Publish();
        }
        private void lostCancelButton1_Click(object sender, EventArgs e)
        {
        }
        private void btnBoxMuteLocalAudio_Click(object sender, EventArgs e)
        {
            MuteLocalAudio(!AgoraObject.IsLocalAudioMute);
        }
        private void btnBoxMuteLocalVideo_Click(object sender, EventArgs e)
        {
            CamMute = !AgoraObject.IsLocalVideoMute;
            MuteLocalVideo(CamMute);
        }
        private void trackBar1_ValueChanged()
        {
            NewDevices.SetVolume(trackBar1.Value);
            if (devices != null && devices.IsDisposed == false)
                devices.UpdateSoundTrackBar();
        }
        public void SetTrackBarVolume(int volume)
        {
            trackBar1.Value = volume;
        }
        private void socialButton1_Click(object sender, EventArgs e)
        {
            trackBar1.Visible = !(trackBar1.Visible);
            if (trackBar1.Visible)
                labelVolume.ForeColor = Color.Red;
            else
                labelVolume.ForeColor = Color.White;
        }
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            Close();
        }
        private void SourceLangButton_Click(object sender, EventArgs e)
        {
            panelRelayButtons.Visible = true;
        }
        private void SrcBtnClose_Click(object sender, EventArgs e)
        {
            panelRelayButtons.Visible = false;
        }
        private void HideButton_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            this.WindowState = FormWindowState.Minimized;
        }

        private void NewFullScreenButton_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            if (this.Size.Width == 1280)
            {
                this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
                this.MinimumSize = Screen.PrimaryScreen.WorkingArea.Size;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                CenterToScreen();
            }
            else
            {
                this.MaximumSize = new Size(1280, 800);
                this.MinimumSize = new Size(1280, 800);
                this.Size = new Size(1280, 800);
                CenterToScreen();
            }
            RebuildMaxInPage();
        }
        private void CoughButton_MouseDown(object sender, MouseEventArgs e)
        {
            MuteLocalAudio(true);
        }

        private void CoughButton_MouseUp(object sender, MouseEventArgs e)
        {
            MuteLocalAudio(false);
        }
        private void socialButton2_Click(object sender, EventArgs e)
        {
            labelSettings.ForeColor = Color.White;
            if (devices != null && !(devices.IsDisposed))
            {
                DevicesClosed(devices);
                //Thread.Sleep(100);
            }
            if (chat.Visible == false)
            {
                CallSidePanel(chat);
                chat.ButtonsVisibility(true);
                labelChat.ForeColor = Color.Red;
            }
            else
            {
                chat.ButtonsVisibility(false);
                ChatClosed(chat);
                labelChat.ForeColor = Color.White;
            }
        }
        private void CoughButton_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxRemoteVideo_Resize(object sender, EventArgs e)
        {
            //pictureBoxRemoteVideo.Invalidate(false);
            //pictureBoxRemoteVideo.Update();
        }
        public void GetMessage(string message, string nickname, CHANNEL_TYPE channel)
        {
            if (chat != null && chat.IsHandleCreated)
                chat.chat_NewMessageInvoke(message, nickname, channel);
        }

        public IntPtr NewTranslStreamInvoke(string name, string lang) 
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                { NewTranslStream(name, lang); });
            }
            else
                NewTranslStream(name, lang);

            return IntPtr.Zero;
        }
        private IntPtr NewTranslStream(string name, string lang) 
        {
            int curBtn = 0;
            foreach (var l in AgoraObject.GetComplexToken().GetTargetLangs) 
            {
                if (lang == l.langShort) break;
                curBtn++;
            }

            var handler = IntPtr.Zero;
            foreach (Control pn in panelRelayButtons.Controls) 
            {
                if (pn is TableLayoutPanel == false ||
                    Convert.ToInt32(pn.Name.Substring(3)) != curBtn) continue;
                
                foreach (Control el in (pn as TableLayoutPanel).Controls) 
                {
                    if (el is PictureBox) handler = (el as PictureBox).Handle;
                    if (el is Label) (el as Label).Text = name;
                    if (el is ReaLTaiizor.Controls.SkyButton) m_intStreamLg.Add(Convert.ToInt32(curBtn));

                    //(pn as TableLayoutPanel).Size = new Size(120, 60);
                    (pn as TableLayoutPanel).BackColor = Color.Black;
                }
                break;
            }
            buttonColorUpdate();
            UpdatePanelWithNewStreamTransl();
            return handler;
        }
        public IntPtr TranslStreamLeaveInvoke(string lang)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                { TranslStreamLeave(lang); });
            }
            else
                TranslStreamLeave(lang);

            return IntPtr.Zero;
        }
        private void TranslStreamLeave(string lang) 
        {
            int curBtn = 0;
            foreach (var l in AgoraObject.GetComplexToken().GetTargetLangs)
            {
                if (lang == l.langShort) break;
                curBtn++;
            }

            foreach (Control pn in panelRelayButtons.Controls)
            {
                if (pn is TableLayoutPanel == false ||
                    Convert.ToInt32(pn.Name.Substring(3)) != curBtn) continue;
                
                foreach (Control el in (pn as TableLayoutPanel).Controls)
                {
                    if (el is Label) (el as Label).Text = "";
                    if (el is ReaLTaiizor.Controls.SkyButton)
                    {
                        m_intStreamLg.Remove(Convert.ToInt32(curBtn));
                        relayPanelCheck(curBtn.ToString());
                    }

                    (pn as TableLayoutPanel).BackColor = Color.Black;
                }
                break;
            }
            buttonColorUpdate();
            UpdatePanelWithNewStreamTransl();
        }
        private void UpdatePanelWithNewStreamTransl()
        {
            int strCount = 0;
            foreach (Control pn in panelRelayButtons.Controls)
            {
                if (pn is not TableLayoutPanel) continue;
                Label checkLb = null;
                ReaLTaiizor.Controls.SkyButton checkBtn = null;

                foreach (Control ctr in ((TableLayoutPanel)pn).Controls)
                {
                    if (ctr is Label) checkLb = ctr as Label;
                    if (ctr is ReaLTaiizor.Controls.SkyButton) checkBtn = ctr as ReaLTaiizor.Controls.SkyButton;

                }
                if (checkLb != null && checkBtn != null && checkLb.Text != String.Empty)
                {
                    SkyBtnUpdate(checkBtn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                            Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.BurlyWood,
                            Color.BurlyWood);
                    strCount++;
                }
            }
            //panelRelayButtons.Size = new Size(panelRelayButtons.Size.Width, DefPanSize.Height + 25 * strCount);
        }
        #endregion

        private void pictureBoxRemoteVideo_Click(object sender, EventArgs e)
        {

        }

        private void nightControlBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point ptn = e.Location;
            if (!(ptn.X > 46 && ptn.X < 94)) return;
            this.BringToFront();
            if (this.Size.Width == 1280)
            {
                ResizeForm(Screen.PrimaryScreen.WorkingArea.Size, this);
                ResizeForm(Screen.PrimaryScreen.WorkingArea.Size, formTheme1);
            }
            else
            {
                ResizeForm(new Size(1280, 800), this);
                ResizeForm(new Size(1280, 800), formTheme1);
            }
        }
        private void ResizeForm(Size size, Form target)
        {
            target.MaximumSize = size;
            target.MinimumSize = size;
            target.Size = size;
        }
        private void ResizeForm(Size size, ReaLTaiizor.Forms.FormTheme target)
        {
            target.MaximumSize = size;
            target.MinimumSize = size;
            target.Size = size;
        }

        private void lostCancelPB_MouseEnter(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.FromArgb(64, 64, 64))
                ((PictureBox)sender).BackColor = Color.FromArgb(70, 70, 70);
        }

        private void lostCancelPB_MouseLeave(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.FromArgb(70, 70, 70))
                ((PictureBox)sender).BackColor = Color.FromArgb(64, 64, 64);
        }
    }
}