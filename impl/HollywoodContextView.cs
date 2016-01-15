﻿/*
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
using falcy.strange.extension.hollywood.api;
using strange.extensions.context.impl;

/// <summary>
/// A context in an Hollywood project must realize HollywoodContextView
/// </summary>

namespace falcy.strange.extension.hollywood.impl
{
    public abstract class HollywoodContextView : ContextView, IHollywoodView
    {
    }
}