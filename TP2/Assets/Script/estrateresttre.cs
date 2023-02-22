using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrateresttre : MonoBehaviour
{
    [SerializeField] float vitesseEnnemi = 10;
    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            transform.Translate(-1 * vitesseEnnemi * Time.deltaTime, -1 * Time.deltaTime * vitesseEnnemi, 0);
        }

    }
}
