using System.Text;

namespace RemoteAlarm
{
    public class DaySelection
    {
        /// <summary>
        /// Gets or sets the weekday.E.G.: Monday tuesday...
        /// </summary>
        /// <value>
        /// The weekday.
        /// </value>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        public EWeekDay Weekday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DaySelection"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        public bool Active { get; set; }
        
        public DaySelection()
        {
            Active = false;
        }

        public DaySelection(EWeekDay weekDay)
        {
            Weekday = weekDay;
            Active = false;
        }
    }
}