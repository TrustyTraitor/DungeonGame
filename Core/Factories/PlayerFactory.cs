using Arch.Core;
using Core.Components;

namespace Core.Factories;

public class PlayerFactory : IEntityFactory
{
    public static Entity Create(in World world)
    {
        Entity player = world.Create(
            new Player(),
            new Health(100,100,0),
            new Position(),
            new Velocity()
            );
        
        return player;
    }
}