using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private float maxRangeX = 26.0f;
    private float maxRangeY = 12.0f;

    [SerializeField] private List<GameObject> playerBulletList;
    public bool canShoot = true;
    public float shootCD = .5f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform playerBulletListParent;

    private void Update()
    {
        ConstrainPlayerMovement();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0f).normalized * speed * Time.deltaTime);

        if (canShoot && Input.GetMouseButton(0))
        {
            canShoot = false;
            Shoot();
            StartCoroutine("ShootCD");
        }
    }

    private void ConstrainPlayerMovement()
    {
        if (transform.position.x > maxRangeX)
        {
            transform.position = new Vector3(maxRangeX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -maxRangeX)
        {
            transform.position = new Vector3(-maxRangeX, transform.position.y, transform.position.z);
        }

        if (transform.position.y > maxRangeY)
        {
            transform.position = new Vector3(transform.position.x, maxRangeY, transform.position.z);
        }
        else if (transform.position.y < -maxRangeY)
        {
            transform.position = new Vector3(transform.position.x, -maxRangeY, transform.position.z);
        }
    }

    void Shoot()
    {
        bool bulletFound = false;

        // Busca la primera bala de la lista que no esté activada
        foreach(GameObject playerBullet in playerBulletList)
        {
            if (!playerBullet.activeInHierarchy)
            {
                playerBullet.transform.position = shootPoint.position;
                playerBullet.SetActive(true);
                bulletFound = true;
                break;
            }
        }

        // Si no hay balas desactivadas, añade una nueva
        if (!bulletFound)
        {
            GameObject playerBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            playerBullet.SetActive(false);
            playerBulletList.Add(playerBullet);
            playerBullet.transform.parent = playerBulletListParent;
        }
    }

    IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(shootCD);
        canShoot = true;
    }
}
