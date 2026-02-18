using Riptide;

namespace Server.Network;

// Event passthrough functions due to the underlying server being private.
public partial class Server
{
    #region Client Connections
    public void SubscribeClientConnected(EventHandler<ServerConnectedEventArgs> callback) 
        => _server.ClientConnected +=  callback;

    public void UnsubscribeClientConnected(EventHandler<ServerConnectedEventArgs> callback) 
        => _server.ClientConnected -=  callback;
    #endregion

    #region Client Disconnections
    public void SubscribeClientDisconnected(EventHandler<ServerDisconnectedEventArgs> callback) 
        => _server.ClientDisconnected +=  callback;

    public void UnsubscribeClientDisconnected(EventHandler<ServerDisconnectedEventArgs> callback) 
        => _server.ClientDisconnected -=  callback;
    #endregion

    #region Connection Failed
    public void SubscribeConnectionFailed(EventHandler<ServerConnectionFailedEventArgs> callback) 
        => _server.ConnectionFailed +=  callback;

    public void UnsubscribeClientConnected(EventHandler<ServerConnectionFailedEventArgs> callback) 
        => _server.ConnectionFailed -=  callback;
    #endregion

    #region Message Received
    public void SubscribeMessageReceived(EventHandler<MessageReceivedEventArgs> callback)
        => _server.MessageReceived +=  callback;

    public void UnsubscribeMessageReceived(EventHandler<MessageReceivedEventArgs> callback)
        => _server.MessageReceived -=  callback;
    #endregion
}