using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 20.0f;
    public float jumpForce = 7f;
    private Rigidbody playerRb;
    private float zBound = 6f;

    private bool isGrounded;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit an enemy");
        }

        if (collision.gameObject.CompareTag("Environment"))
        {
            Debug.Log("Player hit a tree");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Picked up a powerup");
        }
    }

    void MovePlayer()
    {
        // Movement input
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        Vector3 move = new Vector3(horizontal, 0, vertical) * moveSpeed;
        playerRb.linearVelocity = new Vector3(move.x, playerRb.linearVelocity.y, move.z);
        // playerRb.AddForce(Vector3.forward * moveSpeed * vertical);
        // playerRb.AddForce(Vector3.right * moveSpeed * horizontal);


        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}