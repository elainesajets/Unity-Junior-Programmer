using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject pauseScreen;
    public GameObject winScreen;

    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI winTotalScore;
    //public GameObject timer;

    private int totalScore;
    private bool isPaused = false;

    public SpawnManager spawnManagerScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !startScreen.activeSelf) PauseUnPause();
        if (totalScore == spawnManagerScript.beadCount && totalScore > 0) Win();

    }

    public void StartGame()
    {
        spawnManagerScript.SpawnBeads();
        startScreen.SetActive(false);
        //timer.SetActive(true);
    }

    // public void GameOver()
    // {
    //     totalScoreText.text = "Final score: " + totalScore;
    //     endScreen.SetActive(true);
    //     timer.SetActive(false);
    // }

    public void Win()
    {
        winTotalScore.text = "Final score: " + totalScore;
        winScreen.SetActive(true);
        //timer.SetActive(false);
    }

    public void RestartGame()
    {
        if (!startScreen.activeSelf)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        //timer.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

}