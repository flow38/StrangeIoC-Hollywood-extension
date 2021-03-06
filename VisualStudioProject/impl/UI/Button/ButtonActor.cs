﻿using System;

namespace strange.extensions.hollywood.impl.UI.Button
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
    public class ButtonActor : SingleUIActor, IButtonActor
    {
        public string Label
        {
            get { return text.text; }
            set { text.text = value; }
        }

        public UnityEngine.UI.Button Button
        {
            get { return button; }
        }

        public Action OnClick { get; set; }


        private UnityEngine.UI.Text text;
        private UnityEngine.UI.Button button;

        protected override void Awake()
        {
            //Get Text component
            text = GetComponentInChildren<UnityEngine.UI.Text>();

            //Get Button component
            button = GetComponentInChildren<UnityEngine.UI.Button>();
            if (button == null)
                throw new Exception("Button component cannot be not found !!");

            base.Awake();
        }

        protected override void OnDestroy()
        {
            text = null;
            button = null;

            base.OnDestroy();
        }

        public void OnClickHandler()
        {
            if (OnClick != null)
                OnClick.Invoke();
        }
    }
}