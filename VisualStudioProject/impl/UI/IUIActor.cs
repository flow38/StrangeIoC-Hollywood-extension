using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl.UI.Utils;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    public interface IUIActor : IActor, IRectTransformWrapper
    {
        RectTransform RectTransform { get; }

       
    }
}