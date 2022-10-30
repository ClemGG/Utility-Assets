using UnityEngine;
using Project.Pool;
using System.Collections.Generic;

public class ObjectPoolTester : MonoBehaviour
{
    [field: SerializeField]
    private GameObject _prefab { get; set; }
    [field: SerializeField]
    private float _spawnDelay { get; set; } = .1f;


    private ClassPooler<GameObject> _pooler { get; set; }
    private List<Instance> _spawnedObjs { get; set; } = new List<Instance>();
    private float _spawnCounter { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _pooler = new ClassPooler<GameObject>
            (
                new Pool<GameObject>(_prefab.name, 100, () => Instantiate(_prefab, transform))
            );
    }

    // Update is called once per frame
    void Update()
    {
        _spawnCounter += Time.deltaTime;

        if(_spawnCounter >= _spawnDelay)
        {
            _spawnCounter = 0f;

            Vector3 spawnPos = transform.position;
            spawnPos.x += Random.Range(-5f, 5f);
            spawnPos.z += Random.Range(-5f, 5f);

            Instance i = _pooler.GetFromPool<GameObject>(_prefab.name).GetComponent<Instance>();
            i.Init(_pooler, spawnPos, _spawnedObjs);
            _spawnedObjs.Add(i);

        }


        for (int i = 0; i < _spawnedObjs.Count; i++)
        {
            _spawnedObjs[i].UpdateMe();
        }
    }
}
