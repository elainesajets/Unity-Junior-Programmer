using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject mouse;
    [SerializeField] GameObject obstacle;

    private float ySpawnPos = 0.3f;
    private float zSpawnPos = 10.0f;
    private float xSpawnRange = 12.0f;
    private float lastX;
    [SerializeField] private float spawnDistance = 2.0f;

    private float spawnDelay = 1.0f;
    private float repeatRate = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, repeatRate);
        InvokeRepeating("SpawnObstacle", spawnDelay, repeatRate + 2.0f);
        InvokeRepeating("SpawnMouse", spawnDelay, repeatRate + 5.0f);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(GetValidX(), ySpawnPos, zSpawnPos);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnMouse()
    {
        Vector3 spawnPos = new Vector3(GetValidX(), ySpawnPos, zSpawnPos);

        Instantiate(mouse, spawnPos, Quaternion.identity);
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(GetValidX(), ySpawnPos, zSpawnPos);

        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }

    float GetValidX()
    {
        float randomX;
        do
        {
            randomX = Random.Range(-xSpawnRange, xSpawnRange);
        } while (Mathf.Abs(randomX - lastX) < spawnDistance);

        lastX = randomX;
        return randomX;

    }
}
