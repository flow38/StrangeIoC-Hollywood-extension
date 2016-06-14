using UnityEngine;

namespace strange.extensions.hollywood.extensions.Device
{
    /// <summary>
    /// Interface matching UnityEngine.Screen Class methods (v5.3)
    /// </summary>
    public interface IUnityScreen
    {
        /// <summary>
        /// Allow auto-rotation to landscape left?
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeLeft.html
        /// </summary>
        bool AutorotateToLandscapeLeft { get; set; }

        /// <summary>
        /// Allow auto-rotation to landscape right?
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeRight.html
        /// </summary>
        bool AutorotateToLandscapeRight { get; set; }

        /// <summary>
        /// Allow auto-rotation to portrait?
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-autorotateToPortrait.html
        /// </summary>
        bool AutorotateToPortrait { get; set; }

        /// <summary>
        /// Allow auto-rotation to portrait, upside down?
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-autorotateToPortraitUpsideDown.html
        /// </summary>
        bool AutorotateToPortraitUpsideDown { get; set; }


        /// <summary>
        /// Window mode resolution
        /// 
        /// If the player is running in window mode, this returns the current resolution of the desktop.
        ///
        /// https://docs.unity3d.com/ScriptReference/Screen-currentResolution.html
        /// </summary>
        /// <returns></returns>
        Resolution WindowModeResolution { get; }


        /// <summary>
        /// Current DPI of the screen
        /// https://docs.unity3d.com/ScriptReference/Screen-dpi.html
        /// </summary>
        float Dpi { get; }

        /// <summary>
        /// Is the game running fullscreen?
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-fullScreen.html
        /// </summary>
        bool FullScreen { get; set; }

        /// <summary>
        /// The current height of the screen window in pixels (Read Only).
        /// https://docs.unity3d.com/ScriptReference/Screen-height.html
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Specifies logical orientation of the screen.
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-orientation.html
        /// </summary>
        ScreenOrientation Orientation { get; set; }

        /// <summary>
        /// All fullscreen resolutions supported by the monitor (Read Only).
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-resolutions.html
        /// </summary>
        Resolution[] Resolutions { get; }

        /// <summary>
        /// A power saving setting, allowing the screen to dim some time after the last active user interaction.
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-sleepTimeout.html
        /// </summary>
        int SleepTimeout { get; set; }

        /// <summary>
        /// The current width of the screen window in pixels (Read Only).
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen-width.html
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Switches the screen resolution.
        /// 
        /// https://docs.unity3d.com/ScriptReference/Screen.SetResolution.html
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fullscreen"></param>
        /// <param name="preferredRefreshRate"></param>
        void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate = 0);
    }
}