using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using falcy.strange.extensions.hollywood.api;

namespace falcy.strange.extensions.hollywood.impl
{
    class BaseDirector : IDirector
    {

        /// <summary>
        /// Fires directly after creation and before injection
        /// </summary>
        public void PreRegister()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Fires after all injections satisifed.
        /// Override and place your initialization code here
        /// 
        /// ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        ///
        /// </summary>
        public void OnRegister(IActor actor)
        {
            Actor = actor;
        }

        /// <summary>
        /// Fires on removal of view.
        /// Override and place your cleanup code here
        /// 
        /// ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        /// 
        /// </summary>
        public void OnRemove()
        {
            Actor = null;
        }

        public IActor Actor { get; set; }
    }
}
