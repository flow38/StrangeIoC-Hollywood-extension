namespace strange.extensions.hollywood.impl.Command
{
    /// <summary>
    /// Dispatch a singleton instance of LaunchAppIsDoneSignal, instance which can 
    /// be listen by directors or services.
    /// </summary>
    public class AppLaunchIsDone : command.impl.Command
    {
        private readonly LaunchAppIsDoneSignal _launchIsDoneSignal;

        [Construct]
        public AppLaunchIsDone(LaunchAppIsDoneSignal launchIsDoneSignal)
        {
            _launchIsDoneSignal = launchIsDoneSignal;
        }

        public override void Execute()
        {
            _launchIsDoneSignal.Dispatch();
        }
    }
}