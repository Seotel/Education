using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace JintLibrary.JintWrapper
{
    [Serializable()]
    public class DataOutcome
    {
        [DataMember(Name = "isSuccess")]
        public bool IsSuccess { get; set; }
    }
}
