namespace JintLibrary.JintWrapper
{
    using fastJSON;
    using Jint;
    using Jint.Native;
    using Jint.Native.Json;
    using System.IO;
    using System.Text;
    using System;

    public class JintManager : ScriptManager
    {
        public JintManager()
        {
            this.Engine = new Engine();
        }

        public Engine Engine { get; protected set; }
        public bool IsDebugMode { get; set; }

        public void SetValue(string name, Delegate value)
        {
            this.Engine.SetValue(name, value);
        }

        public OUT Execute<IN, OUT>(IN data)
            where IN : DataIncome
            where OUT : DataOutcome
        {
            string script = ReadJsScrips(data.Script);
            Engine engine = Engine.Execute(script);
            return this.ExecuteTempale<IN, OUT>(engine, data);
        }

        public OUT ExecuteTempale<IN, OUT>(Engine engine, IN data)
            where IN : DataIncome
            where OUT : DataOutcome
        {
            string income = JSON.ToJSON(data, new JSONParameters() { EnableAnonymousTypes = true});
            var executor = engine.GetCompletionValue().AsObject().Get(data.FunctionName);
            JsValue jsIncome = new JsonParser(engine).Parse(income);
            JsValue resultData = executor.Invoke(jsIncome);
            string outcome = new JsonSerializer(engine).Serialize(resultData, JsValue.Null, JsValue.Null).AsString();
            return JSON.ToObject<OUT>(outcome);
        }

        public string ReadJsScrips(ScriptFileInfo scriptInfo)
        {
            string scriptText = null;
            string path = GetJsFilePath(scriptInfo);
            int bufferSize = 256;
            using (FileStream reader = File.Open(path, FileMode.Open))
            {
                scriptText = ReadTextFromStream(reader, bufferSize).ToString();
            }
            return scriptText;
        }

        public StringBuilder ReadTextFromStream(Stream stream, int bufferSize)
        {
            StringBuilder sb = new StringBuilder();
            Encoding encoding = Encoding.UTF8;
            byte[] buffer = new byte[bufferSize];
            int readedBytesCount = 0;
            do
            {
                readedBytesCount = stream.Read(buffer, 0, buffer.Length);
                sb.Append(encoding.GetString(buffer, 0, readedBytesCount));
            }
            while (readedBytesCount == buffer.Length);
            return sb;
        }

        public string GetJsFilePath(ScriptFileInfo scriptInfo)
        {
            return Path.ChangeExtension(Path.Combine(scriptInfo.Path, scriptInfo.Name), scriptInfo.Extention);
        }
    }
}
