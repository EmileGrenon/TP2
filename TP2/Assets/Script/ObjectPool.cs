using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField] GameObject[] objectsToPool;
    [SerializeField] int[] quantiteParObjets;

    public static ObjectPool objectPoolInstance;

    private void Awake()
    {
        if (objectPoolInstance == null)
        {
            objectPoolInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Mathf.Min(objectsToPool.Length, quantiteParObjets.Length); i++)
        {
            for (int o = 0; o < quantiteParObjets[i]; o++)
            {
                GameObject obj = Instantiate(objectsToPool[i]);
                obj.name = objectsToPool[i].name;
                obj.SetActive(false);
                pool.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(GameObject typeObject)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].name == typeObject.name && !pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return null;
    }
}