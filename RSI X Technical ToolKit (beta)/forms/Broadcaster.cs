using System;
using System.Windows.Forms;
using agorartc;
using MaterialSkin;
using MaterialSkin.Controls;

namespace RSI_X_Desktop
{
    public partial class Broadcaster : MaterialForm
    {
        internal static IntPtr LocalWinId;
        //internal static IntPtr RemoteWinId;
        internal DumpForm dumpDlg;
        internal DevicesForm devicesDlg;
        internal ScreenSharing sharingDig;
        private bool IsSharingScreen = false;

        public Broadcaster()
        {
            InitializeComponent();
        }

        private void Conference_Load(object sender, EventArgs e)
        {
            AgoraObject.Rtc.EnableVideo();
            this.DoubleBuffered = true;
            var ret = AgoraObject.JoinChannel(
                AgoraObject.GetComplexToken().GetHostName,
                AgoraObject.GetComplexToken().GetToken);
            SetupLocalVideo();

            ToolTip t = new ToolTip();
            t.SetToolTip(btnMuteAudio, "Mute / Unmute microphone");
            t.SetToolTip(btnMuteVideo, "Turn on / off the camera");
            t.SetToolTip(btnScreenShare, "Start / end screen or app sharing");
            //t.SetToolTip(btnDump, "Report a bug or error in the application");
            t.SetToolTip(btnDevices, "Configure broadcast equipment");        }

        private void SetupLocalVideo()
        {
            AgoraObject.MuteLocalAudioStream(false);
            AgoraObject.MuteLocalVideoStream(false);

            AgoraObject.Rtc.EnableLocalVideo(true);
            AgoraObject.Rtc.StartPreview();

            LocalWinId = localView.Handle;
            var ret = new VideoCanvas((ulong)LocalWinId, 0);
            AgoraObject.Rtc.SetupLocalVideo(ret);
        }

        private void btnMuteAudio_Click(object sender, EventArgs e)
        {
            var ret = AgoraObject.MuteLocalAudioStream(!AgoraObject.IsLocalAudioMute);

            if (ret == ERROR_CODE.ERR_OK) 
            {
                if (AgoraObject.IsLocalAudioMute)
                    ((PictureBox)sender).BackgroundImage = Properties.Resources.rsi_microphone_off_100;
                else
                    ((PictureBox)sender).BackgroundImage = Properties.Resources.rsi_microphone_100;
            }
        }

        private void btnMuteVideo_Click(object sender, EventArgs e)
        {
            var ret = AgoraObject.MuteLocalVideoStream(!AgoraObject.IsLocalVideoMute);

            if (ret == ERROR_CODE.ERR_OK)
            {
                if (AgoraObject.IsLocalVideoMute)
                    ((PictureBox)sender).BackgroundImage = Properties.Resources.rsi_video_call_mute;
                else
                    ((PictureBox)sender).BackgroundImage = Properties.Resources.rsi_video_call_100;
            }
        }

        private void Broadcaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            AgoraObject.LeaveChannel();
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            if (dumpDlg != null && !dumpDlg.IsDisposed && dumpDlg.Visible)
                dumpDlg.Close();

            dumpDlg = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                Visible = true,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
        }

        private void btnDevices_Click(object sender, EventArgs e)
        {
            if (devicesDlg != null && !devicesDlg.IsDisposed && devicesDlg.Visible)
                devicesDlg.Close();

            devicesDlg = new()
            {
                StartPosition = FormStartPosition.CenterParent,
                Visible = true,
            };

            devicesDlg.FormClosed += (s,e) => SetupLocalVideo();
        }

        private void btnScreenShare_Click(object sender, EventArgs e)
        {
            IsSharingScreen = !IsSharingScreen;

            if (IsSharingScreen)
            {
                if (sharingDig != null && !sharingDig.IsDisposed && sharingDig.Visible)
                    sharingDig.Close();

                sharingDig = new()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Visible = true,
                    //FormBorderStyle = FormBorderStyle.FixedSingle
                };
                //AgoraObject.EnableScreenCapture();


            }
            else
            {
                AgoraObject.Rtc.StopScreenCapture();
                ((PictureBox)sender).BackgroundImage = Properties.Resources.screen_share;
            }

            localView.Invalidate();
        }

        private void signOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
