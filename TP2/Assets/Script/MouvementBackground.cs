using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBackground : MonoBehaviour
{
    Camera cam;
    MeshRenderer mr;
    float camMax;
    float camMin;
    float hauteur;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        mr = GetComponent<MeshRenderer>();
        hauteur = mr.bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
