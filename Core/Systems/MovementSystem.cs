using Arch.Core;
using Arch.System;
using Arch.System.SourceGenerator;
using Core.Components;

namespace Core.Systems;

public partial class MovementSystem : BaseSystem<World, float>
{
    public MovementSystem(World world) : base(world) {}

    [Query]
    [All<Position, Velocity>]
    private static void Move(ref Position position, ref Velocity velocity)
    {
        position.X += velocity.X;
        position.Y += velocity.Y;
    }
}