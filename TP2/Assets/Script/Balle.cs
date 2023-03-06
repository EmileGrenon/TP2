using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] float vitesse = 20;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(transform.up * vitesse * Time.deltaTime, Space.World);
        rb.velocity = transform.up * Time.deltaTime * vitesse;
        //print(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
