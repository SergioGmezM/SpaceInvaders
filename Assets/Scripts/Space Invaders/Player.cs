using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 10f;

    Vector3 horMove;

    bool canShoot = true;
    public float shootCD = .5f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        horMove = new Vector3(horizontal, vertical, 0f).normalized;

        if (canShoot && Input.GetMouseButton(0))
        {
            canShoot = false;
            Shoot();
            StartCoroutine("ShootCD");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + horMove * speed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
    }
    IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(shootCD);
        canShoot = true;
    }
}
