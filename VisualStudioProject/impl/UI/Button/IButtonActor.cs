using System;

namespace strange.extensions.hollywood.impl.UI.Button
{
    public interface IButtonActor : ISingleUIActor
    {
        string Label { get; set; }

        Action OnClick { get; set; }
    }
}