using System;

namespace strange.extensions.hollywood.impl.IntegrationTest.Input
{
    public class IntegrationTestUseCase
    {
        private float delayBeforeAssert = 0f;


        public Action Act { get; set; }
        public Func<string> TestPass { get; set; }

        public float DelayBeforeAssert
        {
            get { return delayBeforeAssert; }
            set { delayBeforeAssert = value; }
        }
    }
}