using strange.extensions.hollywood.api;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    public interface IUIActor : IActor
    {
        RectTransform RectTransform { get; }
    }
}