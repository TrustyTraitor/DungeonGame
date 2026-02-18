using Riptide;
using Riptide.Utils;

namespace Server.Network;

public partial class Server
{
    private readonly Riptide.Server _server;
    
    public Server(ushort port, ushort maxClients)
    {
        RiptideLogger.Initialize(Console.WriteLine, true);
        
        _server = new Riptide.Server();
        _server.Start(port, maxClients);
    }
    
    ~Server()
    {
        _server.Stop();
    }
    
    public void Update()
    {
        _server.Update();
    }

    // TODO: Benchmark if this method of syncing clients is fast enough. I hope so...
    public void SyncClientsWorldState(byte[] worldBytes)
    {
        var message = Message.Create(MessageSendMode.Unreliable);
        message.AddBytes(worldBytes);
        
        _server.SendToAll(message);
    }
}