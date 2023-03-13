using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur;
    int nb = 150;
    float maxLargeur;
    float minLargeur;
    float hauteur;

    void Start()
    {
        float camLargeur = (Camera.main.orthographicSize * Camera.main.aspect);
        maxLargeur = camLargeur - 4;
        minLargeur = -camLargeur + 4;
        hauteur = Camera.main.transform.position.y + Camera.main.orthographicSize + 2;
    }

    void FixedUpdate()
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
