
using Microsoft.AspNetCore.SignalR;

namespace ASP_NET_Razor_WorkEF_SignalR.Hubs
{
    public class SignalRServer: Hub
    {
        public void RefreshData()
        {
            Clients.All.SendAsync("ReloadData");
        }
    }
}
