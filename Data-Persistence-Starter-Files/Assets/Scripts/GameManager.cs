using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void ResetData()
    {
        string path = Path.Combine(Application.persistentDataPath, "savefile.json");

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log(path + " deleted");

            if (SceneManager.GetActiveScene().name == "menu")
            {
                GameObject highScoreDisplay = GameObject.FindWithTag("HighScoreDisplay");
                TextMeshProUGUI tmp = highScoreDisplay.GetComponent<TextMeshProUGUI>();
                tmp.SetText("Best Score: 0");
            }
        }

        else
        {
            Debug.Log("No save file found");
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
