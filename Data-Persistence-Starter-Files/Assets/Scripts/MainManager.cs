using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    private int bestScore;
    private string highScoreName;
    public string playerName;

    private bool m_GameOver = false;

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
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_Points > bestScore) UpdateBestScore();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.instance.ResetData();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log(playerName);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    void UpdateBestScore()
    {
        bestScore = m_Points;
        highScoreName = playerName;

        if (HighScoreText != null) HighScoreText.text = $"Best Score: {highScoreName} : {bestScore}";
        //SavePoints();
        SaveSystem.Save(new SaveData
        {
            bestScore = bestScore,
            highScoreName = highScoreName,
            playerName = playerName
        });

    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    // [System.Serializable]
    // class SaveData
    // {
    //     public int bestScore;
    //     public string highScoreName;
    //     public string playerName;
    // }

    // public void SavePoints()
    // {
    //     var data = new SaveData
    //     {
    //         bestScore = bestScore,
    //         highScoreName = highScoreName,
    //         playerName = playerName
    //     };
    //     File.WriteAllText(Path.Combine(Application.persistentDataPath, "savefile.json"),
    //                       JsonUtility.ToJson(data));
    // }

    // public void LoadPoints()
    // {
    //     var path = Path.Combine(Application.persistentDataPath, "savefile.json");
    //     if (!File.Exists(path)) return;
    //     var data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
    //     bestScore = data.bestScore;
    //     highScoreName = data.highScoreName;
    //     playerName = data.playerName;
    // }

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
