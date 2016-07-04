
#if HOLLYWOOD_LOG_ENABLE
using System;

namespace strange.extensions.hollywood.impl.Service.Logger
{

    public class HollywoodLogger : IHollywoodLogger
    {

        private DisplayMode _displayMode = DisplayMode.RAW;

        public HollywoodLogger()
        {

#if HOLLYWOOD_LOG_HTML
            _displayMode = DisplayMode.HTML;
#elif UNITY_EDITOR
            _displayMode = DisplayMode.EDITOR;
#endif

        }

        public void Log(string context, string message, LogLevel logLevel)
        {
            if (_displayMode == DisplayMode.HTML)
            {
                //Html encode workaround as we do not have access to HttpServerUtility.HtmlEncode method... :(
                message = Uri.EscapeDataString(message);
                switch (logLevel)
                {
                    case LogLevel.DEBUG:
                        UnityEngine.Debug.Log(string.Format("<span style=\"color:grey; font-weight:bold;\">[{0}]</span>&nbsp;-&nbsp;{1}", format(context), message));
                        break;
                    case LogLevel.INFO:
                        UnityEngine.Debug.Log(string.Format("<span style=\"color:white; font-weight:bold;\">[{0}]</span>&nbsp;-&nbsp;{1}", format(context), message));
                        break;
                    case LogLevel.WARNING:
                        UnityEngine.Debug.Log(string.Format("<span style=\"color:orange; font-weight:bold;\">[{0}]</span>&nbsp;-&nbsp;{1}", format(context), message));
                        break;
                    case LogLevel.ERROR:
                        UnityEngine.Debug.LogError(string.Format("<span style=\"color:red; font-weight:bold;\">[{0}]</span>&nbsp;-&nbsp;{1}", format(context), message));
                        break;
                }
            }
            else if (_displayMode == DisplayMode.EDITOR)
            {
                switch (logLevel)
                {
                    case LogLevel.DEBUG:
                        UnityEngine.Debug.Log(String.Format("<color=\"grey\">[{0}]</color> {1}", context.ToString(),
                            (object)message));
                        break;
                    case LogLevel.INFO:
                        UnityEngine.Debug.Log(String.Format("<color=\"green\">[{0}]</color> {1}", context.ToString(),
                            (object)message));
                        break;
                    case LogLevel.WARNING:
                        UnityEngine.Debug.Log(String.Format("<color=\"orange\">[{0}]</color> {1}", context.ToString(),
                            (object)message));
                        break;
                    case LogLevel.ERROR:
                        UnityEngine.Debug.LogError(String.Format("<color=\"red\">[{0}]</color> {1}", context.ToString(),
                            (object)message));
                        break;

                }
            }
            else
            {
                switch (logLevel)
                {
                    case LogLevel.DEBUG:
                        UnityEngine.Debug.Log(string.Format("[{0}] - {1}", context.ToString(), message));
                        break;
                    case LogLevel.INFO:
                        UnityEngine.Debug.Log(string.Format("[{0}] - {1}", context.ToString(), message));
                        break;
                    case LogLevel.WARNING:
                        UnityEngine.Debug.Log(string.Format("[{0}] - {1}", context.ToString(), message));
                        break;
                    case LogLevel.ERROR:
                        UnityEngine.Debug.LogError(string.Format("[{0}] - {1}", context.ToString(), message));
                        break;
                }
            }

        }

        public void Log(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void Debug(string context, string message)
        {
            Log(context, message, LogLevel.DEBUG);
        }

        public void Info(string context, string message)
        {
            Log(context, message, LogLevel.INFO);
        }

        public void Warning(string context, string message)
        {
            Log(context, message, LogLevel.WARNING);
        }

        public void Error(string context, string message)
        {
            Log(context, message, LogLevel.ERROR);
        }

        private string format(string context)
        {
            return context.ToString();
        }

    }
}
#endif