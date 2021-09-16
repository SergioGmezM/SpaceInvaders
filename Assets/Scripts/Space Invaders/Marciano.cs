using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marciano : MonoBehaviour
{

    [SerializeField] float shootCooldown = 20f;
    [SerializeField]GameObject bullet;

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootCooldown);
            shootCooldown -= 0.1f;
        }
    }
}
