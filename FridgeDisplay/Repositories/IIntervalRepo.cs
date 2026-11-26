using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public interface IIntervalRepository
    {
        Interval GetInterval();
        Interval UpdateInterval(Interval interval);
        Interval ResetInterval();
    }
}
