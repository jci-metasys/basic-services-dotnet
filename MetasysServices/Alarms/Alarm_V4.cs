using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


    public class Alarm_V4: Alarm
    {   
        public string Description { get; set; }
        public AlarmGeneratorObject AlarmGeneratorObject { get; set; }
        public TriggerValue TriggerValue { get; set; } 
        public string ActivityManagementStatus { get; set; }
    }
    public class ReferencedObject
    {
        public string objectUrl { get; set; }
    }

    public class AlarmGeneratorObject
    {
        public string objectReference { get; set; }
        public ReferencedObject referencedObject { get; set; }
    }

    public class Units
    {
        public string id { get; set; }
        public string title { get; set; }
    }

    public class Schema
    {
        public string type { get; set; }
        public string metasysType { get; set; }
        public Units units { get; set; }
    }

    public class TriggerValue: Measurement
    {
        public string item { get; set; }
        public Schema schema { get; set; }
    }



}
