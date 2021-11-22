
namespace RSI_X_Desktop
{
    partial class Broadcaster
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.localView = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnScreenShare = new System.Windows.Forms.PictureBox();
            this.btnDevices = new System.Windows.Forms.PictureBox();
            this.btnMuteVideo = new System.Windows.Forms.PictureBox();
            this.btnMuteAudio = new System.Windows.Forms.PictureBox();
            this.mButtonClose = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.localView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScreenShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMuteVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMuteAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // localView
            // 
            this.localView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.localView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localView.Location = new System.Drawing.Point(3, 64);
            this.localView.Margin = new System.Windows.Forms.Padding(0);
            this.localView.Name = "localView";
            this.localView.Size = new System.Drawing.Size(1291, 521);
            this.localView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.localView.TabIndex = 0;
            this.localView.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnScreenShare, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDevices, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMuteVideo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMuteAudio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mButtonClose, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 543);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1291, 42);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnScreenShare
            // 
            this.btnScreenShare.BackgroundImage = global::RSI_X_Desktop.Properties.Resources.screen_share;
            this.btnScreenShare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScreenShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenShare.Location = new System.Drawing.Point(135, 3);
            this.btnScreenShare.Name = "btnScreenShare";
            this.btnScreenShare.Size = new System.Drawing.Size(32, 36);
            this.btnScreenShare.TabIndex = 12;
            this.btnScreenShare.TabStop = false;
            this.btnScreenShare.Click += new System.EventHandler(this.btnScreenShare_Click);
            // 
            // btnDevices
            // 
            this.btnDevices.BackgroundImage = global::RSI_X_Desktop.Properties.Resources.rsi_gear_100;
            this.btnDevices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevices.Location = new System.Drawing.Point(89, 3);
            this.btnDevices.Name = "btnDevices";
            this.btnDevices.Size = new System.Drawing.Size(40, 36);
            this.btnDevices.TabIndex = 13;
            this.btnDevices.TabStop = false;
            this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);
            // 
            // btnMuteVideo
            // 
            this.btnMuteVideo.BackgroundImage = global::RSI_X_Desktop.Properties.Resources.rsi_video_call_100;
            this.btnMuteVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMuteVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuteVideo.Location = new System.Drawing.Point(45, 3);
            this.btnMuteVideo.Name = "btnMuteVideo";
            this.btnMuteVideo.Size = new System.Drawing.Size(38, 36);
            this.btnMuteVideo.TabIndex = 11;
            this.btnMuteVideo.TabStop = false;
            this.btnMuteVideo.Click += new System.EventHandler(this.btnMuteVideo_Click);
            // 
            // btnMuteAudio
            // 
            this.btnMuteAudio.BackgroundImage = global::RSI_X_Desktop.Properties.Resources.rsi_microphone_100;
            this.btnMuteAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMuteAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuteAudio.Location = new System.Drawing.Point(3, 3);
            this.btnMuteAudio.Name = "btnMuteAudio";
            this.btnMuteAudio.Size = new System.Drawing.Size(36, 36);
            this.btnMuteAudio.TabIndex = 10;
            this.btnMuteAudio.TabStop = false;
            this.btnMuteAudio.Click += new System.EventHandler(this.btnMuteAudio_Click);
            // 
            // mButtonClose
            // 
            this.mButtonClose.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.mButtonClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButtonClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonClose.Depth = 0;
            this.mButtonClose.HighEmphasis = true;
            this.mButtonClose.Icon = null;
            this.mButtonClose.Location = new System.Drawing.Point(1202, 6);
            this.mButtonClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonClose.Name = "mButtonClose";
            this.mButtonClose.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.mButtonClose.Size = new System.Drawing.Size(85, 30);
            this.mButtonClose.TabIndex = 14;
            this.mButtonClose.Text = "Sign off";
            this.mButtonClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonClose.UseAccentColor = false;
            this.mButtonClose.UseVisualStyleBackColor = true;
            this.mButtonClose.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // Broadcaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.localView);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(740, 480);
            this.Name = "Broadcaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSI X Broadcaster";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Broadcaster_FormClosed);
            this.Load += new System.EventHandler(this.Conference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScreenShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMuteVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMuteAudio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox localView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox btnMuteAudio;
        private System.Windows.Forms.PictureBox btnMuteVideo;
        private System.Windows.Forms.PictureBox btnScreenShare;
        private System.Windows.Forms.PictureBox btnDevices;
        private MaterialSkin.Controls.MaterialButton mButtonClose;
    }
}