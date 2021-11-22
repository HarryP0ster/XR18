using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;
using agorartc;

namespace RSI_X_Desktop
{
    public enum TYPE_SETTINGS
    {
        AUDIENCE,
        BROADCASTER,
        ITERPRETER
    }

    public partial class DevicesForm : Form
    {
        AgoraAudioRecordingDeviceManager audioInDeviceManager;
        AgoraAudioPlaybackDeviceManager audioOutDeviceManager;
        AgoraVideoDeviceManager videoDeviceManager;

        public DevicesForm()
        {
            InitializeComponent();
        }

        private void Devices_Load(object sender, EventArgs e)
        {
            audioInDeviceManager = AgoraObject.Rtc.CreateAudioRecordingDeviceManager();
            audioOutDeviceManager = AgoraObject.Rtc.CreateAudioPlaybackDeviceManager();
            videoDeviceManager = AgoraObject.Rtc.CreateVideoDeviceManager();

            trackBarSoundIn.Value = audioInDeviceManager.GetDeviceVolume();
            trackBarSoundOut.Value = audioOutDeviceManager.GetDeviceVolume();

            comboBoxAudioInput.DataSource = getListAudioInputDevices();
            comboBoxAudioOutput.DataSource = getListAudioOutDevices();
            comboBoxVideo.DataSource = getListVideoDevices();

            comboBoxAudioInput.SelectedIndex = getActiveAudioInputDevice();
            comboBoxAudioOutput.SelectedIndex = getActiveAudioOutputDevice();
            comboBoxVideo.SelectedIndex = getActiveVideoDevice();

            getComputerDescription();

            AgoraObject.Rtc.StartPreview();
            VideoCanvas vc = new((ulong)pictureBoxLocalVideoTest.Handle, 0);
            AgoraObject.Rtc.EnableVideo();
            AgoraObject.Rtc.SetupLocalVideo(vc);
        }

        private void getComputerDescription()
        {
            label5.Text = "Версия ОС - " + OSVersion.VersionString;

            if (Is64BitOperatingSystem == true)
            {
                label6.Text = "64 Bit операционная система";
            }
            else
            {
                label6.Text = "32 Bit операционная система";
            }

            label7.Text = "Пользователь - " + UserName;

        }

        private int getActiveAudioInputDevice()
        {
            int id = -1;

            audioInDeviceManager.GetCurrentDeviceInfo(out string idAcvite, out string nameAcitve);

            for (int i = 0; i < audioInDeviceManager.GetDeviceCount(); i++)
            {
                var ret = audioInDeviceManager.GetDeviceInfoByIndex(i, out string name, out string deviceid);
                if(idAcvite == deviceid)
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

        private void trackBarSoundIn_Scroll(object sender, EventArgs e)
        {
            audioInDeviceManager.SetDeviceVolume(
                ((TrackBar)sender).Value
                );
        }

        private void trackBarSoundOut_Scroll(object sender, EventArgs e)
        {
            audioOutDeviceManager.SetDeviceVolume(
                ((TrackBar)sender).Value
                );
        }

        public void SetAudienceSettings() 
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
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

            Close();
        }

        private void DevicesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AgoraObject.Rtc.EnableLocalVideo(false);
            if (Owner is TransLater)
                ((TransLater)Owner).SetLocalVideoPreview();
            Owner.Show();
            Owner.Refresh();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
