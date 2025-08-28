using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Rigidbody objectsRb;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectsRb.AddForce(Vector3.forward * -speed);

    }
}
