using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace falcy.strange.extensions.hollywood.api
{
    public interface IActor
    {
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
