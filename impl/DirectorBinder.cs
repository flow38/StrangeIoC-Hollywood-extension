/*
 * Copyright 2013 ThirdMotion, Inc.
 *
 *	Licensed under the Apache License, Version 2.0 (the "License");
 *	you may not use this file except in compliance with the License.
 *	You may obtain a copy of the License at
 *
 *		http://www.apache.org/licenses/LICENSE-2.0
 *
 *		Unless required by applicable law or agreed to in writing, software
 *		distributed under the License is distributed on an "AS IS" BASIS,
 *		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *		See the License for the specific language governing permissions and
 *		limitations under the License.
 */

/**
 * @class strange.extensions.mediation.impl.MediationBinder
 * 
 * Binds Views to Mediators.
 * 
 * Please read strange.extensions.mediation.api.IMediationBinder
 * where I've extensively explained the purpose of View mediation
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using falcy.strange.extension.hollywood.api;
using falcy.strange.extensions.hollywood.api;
using strange.extensions.command.api;
using UnityEngine;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.framework.api;
using strange.framework.impl;
using Binder = strange.framework.impl.Binder;

namespace falcy.strange.extensions.hollywood.impl
{
    public class DirectorBinder : Binder, IDirectorBinder
    {

        [Inject]
        public IInjectionBinder injectionBinder { get; set; }

        /// Tracker for IDirector instances
		public Dictionary<IActor, List<IDirector>> directory = new Dictionary<IActor, List<IDirector>>();

        public DirectorBinder()
        {
        }


        public override IBinding GetRawBinding()
        {
            return new MediationBinding(resolver) as IBinding;
        }

        public void Trigger(MediationEvent evt, IActor actor)
        {
            Type viewType = actor.GetType();
            IMediationBinding binding = GetBinding(viewType) as IMediationBinding;
            if (binding != null)
            {
                switch (evt)
                {
                    case MediationEvent.AWAKE:
                        injectActorAndChildren(actor);
                        mapView(actor, binding);
                        break;
                    case MediationEvent.DESTROYED:
                        unmapActor(actor, binding);
                        break;
                    default:
                        break;
                }
            }
            else if (evt == MediationEvent.AWAKE)
            {
                //Even if not mapped, Views (and their children) have potential to be injected
                injectActorAndChildren(actor);
            }
        }

        /// Initialize all IActor within an actor instance
        protected virtual void injectActorAndChildren(IActor actor)
        {
            MonoBehaviour mono = actor as MonoBehaviour;
            Component[] actors = mono.GetComponentsInChildren(typeof(IActor), true) as Component[];

            int aa = actors.Length;
            for (int a = aa - 1; a > -1; a--)
            {
                IActor anActor = actors[a] as IActor;
                if (anActor != null)
                {
                    if (anActor.autoRegisterWithContext && anActor.registeredWithContext)
                    {
                        continue;
                    }
                    anActor.registeredWithContext = true;
                    if (anActor.Equals(mono) == false)
                        Trigger(MediationEvent.AWAKE, anActor);
                }
            }
            //
            injectionBinder.injector.Inject(mono, false);
        }

        new public IMediationBinding Bind<T>()
        {
            return base.Bind<T>() as IMediationBinding;
        }

        public IMediationBinding BindView<T>() where T : MonoBehaviour
        {
            return base.Bind<T>() as IMediationBinding;
        }

        /// Creates and registers one or more Director for a specific Actor instance.
        /// Please note that in this extansion's way of thinking, an Actor has one and only one Director.
        /// Takes a specific Actor instance and a binding and, if a binding is found for that type, creates and registers a Director.
        protected virtual void mapView(IActor actor, IMediationBinding binding)
        {
            Type viewType = actor.GetType();

            if (bindings.ContainsKey(viewType))
            {
                object[] values = binding.value as object[];
                int aa = values.Length;
                for (int a = 0; a < aa; a++)
                {
                    MonoBehaviour mono = actor as MonoBehaviour;
                    Type mediatorType = values[a] as Type;
                    if (mediatorType == viewType)
                    {
                       // throw new HollywoodException(viewType + "mapped to itself. The result would be a stack overflow.", HollywoodExceptionType.IMPLICIT_BINDING_MEDIATOR_TYPE_IS_NULL).MEDIATOR_VIEW_STACK_OVERFLOW);
                    }
                    
                    injectionBinder.Bind<IDirector>().To(mediatorType);
                    IDirector director = injectionBinder.GetInstance<IDirector>();
                    injectionBinder.Unbind<IDirector>();
                    ((IDirector)director).PreRegister();

                    Type typeToInject = (binding.abstraction == null || binding.abstraction.Equals(BindingConst.NULLOID)) ? viewType : binding.abstraction as Type;
                    injectionBinder.Bind(typeToInject).ToValue(actor).ToInject(false);
                    injectionBinder.injector.Inject(director);
                    injectionBinder.Unbind(typeToInject);
                    ((IMediator)director).OnRegister();
                    registerDirector(actor, director);
                }
            }
        }

        private void registerDirector(IActor actor, IDirector director)
        {
            if(!directory.ContainsKey(actor))
                directory.Add(actor, new List<IDirector>());
            directory[actor].Add(director);
        }

        /// Removes a mediator when its actor is destroyed
        virtual protected void unmapActor(IActor actor, IMediationBinding binding)
        {
            Type actorType = actor.GetType();

            if (bindings.ContainsKey(actorType))
            {
                int length = directory[actor].Count;
                for (int i = 0; i < length; i++)
                {
                    directory[actor][i].OnRemove();
                }
            }
            //remove reference to IActor and IDirector instances to allow gc 
            directory[actor].Clear();
            directory.Remove(actor);
        }

        private void enableView(IView view)
        {
        }

        private void disableView(IView view)
        {
        }
    }
}

