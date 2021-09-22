using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paella : MonoBehaviour
{

    [SerializeField] int vida = 5;

    private void OnTriggerEnter(Collider other)
    {
        vida--;
        other.gameObject.SetActive(false);
        if (vida <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
