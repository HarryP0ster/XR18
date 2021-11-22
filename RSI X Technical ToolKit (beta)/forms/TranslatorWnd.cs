using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using agorartc;

namespace RSI_X_Desktop
{
    partial class TransLater
    {
        struct _AGVIDEO_WNDINFO
        {
            internal uint nUID;
            internal int nIndex;

            internal PictureBox HWnd;
            internal PictureBox MuteOther;
            internal PictureBox HideOther;
            internal TableLayoutPanel ctrlPanel;
            internal ReaLTaiizor.Controls.DungeonTrackBar userVolume;


            internal string channelID;

            internal bool IsMuted;
            internal bool IsHidden;
            internal Label nameLabel;
            internal int Page;

            internal void OnMute(object sender, EventArgs e)
            {  MuteRemoteAudio(!IsMuted); }
            internal void OnHide(object sender, EventArgs e)
            { HideRemoteVideo(!IsHidden); }

            internal void MuteRemoteAudio(bool mute) 
            {
                IsMuted = mute;
                if (userVolume != null)
                {
                    if (userVolume.Value == 0)
                        MuteOther.BackgroundImage = Properties.Resources.rsi_mute_100_white;
                    else
                        MuteOther.BackgroundImage = Properties.Resources.rsi_voice_100_white;
                    userVolume.Visible = IsMuted;
                    nameLabel.Visible = !IsMuted;
                }
            }

            internal void HideRemoteVideo(bool Hide)
            {

                IsHidden = Hide;
                if (IsHidden)
                {
                    HideOther.BackgroundImage = Properties.Resources.rsi_video_call_1001_white;

                    PictureBox dummy = new PictureBox();
                    var ret = new VideoCanvas((ulong)dummy.Handle, nUID);
                    ret.channelId = channelID;
                    ret.uid = nUID;

                    AgoraObject.Rtc.SetupRemoteVideo(ret);
                }
                else
                {
                    HideOther.BackgroundImage = Properties.Resources.rsi_video_call_100_white;
                }
                AgoraObject.m_channelTransl.MuteRemoteVideoStream(nUID, IsHidden);
                HWnd.Invalidate();
            }

            internal void ShowPanel(object sender, EventArgs e)
            {
                MuteOther.Show();
                HideOther.Show();
                nameLabel.Show();
                ctrlPanel.Show();
            }
            internal void HidePanel(object sender, EventArgs e)
            {
                Point p = HWnd.PointToClient(Cursor.Position);
                if (!HWnd.ClientRectangle.Contains(p))
                {
                    MuteOther.Hide();
                    HideOther.Hide();
                    nameLabel.Hide();
                    ctrlPanel.Hide();
                }
            }

            internal void UpdatePage(int newPage)
            {
                Page = newPage;
            }
            internal void volumeScroll()
            {
                int volume = userVolume.Value;
                if (volume < 5)
                    volume = 0;
                AgoraObject.UpdateUserVolume(nUID, volume);
                if (volume == 0)
                    MuteOther.BackgroundImage = Properties.Resources.rsi_mute_100_white;
                else
                    MuteOther.BackgroundImage = Properties.Resources.rsi_voice_100_white;
            }
        }

        #region Interpreter Wnd controls

        public void RebindVideoWndInvoke() 
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { RebindVideoWnd(); });
            else
                RebindVideoWnd();
        }
        protected void RebindVideoWnd()
        {
            ButtonsState();
            int InCurPage = GetCurrentPage();
            int loc = 1;
            string userName;
            int StartPointX = pictureBoxRemoteVideo.Width / 2 - 250 * InCurPage / 2 - 90;

            HideAllWnd();
            BuildWndPages();

            //Local wnd
            intWnd_local.Location = new Point(StartPointX, pictureBoxRemoteVideo.Height - intWnd_local.Height - 15);
            intWnd_local.Show();
            intWnd_local.Parent = pictureBoxRemoteVideo;
            intWnd_local.BringToFront();
            intWnd_local.Region = regWnd;

            foreach (_AGVIDEO_WNDINFO curWnd in agvideoWnd)
            {
                //Remote wnd
                if (curWnd.Page == CurrentPage)
                {
                    DBReader.GetAllNames.TryGetValue(curWnd.nUID, out userName);
                    curWnd.HWnd.Location = new Point(StartPointX + 250 * loc, pictureBoxRemoteVideo.Height - curWnd.HWnd.Height - 15);
                    curWnd.HWnd.Parent = pictureBoxRemoteVideo;
                    curWnd.HWnd.BringToFront();
                    curWnd.HWnd.Region = regWnd;
                    curWnd.HWnd.Show();
                    curWnd.nameLabel.Text = userName;

                    var ret = new VideoCanvas((ulong)curWnd.HWnd.Handle, curWnd.nUID);
                    ret.channelId = curWnd.channelID;
                    ret.uid = curWnd.nUID;

                    AgoraObject.Rtc.SetupRemoteVideo(ret);
                    loc++;
                }
                else
                {
                    continue;
                }
            }
            panel1.BringToFront();
        }

        private int GetCurrentPage()
        {
            int InCurPage;
            if (MaxInPage > 0 && CurrentPage == agvideoWnd.Count / MaxInPage)
                InCurPage = agvideoWnd.Count % MaxInPage;
            else
                InCurPage = MaxInPage;

            if (InCurPage == 0 && CurrentPage != 0)
            {
                CurrentPage--;
                return GetCurrentPage();
            }

            return InCurPage;
        }

        private void ButtonsState()
        {
            if (MaxInPage > 0)
            {
                int LastPage = agvideoWnd.Count / MaxInPage;
                if (agvideoWnd.Count % MaxInPage == 0)
                    LastPage--;
                if (LastPage > 0)
                {
                    if (CurrentPage == 0)
                    {
                        TranslPrevPage.Hide();
                        TranslPage.Show();
                        return;
                    }
                    else if (CurrentPage == LastPage)
                    {
                        TranslPage.Hide();
                        TranslPrevPage.Show();
                        return;
                    }
                    else
                    {
                        TranslPage.Show();
                        TranslPrevPage.Show();
                        return;
                    }
                }
            }
            TranslPage.Hide();
            TranslPrevPage.Hide();
            return;
        }

        private void BuildWndPages()
        {
            int page = 0; int pointer = MaxInPage;
            for (int Index = 0; Index < agvideoWnd.Count; Index++)
            {
                _AGVIDEO_WNDINFO curWnd = agvideoWnd[Index];
                curWnd.Page = page;
                agvideoWnd[Index] = curWnd;
                pointer--;
                if (pointer == 0)
                {
                    pointer = MaxInPage;
                    page++;
                }
            }
            if (CurrentPage > page)
                CurrentPage = page;
        }

        public void InitNewWnd(string channelId, uint uid)
        {
            Color DefColor = Color.FromArgb(15,15,15);
            int size = 30;
            //New user has joined
            _AGVIDEO_WNDINFO newWnd = new _AGVIDEO_WNDINFO();
            newWnd.nIndex = agvideoWnd.Count;
            newWnd.nUID = uid;
            newWnd.channelID = channelId;
            newWnd.Page = 0;

            #region Wnd
            newWnd.HWnd = new PictureBox();
            newWnd.HWnd.Size = new Size(180, 130);
            newWnd.HWnd.BackgroundImageLayout = ImageLayout.Stretch;
            newWnd.HWnd.BackgroundImage = Properties.Resources.video_call_empty;
            newWnd.HWnd.BackColor = Color.FromArgb(15, 15, 15);
            newWnd.HWnd.Anchor = AnchorStyles.Bottom;
            #endregion
            #region MuteOther
            newWnd.MuteOther = new PictureBox();
            newWnd.MuteOther.Parent = newWnd.HWnd;
            newWnd.MuteRemoteAudio(newWnd.IsMuted);
            newWnd.MuteOther.Size = new Size(size, size);
            newWnd.MuteOther.Location = new Point(newWnd.HWnd.Left + 10, newWnd.HWnd.Bottom - size);
            newWnd.MuteOther.BackgroundImageLayout = ImageLayout.Stretch;
            newWnd.MuteOther.BackgroundImage = Properties.Resources.rsi_voice_100_white;
            newWnd.MuteOther.BackColor = DefColor;
            newWnd.MuteOther.Cursor = Cursors.Hand;
            #endregion
            #region UserVolume
            newWnd.userVolume = new();
            newWnd.userVolume.Visible = false;
            newWnd.userVolume.Parent = newWnd.HWnd;
            newWnd.userVolume.Location = new Point(newWnd.MuteOther.Location.X + newWnd.MuteOther.Width, newWnd.MuteOther.Location.Y + 4);
            newWnd.userVolume.BackColor = DefColor;
            newWnd.userVolume.Maximum = 100;
            newWnd.userVolume.Minimum = 0;
            newWnd.userVolume.Value = 100;
            newWnd.userVolume.FillBackColor = Color.DimGray;
            newWnd.userVolume.Cursor = Cursors.Hand;

            #endregion
            #region HideOther
            newWnd.HideOther = new PictureBox();
            newWnd.HideOther.Parent = newWnd.HWnd;
            newWnd.HideRemoteVideo(newWnd.IsHidden);
            newWnd.HideOther.Size = new Size(size, size);
            newWnd.HideOther.Location = new Point(newWnd.HWnd.Right - 10- size, newWnd.HWnd.Bottom - size);
            newWnd.HideOther.BackgroundImageLayout = ImageLayout.Stretch;
            newWnd.HideOther.BackColor = DefColor;
            newWnd.HideOther.Cursor = Cursors.Hand;
            //newWnd.HideOther.Hide();
            #endregion
            #region NameLabel
            newWnd.nameLabel = new Label();
            newWnd.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            newWnd.nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            newWnd.nameLabel.Size = new Size(100, size);
            newWnd.nameLabel.Font = new Font(FontFamily.GenericSansSerif, 12);
            newWnd.nameLabel.ForeColor = Color.White;
            newWnd.nameLabel.Parent = newWnd.HWnd;
            newWnd.nameLabel.BackColor = DefColor;
            newWnd.nameLabel.Location = new Point(0, newWnd.HWnd.Bottom - size);
            newWnd.nameLabel.Dock = DockStyle.Bottom;
            newWnd.nameLabel.Invalidate();
            //newWnd.nameLabel.Hide();
            #endregion
            #region Panel
            newWnd.ctrlPanel = new TableLayoutPanel();
            newWnd.ctrlPanel.Parent = newWnd.HWnd;
            newWnd.ctrlPanel.Size = new Size(200, size);
            newWnd.ctrlPanel.BackColor = DefColor;
            newWnd.ctrlPanel.Location = new Point(newWnd.HWnd.Left, newWnd.HWnd.Bottom - size);
            //newWnd.ctrlPanel.Hide();
            #endregion
            #region Events
            newWnd.MuteOther.Click += newWnd.OnMute;
            newWnd.HideOther.Click += newWnd.OnHide;
            newWnd.HWnd.MouseEnter += newWnd.ShowPanel;
            //newWnd.HWnd.MouseLeave += newWnd.HidePanel;
            //newWnd.ctrlPanel.MouseLeave += newWnd.HidePanel;
            //newWnd.HideOther.MouseLeave += newWnd.HidePanel;
            //newWnd.MuteOther.MouseLeave += newWnd.HidePanel;
            newWnd.userVolume.ValueChanged += newWnd.volumeScroll;
            #endregion

            agvideoWnd.Add(newWnd);
        }

        public void RemoveWnd(uint uid)
        {
            foreach (_AGVIDEO_WNDINFO curWnd in agvideoWnd)
            {
                if (curWnd.nUID == uid)
                {
                    agvideoWnd.Remove(curWnd);
                    Invoke((MethodInvoker)delegate { curWnd.HWnd.Dispose(); });
                    GC.Collect();
                    return;
                }
            }
        }
        private void HideAllWnd()
        {
            foreach (_AGVIDEO_WNDINFO curWnd in agvideoWnd)
            {
                curWnd.HWnd.Hide();
            }
        }
        public void ClearWnd()
        {
            foreach (_AGVIDEO_WNDINFO curWnd in agvideoWnd)
            {
                try
                {
                    if (curWnd.HWnd.IsHandleCreated && !curWnd.HWnd.IsDisposed)
                        Invoke((MethodInvoker)delegate { curWnd.HWnd.Dispose(); });
                }
                catch
                {

                }
            }
            agvideoWnd.Clear();
            GC.Collect();
        }
        private void TransPrevPage_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            if (CurrentPage >= 0)
                RebindVideoWnd();
            else
                CurrentPage = 0;
        }
        private void TranslPage_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            if (CurrentPage <= agvideoWnd.Count / MaxInPage && agvideoWnd.Count - CurrentPage * MaxInPage > 0)
                RebindVideoWnd();
            else
                CurrentPage--;
        }
        #endregion
    }
}
