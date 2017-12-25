using Owin.WebSocket;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

public class LionWebHub : Hub
{
    public void Send(string name, string message)
    {
        // Call the broadcastMessage method to update clients.
        Clients.All.broadcastMessage(name, message);
    }

    public override Task OnConnected()
    {
        Console.WriteLine("connected");
        return base.OnConnected();
    }

    public string ServerMethodName()
    {
        Console.WriteLine("ServerMethodName");
        Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Send(i.ToString(), i.ToString());
            }
        });
        return "My Name Is Toni Montana";
    }
}