using Core.Factories;
using Riptide;

namespace Server.WorldManager;

public sealed partial class WorldManager
{
    public void PlayerConnected(object? sender, ClientConnectedEventArgs e)
    {
        PlayerFactory.Create(_world);
    }

    public void PlayerDisconnected(object? sender, ClientDisconnectedEventArgs e)
    {
        
    }
}