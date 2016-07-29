using SnipeBot.UserLogger;
using POGOProtos.Data;
using POGOProtos.Map.Fort;
using POGOProtos.Networking.Responses;
using PokemonGo.RocketAPI;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace SnipeBot.Utils
{
    public static class Events
    {

        public static event MessageHandler OnMessageReceived;
        public delegate void MessageHandler(object sender, LogReceivedArgs e);

        public static async void Log(string sender, string message, Color color)
        {
            OnMessageReceived(null, new LogReceivedArgs() { Sender = sender, Message = message, Color = color });
        }


    }
    public class AsyncManualResetEvent
    {
        private volatile TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();

        public Task WaitAsync() { return m_tcs.Task; }

        public void Set()
        {
            var tcs = m_tcs;
            Task.Factory.StartNew(s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
                tcs, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
            tcs.Task.Wait();
        }

        public void Reset()
        {
            while (true)
            {
                var tcs = m_tcs;
                if (!tcs.Task.IsCompleted ||
                    Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
                    return;
            }
        }
    }
    public class LogReceivedArgs : EventArgs
    {
        public string Sender;
        public string Message;
        public Color Color;
    }

}