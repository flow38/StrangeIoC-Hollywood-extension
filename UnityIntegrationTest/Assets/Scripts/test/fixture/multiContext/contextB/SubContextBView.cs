using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextB
{
    internal class SubContextBView : HollywoodContextView
    {
        public void Awake()
        {
            context = new SubContextB(this);
        }
    }
}