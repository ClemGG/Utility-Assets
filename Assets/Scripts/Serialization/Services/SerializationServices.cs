using Project.Serialization.JSON;
using Project.Serialization.XML;

namespace Project.Serialization
{
    /// <summary>
    /// Permet d'interfacer plus facilement avec les classes
    /// de sérialisation pour différents types de fichiers
    /// </summary>
    public static class SerializationServices
    {
        #region Variables statiques

        /// <summary>
        /// Cache le sérialiseur pour n'en créer une instance qu'en cas de besoin
        /// </summary>
        private static IFileWriter s_writer { get; set; } = null;

        /// <summary>
        /// Cache le sérialiseur pour n'en créer une instance qu'en cas de besoin
        /// </summary>
        private static IFileReader s_reader { get; set; } = null;

        #endregion

        #region Fonctions publiques

        /// <summary>
        /// Interface avec la méthode de sauvegarde du sérialiseur
        /// </summary>
        /// <typeparam name="T">Le type de donnée</typeparam>
        /// <param name="data">La structure à sérialiser</param>
        /// <param name="filePath">Le chemin d'accès au fichier (avec l'extension)</param>
        /// <param name="targetType">Le type de sérialisation à effectuer</param>
        public static void WriteToFile<T>(T data, string filePath, SerializationTargetType targetType)
        {
            string extension = string.Empty;
            switch (targetType)
            {
                case SerializationTargetType.Json:
                    if (s_writer is not JSONSerializer)
                    {
                        s_writer = new JSONSerializer();
                    }
                    extension = ".json";
                    break;

                case SerializationTargetType.XML:
                    if (s_writer is not XMLSerializer)
                    {
                        s_writer = new XMLSerializer();
                    }
                    extension = ".xml";
                    break;
            }

            s_writer.WriteToFile(data, $"{filePath}{extension}");
        }

        /// <summary>
        /// Interface avec la méthode de chargement du sérialiseur
        /// </summary>
        /// <typeparam name="T">Le type de donnée à retourner</typeparam>
        /// <param name="filePath">Le chemin d'accès au fichier (avec l'extension)</param>
        /// <param name="targetType">Le type de sérialisation à effectuer</param>
        public static T ReadFromFile<T>(string filePath, SerializationTargetType targetType) where T : new()
        {
            string extension = string.Empty;
            switch (targetType)
            {
                case SerializationTargetType.Json:
                    if (s_reader is not JSONSerializer)
                    {
                        s_reader = new JSONSerializer();
                    }
                    extension = ".json";
                    break;

                case SerializationTargetType.XML:
                    if (s_reader is not XMLSerializer)
                    {
                        s_reader = new XMLSerializer();
                    }
                    extension = ".xml";
                    break;
            }

            return s_reader.ReadFromFile<T>($"{filePath}{extension}");
        }

        #endregion
    }
}