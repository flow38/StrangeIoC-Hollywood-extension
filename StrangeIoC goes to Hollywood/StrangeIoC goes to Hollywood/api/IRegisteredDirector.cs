using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.signal.impl;

namespace falcy.strange.extensions.hollywood.api
{
    interface IRegisteredDirector : IDirector
    {
        Signal<IRegisteredDirector> RegisterMe { get; set; }
    }
}