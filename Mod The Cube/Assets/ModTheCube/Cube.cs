using UnityEngine;
using UnityEngine.AI;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Material material;

    public Vector3 cubePosition = new Vector3(3, 4, 1);
    public Vector3 cubeScale = Vector3.one * 3f;
    private Vector3 targetScale = Vector3.one * 1f;

    public float xAngle = 10.0f;
    public float yAngle = 0.0f;
    public float zAngle = 0.0f;
    public Vector3 currentRotation;

    public Color startColor = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    private Color targetColor;

    public float changeSpeed = 5f;


    void Start()
    {
        transform.position = cubePosition;
        transform.localScale = cubeScale;

        material = Renderer.material;

        material.color = startColor;

        targetColor = new Color(Random.value, Random.value, Random.value, 1f);

        //targetScale = Vector3.one * Random.Range(1f, 3f);
    }

    void Update()
    {
        float random = Random.Range(0f, 1f);
        Debug.Log(random);

        currentRotation = new Vector3(
            xAngle * Time.deltaTime + random,
            yAngle * Time.deltaTime,
            zAngle * Time.deltaTime
        );

        transform.Rotate(currentRotation);

        material.color = Color.Lerp(material.color, targetColor, changeSpeed * Time.deltaTime);

        if (Vector4.Distance(material.color, targetColor) < 0.01f)
        {
            targetColor = new Color(Random.value, Random.value, Random.value, 1f);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * changeSpeed);

        if (Vector3.Distance(transform.localScale, targetScale) < 0.05f)
        {
            Vector3 temp = cubeScale;
            cubeScale = targetScale;
            targetScale = temp;
        }

    }
}
