using Arch.Bus;
using Arch.Core;
using Arch.Core.Extensions;
using Core.Components;

namespace Server;

public ref struct ShootEvent
{
    public ref Entity attacker;
    public ref Entity victim;

    public int amount;
}

public static class EventBusTest
{
    [Event]
    public static void OnShootEvent(ref ShootEvent @event)
    {
        if (!@event.victim.Has<Health>()) return;
        
        ref Health health = ref @event.victim.Get<Health>();
        health.Value = health.Value - @event.amount;
    }
}

public static class Program
{
    public static void Main(String[] args)
    {
        var world = World.Create();

        var player = world.Create(new Health(10,10,0));
        var enemy = world.Create(new Health(10,10,0));
        
        Console.Out.WriteLine($"Player ({player.Id}) Health: {player.Get<Health>().Value}");
        Console.Out.WriteLine($"Enemy ({enemy.Id}) Health: {enemy.Get<Health>().Value}");
        
        var shootEvent = new ShootEvent
        {
            attacker=ref player, 
            victim=ref enemy, 
            amount=5
        };
        EventBus.Send(ref shootEvent);
        Console.Out.WriteLine("I've shot you!");
        
        Console.Out.WriteLine($"Player ({player.Id}) Health: {player.Get<Health>().Value}");
        Console.Out.WriteLine($"Enemy ({enemy.Id}) Health: {enemy.Get<Health>().Value}");
    }
}