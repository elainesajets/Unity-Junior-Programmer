using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;

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
        LoadHighScore();

        if (highestScorer != null)
        {
            highScoreText.text = $"Best Score: {highestScorer} : {highestPoints}";
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
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string highScoreName;
    }

    public void LoadHighScore()
    {
        var path = Path.Combine(Application.persistentDataPath, "savefile.json");
        if (!File.Exists(path)) return;
        var data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
        highestPoints = data.bestScore;
        highestScorer = data.highScoreName;
    }

}


