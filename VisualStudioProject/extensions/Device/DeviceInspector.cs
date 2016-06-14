using strange.extensions.hollywood.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.Device
{
    class DeviceInspector : HollywoodService, IDeviceInspector
    {
        #region IUnityScreen interface
        public bool AutorotateToLandscapeLeft
        {
            get { return Screen.autorotateToLandscapeLeft; }
            set { Screen.autorotateToLandscapeLeft = value; }
        }

        public bool AutorotateToLandscapeRight
        {
            get { return Screen.autorotateToLandscapeRight; }
            set { Screen.autorotateToLandscapeRight = value; }
        }

        public bool AutorotateToPortrait
        {
            get { return Screen.autorotateToPortrait; }
            set { Screen.autorotateToPortrait = value; }
        }

        public bool AutorotateToPortraitUpsideDown
        {
            get { return Screen.autorotateToPortraitUpsideDown; }
            set { Screen.autorotateToPortraitUpsideDown = value; }
        }

        public Resolution WindowModeResolution
        {
            get { return Screen.currentResolution; }
        }

        public float Dpi
        {
            get { return Screen.dpi; }
        }

        public bool FullScreen
        {
            get { return Screen.fullScreen; }
            set { Screen.fullScreen = value; }
        }

        public int Height
        {
            get { return Screen.height; }
        }

        public ScreenOrientation Orientation
        {
            get { return Screen.orientation; }
            set { Screen.orientation = value; }
        }

        public Resolution[] Resolutions
        {
            get { return Screen.resolutions; }
        }

        public int SleepTimeout
        {
            get { return Screen.sleepTimeout; }
            set { Screen.sleepTimeout = value; }
        }

        public int Width
        {
            get { return Screen.width; }
        }

        public void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate = 0)
        {
            Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
        }
        #endregion

        public float ScreenRatio
        {
            get {
                return (float)Screen.width / (float)Screen.height;
            }
        }
    }
}
