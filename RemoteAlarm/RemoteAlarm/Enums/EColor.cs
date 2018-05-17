using System.ComponentModel;

namespace RemoteAlarm
{
    /// <summary>
    /// We could replace this with a color picker.
    /// </summary>
    /// <version author="Andre Cachopas" date="15/05/2018" version="1.0" machine="KLAP"></version>
    public enum EColor
    {
        [Description("None")]
        None = 0,           //Off
        [Description("Blue")]
        Blue,
        [Description("Green")]
        Green,
        [Description("Red")]
        Red,
        [Description("Monday")]
        Yellow,
        [Description("Monday")]
        Purple,
        [Description("Monday")]
        Pink,
        [Description("Monday")]
        White
    }
}