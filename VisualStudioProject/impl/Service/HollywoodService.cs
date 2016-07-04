
using strange.extensions.hollywood.api;
using strange.extensions.injector.api;

namespace strange.extensions.hollywood.impl
{
    public abstract class HollywoodService : IService
    {
        [Inject(HollywoodSignals.Start)]
        public ISignal StartSignal { get; set; }

        [Inject(HollywoodSignals.WarmUp)]
        public ISignal WarmupSignal { get; set; }

        [Inject]
        public IHollywoodContextView ContextView { get; set; }

        [Inject]
        public IInjectionBinder _injectionBinder { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            if (ContextView.hasAlreadyStart())
            {
                WarmUp();
                Start();
            }
            else
            {
                WarmupSignal.AddOnce(WarmUp);
                StartSignal.AddOnce(Start);
            }
        }

        protected virtual void WarmUp()
        {

        }

        /// <summary>
        /// Implement this method to access late instanciate service or Director instance via some
        /// other injected Factory like service, or via an injected IInjectionBinder...
        /// </summary>
        protected virtual void Start()
        {
            //throw new System.NotImplementedException();
        }
    }
}
