using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Material material;

    private Vector3 cubePosition = new Vector3(0, 0, 0);
    private Vector3 targetPosition;

    public float changeInterval = 2f;
    private float changeTimer = 0f;

    private Vector3 cubeScale = Vector3.one * 3f;
    private Vector3 targetScale = Vector3.one * 1f;

    private Color startColor = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    private Color targetColor;

    public float transformSpeed = 2f; // How fast the color and scale transitions
    public float moveSpeed = 2f; // How fast the cube moves


    void Start()
    {
        transform.position = cubePosition;
        targetPosition = GetNewRandomPosition();

        transform.localScale = cubeScale;

        material = Renderer.material;
        material.color = startColor;
        targetColor = GetNewRandomColor();
    }

    void Update()
    {
        // Change rotation
        float randomSmall = Random.Range(0f, 1f);

        Vector3 currentRotation = new Vector3(10f * Time.deltaTime + randomSmall, 2f * Time.deltaTime + randomSmall, 3f * Time.deltaTime + randomSmall);
        transform.Rotate(currentRotation);

        // Gradually blend to the new color
        material.color = Color.Lerp(material.color, targetColor, transformSpeed * Time.deltaTime);

        // Gradually transition to new size 
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transformSpeed);

        // Timer for changing position, scale and color
        changeTimer += Time.deltaTime;
        if (changeTimer >= changeInterval)
        {
            targetPosition = GetNewRandomPosition();

            targetColor = GetNewRandomColor();

            // Change between two cube sizes
            Vector3 temp = cubeScale;
            cubeScale = targetScale;
            targetScale = temp;

            changeTimer = 0f;
        }

        // Smooth movement toward target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    private Vector3 GetNewRandomPosition()
    {
        Vector3 newPos;
        float setNumber = 10f; // Needs better name

        do
        {
            float randomX = Random.Range(-setNumber, setNumber);
            float randomZ = Random.Range(-setNumber, setNumber);
            float y = transform.position.y; // Fixed y value
            newPos = new Vector3(randomX, y, randomZ);

        } while (Mathf.Abs(newPos.z - transform.position.z) < 5f && (Mathf.Abs(newPos.x - transform.position.x) < 5f));

        return newPos;
    }

    private Color GetNewRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1f);
    }
}
