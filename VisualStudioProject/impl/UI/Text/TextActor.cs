namespace strange.extensions.hollywood.impl.UI.Text
{
    /// <summary>
    /// TextActor wrap a Text game object.
    /// 
    /// TextActor is an AloneActor instance, which means there is no Director intance bind or attach to it
    /// 
    /// GameObject must be composed by a Text component
    /// </summary>
    public class TextActor : SingleUIActor, ITextActor
    {
        private UnityEngine.UI.Text _text;

        public UnityEngine.UI.Text Text
        {
            get
            {
                return _text;
            }
        }

        protected override void Awake()
        {
            //Get Text component
            _text = GetComponent<UnityEngine.UI.Text>();
           
            base.Awake();
        }

        protected override void OnDestroy()
        {
            _text = null;

            base.OnDestroy();
        }

    }
}