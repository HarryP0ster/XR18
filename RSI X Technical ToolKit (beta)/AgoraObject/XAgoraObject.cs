using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agorartc;

namespace RSI_X_Desktop
{
    class XAgoraObject
    {
        AgoraRtcEngine Rtc;
        AgoraAudioRecordingDeviceManager audioInDeviceManager;

        public bool IsJoin { get; private set; }

        public XAgoraObject() 
        {
            Rtc = AgoraRtcEngine.CreateRtcEngine();
            Rtc.Initialize(new RtcEngineContext(AgoraObject.AppID));
            audioInDeviceManager = Rtc.CreateAudioRecordingDeviceManager();
        }

        public ERROR_CODE SetupInputDevices(int ind) 
        {
            audioInDeviceManager.GetDeviceInfoByIndex(ind, out string nameOUT, out string idOUT);
            return audioInDeviceManager.SetCurrentDevice(idOUT);
        }

        public ERROR_CODE Publish(langHolder langDest) 
        {
            ERROR_CODE res = Rtc.JoinChannel(langDest.token, langDest.langFull, "", 0);

            if (res == ERROR_CODE.ERR_OK)
                IsJoin = true;

            return res;
        }

        public void UnPublish() 
        {
            Rtc.LeaveChannel();
            IsJoin = false;
        }
    }
}
