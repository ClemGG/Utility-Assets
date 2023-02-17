using UnityEngine;

/// <summary>
/// Permet de modifier les param�tres des performances
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
    /// <param name="framerate">Le nouveau framerate � atteindre</param>
    public static void SetFramerate(int framerate)
    {
        Application.targetFrameRate = framerate;
        _userDefinedFrameRate = framerate;
    }

    #endregion

    #region Fonctions priv�es

    /// <summary>
    /// Appel�e avant l'�cran de d�marrage pour initialiser les param�tres
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void OnBeforeSplashScreen()
    {
        SetFramerate(DEFAULT_FRAMERATE);
        Application.lowMemory += OnApplicationLowMemory;
        Application.focusChanged += OnApplicationFocusChanged;
    }

    /// <summary>
    /// Appel�e quand l'application perd ou regagne le focus
    /// </summary>
    /// <param name="focus">Indique si l'appli est active ou tourne en arri�re-plan</param>
    private static void OnApplicationFocusChanged(bool focus)
    {
        Application.targetFrameRate = focus ? _userDefinedFrameRate : UNFOCUSED_FRAMERATE;
    }

    /// <summary>
    /// Appel�e quand la m�moire de l'application est trop faible
    /// </summary>
    private static void OnApplicationLowMemory()
    {
        // Retire tous les scripts et assets sans r�f�rences.
        // Appelle aussi GC.Collect() en interne.

        Resources.UnloadUnusedAssets();
    }

    #endregion
}
