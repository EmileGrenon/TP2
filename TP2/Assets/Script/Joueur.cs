using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] float vitesse = 50;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
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
