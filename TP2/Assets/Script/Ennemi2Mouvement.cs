using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2Mouvement : MonoBehaviour
{
    [SerializeField] float amplitude = 3;
    [SerializeField] float radStepPerSecond = (float)(3.14159 / 2);
    [SerializeField] GameObject balleEnnemi;

    [SerializeField] float vitesseTir = 0.1f;
    bool uneBalle = false;

    GameObject barrel;
    GameObject player;
    const float tempsTir = 3;
    float placeIni;
    float deltaTir = 0;
    float tempsIni;
    // Start is called before the first frame update
    void Start()
    {
        placeIni = transform.position.x;
        tempsIni = Time.time; 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        deltaTir += Time.deltaTime;

        transform.Translate(placeIni + (amplitude * Mathf.Sin(Time.time - tempsIni))
            - transform.position.x, (float)-0.005, 0);

        if (deltaTir >= tempsTir)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(balleEnnemi);

            if (obj != null)
            {
                obj.transform.position = transform.position;
                obj.transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
                obj.SetActive(true);
                obj = null;
                deltaTir= 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
