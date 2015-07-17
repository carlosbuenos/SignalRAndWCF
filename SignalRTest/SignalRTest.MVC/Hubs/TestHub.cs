using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System.Collections.Concurrent;

namespace SignalRTest.MVC.Hubs
{
    public class TestHub : Hub
    {
        public static ConcurrentDictionary<String, String> UsersOnline = new ConcurrentDictionary<String, String>();

        public override System.Threading.Tasks.Task OnConnected()
        {
            UsersOnline.TryAdd(Context.ConnectionId, Context.User.Identity.GetUserId());
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            String UserIdThatLeft = String.Empty;
            UsersOnline.TryRemove(Context.ConnectionId, out UserIdThatLeft);
            return base.OnDisconnected(stopCalled);
        }

        public void LongRunningTask(String ConnectionId)
        {
            using (var svc = new Services.MyWebService.SignalRTestServiceClient())
            {
                svc.LongRunningTask(ConnectionId);
            } // end using
        } // end LongRunningTask
    } // end class TestHub
} // end namespace