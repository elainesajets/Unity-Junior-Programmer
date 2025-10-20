using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string PathToFile = Path.Combine(Application.persistentDataPath, "savefile.json");

    public static SaveData Load()
    {
        if (!File.Exists(PathToFile)) return null;
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(PathToFile));
    }

    public static void Save(SaveData data)
    {
        File.WriteAllText(PathToFile, JsonUtility.ToJson(data));
    }

    public static void Delete()
    {
        if (File.Exists(PathToFile)) File.Delete(PathToFile);
    }

}
