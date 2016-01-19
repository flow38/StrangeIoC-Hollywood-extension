using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextA
{
    internal class SubContextAView : HollywoodContextView
    {
        public void Awake()
        {
            context = new SubContextA(this);
        }
    }
}