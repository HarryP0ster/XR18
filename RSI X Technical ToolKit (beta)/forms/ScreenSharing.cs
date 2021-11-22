using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using agorartc;
using HWND = System.IntPtr;
using MaterialSkin;
using MaterialSkin.Controls;

namespace RSI_X_Desktop
{
    public partial class ScreenSharing : MaterialForm
    {
        private int flag;

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        public ScreenSharing()
        {
            InitializeComponent();
        }

        static IDictionary<HWND, string> applications = ScreenSharing.GetOpenWindows();

        public static IDictionary<HWND, string> GetOpenWindows()
        {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private void ScreenSharing_Load(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;

            for (int number = 0; number < screens.Length; number++)
            {
                screensList.Items.Add(screens[number].DeviceName);
            }

            foreach (var value in applications.Values)
            {
                if (!screensList.Items.Contains(value))
                    screensList.Items.Add(value);
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            int selectedApplicationIndex;

            switch (flag)
            {
                case (0):
                    AgoraObject.EnableScreenCapture();
                    break;
                    
                case (1):
                    selectedApplicationIndex = screensList.SelectedIndex;
                    AgoraObject.EnableWindowCapture(applications.ElementAt(selectedApplicationIndex).Key);
                    break;

                default:
                    break;
            }

            Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedTab.Text)
            {
                case ("Screens"):
                    flag = 0;
                    break;

                case ("Applications"):
                    flag = 1;
                    break;

                default:
                    break;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void screensList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mButtonApply_Click(object sender, EventArgs e)
        {
            int selectedApplicationIndex;

            switch (flag)
            {
                case (0):
                    AgoraObject.EnableScreenCapture();
                    break;

                case (1):
                    selectedApplicationIndex = WindowsList.SelectedIndex;
                    AgoraObject.EnableWindowCapture(applications.ElementAt(selectedApplicationIndex).Key);
                    break;

                default:
                    break;
            }

            Close();
        }

        private void mButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ScreenSharing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Broadcaster broadcaster = new();
            broadcaster.Show();
            this.Hide();
        }
    }
}
