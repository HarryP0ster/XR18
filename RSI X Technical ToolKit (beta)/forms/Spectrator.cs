using System;
using System.Windows.Forms;
using agorartc;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MaterialSkin;
using MaterialSkin.Controls;

namespace RSI_X_Desktop
{
    //public partial class Spectator : Form, IFormHostHolder
    public partial class Spectator : Form
    {
        public IntPtr RemoteWnd { get; private set; }
        private DevicesForm devices;

        private List<string> TarLang;
        private bool IsOriginal = false;
        private string AppCID = string.Empty;
        private string ChToken = string.Empty;
        private string HostName = string.Empty;
        private int audioLastVolume;

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume); //Контроль громкости

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume); //Контроль громкости

        public Spectator()
        {
            InitializeComponent();
        }

        public Spectator(string AppID, string Token, string ChannelName)
        {
            AppCID = AppID;
            ChToken = Token;
            HostName = ChannelName;
            InitializeComponent();
            //radioButton1.Enabled = false;
        }

        private void Spectator_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            label9.Text = AgoraObject.GetComplexToken().GetRoomName;

            Spectator_SizeChanged(this, new EventArgs());
            JoinChannel();
        }

        private void UpdateLangComboBox()
        {
            TarLang = AgoraObject.GetLangCollection();
            List<string> test = TarLang;
            langBox.Items.Clear();
            foreach (string lang in TarLang)
            {
                // only EN_S_###
                if (lang[3] == 'S') continue;
                int Index = lang.IndexOf("_");
                string lang_short = lang.Remove(Index, lang.Length - Index);
                langBox.Items.Add(lang_short);
            }
            //langBox.Items.RemoveAt(0);
            langBox.SelectedIndex = 0;
        }

        public ERROR_CODE JoinChannel()
        {
            ERROR_CODE res = ERROR_CODE.ERR_OK;

            AgoraObject.Rtc.SetChannelProfile(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION);
            AgoraObject.Rtc.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);
            AgoraObject.Rtc.EnableVideo();
            AgoraObject.Rtc.EnableLocalVideo(false);
            AgoraObject.Rtc.EnableLocalAudio(false);

            //pictureBoxRemoteVideo.Width = this.Width;
            RemoteWnd = pictureBoxRemoteVideo.Handle;
            UpdateLangComboBox();

            if (ChToken == string.Empty)
                AgoraObject.JoinChannelHost(AgoraObject.GetHostName(), AgoraObject.GetHostToken(), 0, "");
            else
                AgoraObject.JoinChannelHost(HostName, ChToken, 0, "");

            pictureBoxRemoteVideo.Invalidate();

            return res;
        }

        private void Spectator_FormClosed(object sender, FormClosedEventArgs e)
        {
            AgoraObject.LeaveHostChannel();
            AgoraObject.LeaveSrcChannel();
            AgoraObject.MuteAllRemoteAudioStream(false);
            AgoraObject.MuteAllRemoteVideoStream(false);

            waveOutSetVolume(IntPtr.Zero, uint.MaxValue);

            Owner.Show();
            Owner.Refresh();
        }

        private void langBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Выпадающий список языков
            if (!IsOriginal)
            {
                var InterRoom = AgoraObject.GetComplexToken().GetTargetRoomsAt(langBox.SelectedIndex + 1);
                AgoraObject.JoinChannelSrc(InterRoom);
            }
        }

        private void LabelTurnOriginal_Click(object sender, EventArgs e)
        {
            //Включение оригинальной дорожки (floor)
            if (IsOriginal)
            {
                var InterRoom = AgoraObject.GetComplexToken().GetTargetRoomsAt(langBox.SelectedIndex + 1);
                AgoraObject.JoinChannelSrc(InterRoom);
                mSwitchOriginal.Checked = false;
            }
            else
            {
                AgoraObject.LeaveSrcChannel();
                mSwitchOriginal.Checked = true;
            }
            langBox.Enabled = IsOriginal;
            IsOriginal = !IsOriginal;
        }

        private void pictureBoxMuteAudio_Click(object sender, EventArgs e)
        {
            //AgoraObject.MuteAllRemoteAudioStream(!AgoraObject.IsAllRemoteAudioMute);

            //pictureBoxMuteAudio.Image = AgoraObject.IsAllRemoteAudioMute ?
            //    Properties.Resources.rsi_mute_100 :
            //    Properties.Resources.rsi_audio_100;
        }

        private void pictureBoxMuteVideo_Click(object sender, EventArgs e)
        {
            AgoraObject.MuteAllRemoteVideoStream(!AgoraObject.IsAllRemoteVideoMute);

            if (AgoraObject.IsAllRemoteVideoMute)
            {
                AgoraObject.Rtc.StopPreview();
                pictureBoxMuteVideo.Image = Properties.Resources.rsi_video_call_mute;
                UpdateRemoteWnd();
            }
            else
            {
                AgoraObject.Rtc.StartPreview();
                pictureBoxMuteVideo.Image = Properties.Resources.rsi_video_call_100;
            }
        }

        private void pictureBoxFullscreen_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ?
                FormWindowState.Normal :
                FormWindowState.Maximized;
        }


        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.IsDisposed)
            {
                devices = new DevicesForm();
                devices.SetAudienceSettings();
            }

            if (devices.Visible == false)
            {
                devices.Location = this.Location;
                devices.Show(this);
            }
            devices.Focus();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarVolumeBar_Scroll(object sender, EventArgs e)
        {
            int NewVolume = ((ushort.MaxValue / 100) * trackBarVolumeBar.Value);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));

            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);

            if (trackBarVolumeBar.Value == 0)
            {
                pictureBoxAudioVolumeStatus.Image = Properties.Resources.rsi_mute_100;
            }
            else if (trackBarVolumeBar.Value > 0 &&
                     trackBarVolumeBar.Value < 40)
            {
                pictureBoxAudioVolumeStatus.Image = Properties.Resources.rsi_low_volume_100;
            }
            else if (trackBarVolumeBar.Value >= 40 &&
                     trackBarVolumeBar.Value < 85)
            {
                pictureBoxAudioVolumeStatus.Image = Properties.Resources.rsi_voice_100;
            }
            else if (trackBarVolumeBar.Value >= 85)
            {
                pictureBoxAudioVolumeStatus.Image = Properties.Resources.rsi_audio_100;
            }
        }

        private void pictureBoxAudioVolumeStatus_Click(object sender, EventArgs e)
        {

            if (trackBarVolumeBar.Value == 0)
            {
                trackBarVolumeBar.Value = audioLastVolume;
            }
            else
            {
                audioLastVolume = trackBarVolumeBar.Value;
                trackBarVolumeBar.Value = 0;
            }

            trackBarVolumeBar_Scroll(sender, new EventArgs());
        }
        const double Ratio = 4 / 3;

        private void Spectator_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxRemoteVideo.Height = (int)(Width * Ratio);
            pictureBoxRemoteVideo.Width = (int)(pictureBoxRemoteVideo.Height * Ratio);
            BuildBorder();
        }

        public void UpdateRemoteWnd()
        {
            AgoraObject.Rtc.StopPreview();
            pictureBoxRemoteVideo.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BuildBorder()
        {
            //tableLayoutPanel1
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            int d = 15;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.X, r.Y - 100, d, d, 180, 90);
            path.AddArc(r.X + r.Width - d, r.Y - 100, d, d, 270, 90);
            path.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            path.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);

            tableLayoutPanel1.Region = new Region(path);
        }
    }
}
