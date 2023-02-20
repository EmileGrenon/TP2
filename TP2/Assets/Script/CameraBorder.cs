using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    [SerializeField] GameObject personnage;
    Camera camera;
    float hauteur;
    float largeur;
    float hauteurPersonnage;
    float largeurPersonnage;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        hauteur = 2f * camera.orthographicSize;
        largeur = hauteur * camera.aspect;
        hauteurPersonnage = personnage.transform.localScale.y;
        largeurPersonnage = personnage.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        float xMin = camera.transform.position.x - hauteur / 2 + largeurPersonnage / 2;
        float xMax = camera.transform.position.x + hauteur / 2 - largeurPersonnage / 2;
        float yMin = camera.transform.position.y - hauteur / 2 + hauteurPersonnage / 2;
        float yMax = camera.transform.position.y + hauteur / 2 - hauteurPersonnage / 2;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        transform.position = clampedPosition;
    }
}
