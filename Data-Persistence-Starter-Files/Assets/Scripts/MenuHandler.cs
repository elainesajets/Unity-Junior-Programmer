using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public static class SessionData
{
    public static string PlayerName;
}

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    private string highestScorer;
    private int highestPoints;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI warning;

    public void SaveName(string name)
    {
        SessionData.PlayerName = name;
        Debug.Log(SessionData.PlayerName);
    }

    void Awake()
    {
        var savedData = SaveSystem.Load();

        if (savedData != null && !string.IsNullOrEmpty(savedData.highScoreName))
        {
            highestScorer = savedData.highScoreName;
            highestPoints = savedData.bestScore;

            highScoreText.text = $"Best Score: {highestScorer}: {highestPoints}";
        }
        else
        {
            highScoreText.text = "Best Score: 0";
        }
    }

    public void StartNew()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            warning.gameObject.SetActive(true);
            Debug.Log("Please enter a name");
            return;
        }
        else
        {
            SessionData.PlayerName = nameInput.text;
            SceneManager.LoadScene(1);
        }
    }

    public void OnResetClicked()
    {
        if (GameManager.instance != null) GameManager.instance.ResetData();
        highScoreText.text = "Best Score: 0";

        if (warning.gameObject.activeSelf) warning.gameObject.SetActive(false);

    }

    void OnEnable() { GameManager.OnDataReset += ResetHighScoreText; }
    void OnDisable() { GameManager.OnDataReset -= ResetHighScoreText; }

    public void ResetHighScoreText()
    {
        highScoreText.text = "Best score: 0";
    }
}


