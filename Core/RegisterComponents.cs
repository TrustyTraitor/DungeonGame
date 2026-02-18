using Arch.Core;
using Arch.Core.Utils;
using Core.Components;

namespace Core;

public static class RegisterComponents
{
    // This Ensures that the components are registered in the same order on the client and server.
    public static void Register()
    {
        ComponentRegistry.Add<ClientControllerId>();
        ComponentRegistry.Add<Health>();
        ComponentRegistry.Add<Player>();
        ComponentRegistry.Add<Position>();
        ComponentRegistry.Add<Velocity>();
    }
}