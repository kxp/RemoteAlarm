using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace RemoteAlarm
{
	public partial class MainPage : ContentPage
	{
	    public TimeSpan AlarmTime { get; set; }

	    public List<DaySelection> SelectedDays { get; set; }

	    
	    public MainPage()
		{
            Initialize(Content);
			InitializeComponent();

            PopulateList();
            AlarmPicker.Time = new TimeSpan();
		    ListView.ItemsSource = SelectedDays;
		}

	    public void Initialize(View content)
	    {
	     

        }

        /// <summary>
        /// Populates the list, In case we didnt create one before.
        /// </summary>
        /// <version author="Andre Cachopas" date="13/05/2018" version="1.0" machine="KLAP"></version>
        private void PopulateList()
	    {
	        SelectedDays = new List<DaySelection>();
	        for (int i = 0; i < 7; i++)
	        {
                //Not pretty but works for what we want
	            DaySelection newDaySelection = new DaySelection((EWeekDay)i);
                SelectedDays.Add(newDaySelection);
	        }
        }


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
	        throw new NotImplementedException();
	    }
	}
}
