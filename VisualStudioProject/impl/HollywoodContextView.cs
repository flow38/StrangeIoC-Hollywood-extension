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

using strange.extensions.context.impl;
using strange.extensions.hollywood.api;
using UnityEngine;

/// <summary>
/// A context in an Hollywood project must realize HollywoodContextView
/// </summary>

namespace strange.extensions.hollywood.impl
{
    public abstract class HollywoodContextView : ContextView, IHollywoodContextView
    {
        private bool _haveAlreadyStart = false;

        public ISignal WarmUpDirectors
        {
            get; set;
        }

        public ISignal StartDirectors
        {
            get; set;
        }

        public virtual void Start()
        {
            StartContext();
        }

        public virtual void StartContext()
        {
            //Very important to first set  _haveAlreadyStart flag to true BEFORE dispatching WarmUpDirectors & StartDirectors signals !!!
            _haveAlreadyStart = true;
            //Trigger directors (and services) dependencies creation
            WarmUpDirectors.Dispatch();
            //Directors (and service) can now call other entities method wihtout errors
            StartDirectors.Dispatch();
        }

        public void OnDisable()
        {
            _haveAlreadyStart = false;
        }

        public bool hasAlreadyStart()
        {
            return _haveAlreadyStart;
        }

    }
}