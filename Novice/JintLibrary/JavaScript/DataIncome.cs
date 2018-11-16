using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace JintLibrary.JintWrapper
{
    [Serializable()]
    public class DataIncome
    {
        public DataIncome(string scriptName)
        {
            this.FunctionName = "fnExecute";
            this.Script = new ScriptFileInfo() { Extention = ".js", Name = scriptName, Path = string.Empty };
        }

        [XmlIgnore]
        public ScriptFileInfo Script { get; protected set; }

        [XmlIgnore]
        public string FunctionName { get; set; }


        [DataMember(Name = "someValue")]
        public int SomeValue { get; set; }

    }
}
