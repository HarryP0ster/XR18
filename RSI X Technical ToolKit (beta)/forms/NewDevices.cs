using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ReaLTaiizor;
using agorartc;
using RSI_X_Desktop.forms;
using static System.Environment;

namespace RSI_X_Desktop.forms
{
    public partial class NewDevices : Form
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume); //Контроль громкости
        private static int volume = 100;
        public static int Volume { get => volume; }

        private IFormHostHolder workForm = AgoraObject.GetWorkForm;
        private AgoraAudioRecordingDeviceManager audioInDeviceManager;
        private AgoraAudioPlaybackDeviceManager audioOutDeviceManager;
        private AgoraVideoDeviceManager videoDeviceManager;

        public NewDevices()
        {
            InitializeComponent();
        }

        private void formTheme1_Click(object sender, EventArgs e)
        {

        }

        private void NewDevices_Load(object sender, EventArgs e)
        {
            //button1.Location = new Point(button1.Location.X, General.Height - button1.Height - 15);
            //button2.Location = new Point(button2.Location.X, Sound.Height - button2.Height - 15);
            //button3.Location = new Point(button3.Location.X, Sound.Height - button3.Height - 15);
            //button4.Location = new Point(button4.Location.X, Video.Height - button4.Height - 15);
            //button5.Location = new Point(button5.Location.X, Video.Height - button5.Height - 15);
            AgoraObject.Rtc.EnableVideo();

            audioInDeviceManager = AgoraObject.Rtc.CreateAudioRecordingDeviceManager();
            audioOutDeviceManager = AgoraObject.Rtc.CreateAudioPlaybackDeviceManager();
            videoDeviceManager = AgoraObject.Rtc.CreateVideoDeviceManager();

            trackBarSoundIn.Value = audioInDeviceManager.GetDeviceVolume();
            //trackBarSoundOut.Value = audioOutDeviceManager.GetDeviceVolume();

            comboBoxAudioInput.DataSource = getListAudioInputDevices();
            comboBoxAudioOutput.DataSource = getListAudioOutDevices();
            comboBoxVideo.DataSource = getListVideoDevices();

            comboBoxAudioInput.SelectedIndex = getActiveAudioInputDevice();
            comboBoxAudioOutput.SelectedIndex = getActiveAudioOutputDevice();
            comboBoxVideo.SelectedIndex = getActiveVideoDevice();

            getComputerDescription();
        }

        private void getComputerDescription()
        {
            dungeonLabel1.Text = "Версия ОС - " + OSVersion.VersionString;

            if (Is64BitOperatingSystem == true)
            {
                dungeonLabel2.Text = "64 Bit операционная система";
            }
            else
            {
                dungeonLabel2.Text = "32 Bit операционная система";
            }

            dungeonLabel3.Text = "Пользователь - " + UserName;

        }

        private int getActiveAudioInputDevice()
        {
            int id = -1;

            audioInDeviceManager.GetCurrentDeviceInfo(out string idAcvite, out string nameAcitve);

            for (int i = 0; i < audioInDeviceManager.GetDeviceCount(); i++)
            {
                var ret = audioInDeviceManager.GetDeviceInfoByIndex(i, out string name, out string deviceid);
                if (idAcvite == deviceid)
                {
                    id = i;
                    break;
                }

            }
            return id;
        }

        private int getActiveAudioOutputDevice()
        {
            int id = -1;

            audioOutDeviceManager.GetCurrentDeviceInfo(out string idAcvite, out string nameAcitve);

            for (int i = 0; i < audioOutDeviceManager.GetDeviceCount(); i++)
            {
                var ret = audioOutDeviceManager.GetDeviceInfoByIndex(i, out string name, out string deviceid);
                if (idAcvite == deviceid)
                {
                    id = i;
                    break;
                }

            }
            return id;
        }

        private int getActiveVideoDevice()
        {
            int id = -1;

            string idActive = videoDeviceManager.GetCurrentDevice();

            for (int i = 0; i < videoDeviceManager.GetDeviceCount(); i++)
            {
                var ret = videoDeviceManager.GetDeviceInfoByIndex(i, out string name, out string deviceid);
                if (idActive == deviceid)
                {
                    id = i;
                    break;
                }

            }
            return id;
        }

        #region getDevicesList
        private List<string> getListAudioInputDevices()
        {
            List<string> devicesOut = new();

            for (int i = 0; i < audioInDeviceManager.GetDeviceCount(); i++)
            {
                string device, id;

                var ret = audioInDeviceManager.GetDeviceInfoByIndex(i, out device, out id);

                if (ret == ERROR_CODE.ERR_OK)
                    devicesOut.Add(device);
            }
            return devicesOut;
        }

        private List<string> getListAudioOutDevices()
        {
            List<string> devicesOut = new();

            for (int i = 0; i < audioOutDeviceManager.GetDeviceCount(); i++)
            {
                string device, id;

                var ret = audioOutDeviceManager.GetDeviceInfoByIndex(i, out device, out id);

                if (ret == ERROR_CODE.ERR_OK)
                    devicesOut.Add(device);
            }

            return devicesOut;
        }

        private List<string> getListVideoDevices()
        {
            List<string> devicesOut = new();

            for (int i = 0; i < videoDeviceManager.GetDeviceCount(); i++)
            {
                string device, id;

                var ret = videoDeviceManager.GetDeviceInfoByIndex(i, out device, out id);

                if (ret == ERROR_CODE.ERR_OK)
                    devicesOut.Add(device);
            }

            return devicesOut;
        }
        #endregion

        #region ComboBoxEventHandlers
        private void comboBoxAudioInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = ((ComboBox)sender).SelectedIndex;
            string name, id;

            audioInDeviceManager.GetDeviceInfoByIndex(ind, out name, out id);
            //audioInDeviceManager.SetCurrentDevice(id);
        }

        private void comboBoxAudioOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = ((ComboBox)sender).SelectedIndex;
            string name, id;

            audioOutDeviceManager.GetDeviceInfoByIndex(ind, out name, out id);
            //audioOutDeviceManager.SetCurrentDevice(id);
        }

        private void comboBoxVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = ((ComboBox)sender).SelectedIndex;
            string name, id;

            videoDeviceManager.GetDeviceInfoByIndex(ind, out name, out id);
            //videoDeviceManager.SetCurrentDevice(id);
        }


        #endregion

        private void NewDevices_FormClosed(object sender, FormClosedEventArgs e)
        {
            AgoraObject.Rtc.EnableLocalVideo(false);
            TransLater TransForm = AgoraObject.GetTranslatorForm();
            if (TransForm != null)
                TransForm.SetLocalVideoPreview();
            Dispose();
        }

        private void trackBarSoundIn_ValueChanged()
        {
            audioInDeviceManager.SetDeviceVolume(
                trackBarSoundIn.Value);

        }

        private void trackBarSoundOut_ValueChanged(object sender, EventArgs e)
        {
            audioOutDeviceManager.SetDeviceVolume(
                ((TrackBar)sender).Value
                );
        }

        public void SetAudienceSettings()
        {
            materialShowTabControl1.SelectTab(1);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int indIN = comboBoxAudioInput.SelectedIndex;
            string nameIN, idIN;

            audioInDeviceManager.GetDeviceInfoByIndex(indIN, out nameIN, out idIN);
            audioInDeviceManager.SetCurrentDevice(idIN);

            int indOUT = comboBoxAudioOutput.SelectedIndex;
            string nameOUT, idOUT;

            audioOutDeviceManager.GetDeviceInfoByIndex(indOUT, out nameOUT, out idOUT);
            audioOutDeviceManager.SetCurrentDevice(idOUT);

            int indVID = comboBoxVideo.SelectedIndex;
            string nameVID, idVID;

            videoDeviceManager.GetDeviceInfoByIndex(indVID, out nameVID, out idVID);
            videoDeviceManager.SetCurrentDevice(idVID);

            CloseButton_Click(sender, e);
        }

        internal void CloseButton_Click(object sender, EventArgs e)
        {
            TransLater TransForm = AgoraObject.GetTranslatorForm();
            if (TransForm != null)
            {
                Close();
                TransForm.DevicesClosed(this);
            }
            else
            {
                Close();
            }
        }

        private void trackBarSoundOut_ValueChanged()
        {
            SetVolume(trackBarSoundOut.Value);
            if (workForm != null)
                workForm.SetTrackBarVolume(trackBarSoundOut.Value);
        }
        public static void SetVolume(int value)
        {
            volume = value;
            int NewVolume = ((ushort.MaxValue / 100) * value);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));

            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
        public void UpdateSoundTrackBar()
        {
            trackBarSoundOut.Value = volume;
        }
        public void typeOfAlligment(bool sign)
        {
            if (sign == true)
                materialShowTabControl1.Alignment = TabAlignment.Left;
            else
                materialShowTabControl1.Alignment = TabAlignment.Right;
        }
        private void materialShowTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == Video)
            {
                workForm?.RefreshLocalWnd();
                VideoCanvas vc = new((ulong)pictureBoxLocalVideoTest.Handle, 0);
                vc.renderMode = ((int)RENDER_MODE_TYPE.RENDER_MODE_FIT);
                AgoraObject.Rtc.StartPreview();
                AgoraObject.Rtc.SetupLocalVideo(vc);
            }
        }
        private void materialShowTabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == Video)
            {
                workForm?.SetLocalVideoPreview();
            }
        }
    }
}
