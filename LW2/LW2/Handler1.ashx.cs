using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace LW2
{
    /// <summary>
    /// Сводное описание для Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        WebSocket socket;
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            while (socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(2000);
                await Send();
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
        private async Task Send()
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString()));
            await socket.SendAsync(sendbuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}