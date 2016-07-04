namespace strange.extensions.hollywood.impl.Service.Logger
{
    public interface IHollywoodLogger
    {
        void Log(string context, string message, LogLevel logLevel);
        void Log(string message);
        void Debug(string context, string message);
        void Info(string context, string message);
        void Warning(string context, string message);
        void Error(string context, string message);
    }
}