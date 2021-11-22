
namespace RSI_X_Desktop
{
    partial class ScreenSharing
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mButtonClose = new MaterialSkin.Controls.MaterialButton();
            this.mButtonApply = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.screensList = new MaterialSkin.Controls.MaterialComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.WindowsList = new MaterialSkin.Controls.MaterialComboBox();
            this.panel1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mButtonClose);
            this.panel1.Controls.Add(this.mButtonApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 55);
            this.panel1.TabIndex = 0;
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
            this.mButtonClose.Location = new System.Drawing.Point(636, 9);
            this.mButtonClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonClose.Name = "mButtonClose";
            this.mButtonClose.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.mButtonClose.Size = new System.Drawing.Size(66, 36);
            this.mButtonClose.TabIndex = 3;
            this.mButtonClose.Text = "Close";
            this.mButtonClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonClose.UseAccentColor = false;
            this.mButtonClose.UseVisualStyleBackColor = true;
            this.mButtonClose.Click += new System.EventHandler(this.mButtonClose_Click);
            // 
            // mButtonApply
            // 
            this.mButtonApply.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.mButtonApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButtonApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButtonApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButtonApply.Depth = 0;
            this.mButtonApply.HighEmphasis = true;
            this.mButtonApply.Icon = null;
            this.mButtonApply.Location = new System.Drawing.Point(710, 9);
            this.mButtonApply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButtonApply.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButtonApply.Name = "mButtonApply";
            this.mButtonApply.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.mButtonApply.Size = new System.Drawing.Size(67, 36);
            this.mButtonApply.TabIndex = 2;
            this.mButtonApply.Text = "Apply";
            this.mButtonApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButtonApply.UseAccentColor = false;
            this.mButtonApply.UseVisualStyleBackColor = true;
            this.mButtonApply.Click += new System.EventHandler(this.mButtonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Avalaible monitors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opened windows";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(794, 456);
            this.materialTabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DimGray;
            this.tabPage3.Controls.Add(this.screensList);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(786, 428);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Screen";
            // 
            // screensList
            // 
            this.screensList.AutoResize = false;
            this.screensList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.screensList.Depth = 0;
            this.screensList.Dock = System.Windows.Forms.DockStyle.Top;
            this.screensList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.screensList.DropDownHeight = 174;
            this.screensList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screensList.DropDownWidth = 121;
            this.screensList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.screensList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.screensList.FormattingEnabled = true;
            this.screensList.IntegralHeight = false;
            this.screensList.ItemHeight = 43;
            this.screensList.Location = new System.Drawing.Point(3, 3);
            this.screensList.MaxDropDownItems = 4;
            this.screensList.MouseState = MaterialSkin.MouseState.OUT;
            this.screensList.Name = "screensList";
            this.screensList.Size = new System.Drawing.Size(780, 49);
            this.screensList.StartIndex = 0;
            this.screensList.TabIndex = 2;
            this.screensList.SelectedIndexChanged += new System.EventHandler(this.screensList_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DimGray;
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.WindowsList);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(786, 428);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Applications";
            // 
            // WindowsList
            // 
            this.WindowsList.AutoResize = false;
            this.WindowsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.WindowsList.Depth = 0;
            this.WindowsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.WindowsList.DropDownHeight = 174;
            this.WindowsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowsList.DropDownWidth = 121;
            this.WindowsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.WindowsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WindowsList.FormattingEnabled = true;
            this.WindowsList.IntegralHeight = false;
            this.WindowsList.ItemHeight = 43;
            this.WindowsList.Location = new System.Drawing.Point(3, 3);
            this.WindowsList.MaxDropDownItems = 4;
            this.WindowsList.MouseState = MaterialSkin.MouseState.OUT;
            this.WindowsList.Name = "WindowsList";
            this.WindowsList.Size = new System.Drawing.Size(780, 49);
            this.WindowsList.StartIndex = 0;
            this.WindowsList.TabIndex = 0;
            // 
            // ScreenSharing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.panel1);
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "ScreenSharing";
            this.Text = "ScreenSharing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScreenSharing_FormClosed);
            this.Load += new System.EventHandler(this.ScreenSharing_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialComboBox screensList;
        private MaterialSkin.Controls.MaterialComboBox WindowsList;
        private MaterialSkin.Controls.MaterialButton mButtonClose;
        private MaterialSkin.Controls.MaterialButton mButtonApply;
    }
}