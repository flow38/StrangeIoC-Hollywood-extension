namespace falcy.strange.extensions.hollywood.api
{
    interface IDirector
    {
        void PreRegister();

        void OnRegister();

        void OnRemove();

        IActor Actor { get; set; }
        
    }
}
