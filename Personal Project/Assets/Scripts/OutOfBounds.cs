using System.IO.Compression;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    private float zbound = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -zbound)
        {
            Destroy(gameObject);
        }
    }
}
