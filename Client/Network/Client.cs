using Riptide;

namespace Client.Network;

// TODO: Rework this so it isn't composed but inherited... probably. idk gotta think about it
public class Client : Riptide.Client
{
    ~Client()
    {
        this.Disconnect();
    }
    
    public void SyncEntityState(byte[] entityBytes)
    {
        var message = Message.Create(MessageSendMode.Unreliable);
        message.AddBytes(entityBytes);
        
        this.Send(message);
    }
}