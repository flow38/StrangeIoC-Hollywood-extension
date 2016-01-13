using strange.extensions.mediation.api;
using UnityEngine;

namespace falcy.strange.extensions.hollywood.api
{
    public interface IDirectorBinder
    {
        /// An event that just happened, and the View it happened to.
        /// If the event was Awake, it will trigger creation of a mapped Director.
        void Trigger(MediationEvent evt, IView view);

        /// Porcelain for Bind<T> providing a little extra clarity and security.
        IDirectorBinding BindView<T>() where T : MonoBehaviour;
    }
}