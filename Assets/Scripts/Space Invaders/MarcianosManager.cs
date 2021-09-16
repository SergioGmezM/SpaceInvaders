using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcianosManager : MonoBehaviour
{
    // buscar una forma de ver si hay alguno vivo para poner en el while de la corrutina, por ahora lo pongo infinito (tipo un contador de marcianitos)
    // crear un monton de waypoints de todas las posiciones por las que pasaran los marcianitos

    Transform[] waypoints;
    [SerializeField] Transform waypointDad;
    GameObject[] marcianitos;
    [SerializeField] Transform marcianitosDad;
    [SerializeField] float moveTime = 1f;

    private void Start()
    {
        waypoints = new Transform[waypointDad.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointDad.GetChild(i);
        }

        marcianitos = new GameObject[marcianitosDad.childCount];
        for (int i = 0; i < marcianitos.Length; i++)
        {
            marcianitos[i] = marcianitosDad.GetChild(i).gameObject;
        }
        StartCoroutine("MoveMarcianitos");
    }

    IEnumerator MoveMarcianitos()
    {
        while (true) // importante que el while acabe cuando no haya marcianitos
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                marcianitos[i].transform.position = waypoints[i].position;
            }

            yield return new WaitForSeconds(moveTime);
            moveTime -= .01f;
        }
    }
}
