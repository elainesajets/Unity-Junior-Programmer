using UnityEngine;
using System.IO;

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
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }


    }

    public void ResetData()
    {
        string path = Path.Combine(Application.persistentDataPath, "savefile.json");

        if (File.Exists(path))
        {
            SaveSystem.Delete();
            Debug.Log("Deleted save file");
            OnDataReset?.Invoke();
        }
        else
        {
            Debug.Log("No save files");
        }
    }

    public static event System.Action OnDataReset;

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
