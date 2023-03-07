using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMouvement : MonoBehaviour
{
    [SerializeField] float vitesse = 5;
    Camera cam;
    SpriteRenderer sr;
    float hauteurCam;
    float hauteurMesh;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        hauteurMesh = sr.bounds.size.y / 2;
        hauteurCam = cam.orthographicSize * cam.aspect / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + hauteurMesh < -hauteurCam + cam.transform.position.y)
        {
            transform.position = transform.position + new Vector3(0, hauteurMesh * 4 -1, 0);
        }
        transform.Translate(transform.up * -vitesse * Time.deltaTime);
    }
}
