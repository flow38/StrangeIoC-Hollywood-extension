using System;
using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.impl.UI.HollywoodButton
{
    public interface IButtonActor : IActor
    {
        string Label { get; set; }

        Action OnClick { get; set; }
    }
}