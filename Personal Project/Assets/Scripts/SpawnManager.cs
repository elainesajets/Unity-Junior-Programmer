using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject mouse;
    public GameObject obstacle;

    private float ySpawnPos = 0.5f;
    private float zSpawnPos = 10.0f;
    private float xSpawnRange = 12.0f;

    private float spawnDelay = 1.0f;
    private float repeatRate = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, repeatRate);
        InvokeRepeating("SpawnObstacle", spawnDelay, repeatRate + 2.0f);
        InvokeRepeating("SpawnMouse", spawnDelay, repeatRate + 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, zSpawnPos);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnMouse()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, zSpawnPos);

        Instantiate(mouse, spawnPos, Quaternion.identity);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, zSpawnPos);

        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }
}
