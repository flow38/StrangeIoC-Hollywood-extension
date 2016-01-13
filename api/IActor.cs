using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace falcy.strange.extensions.hollywood.api
{
    public interface IActor
    {
        /// Indicates whether the actor can work absent a context
		/// 
		/// Leave this value true most of the time. If for some reason you want
		/// a view to exist outside a context you can set it to false. The only
		/// difference is whether an error gets generated.
		bool requiresContext { get; set; }

        /// Indicates whether this actor  has been registered with a Context
        bool registeredWithContext { get; set; }

        /// Exposure to code of the registerWithContext (Inspector) boolean. If false, the Actor won't try to register.
        bool autoRegisterWithContext { get; }



        /// <summary>
        /// 
        /// </summary>
        /// <returns>Position in world space</returns>
        Vector3 GetPosition();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">Position in world space</param>
        void SetPosition(Vector3 pos); 
    }
}
