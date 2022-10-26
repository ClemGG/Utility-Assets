using System;
using System.Runtime.Serialization;
using Project.Serialization.JSON;
using UnityEngine;

public class JSONSerializationExample : MonoBehaviour
{
    // Start is called before the first frame update
    [ContextMenu("Save V1")]
    void SaveV1()
    {
        JSONSerializer jsonSer = new();
        V1 v1 = jsonSer.LoadFromFile<V1>($"C:\\Code tests\\jsonFile.json");
        print(v1);
        print("Avant sauvegarde : ");
        print($"v1.Name : {v1.Name}");
        print($"v1.age : {v1.age}");

        v1.Name = "Version 1";
        v1.age = 1;

        jsonSer.SaveToFile(v1, $"C:\\Code tests\\jsonFile.json");

        print("Après sauvegarde : ");
        print($"v1.Name : {v1.Name}");
        print($"v1.age : {v1.age}");

    }

    // Start is called before the first frame update
    [ContextMenu("Save V2")]
    void SaveV2()
    {
        JSONSerializer jsonSer = new();
        V2 v2 = jsonSer.LoadFromFile<V2>($"C:\\Code tests\\jsonFile.json");

        print("Avant sauvegarde : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

        v2.Name = "Version 2";
        v2.age = 2;
        v2.Position = Vector3.one * 2;

        jsonSer.SaveToFile(v2, $"C:\\Code tests\\jsonFile.json");

        print("Après sauvegarde : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

    }

    // Start is called before the first frame update
    [ContextMenu("Load V1")]
    void LoadV1()
    {
        JSONSerializer jsonSer = new();
        V1 v1 = jsonSer.LoadFromFile<V1>("C:\\Code tests\\jsonFile.json");

        print("Après chargement : ");
        print($"v2.Name : {v1.Name}");
        print($"v2.age : {v1.age}");

    }

    // Start is called before the first frame update
    [ContextMenu("Load V2")]
    void LoadV2()
    {
        JSONSerializer jsonSer = new();
        V2 v2 = jsonSer.LoadFromFile<V2>("C:\\Code tests\\jsonFile.json");

        print("Après chargement : ");
        print($"v2.Name : {v2.Name}");
        print($"v2.age : {v2.age}");
        print($"v2.Position : {v2.Position}");

    }
}

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