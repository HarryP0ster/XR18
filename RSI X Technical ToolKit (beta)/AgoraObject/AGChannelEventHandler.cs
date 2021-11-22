using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agorartc;
using System.Windows.Forms;


namespace RSI_X_Desktop
{
    public enum CHANNEL_TYPE
    {
        CHANNEL_SRC = 255,
        CHANNEL_TRANSL,
        CHANNEL_DEST,
        CHANNEL_HOST,
    };
    public class AGChannelEventHandler : IRtcChannelEventHandlerBase
    {
        internal List<uint> hostBroacsters = new();
        private IFormHostHolder form;
        public CHANNEL_TYPE chType { get; private set; }

        public AGChannelEventHandler(IFormHostHolder form_new, CHANNEL_TYPE new_chType)
        {
            form = form_new;
            chType = new_chType;
        }
        public override void OnChannelWarning(string channelId, int warn, string msg)
        {
        }

        public override void OnChannelError(string channelId, int err, string msg)
        {
        }

        public override void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    AgoraObject.UpdateClientID(uid.ToString());
                    AgoraObject.UpdateRoomName(channelId);
                    //System.Threading.Thread.Sleep(1000);
                    DBReader.JoinRoom();
                    
                    break;
                case CHANNEL_TYPE.CHANNEL_HOST:
                case CHANNEL_TYPE.CHANNEL_DEST:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }

        public override void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    AgoraObject.UpdateClientID(uid.ToString());
                    AgoraObject.UpdateRoomName(channelId);
                    DBReader.LeaveRoom();
                    DBReader.JoinRoom();

                    ////System.Threading.Thread.Sleep(1000);
                    //DBReader.JoinRoom();

                    break;
                case CHANNEL_TYPE.CHANNEL_HOST:
                case CHANNEL_TYPE.CHANNEL_DEST:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }


        public override void OnChannelLeaveChannel(string channelId, RtcStats stats)
        {
            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    ((TransLater)form).ClearWnd();
                    DBReader.LeaveRoom();
                    break;
                case CHANNEL_TYPE.CHANNEL_HOST:
                case CHANNEL_TYPE.CHANNEL_DEST:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }

        public override void OnChannelClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole,
            CLIENT_ROLE_TYPE newRole)
        {
        }

        public override void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
            switch (chType) 
            {
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    Console.WriteLine("OnUserJoined");

                    if (form.RemoteWnd == IntPtr.Zero) return;
                    UserInfo info;
                    AgoraObject.Rtc.GetUserInfoByUid(uid, out info);

                    ((TransLater)form).InitNewWnd(channelId, uid);
                    ((TransLater)form).RebindVideoWndInvoke();
                    break;
                case CHANNEL_TYPE.CHANNEL_DEST:
                    break;
                case CHANNEL_TYPE.CHANNEL_HOST:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }

            if (chType is CHANNEL_TYPE.CHANNEL_TRANSL)
            {
                //form.ShowRemoteWnd();
            }
        }

        public override void OnChannelUserOffLine(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_HOST:

                    hostBroacsters.Remove(uid);
                    Console.WriteLine("UserOffLine");

                    if (hostBroacsters.Count > 0)
                    {
                        if (form.RemoteWnd == IntPtr.Zero) return;
                        VideoCanvas canv = new ((ulong)form.RemoteWnd, hostBroacsters.Last());
                        canv.renderMode = ((int)RENDER_MODE_TYPE.RENDER_MODE_HIDDEN);
                        canv.channelId = channelId;


                        AgoraObject.Rtc.SetupRemoteVideo(canv);
                    }
                    else
                        form.UpdateRemoteWnd();
                    break;
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    if (form is IFormInterpreterHolder == false) return;

                    ((TransLater)form).RemoveWnd(uid);
                    ((TransLater)form).RebindVideoWndInvoke();
                    break;
                case CHANNEL_TYPE.CHANNEL_DEST:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }
        

        public override void OnChannelConnectionLost(string channelId)
        {
        }

        public override void OnChannelRequestToken(string channelId)
        {
        }

        public override void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
        {
        }

        public override void OnChannelRtcStats(string channelId, RtcStats stats)
        {
        }

        public override void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
        }


        public override void OnChannelRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
        }

        public override void OnChannelRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
        }

        public override void OnChannelRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            
        }

        public override void OnChannelAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public override void OnChannelVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public override void OnChannelAudioSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public override void OnChannelVideoSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public override void OnChannelUserSuperResolutionEnabled(string channelId, uint uid, bool enabled,
            SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        public override void OnChannelActiveSpeaker(string channelId, uint uid)
        {
        }

        public override void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
        }

        public override void OnChannelRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            var formInterpr = (form as TransLater);
            
            //TODO: добавить очистку окон коллег через state == REMOTE_VIDEO_STATE_STOPPED
            switch (state) {
                case REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_DECODING:
                    FirstFrameDecoding(channelId, uid, reason);
                    break;
                case REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STOPPED:
                    VideoStreamHasStopped(channelId, uid, reason);
                    break;
                case REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_FROZEN:
                case REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_FAILED:
                    if (channelId.Contains("HOST"))
                    {
                        formInterpr.LiveIconShowInvoke(show:false);
                    }
                    break;
                case REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STARTING:
                    break;
                default:
                    break;

            }

        }

        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
        private void VideoStreamHasStopped(string channelId, uint uid, REMOTE_VIDEO_STATE_REASON reason)
        {
            UserInfo user;
            AgoraObject.Rtc.GetUserInfoByUid(uid, out user);

            var formInterpr = (form as TransLater);
            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_HOST:
                    if (user.userAccount == "") formInterpr.LiveIconShowInvoke(show: false);
                    break;
                case CHANNEL_TYPE.CHANNEL_DEST:
                    formInterpr.TranslStreamLeaveInvoke(channelId.Split('_')[0]);
                    break;
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }

        private void FirstFrameDecoding(string channelId, uint uid, REMOTE_VIDEO_STATE_REASON reason)
        {
            UserInfo user;
            AgoraObject.Rtc.GetUserInfoByUid(uid, out user);

            VideoCanvas canv;
            var formInterpr = (form as TransLater);

            switch (chType)
            {
                case CHANNEL_TYPE.CHANNEL_HOST:
                    if (form.RemoteWnd == IntPtr.Zero) return;

                    hostBroacsters.Add(uid);
                    canv = new((ulong)form.RemoteWnd, uid);
                    canv.renderMode = (int)RENDER_MODE_TYPE.RENDER_MODE_FIT;
                    canv.channelId = channelId;

                    AgoraObject.Rtc.SetupRemoteVideo(canv);
                    formInterpr.LiveIconShowInvoke(show: true);
                    break;
                case CHANNEL_TYPE.CHANNEL_TRANSL:
                    if (form is IFormInterpreterHolder == false) return;
                    formInterpr.RebindVideoWndInvoke();
                    break;
                case CHANNEL_TYPE.CHANNEL_DEST:
                    if (reason != REMOTE_VIDEO_STATE_REASON.REMOTE_VIDEO_STATE_REASON_INTERNAL ) return;

                    var handler = formInterpr.NewTranslStreamInvoke(user.userAccount, channelId.Split('_')[0]);

                    canv = new((ulong)handler, uid);
                    canv.renderMode = (int)RENDER_MODE_TYPE.RENDER_MODE_FIT;
                    canv.channelId = channelId;

                    AgoraObject.Rtc.SetupRemoteVideo(canv);
                    break;
                case CHANNEL_TYPE.CHANNEL_SRC:
                default:
                    break;
            }
        }
        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|

        public string message = "";

        public override void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, byte[] data, uint length)
        {
            UserInfo name;
            string Message = AgoraObject.utf8enc.GetString(data);

            AgoraObject.Rtc.GetUserInfoByUid(uid, out name);
            string UserName = name.userAccount;
            var formInterpr = (form as TransLater);
            formInterpr.GetMessage(Message, UserName, chType);
        }

        public override void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
        }

        public override void OnChannelMediaRelayStateChanged(string channelId, CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        public override void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        public override void OnChannelRtmpStreamingStateChanged(string channelId, string url,
            RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR errCode)
        {
        }

        public override void OnChannelRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public override void OnChannelTranscodingUpdated(string channelId)
        {
        }

        public override void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
        }

        public override void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            bool isFallbackOrRecover)
        {
        }

        public override void OnChannelConnectionStateChanged(string channelId, CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public override void OnChannelLocalPublishFallbackToAudioOnly(string channelId, bool isFallbackOrRecover)
        {
        }

        public override void OnChannelApiTest(int apiType, string @params)
        {
        }
    }

}
