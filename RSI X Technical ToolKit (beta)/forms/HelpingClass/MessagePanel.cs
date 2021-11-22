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

namespace RSI_X_Desktop.forms.HelpingClass
{
    public partial class MessagePanelL : System.Windows.Forms.Panel
    {
        public const string MyOwn = "Me";
        const int maxSymbol = 25;
        ChatBubbleLeft labelL;
        ChatBubbleRight labelR;
        Label Sender;
        Label Date;
        int actual_width = 20;
        Control Owner;

        public int ActualWidth
        {
            get => actual_width;
        }
        public MessagePanelL(string text, string sender, Control owner)
        {
            Owner = owner;
            this.AutoSize = true;
            Height = 65;
            Width = 10;
            Sender = new Label(); 
            Date = new Label();
            if (sender == MyOwn)
            {
                labelR = new ChatBubbleRight();
                labelR.SizeAuto = true;
                labelR.SizeAutoW = true;
                labelR.SizeAutoH = true;
                labelR.SizeChanged += Bubble_SizeChanged;

                if (text.Length > 0) labelR.Text += text[0];

                labelR.Text = text;

                for (int i = maxSymbol-1; i < text.Length; i += maxSymbol)
                {
                    labelR.Text = labelR.Text.Insert(i, "\n");
                }

                labelR.Location = new Point(0, Height - labelR.Height);
                Sender.Location = new Point(0, labelR.Location.Y - Sender.Height);
                Sender.TextAlign = ContentAlignment.BottomLeft;
                labelR.Show();
                Controls.Add(labelR);
                Name = "Right";
            }
            else
            {
                labelL = new ChatBubbleLeft();
                labelL.SizeAuto = true;
                labelL.SizeAutoW = true;
                labelL.SizeAutoH = true;
                labelL.SizeChanged += Bubble_SizeChanged;

                if (text.Length > 0) labelL.Text += text[0];

                labelL.Text = text;

                for (int i = maxSymbol-1; i < text.Length; i += maxSymbol)
                {
                        labelL.Text = labelL.Text.Insert(i, "\n");
                }

                labelL.Location = new Point(0, Height - labelL.Height);
                Sender.Location = new Point(0, labelL.Location.Y- Sender.Height);
                Sender.TextAlign = ContentAlignment.BottomLeft;
                labelL.Show();
                Controls.Add(labelL);
                Name = "Left";
            }
            Sender.Text = sender;
            Controls.Add(Sender);
        }

        public void Bubble_SizeChanged(object sender, EventArgs e)
        {
            //foreach (Control ctr in Owner.Controls)
            //{
            //    if (this == ctr)
            //        ctr.Location = new Point(Owner.Width - ActualWidth, ctr.Location.Y);
            //}

            //Owner.Controls.Add(this);

            actual_width = ((Control)sender).Width + 25;

            //foreach (Control ctr in Owner.Controls)
            //{
            //    if (ctr.Name == "Right")
            //        ctr.Location = new Point(ctr.Location.X, ctr.Location.Y - ((Control)sender).Height);
            //    else
            //        ctr.Location = new Point(5, ctr.Location.Y - ((Control)sender).Height);
            //}
            if (Name == "Left")
                Location = new Point(5, Owner.Height - Height);
            else
                Location = new Point(Owner.Width - ActualWidth, Owner.Height - Height);

            AgoraObject.GetTranslatorForm().RebuildChatPanel(Owner);
        }
    }
}
