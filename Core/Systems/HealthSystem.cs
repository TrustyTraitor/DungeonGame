using Arch.Buffer;
using Arch.Core;
using Arch.System;
using Arch.System.SourceGenerator;
using Core.Components;

namespace Core.Systems;

public partial class HealthSystem : BaseSystem<World, float>
{
    private CommandBuffer? _commandBuffer;

    public HealthSystem(World world) : base(world) { }

    public override void Initialize()
    {
        _commandBuffer = new CommandBuffer();
    }

    public override void Update(in float delta)
    {
        HealthDisplaySystemQuery(World);
        _commandBuffer?.Playback(World);
    }

    [Query]
    [All<Health, HealthChanged>]
    public void HealthDisplaySystem(Entity entity, ref Health health)
    {
        _commandBuffer?.Remove<HealthChanged>(entity);
        Console.WriteLine(health.Value);
    }
}