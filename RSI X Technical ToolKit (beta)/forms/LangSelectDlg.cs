using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace RSI_X_Desktop
{
    public partial class LangSelectDlg : Form
    {
        public bool GetOutCode { get; private set; } = false;
        public string NickName { get; private set; } = string.Empty;
        public int RoomIndex { get; private set; } = 0;

        public bool IsCheckBoxMicOn() => CheckBoxMic.Checked;
        public bool IsCheckBoxCamOn() => CheckBoxCam.Checked;

        readonly Color ButtonPushColor = Color.LightGray;
        readonly Color ButtonDefaultColor = Color.FromArgb(165, 37, 37);
        readonly Color ButtonPushColorText = Color.FromArgb(27, 94, 137);
        readonly Color ButtonDefaultColorText = Color.White;
        readonly Color ButtonPushBorderColor = Color.FromArgb(249, 249, 249);
        readonly Color ButtonDefaultBorderColor = Color.FromArgb(192, 0, 0);

        private int selectedTargetLangs;

        private forms.NewDevices devices;

        public LangSelectDlg()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            UpdateRelayLangs(); 
            UpdateTargetLangs();
            UpdateInterpreterRoomCB();

            //textBoxNickName.Text = forms.MainForm.GetUserName();
            CheckBoxName.Checked = forms.MainForm.GetUserName() != "";
            _.Text = AgoraObject.GetComplexToken().GetRoomName + " conference configuration";
        }

        internal static ReaLTaiizor.Controls.SkyButton CreateButton(string text, int height=35, int width=50) => new ReaLTaiizor.Controls.SkyButton()
        {
            Text = text,
            Height = height,
            Width = width,
            Font = new Font("Bahnschrift Condensed", 16)

        };

        private void UpdateRelayLangs()
        {
            var langs = AgoraObject.GetComplexToken();
            var panel = panelRelayButtons;


            ReaLTaiizor.Controls.SkyButton btn;
            //panelRelayButtons.Size = new Size(500, panelRelayButtons.Height);
            for (int i = 0; i < langs.GetTranslLangs.Count; i++)
            {
                var lang = langs.GetTranslLangs[i];
                if (lang.langShort == "HOST") continue;

                btn = CreateButton(lang.langShort);
                btn.Name = "REL" + i.ToString();
                //btn.Font = new Font("Bahnschrift Condensed", 20);
                btn.Cursor = Cursors.Hand;
                btn.Click += ButtonRelay_Click;
                btn.ForeColor = ButtonDefaultColor;
                btn.Dock = DockStyle.Right;
                //btn.Location = new Point(LabelSrc.Location.X + LabelSrc.Width + btn.Width * i, LabelSrc.Location.Y + 15);
                btn.Show();

                panel.Controls.Add(new ReaLTaiizor.Controls.Separator() { Dock = DockStyle.Right, Width=3,LineColor = _.BackColor});
                panel.Controls.Add(btn);
                ButtonRelay_Click(btn, new EventArgs());
            }
        }

        private void UpdateTargetLangs()
        {
            var langs = AgoraObject.GetComplexToken();
            var controls = panelTargetButtons.Controls;
            ReaLTaiizor.Controls.SkyButton btn = new();

            for (int i = 0; i < langs.GetTargetLangs.Count; i++)
            {
                var lang = langs.GetTargetLangs[i];
                if (lang.langShort == "HOST") continue;

                btn = CreateButton(lang.langShort);
                btn.Name = "TAR" + i.ToString();
                //btn.Font = new Font("Bahnschrift Condensed", 20);
                btn.Cursor = Cursors.Hand;                
                btn.Click += ButtonTarget_Click;
                btn.ForeColor = ButtonDefaultColor;
                btn.Dock = DockStyle.Right;
                //btn.Location = new Point(LabelTrg.Location.X + LabelTrg.Width + btn.Width * i, LabelTrg.Location.Y + 15);
                btn.Show();

                controls.Add(new ReaLTaiizor.Controls.Separator() { Dock = DockStyle.Right, Width=3,LineColor = _.BackColor});
                controls.Add(btn);
                ButtonTarget_Click(btn, new EventArgs());
                selectedTargetLangs++;
            }
            ButtonTarget_Click(btn, new EventArgs());
        }

        private void UpdateInterpreterRoomCB() 
        {
            var langs = AgoraObject.GetComplexToken();

            foreach (var lang in langs.GetTranslLangs) 
            {
                comboBoxInterpreterRoom.Items.Add(lang.langShort);
            }

            if (comboBoxInterpreterRoom.Items.Count > 0)
                comboBoxInterpreterRoom.SelectedIndex = 0;
        }

        private void ButtonTarget_Click(object sender, EventArgs e)
        {
            // buttons with name TAR#
            string m_index = ((ReaLTaiizor.Controls.SkyButton)sender).Name[3..];
            int m_intTar = Convert.ToInt32(m_index);

            bool? langActiveT = AgoraObject.GetComplexToken().IsActiveTargetRoomsAt(m_intTar);

            if (langActiveT != null)
            {
                bool langActive = (bool)langActiveT;

                if (selectedTargetLangs == 1 && langActive) return;

                selectedTargetLangs = langActive ?
                    selectedTargetLangs - 1 :
                    selectedTargetLangs + 1;
#if DEBUG
                langHolder lh = AgoraObject.GetComplexToken().GetTargetRoomsAt(m_intTar);
#endif
                AgoraObject.GetComplexToken().SetActiveTargetRoomsAt(m_intTar, !langActive);

                //(sender as ReaLTaiizor.Controls.SkyButton).ForeColor = !langActive ?
                //    ButtonDefaultColor :
                //    ButtonPushColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorA = !langActive ?
                   ButtonDefaultColor :
                   ButtonPushColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorB = !langActive ?
                   ButtonDefaultColor :
                   ButtonPushColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalForeColor = !langActive ?
                   ButtonDefaultColorText :
                   ButtonPushColorText;
                Color color = !langActive ?
                   ButtonDefaultBorderColor :
                   ButtonPushBorderColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorA = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorB = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorC = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorD = color;
            }
        }

        private void ButtonRelay_Click(object sender, EventArgs e)
        {
            // buttons with name REL#
            string s_index = ((ReaLTaiizor.Controls.SkyButton)sender).Name[3..];
            int m_intRel = Convert.ToInt32(s_index);
            bool? langActiveT = AgoraObject.GetComplexToken().IsActiveInterpRoomsAt(m_intRel);

            if (langActiveT != null)
            {
                bool langActive = (bool)langActiveT;
#if DEBUG
                langHolder lh = AgoraObject.GetComplexToken().GetInterpRoomsAt(m_intRel);
#endif
                AgoraObject.GetComplexToken().SetActiveInterpRoomsAt(m_intRel, !langActive);

                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorA = !langActive ?
                   ButtonDefaultColor :
                   ButtonPushColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBGColorB = !langActive ?
                   ButtonDefaultColor :
                   ButtonPushColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalForeColor = !langActive ?
                   ButtonDefaultColorText :
                   ButtonPushColorText;
                Color color = !langActive ?
                   ButtonDefaultBorderColor :
                   ButtonPushBorderColor;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorA = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorB = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorC = color;
                (sender as ReaLTaiizor.Controls.SkyButton).NormalBorderColorD = color;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            NickName = textBoxNickName.Text;

            if (NickName == "") 
            { 
                MessageBox.Show("Your name must be longer");
                return;
            }
            else if (NickName.Length > 16) //If you change this, consider also chaning limit in IChannel
            {
                MessageBox.Show("Your name is too long");
                return;
            }
            else if (NickName == "Your name")
            {
                MessageBox.Show("Invalid name");
                return;
            }
            foreach (var ch in NickName) 
            {
                if (Convert.ToInt32(ch) > 255) 
                {
                    MessageBox.Show("Nickname contains unsupported characters");
                    return;
                }
            }

            forms.MainForm.UpdateName(CheckBoxName.Checked ? NickName : "");

            GetOutCode = true;
            Close();
        }

        private void textBoxNickName_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;
            var actual = tb.Text;
            var disallowed = @"[^0-9A-Za-z-\/_\(\)]";
            var newText = System.Text.RegularExpressions.Regex.Replace(actual, disallowed, string.Empty);

            if (string.CompareOrdinal(tb.Text, newText) != 0)
            {
                var sstart = tb.SelectionStart;
                tb.Text = newText;
                tb.SelectionStart = sstart - 1;
            }
        }

        private void comboBoxInterpreterRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoomIndex = comboBoxInterpreterRoom.SelectedIndex;
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (devices == null || devices.IsDisposed)
            {
                devices = new forms.NewDevices();
                //devices.SetAudienceSettings();
                devices.typeOfAlligment(true);
            }

            if (devices.Visible == false)
            {
                devices.Location = this.Location;
                devices.Show(this);
            }
            //devices = new DevicesForm();
            //devices.Show();
            devices.Focus();
        }

        private void textBoxNickName_Enter(object sender, EventArgs e)
        {
            if (textBoxNickName.Text == "Your name")
                textBoxNickName.Text = "";
        }

        private void textBoxNickName_Leave(object sender, EventArgs e)
        {
            if (textBoxNickName.Text == "")
                textBoxNickName.Text = "Your name";
        }
    }
}
