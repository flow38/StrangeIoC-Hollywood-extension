using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.test.fixture.monoContext
{
    internal class ViewRoot : HollywoodContextView
    {
        public void Awake()
        {
            context = new MyHollywoodContext(this);
        }
    }
}