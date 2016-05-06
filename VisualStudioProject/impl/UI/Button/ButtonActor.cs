using System;
using strange.extensions.hollywood.api;
using strange.extensions.signal.impl;
using UnityEngine.UI;

namespace strange.extensions.hollywood.impl.UI.HollywoodButton
{
    /// <summary>
    /// ButtonActor wrap a button game object.
    /// 
    /// ButtonActor is an AloneActor instance, which means there is no Director intance bind or attach to it
    /// 
    /// GameObject must be composed by a Text & a Button component
    /// Click call back can be set via OnClick property or by listening OnClickSignal ISignal instance (ie : when accessing ButtonActor instance via its ButtonDirector)
    /// 
    /// </summary>
    public class ButtonActor : AloneActor, IButtonActor
    {
        public string Label
        {
            get { return text.text; }
            set { text.text = value; }
        }

        public Button Button
        {
            get { return button; }
        }

        public Action OnClick { get; set; }

        //TODO remove if unusefulness is confirmed
        //public ISignal OnClickSignal;

        private Text text;
        private Button button;

        protected override void Awake()
        {
            //Get Text component
            text = GetComponentInChildren<Text>();
            if (text == null)
                throw new Exception("GUIText component cannot be not found !!");

            //Get Button component
            button = GetComponentInChildren<Button>();
            if (button == null)
                throw new Exception("Button component cannot be not found !!");

            //Create OnClickSignal (can be listen throught ButtonDirector instance
            //OnClickSignal = new Signal() as ISignal;

            base.Awake();
        }

        protected override void OnDestroy()
        {
            //Destroy signal
            //OnClickSignal.RemoveAllListeners();

            //Destroy all references
            //OnClickSignal = null;
            text = null;
            button = null;

            base.OnDestroy();
        }


        public void OnEnable()
        {
            button.onClick.RemoveListener(onClickHandler);
        }

        public void OnDisable()
        {
            button.onClick.AddListener(onClickHandler);
        }


        private void onClickHandler()
        {
            OnClick?.Invoke();
        }
    }
}