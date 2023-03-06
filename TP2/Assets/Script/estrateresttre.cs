using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrateresttre : MonoBehaviour
{
    [SerializeField] float amplitude = 3;
    [SerializeField] float radStepPerSecond = (float)(3.14159 / 2);
    [SerializeField] GameObject tir;
    [SerializeField] Space space = Space.World;
    GameObject barrel;
    float placeIni;
    // Start is called before the first frame update
    void Start()
    {
        placeIni = transform.position.x;
        barrel = GameObject.FindGameObjectWithTag("barrel2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(placeIni + (amplitude * Mathf.Sin(radStepPerSecond * Time.time))
            - transform.position.x, (float)-0.005, 0, space);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
