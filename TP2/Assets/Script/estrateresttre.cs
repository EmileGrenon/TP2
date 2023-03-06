using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrateresttre : MonoBehaviour
{
    [SerializeField] float amplitude = 3;
    [SerializeField] float radStepPerSecond = (float)(3.14159 / 2);
    [SerializeField] GameObject balleEnnemi;
    [SerializeField] Space space = Space.World;

    float vitesseTir = 0.5f;
    float delaiTir = 0.5f;
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
            - transform.position.x, (float)-0.005, 0, space);

        if (delaiTir <= 0)
        {
            //GameObject.Instantiate(balle,barrel.transform.position, barrel.transform.rotation);

            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(balleEnnemi);

            if (obj != null)
            {
                obj.transform.position = barrel.transform.position;
                obj.transform.rotation = barrel.transform.rotation;
                obj.SetActive(true);
                obj = null;
            }

            delaiTir = 0.5f / vitesseTir;
        }
        else
        {
            delaiTir -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
