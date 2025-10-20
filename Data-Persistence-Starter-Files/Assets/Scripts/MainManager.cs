using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum GameState
{
    WaitingToStart,
    Playing,
    GameOver
}
public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject GameOverText;
    private int m_Points;
    private int bestScore;
    private string highScoreName;
    public string playerName;

    GameState state = GameState.WaitingToStart;


    void Awake()
    {
        var savedData = SaveSystem.Load();
        if (savedData != null)
        {
            bestScore = savedData.bestScore;
            highScoreName = savedData.highScoreName;
            playerName = savedData.playerName;
        }
    }

    void Start()
    {
        if (!string.IsNullOrEmpty(SessionData.PlayerName)) playerName = SessionData.PlayerName;
        Debug.Log("Player name: " + playerName);

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (state == GameState.WaitingToStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = GameState.Playing;
                LaunchBall();
            }
        }
        else if (state == GameState.GameOver)
        {
            HandleGameOverInput();
        }
    }

    void LaunchBall()
    {
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }

    void HandleGameOverInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateBestScore();
            ReloadCurrentScene();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.ResetData();
            ReloadCurrentScene();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateBestScore();
            SceneManager.LoadScene(0);
        }
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    void UpdateBestScore()
    {
        if (m_Points > bestScore)
        {
            bestScore = m_Points;
            highScoreName = playerName;

            if (HighScoreText != null)
                HighScoreText.text = $"Best Score: {highScoreName} : {bestScore}";

            SaveSystem.Save(new SaveData
            {
                bestScore = bestScore,
                highScoreName = highScoreName,
                playerName = playerName
            });
        }

    }

    public void GameOver()
    {
        state = GameState.GameOver;
        GameOverText.SetActive(true);
    }

    void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (HighScoreText == null)
        {
            var go = GameObject.Find("HighScoreText");
            if (go != null) HighScoreText = go.GetComponent<TextMeshProUGUI>();
        }

        if (bestScore > 0)
        {
            HighScoreText.text = $"Best Score: {highScoreName} : {bestScore}";

        }
        else
        {
            HighScoreText.text = $"Best Score: 0";
        }
    }
}
