using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float maxHeight = 15f;

    private float floatForce = 10f;
    private float gravityModifier = 2f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;




    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        float currentY = transform.position.y;

        if (currentY >= maxHeight && playerRb.linearVelocity.y > 0)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0f, playerRb.linearVelocity.z);
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && currentY < maxHeight)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject, 0.8f);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // if the player collides with the ground, bounce and play sound
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerAudio.PlayOneShot(moneySound, 0.7f);
            // balloon keeps bouncing
            playerRb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

}
