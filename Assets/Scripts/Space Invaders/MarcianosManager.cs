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
    int wayPointIndex = 0;

    private void Start()
    {
        waypoints = new Transform[waypointDad.childCount];
        marcianitos = new GameObject[marcianitosDad.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointDad.GetChild(i);
        }

        for (int i = 0; i < marcianitos.Length; i++)
        {
            marcianitos[i] = marcianitosDad.GetChild(i).gameObject;
        }
        StartCoroutine("MoverPollos");
    }


    IEnumerator MoverPollos()
    {
        while (wayPointIndex < (waypoints.Length - marcianitos.Length))
        {
            for (int i = 0; i < marcianitos.Length; i++)
            {
                marcianitos[i].transform.position = waypoints[wayPointIndex + i].position;
            }

            wayPointIndex++;
            yield return new WaitForSeconds(moveTime);
        }
    }
}
