using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.App;
using RemoteAlarm.Communications;
using Xamarin.Forms;


namespace RemoteAlarm
{
	public partial class AlarmPage : ContentPage
	{
	    private const Int32 WeekDays = 7;
        //Private stuff

        //Local list to populate the UI
        private List<EColor> _colors;
        private List<DaySelection> _selectedDays;

        private ClientSide _alarmServer;

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
            
            _alarmServer = ClientSide.Instance;
            PopulateList();
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
            AlarmModel parsedAlarm = null;
            //Initialize the colors picker
            _colors = new List<EColor>();
            for (int i = 0; i < Enum.GetNames(typeof(EColor)).Length; i++)
                _colors.Add((EColor)i);
            //Set the color picker
            SelectedColors.ItemsSource = _colors;
            
            //TODO:This should com from the server!
            string jsonSt = Helper.GetResource();

            if(string.IsNullOrEmpty(jsonSt) == false)
                parsedAlarm = AlarmModel.DeSerialize(jsonSt);

            if (parsedAlarm != null)
            {
                AlarmPicker.Time = AlarmTime = parsedAlarm.AlarmTime;
                _selectedDays = parsedAlarm.SelectedDays;
                SelectedColors.SelectedItem = parsedAlarm.LightColor;
            }
            else
            {
                //if we fail to parse it we initialize it as an empty thing.
                AlarmPicker.Time = new TimeSpan();
                _selectedDays = new List<DaySelection>();

                for (int i = 0; i < WeekDays; i++)
                {
                    //Not pretty but works for what we want
                    DaySelection newDaySelection = new DaySelection((EWeekDay) i);
                    _selectedDays.Add(newDaySelection);
                }
            }
            
            ListView.ItemsSource = _selectedDays;
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
        private async void Refresh_OnClicked(object sender, EventArgs e)
	    {
	        ClientSide client = ClientSide.Instance;
	        await client.RequestAlarm();
	        await client.RequestLight();
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
	        AlarmModel newAlarm = new AlarmModel();
            newAlarm.AlarmTime = AlarmTime;

	        if (SelectedColors.SelectedItem != null)
	        {
	            newAlarm.LightColor = (EColor) SelectedColors.SelectedItem;
	            Debug.WriteLine("Selected color:{0}", (EColor)SelectedColors.SelectedItem);
            }
	        else
	            newAlarm.LightColor = EColor.None;

            newAlarm.SelectedDays =  new List<DaySelection>();
            Debug.WriteLine("Alarm time:{0}",AlarmTime);

	        foreach (DaySelection daySelection in _selectedDays)
	        {
	            Debug.WriteLine("Day:{0} Active:{1}", daySelection.Weekday, daySelection.Active);
                newAlarm.SelectedDays.Add((DaySelection) daySelection.Clone());
	        }

	        string jsonMessage = newAlarm.Serialize();
            Console.WriteLine(jsonMessage);
            ClientSide.Instance.SetAlarm(jsonMessage);
	    }


	}
}
