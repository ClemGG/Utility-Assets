using Project.Pool;
using System.Collections.Generic;
using UnityEngine;

//This class is placed on the script to showcase the use of the IPooled interface.
//Each IPooled object can have its own specific behaviour when it enters or leaves the pool.

public class Instance : MonoBehaviour, IEnqueued, IDequeued
{
    [field: SerializeField]
    private float _despawnDelay = 1.5f;


    private Vector3 _spawnPos;
    private ClassPooler<GameObject> _pooler;
    private List<Instance> _spawnedObjs;
    private float _despawnCounter;



    public void Init(ClassPooler<GameObject> pooler, Vector3 spawnPos, List<Instance> spawnedObjs)
    {
        if (_pooler is null)
        {
            _pooler = pooler;
            _spawnPos = spawnPos;
            transform.position = _spawnPos;
            name = name.Replace("(Clone)", null);
            _spawnedObjs = spawnedObjs;
        }

    }

    public void UpdateMe()
    {
        _despawnCounter += Time.deltaTime;

        if (_despawnCounter >= _despawnDelay)
        {
            _despawnCounter = 0f;
            _spawnedObjs.Remove(this);
            _pooler.ReturnToPool(gameObject, name);
        }
    }


    public void OnEnqueued()
    {
        gameObject.SetActive(false);
    }

    public void OnDequeued()
    {
        gameObject.SetActive(true);
        transform.position = _spawnPos;
    }
}
