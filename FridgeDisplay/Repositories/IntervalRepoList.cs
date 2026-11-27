using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public class IntervalRepoList : IIntervalRepo
    {
        private Interval _currentInterval;

        public IntervalRepoList()
        {
            _currentInterval = new Interval();
        }

        public Interval GetInterval()
        {
            return _currentInterval;
        }

        public Interval ResetInterval()
        {
            _currentInterval = new Interval();
            return _currentInterval;
        }

        public Interval UpdateInterval(Interval interval)
        {
            if (interval.MinTemperature > interval.MaxTemperature)
            {
                throw new ArgumentException("Minimum temperatur kan ikke være større end maksimum temperatur.");
            }

            if (interval.MinHumidity > interval.MaxHumidity)
            {
                throw new ArgumentException("Minimum luftfugtighed kan ikke være større end maksimum luftfugtighedm.");
            }

            _currentInterval = interval;
            return _currentInterval;
        }
    }
}
