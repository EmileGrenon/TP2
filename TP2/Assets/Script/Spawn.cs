using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    GameObject Max;
    GameObject Min;
    // Start is called before the first frame update
    void Start()
    {
        Max = GameObject.FindGameObjectWithTag("Max");
        Min = GameObject.FindGameObjectWithTag("Min");
    }

    // Update is called once per frame
    void Update()
    {
        compteur++;
        GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(ennemi);
        if (compteur == 5000)
        {
            if (obj != null)
            {
                obj.transform.position = Max.transform.position;
                obj.transform.rotation = Max.transform.rotation;
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
