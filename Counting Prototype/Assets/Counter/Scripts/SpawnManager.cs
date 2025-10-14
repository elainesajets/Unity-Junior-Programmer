//using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public BoxCollider spawnBox;
    public GameObject beadPrefab;
    public int beadCount = 20;
    public Vector3 spawnArea = new Vector3(5, 0, 5);


    void Start()
    {
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
    }
}
