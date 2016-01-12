using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace falcy.strange.extensions.hollywood.api
{
    interface IActor
    {
        Vector3 GetPosition();
        void SetPosition(Vector3 pos); 
    }
}
