using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    int nb = 500;
    GameObject Max;
    GameObject Min;

    void Start()
    {
        Max = GameObject.FindGameObjectWithTag("Max");
        Min = GameObject.FindGameObjectWithTag("Min");
    }

    void Update()
    {
        compteur++;
        if (compteur == nb)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(ennemi);
            compteur = 0;
            if (obj != null)
            {
                
                obj.transform.position = new Vector3(Random.Range((int)Min.transform.position.x, (int)Max.transform.position.x),
                    Max.transform.position.y, 0);
                obj.transform.rotation = Max.transform.rotation;
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
