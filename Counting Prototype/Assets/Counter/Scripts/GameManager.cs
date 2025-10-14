using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public Button startButton;
    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject pauseScreen;

    public TextMeshProUGUI totalScoreText;
    public GameObject timer;

    [SerializeField] private int totalScore;
    [SerializeField] private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        timer.SetActive(true);
    }

    public void GameOver()
    {
        totalScoreText.text = "Final score: " + totalScore;
        endScreen.SetActive(true);
        timer.SetActive(false);
    }

    public void RestartGame()
    {
        if (endScreen.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateTotal(int delta)
    {
        totalScore += delta;
        Debug.Log("Total score: " + totalScore);
    }

    public void PauseUnPause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);
        timer.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }


}