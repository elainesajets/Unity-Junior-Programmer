//using System.Numerics;
using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class SpawnManager : MonoBehaviour
{
    public BoxCollider spawnBox;
    public GameObject beadPrefab;
    public int beadCount;
    public Vector3 spawnArea = new Vector3(5, 0, 5);

    private Difficulty difficulty;

    public void SpawnBeads()
    {
        // Switch expression to determine how many beads to spawn
        beadCount = difficulty switch
        {
            Difficulty.Easy => 5,
            Difficulty.Medium => 20,
            Difficulty.Hard => 30,
            _ => 10
        };

        for (int i = 0; i < beadCount; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(spawnBox.bounds.min.x, spawnBox.bounds.max.x),
                spawnBox.bounds.min.y,
                Random.Range(spawnBox.bounds.min.z, spawnBox.bounds.max.z)
            );

            GameObject bead = Instantiate(beadPrefab, spawnPos, Quaternion.identity);

            ColorSetter setter = bead.GetComponent<ColorSetter>();
            ColorType randomColor = (ColorType)Random.Range(0, 3);
            setter.SetColor(randomColor);
        }

        Debug.Log("Bead count: " + beadCount);
    }

    public void ChangeDifficulty(Difficulty newDifficulty)
    {
        difficulty = newDifficulty;
    }

    public void SetEasy() => ChangeDifficulty(Difficulty.Easy);
    public void SetMedium() => ChangeDifficulty(Difficulty.Medium);
    public void SetHard() => ChangeDifficulty(Difficulty.Hard);
}

