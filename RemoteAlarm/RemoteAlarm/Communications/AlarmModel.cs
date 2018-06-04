using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RemoteAlarm.Communications
{
    [DataContract]
    public class AlarmModel
    {
        [DataMember]
        public TimeSpan AlarmTime { get; set; }

        [DataMember]
        public List<DaySelection> SelectedDays { get; set; }

        [DataMember]
        public EColor LightColor { get;set; }


        public AlarmModel()
        {
            SelectedDays = new List<DaySelection>();
        }

        public string Serialize()
        {
            string modelSerialized = JsonConvert.SerializeObject(this, Formatting.Indented);

            return modelSerialized;
        }

        public static AlarmModel DeSerialize(string objectData)
        {
            AlarmModel alarmModel = JsonConvert.DeserializeObject<AlarmModel>(objectData);

            return alarmModel;
        }
    }
}