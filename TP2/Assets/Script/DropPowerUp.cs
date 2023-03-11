using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class DropPowerUp : MonoBehaviour
{
    [SerializeField] float ChanceApparition;
    [SerializeField] GameObject powerUp;
    void OnDisable()
    {
        if (Random.value <= ChanceApparition)
        {
            GameObject obj = ObjectPool.objectPoolInstance.GetPooledObject(powerUp);
            if (obj != null)
            {
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
                obj = null;
            }
        }
    }
}
