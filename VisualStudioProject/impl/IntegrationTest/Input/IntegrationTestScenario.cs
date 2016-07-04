using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace strange.extensions.hollywood.impl.IntegrationTest.Input
{
    public class IntegrationTestScenario : IIntegrationTestScenario
    {
        private List<IntegrationTestUseCase> _actAndAsserts;

        public IntegrationTestScenario()
        {
            _actAndAsserts = new List<IntegrationTestUseCase>();
        }

        #region IIntegrationTestScenario
        public void AddToScenario(Action act, Func<string> testPass, float delayBeforeAssert = 0f)
        {
            IntegrationTestUseCase step = new IntegrationTestUseCase();
            step.Act = act;
            step.TestPass = testPass;
            step.DelayBeforeAssert = delayBeforeAssert;
            _actAndAsserts.Add(step);
        }

        public void AddToScenario(Action act, float delayBeforeAssert = 0f)
        {
            IntegrationTestUseCase step = new IntegrationTestUseCase();
            step.Act = act;
            step.TestPass = () => null;
            step.DelayBeforeAssert = delayBeforeAssert;
            _actAndAsserts.Add(step);
        }

        public IEnumerator Play()
        {
            int i = 0;
            for (; i < _actAndAsserts.Count; i++)
            {
                var actAssert = _actAndAsserts[i];
                //Do some action
                actAssert.Act();

                if (actAssert.DelayBeforeAssert != 0)
                {
                    //Wait
                    yield return new WaitForSeconds(actAssert.DelayBeforeAssert);
                }

                //Assert
                var failMessage = actAssert.TestPass();
                if (failMessage != null)
                {
                    global::IntegrationTest.Fail(failMessage);
                    break;
                }

            }
            if (i == _actAndAsserts.Count)
                global::IntegrationTest.Pass();
        }

        #endregion
    }
}