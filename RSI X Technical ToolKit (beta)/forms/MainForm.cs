using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor;
//using agorartc;
using RSI_X_Desktop.forms;

namespace RSI_X_Desktop.forms
{
    public partial class MainForm : Form
    {
#if DEBUG
        //private HelpingClass.DBTest DBTest = new();
#endif
        static private string userName = "";
        
        AppDomain currentDomain = AppDomain.CurrentDomain;
        private bool bMouseDown = false;
        Point MouseOffset = new Point(0, 0);

        public MainForm()
        {
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            DBReader.Connect();

#if DEBUG
            //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
            //TODO: Delete this
            //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
            //DBReader.ConnectClear("1");
            //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
            //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
#endif
        }

        private void MyHandler(object sender, UnhandledExceptionEventArgs e)
        {
            // Send 'exit' when exception
            if (DBReader.IsConnected)
                DBReader.LeaveRoom();
        }



        private void formTheme1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            string code = NewTextBox.Text.Remove(4,1);
            if (AgoraObject.JoinRoom(code))
            {
                Hide();
                Xtractor TransLater = new();
                AgoraObject.CurrentForm = CurForm.FormTransLater;
                TransLater.Show(this);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            AddMouseEvents(this);
            //AddMouseEvents(pictureBox1);
            AddMouseEvents(dungeonHeaderLabel1);
            AddMouseEvents(LocalTimeLabel);
            AddMouseEvents(TimeLabel);
        }
        private void ChangeMouseState(object sender, MouseEventArgs e)
        {
            bMouseDown = !bMouseDown;
            MouseOffset = e.Location;
        }
        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (bMouseDown)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - MouseOffset.X, p.Y - MouseOffset.Y);
            }
        }

        private void AddMouseEvents(Control Obj)
        {
            Obj.MouseUp += ChangeMouseState;
            Obj.MouseDown += ChangeMouseState;
            Obj.MouseMove += WindowMove;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("HH:mm");
            string i = DateTime.Now.ToString("MM");
            string dm = "";
            switch (i)
            {
                case "01": dm = "January"; break;
                case "02": dm = "February"; break;
                case "03": dm = "March"; break;
                case "04": dm = "April"; break;
                case "05": dm = "May"; break;
                case "06": dm = "June"; break;
                case "07": dm = "July"; break;
                case "08": dm = "August"; break;
                case "09": dm = "September"; break;
                case "10": dm = "October"; break;
                case "11": dm = "November"; break;
                case "12": dm = "December"; break;
            }
            LocalTimeLabel.Text = DateTime.Now.DayOfWeek.ToString() + ", " + dm + " " + DateTime.Now.ToString("dd, yyyy");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            NewTextBox.Clear();
            GC.Collect();
        }

        private void bigTextBox1_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    NewTextBox.Invalidate();
            //    AgoraObject.CurrentForm = CurForm.None;
            //}
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        static public void UpdateName(string name) 
        { userName = name; }

        static public string GetUserName() => userName;

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //для того, чтобы форма не вылетала при сворачивании ее в панель инстурментов
            //НЕ УДАЛЯТЬ!
            if (this.WindowState == FormWindowState.Minimized)
            {
                NewTextBox.Hide();
            }
            else if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                NewTextBox.Show();
            }
        }

        private void NewTextBox_Click(object sender, EventArgs e)
        {
            NewTextBox.SelectionStart = 0;
        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
