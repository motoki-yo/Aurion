using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;                                 // O objeto do jogo de colunas
    public int columnPoolSize = 5;                                  // Quantas colunas para manter em espera.
    public float spawnRate = 2f;                                    // Como rapidamente as colunas aparecem.
    public float columnMin = -1f;                                   // Valor mínimo de y da posição da coluna.
    public float columnMax = 3.5f;                                  // Valor máximo y da posição da coluna.

    private GameObject[] columns;                                   // Coleção de colunas agrupadas.
    private int currentColumn = 0;                                  // Índice da coluna atual na coleção.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     // Uma posição de espera para nossas colunas não utilizadas fora da tela.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;


        // Inicialize a coleção de colunas.
        columns = new GameObject[columnPoolSize];

        // Faz um loop pela coleção ...
        for (int i = 0; i < columnPoolSize; i++)
        {

            //... e crie as colunas individuais.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }


    // Isso gera colunas, desde que o jogo não termine.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;


            // Defina uma posição y aleatória para a coluna
            float spawnYPosition = Random.Range(columnMin, columnMax);


            //...de seguida, defina a coluna atual para essa posição.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);


            // Aumenta o valor de currentColumn. Se o novo tamanho for muito grande, ajuste-o para zero.
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}