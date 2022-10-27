using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Project.Serialization.XML
{
    /// <summary>
    /// Syst�me de sauvegarde/chargement de donn�es dans un fichier au format XML
    /// </summary>
    public class XMLSerializer : IFileWriter, IFileReader
    {
        #region Fonctions publiques

        /// <summary>
        /// Enregristre le fichier sur le disque
        /// </summary>
        /// <param name="data">Donn�es � sauvegarder</param>
        /// <param name="filePath">Fichier a charger</param>
        public void WriteToFile<T>(T data, string filePath) where T : notnull
        {
            FileStream fs = new(filePath, FileMode.OpenOrCreate);
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    ",
            };
            var writer = XmlWriter.Create(fs, settings);
            DataContractSerializer ser = new(typeof(T));

            ser.WriteObject(writer, data);
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// Charge un fichier de type g�n�rique
        /// </summary>
        /// <param name="filePath">Fichier a charger</param>
        /// <returns>Instance du fichier, new T() si le fichier n'existe pas.</returns>
        public T ReadFromFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
            {
                return new T();
            }

            // Cr�e le lecteur du fichier XML
            FileStream fs = new(filePath, FileMode.OpenOrCreate);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new(typeof(T));

            // D�serialise les donn�es
            T result = (T)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();

            return result;
        }

        #endregion
    }
}