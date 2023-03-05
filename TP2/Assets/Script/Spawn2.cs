using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    float temps;
    int nb = 500;
    GameObject Max;
    GameObject Min;
    private System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        Max = GameObject.FindGameObjectWithTag("Max");
        Min = GameObject.FindGameObjectWithTag("Min");
    }

    // Update is called once per frame
    void Update()
    {
        int nombreAleatoire = random.Next((int)Min.transform.position.x, (int)Max.transform.position.x);
        compteur++;
        temps++;
        GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(ennemi);
        if (compteur == nb)
        {
            compteur = 0;
            if (obj != null)
            {
                
                obj.transform.position = new Vector3(nombreAleatoire, Max.transform.position.y, 0);
                obj.transform.rotation = Max.transform.rotation;
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
