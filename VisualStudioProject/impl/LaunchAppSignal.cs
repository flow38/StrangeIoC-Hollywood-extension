using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.impl
{
    public class LaunchAppSignal : Signal
    {
    }

    /// <summary>
    /// Directors can listen to it to be inform  that app is fully intiliazed and working
    /// ie: IntegrationTest case (DirectorTest call their IActorTEst DoTest())
    /// </summary>
    public class LaunchAppIsDoneSignal : Signal
    {
    }
}
