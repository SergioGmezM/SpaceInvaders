using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    int time = 0;

    private void Start()
    {
        StartCoroutine("DeathTime");
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    IEnumerator DeathTime()
    {
        while(time < 5)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
        gameObject.SetActive(false);
    }
}
