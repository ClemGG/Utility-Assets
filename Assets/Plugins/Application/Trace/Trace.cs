using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Utilisée pour écrire plus facilement des logs
/// uniquement dans l'éditeur ou sur un build en mode développement
/// (Ne pas oublier de mettre le symbole dans Project Settings > Player > Scripting Define Symbols)
/// </summary>
public static class Trace
{
    #region Fonctions publiques

    /// <summary>
    /// Identique à Debug.Log
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    [Conditional("ENABLE_LOGS")]
    public static void Log(object msg)
    {
        UnityEngine.Debug.Log(msg);
    }

    /// <summary>
    /// Identique à Debug.Log
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    /// <param name="context">L'objet Unity à surligner pour indiquer la provenance du message</param>
    [Conditional("ENABLE_LOGS")]
    public static void Log(object msg, Object context)
    {
        UnityEngine.Debug.Log(msg, context);
    }

    /// <summary>
    /// Identique à Debug.LogWarning
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    [Conditional("ENABLE_LOGS")]
    public static void LogWarning(object msg)
    {
        UnityEngine.Debug.LogWarning(msg);
    }

    /// <summary>
    /// Identique à Debug.Log
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    /// <param name="context">L'objet Unity à surligner pour indiquer la provenance du message</param>
    [Conditional("ENABLE_LOGS")]
    public static void LogWarning(object msg, Object context)
    {
        UnityEngine.Debug.LogWarning(msg, context);
    }

    /// <summary>
    /// Identique à Debug.LogError
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    [Conditional("ENABLE_LOGS")]
    public static void LogError(object msg)
    {
        UnityEngine.Debug.LogError(msg);
    }

    /// <summary>
    /// Identique à Debug.Log
    /// </summary>
    /// <param name="msg">L'objet à afficher dans la console</param>
    /// <param name="context">L'objet Unity à surligner pour indiquer la provenance du message</param>
    [Conditional("ENABLE_LOGS")]
    public static void LogError(object msg, Object context)
    {
        UnityEngine.Debug.LogError(msg, context);
    }

    #endregion
}
