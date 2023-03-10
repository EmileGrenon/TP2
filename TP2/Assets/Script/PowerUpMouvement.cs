using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMouvement : MonoBehaviour
{
    [SerializeField] float vitesse = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * Time.deltaTime * vitesse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
