using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    Camera camera;
    float hauteur;
    float largeur;
    GameObject player;
    float maxX;
    float minX;
    float maxY;
    float minY;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        hauteur = camera.orthographicSize;
        largeur = hauteur * camera.aspect;
        player = GameObject.FindGameObjectWithTag("Player");
        maxX = camera.transform.position.x + largeur - player.transform.localScale.x;
        minX = camera.transform.position.x - largeur + player.transform.localScale.x;
        maxY = camera.transform.position.y + hauteur - player.transform.localScale.y + player.transform.position.y;
        minY = camera.transform.position.y - hauteur + player.transform.localScale.y + player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minX, maxX),
            Mathf.Clamp(player.transform.position.y, minY, maxY), player.transform.position.z);
    }
}
