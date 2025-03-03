using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> _pools;
    private GameObject _poolContainer;

    private void Awake()
    {
        _pools = new List<GameObject>();
        _poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for(int i = 0; i < poolSize; i++)
        {
            _pools.Add(CreateInstance());
        }
    }

    private GameObject CreateInstance()
    {
        GameObject newInstance = Instantiate(prefab);
        newInstance.transform.SetParent(_poolContainer.transform);
        newInstance.SetActive(false);
        return newInstance;
    }

    public GameObject GetInstanceFromPool()
    {
        for(int i = 0;i < poolSize;i++)
        {
            if (!_pools[i].activeInHierarchy)
            {
                return _pools[i];
            }
        }
        return CreateInstance();
    }
}
