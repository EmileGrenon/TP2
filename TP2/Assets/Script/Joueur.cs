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
        //barrel2 = GameObject.FindGameObjectWithTag("barrel2");
        //barrel3 = GameObject.FindGameObjectWithTag("barrel3");
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();

        if (Input.GetAxis("Fire") > 0 && delaiTir <= 0)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(balle);

            if (obj != null)
            {
                obj.transform.position = barrel1.transform.position;
                obj.transform.rotation = barrel1.transform.rotation;
                obj.SetActive(true);
                obj = null;
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
        vie -= 1;

        if (vie <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

