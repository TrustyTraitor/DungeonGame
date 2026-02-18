using Riptide;
using Riptide.Utils;

namespace Server.Network;


// TODO: Rework this so it isn't composed but inherited... probably. idk gotta think about it
public partial class Server : Riptide.Server
{
    
    public Server(ushort port, ushort maxClients) :  base()
    {
        RiptideLogger.Initialize(Console.WriteLine, true);
        
        this.Start(port, maxClients);
    }
    
    ~Server()
    {
        this.Stop();
    }

    // TODO: Benchmark if this method of syncing clients is fast enough. I hope so...
    public void SyncClientsWorldState(byte[] worldBytes)
    {
        var message = Message.Create(MessageSendMode.Unreliable);
        message.AddBytes(worldBytes);
        
        this.SendToAll(message);
    }
}