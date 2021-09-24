using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    private GameManager gameManager;

    // Variables para la matriz de pollos
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 11;

    // Variables para el movimiento de los pollos
    public float chickenSpeed = 2.0f;
    [SerializeField] private Vector3 moveDirection = Vector2.right;
    [SerializeField] private float padding = 2.0f;
    public Transform rightEdge;
    public Transform leftEdge;

    // Variables para el ataque de los pollos
    [SerializeField] private GameObject chickenBulletPrefab;
    [SerializeField] private List<GameObject> chickenBulletList;
    [SerializeField] private Transform chickenBulletListParent;
    [SerializeField] private float chickenAttackRate;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Se instancia una matriz de pollos
        for (int row = 0; row < rows; row++)
        {
            // Se calcula la posición en la fila en la que se va a instanciar
            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < columns; col++)
            {
                // Se calcula la posición en la columna en la que se va a instanciar
                GameObject chicken = Instantiate(chickenPrefab, transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                chicken.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        StartCoroutine("ChickenAttack");
    }

    private void Update()
    {
        // Movemos el bloque de pollos en la dirección actual
        transform.position += moveDirection * chickenSpeed * Time.deltaTime;

        // Obtenemos los bordes de la pantalla (modificable por otros bordes que queramos poner nosotros)
        Vector3 leftEdgePos = leftEdge.position;
        Vector3 rightEdgePos = rightEdge.position;

        foreach (Transform chicken in transform)
        {
            // Si el pollo está desactivado, continúa al siguiente
            if (!chicken.gameObject.activeInHierarchy)
            {
                continue;
            }

            // Si el bloque de pollos choca con los bordes de la pantalla, los pollos cambian de dirección
            if (moveDirection == Vector3.right && chicken.position.x >= (rightEdgePos.x - padding))
            {
                AdvanceRow();
            }
            else if (moveDirection == Vector3.left && chicken.position.x <= (leftEdgePos.x + padding))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        moveDirection.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    private IEnumerator ChickenAttack()
    {
        while (gameManager.gameOver == false)
        {
            yield return new WaitForSeconds(chickenAttackRate);

            foreach (Transform chicken in transform)
            {
                // Si el pollo está desactivado, continúa al siguiente
                if (!chicken.gameObject.activeInHierarchy)
                {
                    continue;
                }

                // Dada una probabilidad de disparo
                if (Random.value < ((float)(gameManager.GetScore() / transform.childCount) + 0.3f))
                {
                    bool bulletFound = false;

                    // Busca la primera bala de la lista que no esté activada
                    foreach (GameObject chickenBullet in chickenBulletList)
                    {
                        if (!chickenBullet.activeInHierarchy)
                        {
                            chickenBullet.transform.position = chicken.position;
                            chickenBullet.SetActive(true);
                            bulletFound = true;
                            break;
                        }
                    }

                    // Si no hay balas desactivadas, añade una nueva
                    if (!bulletFound)
                    {
                        GameObject chickenBullet = Instantiate(chickenBulletPrefab, chicken.position, Quaternion.identity);
                        chickenBullet.SetActive(false);
                        chickenBulletList.Add(chickenBullet);
                        chickenBullet.transform.parent = chickenBulletListParent;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (chickenAttackRate >= .5f)
            {
                chickenAttackRate -= chickenAttackRate * ((float)gameManager.GetScore() / (transform.childCount * 10));
            }
        }
    }
}
