using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi1Mouvement : MonoBehaviour
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
            transform.Translate(0, -1 * Time.deltaTime * vitesseEnnemi, 0);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        print("allo");
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
