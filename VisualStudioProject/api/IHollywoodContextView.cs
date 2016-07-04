using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.api
{
    public interface IHollywoodContextView : IHollywoodView
    {

        /// <summary>
        /// Dispatch warmup and startDirectors signal and flag context as alreadyStart
        /// </summary>
        void StartContext();

        /// <summary>
        /// Setter invoke by a HollywoodMVCSContext instance
        /// </summary>
        ISignal WarmUpDirectors
        {
            set; get;
        }
        /// <summary>
        /// Setter invoke by a HollywoodMVCSContext instance
        /// </summary>
        ISignal StartDirectors
        {
            set; get;
        }
        /// <summary>
        /// Does context view Start() method have already been invoked or not? 
        /// HollywoodService instances use this info to choose between listen for IStartDirectorsSignal dispatching (occir on context view Start()) 
        /// or to programmatically call OnContextStart()  (when Service is create after context view start !)
        /// 
        /// </summary>
        /// <returns></returns>
        bool hasAlreadyStart();
    }
}