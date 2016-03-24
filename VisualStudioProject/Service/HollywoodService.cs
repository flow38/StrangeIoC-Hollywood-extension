
using strange.extensions.hollywood.api;
using strange.extensions.signal.api;

namespace strange.extensions.hollywood.impl
{
    public abstract class HollywoodService : IService
    {
        [Inject]
        public IStartDirectorsSignal StartContextSignal { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            StartContextSignal.AddOnce(OnContextStart);
        }

        /// <summary>
        /// Implement this method to access late instanciate service or Director instance via some
        /// other injected Factory like service, or via an injected IInjectionBinder...
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public virtual void OnContextStart(IBaseSignal arg1, object[] arg2)
        {

        }
    }
}
