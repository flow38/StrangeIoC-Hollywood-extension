/*
 * Copyright 2016 Florent Falcy.
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


using System;
using System.Collections.Generic;
using strange.extensions.hollywood.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.framework.api;
using strange.framework.impl;
using UnityEngine;

/// <summary>
/// 
/// 
/// Nominal use case : 
/// Binds an IActor instance to an IDirector instance
/// 
/// Other use case : 
/// Bind any IHollywoodView to a
/// 
/// </summary>
namespace strange.extensions.hollywood.impl
{
    public class DirectorBinder : Binder, IMediationBinder
    {
        /// Tracker for IDirector instances
        public Dictionary<IHollywoodView, List<IDirector>> directory = new Dictionary<IHollywoodView, List<IDirector>>();

        [Inject]
        public IInjectionBinder injectionBinder { get; set; }


        public override IBinding GetRawBinding()
        {
            return new MediationBinding(resolver);
        }

        public void Trigger(MediationEvent evt, IView view)
        {
            var hollyView = view as IHollywoodView;
            var viewType = hollyView.GetType();
            var binding = GetBinding(viewType) as IMediationBinding;
            if (binding != null)
            {
                switch (evt)
                {
                    case MediationEvent.AWAKE:
                        injectActorAndChildren(hollyView);
                        mapView(hollyView, binding);
                        break;
                    case MediationEvent.DESTROYED:
                        unmapActor(hollyView, binding);
                        break;
                    default:
                        break;
                }
            }
            else if (evt == MediationEvent.AWAKE)
            {
                //Even if not mapped, Views (and their children) have potential to be injected
                injectActorAndChildren(hollyView);
            }
        }

        public new IMediationBinding Bind<T>()
        {
            return base.Bind<T>() as IMediationBinding;
        }

        public IMediationBinding BindView<T>() where T : MonoBehaviour
        {
            return base.Bind<T>() as IMediationBinding;
        }

        /// Initialize all IActor within an hollyView instance
        protected virtual void injectActorAndChildren(IHollywoodView actor)
        {
            var mono = actor as MonoBehaviour;
            var actors = mono.GetComponentsInChildren(typeof (IHollywoodView), true);

            var aa = actors.Length;
            for (var a = aa - 1; a > -1; a--)
            {
                var anActor = actors[a] as IHollywoodView;
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

        /// Creates and registers one or more Director for a specific Actor instance.
        /// Please note that in this extansion's way of thinking, an Actor has one and only one Director.
        /// Takes a specific Actor instance and a binding and, if a binding is found for that type, creates and registers a Director.
        protected virtual void mapView(IHollywoodView hollyView, IMediationBinding binding)
        {
            var viewType = hollyView.GetType();

            if (bindings.ContainsKey(viewType))
            {
                var values = binding.value as object[];
                var aa = values.Length;
                for (var a = 0; a < aa; a++)
                {
                    var mono = hollyView as MonoBehaviour;
                    var directorType = values[a] as Type;
                    if (directorType == viewType)
                    {
                        throw new MediationException(
                            viewType + "mapped to itself. The result would be a stack overflow.",
                            MediationExceptionType.MEDIATOR_VIEW_STACK_OVERFLOW);
                    }

                    //IDirector director = injectionBinder.GetInstance(directorType) as IDirector;
                    IInjectionBinding bindingTest = injectionBinder.GetBinding(directorType, null) as IInjectionBinding;
                    IDirector director;
                    if (bindingTest == null)
                    {
                        //Default use case
                        injectionBinder.Bind<IDirector>().To(directorType);
                        director = injectionBinder.GetInstance<IDirector>();
                        injectionBinder.Unbind<IDirector>();
                    }
                    else
                    {
                        //Actor is bind to an Interface...
                        director = injectionBinder.GetInstance(directorType) as IDirector;
                    }






                    if (director is IDirector)
                        director.PreRegister();

                    var typeToInject = binding.abstraction == null || binding.abstraction.Equals(BindingConst.NULLOID)
                        ? viewType
                        : binding.abstraction as Type;
                    injectionBinder.Bind(typeToInject).ToValue(hollyView).ToInject(false);
                    injectionBinder.injector.Inject(director, false);
                    injectionBinder.Unbind(typeToInject);

                    if (director is IDirector)
                        director.OnRegister(hollyView as IActor);

                    registerDirector(hollyView, director);
                }
            }
        }

        private void registerDirector(IHollywoodView hollyView, IDirector director)
        {
            if (!directory.ContainsKey(hollyView))
                directory.Add(hollyView, new List<IDirector>());

            directory[hollyView].Add(director);
        }

        /// Removes a mediator when its hollyView is destroyed
        protected virtual void unmapActor(IHollywoodView actor, IMediationBinding binding)
        {
            var actorType = actor.GetType();

            if (bindings.ContainsKey(actorType))
            {
                int  length = 0;
                try
                {
                     length = directory[actor].Count;
                }
                catch (Exception)
                {
                    
                    var t =1;
                }
                
                for (var i = 0; i < length; i++)
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