namespace JintLibrary
{
    using JintLibrary.JintWrapper;

    public interface ScriptManager
    {
        OUT Execute<IN, OUT>(IN data)
            where IN : DataIncome
            where OUT : DataOutcome;
    }
}
