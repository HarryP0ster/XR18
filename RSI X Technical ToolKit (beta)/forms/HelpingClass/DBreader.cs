using System;
using System.Collections.Generic;
using System.Text.Json;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;

namespace RSI_X_Desktop
{
    public class EventArgsNewTargetRooms : EventArgs
    {
        public readonly List<string> targetRooms;

        public EventArgsNewTargetRooms(List<string> targetRooms) 
        {
            this.targetRooms = targetRooms;
        }
    };

    public static class DBReader
    {
        public static event EventHandler OnStreamHasStopped;
        public static event EventHandler OnStreamHasStarted;
        public static event EventHandler OnStreamHasChanged;
        public static event EventHandler OnNewTargetRooms;
        public static event EventHandler OnConnect;
        public static event EventHandler OnDisconnect;

        private static readonly SocketIO client = new ("https://secure.rsi.exchange:3222", new SocketIOOptions() { EIO = 4 });

        private static string nickName = "";
        private static string windowRoom = "";
        private static string clientID = "";
        private static string targetRoom = "";

        private static Dictionary<uint, string> TranslNames = new Dictionary<uint, string>();
        private static readonly HashSet<string> StartedStreams = new();
        private static readonly HashSet<string> StoppedStreams = new();

        public static bool IsConnected { get => client.Connected; }
        public static Dictionary<uint, string> GetAllNames { get => TranslNames; }

#if DEBUG
        public static forms.HelpingClass.DBTest dBTest;
#endif
        private static void DebugLog(string msg, bool time, bool separate=true)
        {
#if DEBUG
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            //dBTest.AddLine(msg, time, separate);
#endif
        }

        static DBReader()
        {
            //client.JsonSerializer = new NewtonsoftJsonSerializer(client.Options.EIO);
            //client.OnAny(onAnyMeth);
        }

        public static void Connect()
        {
            client.OnConnected += OnConnected;
            client.OnDisconnected += OnDisconnected;

            client.On("update", response =>
            {
                Update(client, response);
            });
            client.On("streamHasStopped", response =>
            {
                StreamHasStopped(client, response);
            });
            client.On("newTargetRooms", response =>
            {
                newTargetRooms(client, response);
            });
            client.On("streamHasStarted", response =>
            {
                StreamHasStarted(client, response);
            });
            client.On("streamHasChanged", response =>
            {
                StreamHasChanged(client, response);
            });

            client.ConnectAsync();
        }

        private static void UpdateUserInfo()
        {
            nickName = AgoraObject.NickName;
            windowRoom = AgoraObject.RoomName;
            clientID = AgoraObject.ClientID;
            targetRoom = AgoraObject.RoomTarg;
        }

        public static void JoinRoom()
        {
            UpdateUserInfo();
            client.EmitAsync("join", new { clientID, windowRoom, nickName });
            DebugLog(nickName + " with " + clientID + " uid try join to " + windowRoom, true);
        }

        public static void LeaveRoom()
        {
            //await client.DisconnectAsync();
            client.EmitAsync("exit", new { });
            StoppedStreams.Clear();
            StartedStreams.Clear();
            DebugLog("send exit", true);
        }

        public static void StartStreaming()
        {
            UpdateUserInfo();
            client.EmitAsync("streamingStart", new { clientID, windowRoom, nickName, targetRoom });
            DebugLog(nickName + " with " + clientID + " from " + windowRoom + " try start stream to " + targetRoom, true);
        }

        public static void StopStreaming()
        {
            UpdateUserInfo();
            client.EmitAsync("streamingStop", new { nickName, windowRoom, clientID, targetRoom });
            DebugLog(nickName + " with " + clientID + " from " + windowRoom + " try stop stream to " + targetRoom, true);
        }

        public static void ChangeStreaming()
        {
            string prevRoom = targetRoom;
            UpdateUserInfo();
            //await client.EmitAsync("streamingChanging", new { nickName, windowRoom, clientID, targetRoom, prevRoom });
            StartStreaming();
        }

        public static void Exit()
        {
            client.EmitAsync("exit", new { });
            DebugLog("send exit", true);
        }

        public static void Diconnect()
        {
            client.DisconnectAsync();
            DebugLog("Disconnect", true);
        }

        private static void newTargetRooms(SocketIO client, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");

            if (str.GetString() == null || GetRoomCode(e) != AgoraObject.CodeRoom)
                return;

            var targetRooms = e.GetValue(0).GetProperty("targetRooms").EnumerateArray();
            List<string> tarRooms = new();

            DebugLog("new Target Rooms: ", true);
            foreach (var rm in targetRooms) 
            {
                DebugLog(rm.ToString(), false, separate: false);
                tarRooms.Add(GetRoomLang(rm.ToString()));
            }
            DebugLog("|~~~~~~~~~~~~~~~~~~~~|", false);

            EventArgsNewTargetRooms args = new(tarRooms);
            OnNewTargetRooms?.Invoke(client, args);
        }

        private static void OnDisconnected(object sender, string e)
       {
            EventArgs args = new();
            DebugLog("Disconnect", true);
            OnDisconnect?.Invoke(client, args);
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            EventArgs args = new();
            DebugLog("Connect", true);
            OnConnect?.Invoke(client, args);
        }


        private static void StreamHasStopped(SocketIO sender, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");
            var name = e.GetValue(0).GetProperty("nickName").ToString(); ;

            if (str.GetString() == null || GetRoomCode(e) != AgoraObject.CodeRoom ||
                GetRoomLang(str.ToString()) != AgoraObject.RoomLang)
                return;
            
            StoppedStreams.Add(name);
            UpdateSet();

            DebugLog(name + "Has Stopped Stream", true);

            if (str.ToString() != "" && !AgoraObject.IsPublish())
                AgoraObject.CallNameUpdate(new(StartedStreams));

            EventArgs args = new();
            OnStreamHasStopped?.Invoke(client, args);
        }

        private static void StreamHasStarted(SocketIO sender, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");
            var name = e.GetValue(0).GetProperty("nickName").ToString(); ;

            if (str.GetString() == null || GetRoomCode(e) != AgoraObject.CodeRoom ||
                GetRoomLang(str.ToString()) != AgoraObject.RoomLang)
                return;

            if (AgoraObject.IsPublish() == true)
                AgoraObject.CallUnPublish();

            if (StoppedStreams.Contains(name))
                StoppedStreams.Remove(name);

            DebugLog(name + " Has Started Stream", true);
            StartedStreams.Add(name);

            AgoraObject.CallNameUpdate(new(StartedStreams));
            EventArgs args = new();
            OnStreamHasStarted?.Invoke(client, args);

        }

        private static void UpdateSet() 
        {
            StartedStreams.ExceptWith(StoppedStreams);
        }

        private static void StreamHasChanged(SocketIO sender, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");

            if (str.GetString() == null || GetRoomCode(e) != AgoraObject.CodeRoom ||
                GetRoomLang(str.ToString()) != AgoraObject.RoomLang)
                return;

            DebugLog("StreamHasChanged ", true);
            EventArgs args = new();
            OnStreamHasChanged?.Invoke(client, args);

        }

        private static void Update(SocketIO sender, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");

            if (str.GetString() == null || GetRoomCode(e) != AgoraObject.CodeRoom)
                return;

            List<object> tmp = GetClientProperties(e);
            List<string> tarRooms = UpdatePublish(e, tmp);

            DebugLog("Update:", true);
            foreach (var rm in tarRooms) DebugLog("stream in: " + rm, true, separate:false);
            DebugLog("|~~~~~~~~~~~~~~~~~~~~|", false, separate: false);
            DebugLog("Users in session:", false, separate: false);
            foreach (var prop in e.GetValue(0).GetProperty("clients").EnumerateArray()) 
            {
                var uid = prop.GetProperty("user_id").ToString();
                var unm = prop.GetProperty("user_name").ToString();
                DebugLog(" > " + unm + " | uid:" + uid, false, separate: false);
            }
            DebugLog("|~~~~~~~~~~~~~~~~~~~~|", false);

            EventArgsNewTargetRooms args = new(tarRooms);
            OnNewTargetRooms?.Invoke(client, args);
        }

        private static List<string> UpdatePublish(SocketIOResponse e, List<object> interpreters)
        {
            var targetRooms = e.GetValue(0).GetProperty("targetRooms").EnumerateArray();
            List<string> tarRooms = new();

            foreach (var rm in targetRooms)
            {
                tarRooms.Add(rm.GetString().Split('_')[0]);
                foreach (var interpr in interpreters)
                {
                    if (((JsonElement)interpr).GetProperty("room_target").ToString() == rm.ToString())
                    {
                        string name = ((JsonElement)interpr).GetProperty("user_name").ToString();

                        if (name != AgoraObject.NickName)
                            StartedStreams.Add(name);

                        AgoraObject.CallNameUpdate(new(StartedStreams));
                    }
                }
            }
            return tarRooms;
        }

        private static List<object> GetClientProperties(SocketIOResponse e)
        {
            List<object> tmp = new();
            foreach (var prop in e.GetValue(0).GetProperty("clients").EnumerateArray())
            {
                var unm = prop.GetProperty("user_name");
                var rnm = prop.GetProperty("room_name");
                tmp.Add(prop);
            }
            return tmp;
        }

        private static string GetRoomLang(string el)
        {
            return el.Split('_')[0];
        }
        private static string GetRoomName(SocketIOResponse el)
        {
            string RoomCode = el.GetValue(0).GetProperty("Room").ToString();

            return RoomCode.Split('.')[0];

        }
        private static string GetRoomCode(SocketIOResponse el) 
        {
            var RoomCode = new JsonElement();
            try 
            {
                RoomCode = el.GetValue(0).GetProperty("Room");
                return RoomCode.ToString().Split('.')[1];
            }
            catch 
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show("Incorrect room code");
#endif
                return ""; 
            }
        }

        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|
        //|ZZZZZZZZZZZZZZ DB clearing ZZZZZZZZZZZZZZZ|
        //|ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ|

#if DEBUG
        private static string UID;
        public static List<string> UsersID { get; private set; }
        public static readonly string RoomCode = "41559350";
        public static readonly string RoomLang = "ENG";
        //public static event EventHandler OnClear;

        public static void ConnectClear(string uid)
        {
            client.OnConnected += OnConnected2;

            client.On("update", response =>
            {
                Update2(client, response);
            });
            UID = uid;
            client.ConnectAsync();
        }

        private static void OnConnected2(object sender, EventArgs e)
        {
            Join2(UID);
        }

        private static void Update2(SocketIO sender, SocketIOResponse e)
        {
            var str = e.GetValue(0).GetProperty("Room");
            UsersID = new List<string>();

            if (str.GetString() != null && str.GetString().Split('.')[1] == RoomCode)
            {
                var tmp = new List<object>();


                foreach (var prop in e.GetValue(0).GetProperty("clients").EnumerateArray())
                {
                    var uid = prop.GetProperty("user_id").ToString();
                    var unm = prop.GetProperty("user_name").ToString();


                    UsersID.Add(uid + '|' + unm);
                    tmp.Add(uid + " : " + unm);
                    // breakPointHere
                }
                System.Diagnostics.Debugger.Break();
            }

            string uidNick = UsersID.Find(str => str.Split('|')[1] == "nick").Split('|')[0];
            string uidToRemove = UsersID.Find(str => str.Split('|')[0] != uidNick);

            if (uidToRemove != null)
            {
                uidToRemove = uidToRemove.Split('|')[0];
                Join2(uidToRemove);
                leave2();
            }
        }
        public static void Join2(string uid) 
        {
            clientID = uid;
            windowRoom = RoomLang + "_603bc5c4a2dc13." + RoomCode;
            nickName = "nick";
            targetRoom = "";
            while (IsConnected == false) ;

            client.EmitAsync("join", new { clientID, windowRoom, nickName, targetRoom});
        }
        public static async void leave2() 
        {
            await client.EmitAsync("exit", new { });
        }

#endif
        //private static async void onAnyMeth(string msg, SocketIOResponse args)
        //{ 
        //}

        public static void AddTransLater(uint id, string nickName)
        {
            if (!TranslNames.ContainsKey(id))
            {
                TranslNames.TryAdd(id, nickName);
            }
            else
            {
                TranslNames.TryGetValue(id, out string name);
                if (name != nickName)
                {
                    TranslNames.Remove(id);
                    TranslNames.Add(id, nickName);
                }
            }
        }
    }
}
