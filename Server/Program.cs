using System.Text.RegularExpressions;
using Arch.Buffer;
using Arch.Bus;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.System;
using Core.Components;
using Core.Systems;

namespace Server;


public static class Program
{
    
    public static void Main(String[] args)
    {
        //TODO: This needs to actually be calculated each loop.
        float deltaTime = 0.1f;
        
        var world = World.Create();
        var _systems = new Group<float>( "mainSystems",
            new HealthSystem(world)
            );
        _systems.Initialize();
        
        //TODO: Create a separate thread that handles commands such as closing the server
        while (true)
        {
            
            _systems.BeforeUpdate(in deltaTime);    // Calls .BeforeUpdate on all systems ( can be overriden )
            _systems.Update(in deltaTime);          // Calls .Update on all systems ( can be overriden )
            _systems.AfterUpdate(in deltaTime);     // Calls .AfterUpdate on all System ( can be overriden )
            
            world.TrimExcess();          // Frees unused memory
        }
        
        _systems.Dispose();
        world.Dispose();             // Clearing the world like God in the First Testament
        World.Destroy(world);   
        
    }
}