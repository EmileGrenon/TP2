using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] float vitesse = 20;
    [SerializeField] GameObject impactPrefab;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * Time.deltaTime * vitesse;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject impactFx = ObjectPool.objectPoolInstance.GetPooledObject(impactPrefab);
        if (impactFx != null)
        {
            impactFx.SetActive(true);
            impactFx.transform.position = collision.contacts[0].point;
        }

        gameObject.SetActive(false);
    }
}
