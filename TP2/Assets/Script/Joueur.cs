using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Pool;

public class Joueur : MonoBehaviour
{
    [SerializeField] float vitesse = 50;
    [SerializeField] float vitesseTir = 3;
    [SerializeField] GameObject balle;
    [SerializeField] GameObject powerUp;

    Rigidbody2D rb;
    GameObject barrel1;
    GameObject barrel2;
    GameObject barrel3;
    int vie = 1;

    float delaiTir = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        barrel1 = GameObject.FindGameObjectWithTag("barrel1");
        barrel2 = GameObject.FindGameObjectWithTag("barrel2");
        barrel3 = GameObject.FindGameObjectWithTag("barrel3");
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();

        if (Input.GetAxis("Fire") > 0 && delaiTir <= 0)
        {
            GameObject obj1 = ObjectPoolBalle.objectPoolInstance.GetPooledObject();

            switch (vie)
            {
                case 1:
                    if (obj1 != null)
                    {
                        obj1.transform.position = barrel1.transform.position;
                        obj1.transform.rotation = transform.rotation;
                        obj1.SetActive(true);
                        obj1 = null;
                    }
                    break;
                case 2:

                    if (obj1 != null)
                    {
                        obj1.transform.position = barrel2.transform.position;
                        obj1.transform.rotation = transform.rotation;
                        obj1.SetActive(true);
                        obj1 = null;
                    }
                    GameObject obj2 = ObjectPoolBalle.objectPoolInstance.GetPooledObject();
                    if (obj2 != null)
                    {
                        obj2.transform.position = barrel3.transform.position;
                        obj2.transform.rotation = transform.rotation;
                        obj2.SetActive(true);
                        obj2 = null;
                    }
                    break;
                default:

                    
                    if (obj1 != null)
                    {
                        obj1.transform.position = barrel1.transform.position;
                        obj1.transform.rotation = transform.rotation;
                        obj1.SetActive(true);
                        obj1 = null;
                    }
                    GameObject obj3 = ObjectPoolBalle.objectPoolInstance.GetPooledObject();
                    if (obj3 != null)
                    {
                        obj3.transform.position = barrel2.transform.position;
                        obj3.transform.rotation = transform.rotation;
                        obj3.SetActive(true);
                        obj3 = null;
                    }
                    GameObject obj4 = ObjectPoolBalle.objectPoolInstance.GetPooledObject();
                    if (obj4 != null)
                    {
                        obj4.transform.position = barrel3.transform.position;
                        obj4.transform.rotation = transform.rotation;
                        obj4.SetActive(true);
                        obj4 = null;
                    }
                    break;
            }
            delaiTir = 1 / vitesseTir;
        }
        else
        {
            delaiTir -= Time.deltaTime;
        }
    }

    void Deplacement()
    {
        Vector3 direction = rb.transform.up * Input.GetAxis("Vertical") + rb.transform.right * Input.GetAxis("Horizontal");

        if (direction.magnitude > 0)
        {
            direction = new Vector3(direction.x, direction.y, 0);
            direction.Normalize();
        }
        rb.MovePosition(transform.position + direction * vitesse * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == powerUp.name)
        {
            print("a");
            if (vie >= 3)
                vie = 3;
            else
                vie++;
        }
        else
        {
            vie -= 1;

            if (vie <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

