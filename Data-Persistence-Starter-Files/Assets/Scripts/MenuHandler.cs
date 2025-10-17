using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif


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

    public void SaveName(string name)
    {
        SessionData.PlayerName = name;
        Debug.Log(SessionData.PlayerName);
    }

    public void StartNew()
    {
        if (nameInput != null) SessionData.PlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ResetData()
    {
        string path = Path.Combine(Application.persistentDataPath, "savefile.json");
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log(path + " deleted");
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

