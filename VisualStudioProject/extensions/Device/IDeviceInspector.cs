namespace strange.extensions.hollywood.extensions.Device
{
    public interface IDeviceInspector : IUnityScreen
    {
        /// <summary>
        /// Screen ratio between width and height
        /// </summary>
        float ScreenRatio { get; }
    }
}