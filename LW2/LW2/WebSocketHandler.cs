using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace LW2
{
    public class WebSocketHandler : IHttpHandler
    {

        #region Члены IHttpHandler
        WebSocket socket;
        public bool IsReusable
        {

            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            string s = await Receive();
            await Send(s);
            int i = 0;
            while(socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(2000);
                await Send(i.ToString());
            }
        }
        private async Task<string> Receive()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }
        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(s + " " + DateTime.Now.ToLongTimeString()));
            await socket.SendAsync(sendbuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
        }

        #endregion
    }
}
