using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // keeps it between scenes
        }
        else
        {
            Destroy(gameObject); // prevents duplicates
        }
    }
}
