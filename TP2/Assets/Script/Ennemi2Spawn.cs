using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    int nb = 500;
    float maxLargeur;
    float minLargeur;
    float hauteur;

    void Start()
    {
        float camLargeur = (Camera.main.orthographicSize * Camera.main.aspect);
        print(camLargeur);
        maxLargeur = camLargeur - 3;
        minLargeur = -camLargeur + 3;
        hauteur = Camera.main.transform.position.y + Camera.main.orthographicSize + 2;
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
                obj.transform.position = new Vector3(Random.Range((int)minLargeur, (int)maxLargeur),
                    hauteur, 0);
                obj.transform.rotation = Quaternion.Euler(-Vector3.up);
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
