using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using falcy.strange.extensions.hollywood.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.api;

namespace falcy.strange.extension.hollywood.impl
{
    class Director : BaseDirector
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }
    }
}