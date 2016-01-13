namespace falcy.strange.extensions.hollywood.api
{
    public interface IDirector
    {

        /// This method fires immediately after instantiation, but before injection.
        /// Override to handle anything that needs to happen prior to injection.
        void PreRegister();

        /// This method fires immediately after injection.
        /// Override to perform the actions you might normally perform in a constructor.
        void OnRegister();

        /// This method fires just before Director's actor instance will be destroyed.
        /// Override to clean up any listeners, or anything else that might keep the Actor/Director pair from being garbage collected.
        void OnRemove();

        IActor Actor { get; set; }
        
    }
}
