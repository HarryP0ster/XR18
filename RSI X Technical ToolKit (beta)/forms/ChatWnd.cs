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
using RSI_X_Desktop;
using System.Threading;

namespace RSI_X_Desktop.forms
{
    public partial class ChatWnd : Form
    {
        const int leters_limit = 35;
        int DefPanelWidth = 100;
        int[] scroll_offset = new int[3];
        List<Control>[] messages_list = new List<Control>[3];

        HelpingClass.FireBaseReader FireBase;
        public ChatWnd()
        {
            InitializeComponent();
            foreach (Control ctr in Controls)
            {
                ctr.KeyDown += Enter_KeyDown;
                try
                {
                    ctr.MouseWheel += Scrolled;
                }
                catch
                {

                }
            }
            for (int i = 0; i < 3; i++)
            {
                messages_list[i] = new();
                scroll_offset[i] = 0;
            }
            DefPanelWidth = panel1.Width;
            panel1.Resize += Chat_SizeChanged;
            panel2.Resize += Chat_SizeChanged;
            panel3.Resize += Chat_SizeChanged;

            //foreach (Control ctr in tabPage2.Controls)
            //{
            //    ctr.KeyDown += Enter_KeyDown_General;
            //}
            ButtonsVisibility(false);
        }

        private void ChatWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void chatButtonRight1_Click(object sender, EventArgs e)
        {
            if (bigTextBox1.Text != "")
            {
                AgoraObject.SendMessageToTransl(bigTextBox1.Text);
                AddOwnMessageLocal(bigTextBox1.Text);
                bigTextBox1.Text = "";
            }
        }

        private void Scrolled(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (scroll_offset[materialShowTabControl1.SelectedIndex] + 1 < messages_list[materialShowTabControl1.SelectedIndex].Count)
                    scroll_offset[materialShowTabControl1.SelectedIndex]++;
            }
            else
            {
                if (scroll_offset[materialShowTabControl1.SelectedIndex] - 1 >= 0)
                    scroll_offset[materialShowTabControl1.SelectedIndex]--;
            }
            switch (materialShowTabControl1.SelectedIndex)
            {
                case (0):
                    Chat_SizeChanged(panel1, new EventArgs());
                    break;
                case (1):
                    Chat_SizeChanged(panel2, new EventArgs());
                    break;

                case (2):
                    Chat_SizeChanged(panel3, new EventArgs());
                    break;
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (materialShowTabControl1.SelectedIndex)
            {
                case (0):
                    if (bigTextBox1.Text != "" && e.KeyCode == Keys.Enter)
                    {
                        AgoraObject.SendMessageToTransl(bigTextBox1.Text);
                        AddOwnMessageLocal(bigTextBox1.Text);
                        bigTextBox1.Text = "";
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (scroll_offset[0] + 1 <= messages_list[0].Count)
                            scroll_offset[0]++;
                        Chat_SizeChanged(panel1, new EventArgs());
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (scroll_offset[0] - 1 >= 0)
                            scroll_offset[0]--;
                        Chat_SizeChanged(panel1, new EventArgs());
                    }
                    break;
                case (1):
                    if (bigTextBox2.Text != "" && e.KeyCode == Keys.Enter)
                    {
                        AgoraObject.SendMessageToHost(bigTextBox2.Text);
                        AddOwnMessageGeneral(bigTextBox2.Text);
                        bigTextBox2.Text = "";
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (scroll_offset[1] + 1 <= messages_list[1].Count)
                            scroll_offset[1]++;
                        Chat_SizeChanged(panel2, new EventArgs());
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (scroll_offset[1] - 1 >= 0)
                            scroll_offset[1]--;
                        Chat_SizeChanged(panel2, new EventArgs());
                    }
                    break;
                case (2):
                    if (bigTextBox3.Text != "" && e.KeyCode == Keys.Enter)
                    {
                        FireBase.SendMessage(bigTextBox3.Text);
                        bigTextBox3.Text = "";
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (scroll_offset[2] + 1 <= messages_list[2].Count)
                            scroll_offset[2]++;
                        Chat_SizeChanged(panel3, new EventArgs());
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (scroll_offset[2] - 1 >= 0)
                            scroll_offset[2]--;
                        Chat_SizeChanged(panel3, new EventArgs());
                    }
                    break;
            }
        }

        private void chatButtonRight2_Click(object sender, EventArgs e)
        {
            if (bigTextBox2.Text != "")
            {
                AgoraObject.SendMessageToHost(bigTextBox2.Text);
                AddOwnMessageGeneral(bigTextBox2.Text);
                bigTextBox2.Text = "";
            }
        }

        private void chatButtonRight3_Click(object sender, EventArgs e)
        {
            if (bigTextBox3.Text != "")
            {
                FireBase.SendMessage(bigTextBox3.Text);
                bigTextBox3.Text = "";
            }

        }

        public void chat_NewMessageInvoke(string message, string nickname, CHANNEL_TYPE channel)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate
                    { chat_NewMessage(message, nickname, channel); });
            else
                chat_NewMessage(message, nickname,channel);
        }
        private void chat_NewMessage(string message, string nickname, CHANNEL_TYPE channel) 
        {
            switch (channel)
            {
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    RelocateBubbles(new HelpingClass.MessagePanelL(message, nickname, panel1), panel1, 0);
                    break;
                case CHANNEL_TYPE.CHANNEL_HOST:
                    RelocateBubbles(new HelpingClass.MessagePanelL(message, nickname, panel2), panel2, 1);
                    break;
            }
        }

        public void chat_NewMessageSupInvoke(object sender, HelpingClass.FireBaseUpdateEventArgs arg) 
        {

            if (InvokeRequired)
                Invoke((MethodInvoker)delegate
                { chat_NewMessageSup(sender, arg); });
            else
                chat_NewMessageSup(sender, arg);
        }
        public void chat_NewMessageSup(object sender, HelpingClass.FireBaseUpdateEventArgs arg)
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                    Invoke((MethodInvoker)delegate
                    {  RelocateBubbles(new HelpingClass.MessagePanelL(arg.Msg.msg, arg.Msg.username, panel3), panel3, 2); });
                else
                    RelocateBubbles(new HelpingClass.MessagePanelL(arg.Msg.msg, arg.Msg.username, panel3), panel3, 2);
            }
        }

        private void AddOwnMessageLocal(string msg)
        {
            RelocateBubbles(new HelpingClass.MessagePanelL(msg, HelpingClass.MessagePanelL.MyOwn, panel1), panel1, 0);
        }
        private void AddOwnMessageGeneral(string msg)
        {
            RelocateBubbles(new HelpingClass.MessagePanelL(msg, HelpingClass.MessagePanelL.MyOwn, panel2), panel2, 1);
        }
        private void ChatWnd_Load(object sender, EventArgs e)
        {

        }

        private void RelocateBubbles(Control new_ctr, Control panel, int index)
        {
            panel.Controls.Add(new_ctr);
            messages_list[index].Add(new_ctr);
        }

        public void UpdateFireBase(HelpingClass.FireBaseReader FireBaseReader)
        {
            FireBase = FireBaseReader;
            FireBase.OnNewMessage += chat_NewMessageSupInvoke;
        }

        internal void Chat_SizeChanged(object sender, EventArgs e) //Actually Updates chat wnd
        {
            Control prev_ctr = null;
            ((Control)sender).Controls.Clear();

            int ind;
            if (((Control)sender) == panel1)
                ind = 0;
            else if (((Control)sender) == panel2)
                ind = 1;
            else if (((Control)sender) == panel3)
                ind = 2;
            else
                return;

            var controls = messages_list[ind].ToArray();

            for (int i = messages_list[ind].Count - 1 - scroll_offset[ind]; i >= 0; i--)
            {
                if (prev_ctr != null)
                    controls[i].Location = new Point(controls[i].Location.X, prev_ctr.Location.Y - controls[i].Height);
                else
                    controls[i].Location = new Point(controls[i].Location.X, ((Control)sender).Height - controls[i].Height);
                prev_ctr = controls[i];
                ((Control)sender).Controls.Add(controls[i]);
            }
        }

        internal void ButtonsVisibility(bool state)
        {
            bigTextBox1.Visible = state;
            chatButtonRight1.Visible = state;
            bigTextBox2.Visible = state;
            chatButtonRight2.Visible = state;
            bigTextBox3.Visible = state;
            chatButtonRight3.Visible = state;
        }
    }
}
