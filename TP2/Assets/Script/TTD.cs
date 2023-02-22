using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTD : MonoBehaviour
{
    [SerializeField] float tempsDeVieInitial = 3;
    float tempsDeVie;

    private void OnEnable()
    {
        tempsDeVie = tempsDeVieInitial;
    }

    // Update is called once per frame
    void Update()
    {
        tempsDeVie -= Time.deltaTime;
        if (tempsDeVie <= 0)
            gameObject.SetActive(false);
    }
}