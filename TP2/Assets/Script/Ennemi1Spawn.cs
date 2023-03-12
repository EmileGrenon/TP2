using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Ennemi1Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    float temps;
    int nb = 500;
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
        int nombreAleatoire = Random.Range((int)Min.transform.position.x, (int)Max.transform.position.x);
        compteur++;
        temps++;
        GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(ennemi);
        if (compteur == nb)
        {
            compteur = 0;
            if (obj != null)
            {
                if(temps >= 10000)
                {
                    temps = 0;
                    if(nb >= 101)
                    {
                        nb -= 75;
                    }
                }
                obj.transform.position = new Vector3(nombreAleatoire,Max.transform.position.y,0);
                obj.transform.rotation = Max.transform.rotation;
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
