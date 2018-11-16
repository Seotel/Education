using Novice.Example_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JintLibrary;
using JintLibrary.JintWrapper;

namespace NoviceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JintManager jsManager = new JintManager();
            jsManager.SetValue("fnSum", new Func<int, int, int>(Program.fnSum));
            var data = new DataIncome("BaseFunction") { FunctionName = "fnTest", SomeValue = 8 };
            data.Script.Path = @"C:\AsDriveD\www\git\Education\Novice\JintLibrary\js";
            DataOutcome outcome = jsManager.Execute<DataIncome, DataOutcome>(data);
        }

        static int fnSum(int x, int y)
        {
            return x + y;
        }
    }
}
