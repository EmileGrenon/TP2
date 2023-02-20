using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] float vitesse = 50;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
    }

    void Deplacement()
    {
        Vector3 direction = cc.transform.up * Input.GetAxis("Vertical") + cc.transform.right * Input.GetAxis("Horizontal");

        if (direction.magnitude > 0)
        {
            direction = new Vector3(direction.x, direction.y, 0);
            //direction.y = 0;

            direction.Normalize();
            //direction = direction.normalized;

            //direction = direction * (Input.GetAxis("Sprint") * 0.5f + 1);


        }

        cc.Move((direction * vitesse) * Time.deltaTime);
    }
}
