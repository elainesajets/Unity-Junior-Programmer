using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bonesText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] AudioSource backgroundMusic;

    public int lives;
    public int bones;


    public bool isGameActive;
    public bool isGamePaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isGameActive = false;
        isGamePaused = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && isGameActive)
        {
            PauseUnPause();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter pressed");
            if (gameOverScreen.activeSelf) RestartGame();
            if (titleScreen.activeSelf) StartGame();
        }
    }

    public void StartGame()
    {
        if (isGameActive) return;
        isGameActive = true;
        Time.timeScale = 1;
        titleScreen.SetActive(false);
        spawnManager.Spawn();
        lives = 3;
        livesText.text = $"Lives: {lives}";
        livesText.enabled = true;
        bonesText.enabled = true;
        bones = 0;
        bonesText.text = $"Bones: {bones}";

    }

    public void GameOver()
    {
        if (!isGameActive) return;
        isGameActive = false;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }

    void PauseUnPause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : 1;

        if (isGamePaused)
        {
            pauseScreen.SetActive(true);
            backgroundMusic.Pause();

        }
        else
        {
            pauseScreen.SetActive(false);
            backgroundMusic.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateLives(int damage)
    {
        lives -= damage;
        livesText.text = $"Lives: {lives}";

        if (lives <= 0) GameOver();
    }

    public void UpdateBoneCount(int bone)
    {
        bones += bone;
        bonesText.text = $"Bones: {bones}";
    }

}
