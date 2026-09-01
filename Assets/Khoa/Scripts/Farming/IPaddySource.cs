namespace Khoa.Farming
{
    public interface IPaddySource
    {
        bool HasPaddy { get; }
        bool TryConsumePaddy();
    }
}
