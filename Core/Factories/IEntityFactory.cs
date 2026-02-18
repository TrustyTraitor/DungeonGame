using Arch.Core;

namespace Core.Factories;

public interface IEntityFactory
{
    public static extern Entity Create(in World world);
}