using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JSONSerializer
{
    /// <summary>
    /// Système de sauvegarde/chargement de données dans un fichier au format JSON
    /// </summary>
    public static class JSONSerializerDTO
    {
        #region Fonctions publiques

        /// <summary>
        /// Charge un fichier de type générique
        /// </summary>
        /// <param name="filename">Fichier a charger</param>
        /// <returns>Instance du fichier</returns>
        public static T LoadFromFile<T>(string filename)
        {
            // Lecture du fichier

            string data = File.ReadAllText(filename);

            // Désérialisation des données

            using MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(data));
            DataContractJsonSerializer converter = new DataContractJsonSerializer(typeof(T));
            T result = (T)converter.ReadObject(stream);

            return result;
        }

        /// <summary>
        /// Enregristre le fichier sur le disque
        /// </summary>
        /// <param name="data">Données à sauvegarder</param>
        public static void SaveToFile<T>(T data, string filename)
        {
            using MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer converter = new DataContractJsonSerializer(data.GetType());
            converter.WriteObject(stream, data);
            stream.Position = 0;

            using StreamReader reader = new StreamReader(stream);
            string parsing = reader.ReadToEnd();

            File.WriteAllText(filename, FormatJson(parsing), Encoding.Unicode);
        }

        /// <summary>
        /// Formatte le text Json pour le rendre lisible
        /// </summary>
        /// <param name="json">Le texte Json à rendre lisible</param>
        public static string FormatJson(string json)
        {
            string indent = "  ";
            var indentation = 0;
            var quoteCount = 0;
            var escapeCount = 0;

            var result =
                from ch in json ?? string.Empty
                let escaped = (ch == '\\' ? escapeCount++ : escapeCount > 0 ? escapeCount-- : escapeCount) > 0
                let quotes = ch == '"' && !escaped ? quoteCount++ : quoteCount
                let unquoted = quotes % 2 == 0
                let colon = ch == ':' && unquoted ? ": " : null
                let nospace = char.IsWhiteSpace(ch) && unquoted ? string.Empty : null
                let lineBreak = ch == ',' && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, indentation)) : null
                let openChar = (ch == '{' || ch == '[') && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, ++indentation)) : ch.ToString()
                let closeChar = (ch == '}' || ch == ']') && unquoted ? Environment.NewLine + string.Concat(Enumerable.Repeat(indent, --indentation)) + ch : ch.ToString()
                select colon ?? nospace ?? lineBreak ?? (
                    openChar.Length > 1 ? openChar : closeChar
                );

            return string.Concat(result);
        }

        #endregion
    }
}