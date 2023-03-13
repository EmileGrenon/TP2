using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Ennemi1Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemi;
    int compteur = 0;
    int nb = 50;
    int scaling = 20;
    int currentScaling;
    float maxLargeur;
    float minLargeur;
    float hauteur;
    // Start is called before the first frame update
    void Start()
    {
        currentScaling = scaling;
        float camLargeur = (Camera.main.orthographicSize * Camera.main.aspect);
        print(camLargeur);
        maxLargeur = camLargeur - 1;
        minLargeur = -camLargeur + 1;
        hauteur = Camera.main.transform.position.y + Camera.main.orthographicSize + 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        compteur++;
        if (compteur == nb)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(ennemi);
            compteur = 0;
            if (obj != null)
            {
                if (Time.time >= currentScaling)
                {
                    currentScaling += scaling;
                    if (nb > 10)
                    {
                        nb -= 10;
                    }
                }
                obj.transform.position = new Vector3(Random.Range((int)minLargeur, (int)maxLargeur),hauteur,0);
                obj.transform.rotation = Quaternion.Euler(-Vector3.up);
                obj.SetActive(true);
                obj = null;
            }
        }
        
    }
}
