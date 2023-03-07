using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2Mouvement : MonoBehaviour
{
    [SerializeField] float amplitude = 3;
    [SerializeField] float radStepPerSecond = (float)(3.14159 / 2);
    [SerializeField] GameObject balleEnnemi;

    [SerializeField] float vitesseTir = 0.5f;
    float delaiTir = 0;

    GameObject barrel;
    GameObject player;
    float placeIni;
    float tempsIni;
    // Start is called before the first frame update
    void Start()
    {
        placeIni = transform.position.x;
        barrel = GameObject.FindGameObjectWithTag("barrel2");
        tempsIni = Time.time; 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(placeIni + (amplitude * Mathf.Sin(Time.time - tempsIni))
            - transform.position.x, (float)-0.005, 0);

        if (delaiTir <= 0)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(balleEnnemi);

            if (obj != null)
            {
                obj.transform.position = barrel.transform.position;
                obj.transform.rotation = Quaternion.LookRotation(Vector3.forward,player.transform.position - barrel.transform.position);
                obj.SetActive(true);
                obj = null;
            }

            delaiTir = 1 / vitesseTir;
        }
        else
            delaiTir -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
