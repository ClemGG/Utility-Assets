using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Serialization
{
    /// <summary>
    /// Signature pour l'implémentation des fonctions d'écriture dans un fichier
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Charge un fichier de type générique
        /// </summary>
        /// <param name="filePath">Fichier a charger</param>
        /// <returns>Instance du fichier, new T() si le fichier n'existe pas.</returns>
        T LoadFromFile<T>(string filePath) where T : new();
    }

    /// <summary>
    /// Signature pour l'implémentation des fonctions de lecture dans un fichier
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Enregristre le fichier sur le disque
        /// </summary>
        /// <param name="data">Données à sauvegarder</param>
        /// <param name="filePath">Fichier a charger</param>
        void SaveToFile<T>(T data, string filePath);
    }

    /// <summary>
    /// Signature pour l'implémentation des fonctions de formattage du contenu d'un fichier
    /// </summary>
    public interface IFileFormatter
    {
        /// <summary>
        /// Formatte le texte du fichier pour le rendre lisible
        /// </summary>
        /// <param name="content">Le texte à rendre lisible</param>
        string Format(string content);
    }
}