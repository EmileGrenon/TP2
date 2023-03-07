using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Joueur : MonoBehaviour
{
    [SerializeField] float vitesse = 50;
    Rigidbody2D rb;
    CharacterController cc;
    [SerializeField] float vitesseTir = 3;
    [SerializeField] GameObject balle;
    GameObject barrel;

    float delaiTir = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CharacterController>();
        barrel = GameObject.FindGameObjectWithTag("barrel");
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();

        if (Input.GetAxis("Fire") > 0 && delaiTir <= 0)
        {
            //GameObject.Instantiate(balle,barrel.transform.position, barrel.transform.rotation);

            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(balle);

            if (obj != null)
            {
                obj.transform.position = barrel.transform.position;
                obj.transform.rotation = barrel.transform.rotation;
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

}

