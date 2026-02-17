using System.Text.RegularExpressions;

using Server.Server;

namespace Server;

public static class Program
{
    public static void Main(String[] args)
    {
        var manager = new WorldManager();

        // TODO: Calculate this each loop
        var deltaTime = 0.1f;
        
        while (true)
        {
            manager.Update(deltaTime);
        }
    }
}