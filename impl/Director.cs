using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using falcy.strange.extensions.hollywood.api;

namespace falcy.strange.extensions.hollywood.impl
{
    class Director : IDirector
    {
        public void PreRegister()
        {
            throw new NotImplementedException();
        }

        public void OnRegister()
        {
            throw new NotImplementedException();
        }

        public void OnRemove()
        {
            throw new NotImplementedException();
        }

        public IActor Actor { get; set; }
    }
}
