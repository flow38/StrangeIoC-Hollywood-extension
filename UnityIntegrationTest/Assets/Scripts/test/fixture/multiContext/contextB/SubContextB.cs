using strange.extensions.hollywood.impl;
using strange.extensions.context.api;
using strange.extensions.mediation.api;
using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextB
{
    public class SubContextB : HollywoodMVCSContext
    {
        public SubContextB(MonoBehaviour view) : base(view)
        {
        }

        public SubContextB(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            if (firstContext == this)
            {
                //If this context is execute without a parent context we bind JumpSignal & UpdatedJumpCountSignal
                //Otherwise parent context is in charge of bind this Signal himself (see line 37)
                //injectionBinder.Bind<JumpSignal>().ToSingleton();
                //injectionBinder.Bind<UpdatedJumpCountSignal>().ToSingleton();
                injectionBinder.Bind<Signal<string>>().ToName(SignalEnumB.FromOutSide).ToSingleton();
                injectionBinder.Bind<Signal<string>>().ToName(SignalEnumB.MySignalB).ToSingleton();
            }

            //Share binding with children context
            //injectionBinder.Bind<JumpSignal>().ToSingleton().CrossContext();
            //injectionBinder.Bind<UpdatedJumpCountSignal>().ToSingleton().CrossContext();


            //Injection binding.
            //Map a mock model and a mock service, both as Singletons
            //Example
            //injectionBinder.Bind<IExampleModel>().To<ExampleModel>().ToSingleton();
            //injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();

            //Actor/Director binding
            mediationBinder.Bind<ActorB>().To<DirectorB>();

            //Event/Command binding
            //Example

            //The START event is fired as soon as mappings are complete.
            //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
            //commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();

            //Game Start Signal exemple
            //commandBinder.Bind<MainStartSignal>().To<MainStartCommand>().Once();
        }

        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            //Replace Mediation binding by Director binding
            injectionBinder.Unbind<IMediationBinder>();
            injectionBinder.Bind<IMediationBinder>().To<DirectorBinder>().ToSingleton();
        }
    }
}