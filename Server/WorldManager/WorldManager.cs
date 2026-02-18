using Arch.Buffer;
using Arch.Core;
using Arch.Persistence;
using Arch.System;
using Core.Systems;

namespace Server.WorldManager;

public sealed partial class WorldManager
{
    private Group<float> _systems;
    private readonly World _world;

    private ArchBinarySerializer _serializer;
    private CommandBuffer _commandBuffer;

    public WorldManager()
    {
        _serializer = new ArchBinarySerializer();
        _commandBuffer = new CommandBuffer();
        
        _world = World.Create();
        _systems = new Group<float>( "WorldSystems",
            new HealthSystem(_world),
            new MovementSystem(_world)
        );
        _systems.Initialize();
    }

    ~WorldManager()
    {
        SaveGameBeforeShutdown();
        
        // TODO: Should these happen in the previous function?
        _systems.Dispose();
        _world.Dispose();
        World.Destroy(_world);
    }

    public void Update(float deltaTime = 0.1f)
    {
        _systems.BeforeUpdate(in deltaTime);
        _systems.Update(in deltaTime);
        _systems.AfterUpdate(in deltaTime);

        _world.TrimExcess();
    }

    public byte[] SerializeToBytes()
    {
        return _serializer.Serialize(_world);
    }
}