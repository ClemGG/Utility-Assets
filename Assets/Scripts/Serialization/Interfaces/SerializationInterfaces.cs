namespace Project.Serialization
{
    /// <summary>
    /// Signature pour l'impl�mentation des fonctions d'�criture dans un fichier
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Enregristre le fichier sur le disque
        /// </summary>
        /// <param name="data">Donn�es � sauvegarder</param>
        /// <param name="filePath">Fichier a charger</param>
        void WriteToFile<T>(T data, string filePath) where T : notnull;
    }

    /// <summary>
    /// Signature pour l'impl�mentation des fonctions de lecture dans un fichier
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Charge un fichier de type g�n�rique
        /// </summary>
        /// <param name="filePath">Fichier a charger</param>
        /// <returns>Instance du fichier, new T() si le fichier n'existe pas.</returns>
        T ReadFromFile<T>(string filePath) where T : new();
    }
}