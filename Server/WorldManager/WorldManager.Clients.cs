using Arch.Core;
using Core.Components;
using Core.Factories;
using Riptide;

namespace Server.WorldManager;

public sealed partial class WorldManager
{
    // TODO: Load player from save if they have connected before. Otherwise, create new player.
    public void PlayerConnected(object? sender, ClientConnectedEventArgs e)
    {
        PlayerFactory.Create(_world, e.Id);
    }

    // TODO: Save player data so it can be reloaded later
    // TODO: Should this be a system instead of being managed here like this?
    public void PlayerDisconnected(object? sender, ClientDisconnectedEventArgs e)
    {
        // Searches for the disconnected player and removes them from the world.
        var queryDesc = new QueryDescription().WithAll<Player, ClientControllerId>();
        _world.Query(in queryDesc, (Entity entity, ref ClientControllerId controllerId) =>
        {
            if (controllerId.Id == e.Id)
            {
                _savePlayer(entity);
                _world.Destroy(entity);
            }
        });
    }
}