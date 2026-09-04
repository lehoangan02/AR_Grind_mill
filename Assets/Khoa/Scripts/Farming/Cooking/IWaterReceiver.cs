namespace Khoa.Farming
{
    public interface IWaterReceiver
    {
        bool TryAddWater(float amount);
    }
}
