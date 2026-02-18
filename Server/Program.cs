namespace Server;

public static class Program
{
    public static void Main(String[] args)
    {
        // TODO: Get these from a config file instead of hard coding
        ushort port = 26769;
        ushort maxClients = 16;
        var server = new Network.Server(port, maxClients);

        var manager = new WorldManager.WorldManager();

        var deltaTime = 0.0f;
        var iterStartTime = 0.0f;
        
        while (true)
        {
            iterStartTime = DateTime.Now.Millisecond; // It kept telling me to put this in local scope.
            
            server.Update(); // Server needs to update first so the GameManager has the most up-to-date data.
            manager.Update(deltaTime);
            
            // I really hope this is fast enough. I imagine it might start getting bad if the world is large enough.
            server.SyncClientsWorldState(manager.SerializeToBytes());
            
            deltaTime = (DateTime.Now.Millisecond - iterStartTime)/1000.0f;
        }
    }
}