namespace Core.Components;

public record struct Health(int Value, int MaxValue, int MinValue);

// A tag component. Added to entities whenever their health value changes.
public record struct HealthChanged();