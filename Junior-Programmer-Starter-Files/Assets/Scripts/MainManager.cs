using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    //can set the property value from within he class, but only get from outside the class
    public static MainManager Instance { get; private set; }

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
        Debug.Log($"[SaveColor] Saved to: {path}\n{json}");

    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
            Debug.Log($"[LoadColor] Loaded from: {path}\n{json}");

        }
    }
}
