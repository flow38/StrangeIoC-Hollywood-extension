using strange.extensions.hollywood.impl;
using UnityEngine.SceneManagement;

namespace strange.extensions.hollywood.test.fixture.multiContext
{
    internal class RootContextView : HollywoodContextView
    {
        public void Awake()
        {
            context = new RootContext(this);
        }

        public void Start()
        {
            SceneManager.LoadSceneAsync("SubContextA", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("SubContextB", LoadSceneMode.Additive);
        }
    }
}