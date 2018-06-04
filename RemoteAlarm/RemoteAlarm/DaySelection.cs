using System;
using System.Text;

namespace RemoteAlarm
{
    public class DaySelection : ICloneable
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

        public override string ToString()
        {
            return Weekday.ToString();
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <version author="Andre Cachopas" date="02/06/2018" version="1.0" machine="KLAP"></version>
        public object Clone()
        {
            DaySelection clonedDaySelection = new DaySelection(this.Weekday, this.Active);
            return clonedDaySelection;
        }

        public DaySelection()
        {
            Active = false;
        }

        public DaySelection(EWeekDay weekDay, bool active = false)
        {
            Weekday = weekDay;
            Active = active;
        }
    }
}