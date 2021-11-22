
namespace RSI_X_Desktop.forms
{
    partial class Ingestor
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
            this.panelRelayButtons = new System.Windows.Forms.Panel();
            this.name_session = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mButton_cancel = new MaterialSkin.Controls.MaterialButton();
            this.mButton_start = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRelayButtons
            // 
            this.panelRelayButtons.AutoScroll = true;
            this.panelRelayButtons.Location = new System.Drawing.Point(4, 45);
            this.panelRelayButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelRelayButtons.Name = "panelRelayButtons";
            this.panelRelayButtons.Size = new System.Drawing.Size(582, 384);
            this.panelRelayButtons.TabIndex = 1;
            // 
            // name_session
            // 
            this.name_session.AutoSize = true;
            this.name_session.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.name_session.ForeColor = System.Drawing.Color.White;
            this.name_session.Location = new System.Drawing.Point(3, 0);
            this.name_session.Name = "name_session";
            this.name_session.Size = new System.Drawing.Size(163, 32);
            this.name_session.TabIndex = 0;
            this.name_session.Text = "Name session";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.name_session, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(582, 36);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelRelayButtons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 88);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 559);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mButton_cancel);
            this.panel1.Controls.Add(this.mButton_start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 520);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 36);
            this.panel1.TabIndex = 3;
            // 
            // mButton_cancel
            // 
            this.mButton_cancel.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.mButton_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButton_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButton_cancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButton_cancel.Depth = 0;
            this.mButton_cancel.HighEmphasis = true;
            this.mButton_cancel.Icon = null;
            this.mButton_cancel.Location = new System.Drawing.Point(501, -3);
            this.mButton_cancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButton_cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButton_cancel.Name = "mButton_cancel";
            this.mButton_cancel.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.mButton_cancel.Size = new System.Drawing.Size(77, 36);
            this.mButton_cancel.TabIndex = 4;
            this.mButton_cancel.Text = "Cancel";
            this.mButton_cancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButton_cancel.UseAccentColor = false;
            this.mButton_cancel.UseVisualStyleBackColor = true;
            this.mButton_cancel.Click += new System.EventHandler(this.mButton_cancel_Click);
            // 
            // mButton_start
            // 
            this.mButton_start.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.mButton_start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mButton_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButton_start.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mButton_start.Depth = 0;
            this.mButton_start.HighEmphasis = true;
            this.mButton_start.Icon = null;
            this.mButton_start.Location = new System.Drawing.Point(426, -2);
            this.mButton_start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mButton_start.MouseState = MaterialSkin.MouseState.HOVER;
            this.mButton_start.Name = "mButton_start";
            this.mButton_start.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.mButton_start.Size = new System.Drawing.Size(67, 36);
            this.mButton_start.TabIndex = 3;
            this.mButton_start.Text = "Start";
            this.mButton_start.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mButton_start.UseAccentColor = false;
            this.mButton_start.UseVisualStyleBackColor = true;
            this.mButton_start.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Ingestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(596, 650);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_64;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Ingestor";
            this.Padding = new System.Windows.Forms.Padding(3, 88, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSI X I-ngestor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ingestor_FormClosed);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelRelayButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label name_session;
        private MaterialSkin.Controls.MaterialButton mButton_cancel;
        private MaterialSkin.Controls.MaterialButton mButton_start;
    }
}