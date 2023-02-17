using UnityEngine;

/// <summary>
/// Permet de modifier les paramètres des performances
/// de l'application (fps, etc.)
/// </summary>
public static class ApplicationPerformance
{
    #region Constantes

    private const int DEFAULT_FRAMERATE = 60;
    private const int UNFOCUSED_FRAMERATE = 1;

    #endregion

    #region Variables statiques

    private static int _userDefinedFrameRate = DEFAULT_FRAMERATE;

    #endregion

    #region Fonctions publiques

    /// <summary>
    /// Assigne un nouveau framerate
    /// </summary>
    /// <param name="framerate">Le nouveau framerate à atteindre</param>
    public static void SetFramerate(int framerate)
    {
        Application.targetFrameRate = framerate;
        _userDefinedFrameRate = framerate;
    }

    #endregion

    #region Fonctions privées

    /// <summary>
    /// Appelée avant l'écran de démarrage pour initialiser les paramètres
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void OnBeforeSplashScreen()
    {
        SetFramerate(DEFAULT_FRAMERATE);
        Application.lowMemory += OnApplicationLowMemory;
        Application.focusChanged += OnApplicationFocusChanged;
    }

    /// <summary>
    /// Appelée quand l'application perd ou regagne le focus
    /// </summary>
    /// <param name="focus">Indique si l'appli est active ou tourne en arrière-plan</param>
    private static void OnApplicationFocusChanged(bool focus)
    {
        Application.targetFrameRate = focus ? _userDefinedFrameRate : UNFOCUSED_FRAMERATE;
    }

    /// <summary>
    /// Appelée quand la mémoire de l'application est trop faible
    /// </summary>
    private static void OnApplicationLowMemory()
    {
        // Retire tous les scripts et assets sans références.
        // Appelle aussi GC.Collect() en interne.

        Resources.UnloadUnusedAssets();
    }

    #endregion
}
