using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace RSI_X_Desktop.forms.HelpingClass
{
    struct CounterMessagesRoom
    { public int counterMsgRoom { get; set; } }
    struct CounterMessagesChannel
    {  public int counterMsgChannel { get; set; } }
    public struct Message
    {
        //public byte[] img;
        public string img { get; set; }
        public string msg { get; set; }
        public string time { get; set; }
        public string username { get; set; }
    }

    public class FireBaseUpdateEventArgs : EventArgs
    {
        public Message Msg;

        public FireBaseUpdateEventArgs(Message msg) 
        {
            this.Msg = msg;
        }
    }

    public class FireBaseReader : IDisposable
    {
        public delegate void OnMessageEventHandler(object sender, FireBaseUpdateEventArgs arg);
        public event OnMessageEventHandler OnNewMessage;

        private FirebaseClient FBClient = new ("https://rsix-75a27-default-rtdb.europe-west1.firebasedatabase.app/");
        private IObservable<object> observable;
        private IDisposable subscription;

        string path = string.Empty;
        public void SetChannelName(string channel) 
        {
            path = AgoraObject.GetComplexToken().GetRoomName + "/" +
                channel.Replace(".", "") + 
                "_support";
        }
        public async void Connect() 
        {
            var child = FBClient.Child(path);
            var query = await child.OrderByKey()
                .OnceAsync<object>();

            if (query.Count == 0) {
                await child.PutAsync(new CounterMessagesChannel() { counterMsgChannel = 0 });
            }

            observable = child.AsObservable<object>();
            subscription = observable
                .Subscribe(f => Handler(f));
        }
        public async void SendMessage(string message) 
        {
            Message msg = new()
            {
                msg = message,
                time = GetStringDateTime(),
                username = AgoraObject.NickName
            };
            string key = "/" + 
                ((UInt64) DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds).ToString() + 
                "_User";

            try 
            { 
                await FBClient
                    .Child(path + "/" + key)
                    .PutAsync(msg);
                IncremCounter(); 
            }
            catch (Exception e) 
            { System.Windows.Forms.MessageBox.Show(e.Message + "\nFireBase error"); }
        }
        private async void Handler(object response)
        {
            var resp = (response as Firebase.Database.Streaming.FirebaseEvent<object>);

            if (resp.EventType == Firebase.Database.Streaming.FirebaseEventType.Delete ||
                resp.Key == "" )
                return;

            if (resp.Key == "counterMsgChannel")
            {
                int t = Convert.ToInt32(resp.Object);
            }
            else
            {
                Message msg = new();

                if (resp.Object.ToString() == "System.Object")
                {
                    var newMsg = await FBClient
                        .Child(path)
                        .OrderByKey()
                        .EqualTo(resp.Key)
                        .OnceAsync<object>();
                    
                    msg = JsonSerializer.Deserialize<Message>(newMsg.Single().Object.ToString());

                    if (msg.username == AgoraObject.NickName) msg.username = MessagePanelL.MyOwn;
                }
                else 
                {
                    msg = JsonSerializer.Deserialize<Message>(resp.Object.ToString());
                }

                OnNewMessage?.Invoke(this, new FireBaseUpdateEventArgs(msg));
            }
        }
        private async void IncremCounter()
        {
            int cntCh;
            int cntRm;

            var counterCh = await FBClient
                .Child(path)
                .OrderByKey()
                .EqualTo("counterMsgChannel")
                .OnceAsync<object>();

            cntCh = Convert.ToInt32(counterCh.Single().Object);

            FBClient
                .Child(path)
                .PatchAsync(new CounterMessagesChannel() { counterMsgChannel = cntCh + 1 });


            var counterRm = await FBClient
                .Child(AgoraObject.GetComplexToken().GetRoomName)
                .OrderByKey()
                .EqualTo("counterMsgRoom")
                .OnceAsync<object>();

            cntRm = Convert.ToInt32(counterRm.Single().Object);

            FBClient
                .Child(AgoraObject.GetComplexToken().GetRoomName)
                .PatchAsync(new CounterMessagesRoom() { counterMsgRoom = cntRm + 1 });
        }
        private string GetStringDateTime() 
        {
            return DateTime.Now.ToShortDateString().Replace('/', ':');
        }
        public void Dispose() 
        {
            subscription.Dispose();
            this.Dispose();
        }
    }
}