using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 10f;
    [SerializeField] float tileLength = 50f;


    void Awake()
    {
        tileLength = GetComponent<Renderer>().bounds.size.z;
    }

    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);

        if (transform.position.z < -tileLength)
        {
            transform.position = Vector3.forward * tileLength * 2f;
        }
    }
}