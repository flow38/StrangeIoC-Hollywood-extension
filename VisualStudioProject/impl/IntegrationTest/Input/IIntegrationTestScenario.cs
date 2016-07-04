using System;
using System.Collections;

namespace strange.extensions.hollywood.impl.IntegrationTest.Input
{
    public interface IIntegrationTestScenario
    {
        /// <summary>
        /// Add an atomic test (act & assert) to test scenario
        /// </summary>
        /// <param name="act"></param>
        /// <param name="testPass"></param>
        /// <param name="delayBeforeAssert"></param>
        void AddToScenario(Action act, Func<string> testPass, float delayBeforeAssert = 0f);

        /// <summary>
        /// Add an action without assert anything
        /// </summary>
        /// <param name="act"></param>
        /// <param name="testPass"></param>
        /// <param name="delayBeforeAssert"></param>
        void AddToScenario(Action act, float delayBeforeAssert = 0f);


        /// <summary>
        /// Play test scenario
        /// </summary>
        /// <returns></returns>
        IEnumerator Play();
    }
}