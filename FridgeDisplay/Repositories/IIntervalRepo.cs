using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public interface IIntervalRepo
    {
        Interval GetInterval();
        Interval UpdateInterval(Interval interval);
        Interval ResetInterval();
    }
}
