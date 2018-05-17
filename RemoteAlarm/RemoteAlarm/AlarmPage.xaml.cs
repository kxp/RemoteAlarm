using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;


namespace RemoteAlarm
{
	public partial class AlarmPage : ContentPage
    {
        //Private stuff

        //Local list to populate the UI
        private List<EColor> _colors;
        private List<DaySelection> _selectedDays;

        /// <summary>
        /// Gets or sets the alarm time.
        /// </summary>
        /// <value>
        /// The alarm time.
        /// </value>
        /// <version author="Andre Cachopas" date="17/05/2018" version="1.0" machine="KLAP"></version>
        public TimeSpan AlarmTime { get; set; }

        
	    public AlarmPage()
		{
            Initialize(Content);
			InitializeComponent();

            PopulateList();
            AlarmPicker.Time = new TimeSpan();
		    ListView.ItemsSource = _selectedDays;
		    SelectedColors.ItemsSource = _colors;
		}

	    public void Initialize(View content)
	    {
        }

        //Private Methods

        /// <summary>
        /// Populates the list, In case we didnt create one before.
        /// </summary>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        private void PopulateList()
        {
            _selectedDays = new List<DaySelection>();
            for (int i = 0; i < 7; i++)
            {
                //Not pretty but works for what we want
                DaySelection newDaySelection = new DaySelection((EWeekDay)i);
                _selectedDays.Add(newDaySelection);
            }

            _colors = new List<EColor>();
            for (int i = 0; i < Enum.GetNames(typeof(EColor)).Length; i++)
            {
                _colors.Add((EColor)i);
            }

        }

        //Private events

        /// <summary>
        /// Handles the OnPropertyChanged event of the TimePicker control. When we change the time this event is called.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        private void TimePicker_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
            AlarmTime = AlarmPicker.Time;
	    }

        /// <summary>
        /// Handles the OnPropertyChanged event of the WeekPicker control. NOT USED!
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        private void WeekPicker_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	        //DateTime aa = WeekPicker.Date;
	    }

        /// <summary>
        /// Handles the OnClicked event of the Refresh control. Refreshes the current settings from the server.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version> 
        /// <exception cref="NotImplementedException"></exception>
        private void Refresh_OnClicked(object sender, EventArgs e)
	    {
            
            throw new NotImplementedException();
	    }

        /// <summary>
        /// Handles the OnClicked event of the Apply control. Sends the settings to the server.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version> 
        /// <exception cref="NotImplementedException"></exception>
        private void Apply_OnClicked(object sender, EventArgs e)
	    {
            Debug.WriteLine("Alarm time:{0}",AlarmTime);
	        Debug.WriteLine("Selected color:{0}", (EColor) SelectedColors.SelectedItem);

	        foreach (DaySelection daySelection in _selectedDays)
	        {
	            Debug.WriteLine("Day:{0} yes{1}", daySelection.Weekday, daySelection.Active);
	        }
	    }


	}
}
