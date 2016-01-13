using falcy.strange.extensions.hollywood.api;
using strange.extensions.mediation.api;
using UnityEngine;

namespace falcy.strange.extension.hollywood.api
{
    interface IDirectorBinder
    {
        /// An event that just happened, and the View it happened to.
		/// If the event was Awake, it will trigger creation of a mapped Mediator.
		void Trigger(MediationEvent evt, IActor actor);

        /// Recast binding as IMediationBinding.
        new IMediationBinding Bind<T>();

        /// Porcelain for Bind<T> providing a little extra clarity and security.
        IMediationBinding BindView<T>() where T : MonoBehaviour;
    }
}
