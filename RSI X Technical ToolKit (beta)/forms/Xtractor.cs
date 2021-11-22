using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agorartc;
using System.Diagnostics;

namespace RSI_X_Desktop.forms
{
    public partial class Xtractor : Form
    {
        public class BtnCmbPair 
        {
            internal ReaLTaiizor.Controls.SkyButton btn;
            ComboBox cmb;
            int indexLang;
            public bool langNotActive { get; private set; } = true;

            public int GetIndexID()
            {
                if (cmb == null)
                    return -1;
                return cmb.SelectedIndex; 
            }

            public int GetIndexLang() { return indexLang; }
            public string GetLang()   { return btn.Text; }
            public void Enable(bool enable) 
            {
                btn.Enabled = enable;
                cmb.Enabled = enable;
            }
            public BtnCmbPair(ReaLTaiizor.Controls.SkyButton btn, ComboBox cmb, int indexLang) 
            {
                this.btn = btn;
                this.cmb = cmb;
                this.indexLang = indexLang;
            }

            public void ButtonRelay_Click(object sender, EventArgs e)
            {
                UpdateColors(sender as ReaLTaiizor.Controls.SkyButton);
            }

            public void UpdateColors(ReaLTaiizor.Controls.SkyButton btn)
            {
                int m_intRel = indexLang;
                bool? langActiveT = AgoraObject.room.IsActiveInterpRoomsAt(m_intRel);

                if (langActiveT != null)
                {
                    langNotActive = (bool)langActiveT;
                    AgoraObject.room.SetActiveInterpRoomsAt(m_intRel, !langNotActive);

                    if (langNotActive)
                    {
                        SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                            Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.FromArgb(45, 45, 45),
                                Color.FromArgb(53, 53, 53));
                    }
                    else
                    {
                        SkyBtnUpdate(btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                            Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.Red,
                            Color.DarkRed);
                    }
                }
            }
        }


        public bool GetOutCode { get; private set; } = false;
        public string NickName { get; private set; } = string.Empty;
        public int RoomIndex { get; private set; } = 0;
        public bool IsPublishing { get; private set; } = false;

        AgoraAudioRecordingDeviceManager audioInDeviceManager;

        private int selectedTargetLangs;
        static readonly Color ButtonPushColor = Color.BurlyWood;

        List<string> devicesOutInd = new();
        List<string> devicesOutName = new();
        List<BtnCmbPair> BtnCmbPairs = new();
        List<Process> XAgora = new();

        public Xtractor()
        {
            InitializeComponent();
            
            label_nameOfConference.Text = AgoraObject.GetComplexToken().GetRoomName;
            audioInDeviceManager = AgoraObject.Rtc.CreateAudioRecordingDeviceManager();

            for (int i = 0; i < audioInDeviceManager.GetDeviceCount(); i++)
            {
                string device, id;

                var ret = audioInDeviceManager.GetDeviceInfoByIndex(i, out device, out id);

                devicesOutName.Add(device);
                devicesOutInd.Add(id);
            }

            UpdateRelayLangs(); 
        }

        internal ReaLTaiizor.Controls.SkyButton CreateButton(string text, int height, int width)
        {
            return new ReaLTaiizor.Controls.SkyButton()
            {
                Text = text,
                Height = height,
                Width = width,
                Font = new Font("Bahnschrift Condensed", 14, FontStyle.Bold),
            };
        }

        private void UpdateRelayLangs()
        {
            var langs = AgoraObject.GetComplexToken();
            var controls = panelRelayButtons.Controls;
            int defHeight = 35;
            int offset = 1;

            ReaLTaiizor.Controls.SkyButton btn;
            ComboBox cmb;
            BtnCmbPair pair;

            for (int i = 0; i < langs.GetTranslLangs.Count; i++)
            {
                var lang = langs.GetTranslLangs[i];
                if (lang.langShort == "HOST") continue;

                btn = CreateButton(lang.langShort, defHeight, 80);
                btn.Name = "REL" + i.ToString();
                btn.Height = 35;
                btn.Font = new Font("Segoe UI Semibold", 12);
                btn.Cursor = Cursors.Hand;
                btn.Location = new Point(24, defHeight * offset);
                //ButtonRelay_Click(btn, new EventArgs());
                //btn.BackColor = ButtonPushColor;
                btn.Show();

                cmb = new ComboBox();
                cmb.Name = "CMB" + i.ToString();
                cmb.Height = defHeight;
                cmb.Width = 450;
                cmb.Font = new Font("Segoe UI Semibold", 12);
                cmb.Cursor = Cursors.Hand;
                cmb.Location = new Point(120, defHeight * offset);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;

                if (devicesOutName.Count > 0)
                {
                    foreach (var dev in devicesOutName)
                        cmb.Items.Add(dev);
                    cmb.SelectedIndex = 0;
                }
                cmb.Show();

                controls.Add(cmb);
                controls.Add(btn);

                pair = new(btn, cmb, i);

                btn.Click += pair.ButtonRelay_Click;
                //cmb.SelectedIndexChanged += pair.Cmb_SelectedIndexChanged;

                BtnCmbPairs.Add(pair);
                offset++;
                ButtonRelay_Click(btn, new EventArgs());
                pair.UpdateColors(btn);
            }
        }

        private void ButtonRelay_Click(object sender, EventArgs e)
        {
            // buttons with name REL#
            string s_index = ((ReaLTaiizor.Controls.SkyButton)sender).Name[3..];
            int m_intRel = Convert.ToInt32(s_index);
            bool? langActiveT = AgoraObject.room.IsActiveInterpRoomsAt(m_intRel);

            if (langActiveT != null)
            {
                bool langActive = (bool)langActiveT;
#if DEBUG
                langHolder lh = AgoraObject.room.GetInterpRoomsAt(m_intRel);
#endif
                AgoraObject.room.SetActiveInterpRoomsAt(m_intRel, !langActive);

                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorA = !langActive ? Xtractor.ButtonPushColor : DefaultBackColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorB = !langActive ? Xtractor.ButtonPushColor : DefaultBackColor;
            }
        }

        internal void UnPublish()
        {
            CancelPublish();

            foreach (var pair in BtnCmbPairs)
            {
                if (pair.langNotActive == false)
                {
                    //pair.ButtonRelay_Click();
                    SkyBtnUpdate(pair.btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                    Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.Red,
                    Color.DarkRed);
                    pair.btn.Refresh();
                }
                pair.Enable(true);
            }
            IsPublishing = false;
            mButton_start.Text = "Start!";
        }

        internal void Publish()
        {
            CancelPublish();
            XAgora = new List<Process>();
            int index = 0;
            foreach (var pair in BtnCmbPairs)
            {
                if (pair.langNotActive == false)
                {

                    int indId = pair.GetIndexID();
                    string ind = devicesOutInd[indId];

                    SkyBtnUpdate(pair.btn, Color.FromArgb(80, 80, 80), Color.FromArgb(64, 64, 64), Color.FromArgb(64, 64, 64),
                        Color.FromArgb(50, 50, 50), Color.White, Color.LightGray, Color.FromArgb(45, 45, 45), Color.DarkOrange,
                        Color.Orange);
                    pair.btn.Refresh();
                    langHolder lh = AgoraObject.room.GetTargetRoomsAt(pair.GetIndexLang() + 1);
                    int id = System.Diagnostics.Process.GetCurrentProcess().Id;

                    List<string> args = new() { lh.token, lh.langFull, ind , id.ToString()};

                    Process proc = new Process();
                    proc.StartInfo.CreateNoWindow = true;
                    proc = System.Diagnostics.Process.Start("appIn.exe", args);
                    System.Threading.Thread.Sleep(60);

                    XAgora.Add(proc);
                    index++;
                }
                pair.Enable(false);
            }
            IsPublishing = true;
            mButton_start.Text = "Stop?";
        }

        private void CancelPublish()
        {
            foreach (var proc in XAgora)
            {
                proc.Kill();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IsPublishing)
                UnPublish();
            else
                Publish();
        }

        private void Xtractor_FormClosed(object sender, FormClosedEventArgs e)
        {
            CancelPublish();
            Owner.Show();
            Owner.Refresh();
        }

        private void mButton_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static void SkyBtnUpdate(ReaLTaiizor.Controls.SkyButton btn, Color BorA, Color BorB, Color BorC, Color BorD, Color Fore, Color ForeShad,
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
    }
}
