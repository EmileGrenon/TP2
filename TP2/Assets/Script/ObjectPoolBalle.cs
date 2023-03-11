using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBalle : MonoBehaviour
{
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField] int quantité;
    [SerializeField] GameObject prefab;

    public static ObjectPoolBalle objectPoolInstance;
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
        for (int i = 0; i < quantité; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.name = prefab.name;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return null;
    }
}
