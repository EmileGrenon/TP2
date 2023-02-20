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
        //Deplacement();
    }

    //void Deplacement()
    //{
    //    Vector3 direction = gameObject.transform.forward * Input.GetAxis("Vertical") + gameObject.transform.right * Input.GetAxis("Horizontal");

    //    if (direction.magnitude > 0)
    //    {
    //        direction = new Vector3(direction.x, 0, direction.z);
    //        //direction.y = 0;

    //        direction.Normalize();
    //        //direction = direction.normalized;

    //        direction = direction * (Input.GetAxis("Sprint") * 0.5f + 1);


    //    }
    //    //if (cc.isGrounded)
    //    //{
    //    //    if (Input.GetButtonDown("Jump"))
    //    //    {
    //    //        jump = Vector3.up * forceJump;
    //    //    }
    //    //    jump.y = Mathf.Max(-1, jump.y);
    //    //}
    //    //else
    //    //{
    //    //    jump -= Vector3.up * Time.deltaTime * gravity;
    //    //}

    //    cc.Move((direction * vitesse) * Time.deltaTime);
    //}
}
