using Arch.Core;
using Arch.System;
using Core.Systems;

namespace Server.Server;

public class WorldManager
{
    private Group<float> _systems;
    private World _World;

    public WorldManager()
    {
        _World = World.Create();
        _systems = new Group<float>( "WorldSystems",
            new HealthSystem(_World)
        );
        _systems.Initialize();
    }

    ~WorldManager()
    {
        _systems.Dispose();
        _World.Dispose();
        World.Destroy(_World);
    }

    public void Update(float deltaTime = 0.1f)
    {
        _systems.BeforeUpdate(in deltaTime);
        _systems.Update(in deltaTime);
        _systems.AfterUpdate(in deltaTime);

        _World.TrimExcess();
    }
}