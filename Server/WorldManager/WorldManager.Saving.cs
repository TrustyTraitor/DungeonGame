using Arch.Core;
using Core.Components;

namespace Server.WorldManager;

public partial class WorldManager
{
    // TODO: Save game world to file
    private void SaveGameBeforeShutdown() 
        // TODO: "SaveGame()" needs better name and documentation.
        // This should never be ran while the game is intended to continue running
        // This destroys all connected players after saving them. 
    {
        /*
         * 1. Serialize all players online
         *      - Save each player to file(s)
         *      - Each player should probably have their own file
         * 2. Remove all players from world
         * 3. Serialize world to file
         *
         * Save structure concept:
         * Saves/
         * | - Save1 /
         *   | - Players/
         *     | - player-{uuid}.psave
         *     | - player-{uuid}.psave
         *   | - world.wsave
         *  | - Save2 /
         *     | ...
         */

        var onlinePlayerQuery = new QueryDescription().WithAll<Player>();
        _world.Query(onlinePlayerQuery, (Entity entity) =>
        {
            _savePlayer(entity);
            _commandBuffer.Destroy(entity);
        });
        
        _commandBuffer.Playback(_world);
        
        _saveWorld(_world);
    }
    
    private void _savePlayer(Entity entity)
    {
        // Write Player to save file
        // player-uuid.psave
        var playerBytes = _serializer.Serialize(_world, entity);
        
        // TODO: Save to file
    }

    private void _saveWorld(World world)
    {
        var worldBytes = _serializer.Serialize(world);
        
        // TODO: Save to file
    }
    
}