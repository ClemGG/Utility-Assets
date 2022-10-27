using System.Runtime.Serialization;
using Project.Serialization;
using UnityEngine;

//Raccourci
using Ser = Project.Serialization.SerializationServices;

public class SerializationExample : MonoBehaviour
{
    #region Variables Unity

    /// <summary>
    /// Le type de sérialiseur à utiliser
    /// </summary>
    [field: SerializeField]
    [field: Tooltip("Le type de sérialiseur à utiliser")]
    private SerializationTargetType TargetType { get; set; } = SerializationTargetType.Json;

    /// <summary>
    /// Le chemin du fichier, sans extension
    /// </summary>
    [field: SerializeField]
    [field: Tooltip("Le chemin du fichier, sans extension")]
    private string FilePath { get; set; } = "C:\\Code tests\\jsonFile";

    #endregion

    #region Fonctions privées

    // Start is called before the first frame update
    [ContextMenu("Save V1")]
    void SaveV1()
    {
        V1 v1 = Ser.ReadFromFile<V1>(FilePath, TargetType);
        print(v1);
        print("Avant sauvegarde : ");
        print($"v1.Name : {v1.Name}");
        print($"v1.age : {v1.age}");

        v1.Name = "Version 1";
        v1.age = 1;

        Ser.WriteToFile(v1, FilePath, TargetType);

        print("Après sauvegarde : ");
        print($"v1.Name : {v1.Name}");
        print($"v1.age : {v1.age}");

    }

    // Start is called before the first frame update
    [ContextMenu("Save V2")]
    void SaveV2()
    {
        V2 v2 = Ser.ReadFromFile<V2>(FilePath, TargetType);

        print("Avant sauvegarde : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

        v2.Name = "Version 2";
        v2.age = 2;
        v2.Position = Vector3.one * 2;

        Ser.WriteToFile(v2, FilePath, TargetType);

        print("Après sauvegarde : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

    }

    // Start is called before the first frame update
    [ContextMenu("Load V1")]
    void LoadV1()
    {
        V1 v1 = Ser.ReadFromFile<V1>(FilePath, TargetType);

        print("Après chargement : ");
        print($"v2.Name : {v1.Name}");
        print($"v2.age : {v1.age}");

    }

    // Start is called before the first frame update
    [ContextMenu("Load V2")]
    void LoadV2()
    {
        V2 v2 = Ser.ReadFromFile<V2>(FilePath, TargetType);

        print("Après chargement : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

    }

    #endregion
}

#region Classes de test

[DataContract(Name = "Version")]
public class V1 : IExtensibleDataObject
{
    [DataMember(Order = 0)]
    public string Name = string.Empty;

    [DataMember(Order = 1)]
    public int age = 0;

    public ExtensionDataObject ExtensionData { get; set; }
}

[DataContract(Name = "Version")]
public class V2 : V1, IExtensibleDataObject
{
    [DataMember(Order = 2)]
    public Vector3 Position = Vector3.zero;
}

#endregion