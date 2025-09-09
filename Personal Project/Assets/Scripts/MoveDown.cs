using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Rigidbody objectsRb;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        objectsRb = GetComponent<Rigidbody>();
        objectsRb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //objectsRb.AddForce(Vector3.forward * -speed);
        objectsRb.linearVelocity = Vector3.forward * -speed;

    }
}
