﻿using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.impl
{
    //Actor which are not bind to any Director instance
    public class SingleActor : Actor
    {
        #region IActor

        /*
        public Signal<MonoBehaviorEvent> MonoBehaviorSignal
        {
            get { return _monoBehaviorSignal; }
            set { _monoBehaviorSignal = value; }
        }*/


        public override IDirector Director
        {
            get {
                throw new HollywoodException("Cannot get Director intance as I'm an AloneActor intance !!", HollywoodExceptionType.ActorIsAnAloneActorInstance);
            }
            set {
                throw new HollywoodException("Cannot set Director intance as I'm an AloneActor intance !!", HollywoodExceptionType.ActorIsAnAloneActorInstance);
            }
        }

        #endregion

        #region MonoBehavior

        protected override void Awake()
        {
            CachedGameObjectShortcuts();
            base.Awake();
        }

        protected override void Start()
        {
            //Do nothing
        }

        protected override void OnDestroy()
        {
            //todo pour le moment les acteur sont destroy par le context parent. Dans l'idéal les vue devrait se detruire toute seules sur
            //via un evenement Monobehavior , du coups pour le moment on commente base.OnDestroy(); pour ne pas faire doublon
            //base.OnDestroy();
        }
        #endregion

    }
}