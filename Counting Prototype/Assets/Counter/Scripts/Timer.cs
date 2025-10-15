using UnityEngine;
using TMPro;
using System;

//[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    public float timer = 10f;
    private TextMeshProUGUI timerText;
    public GameObject gameManager;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = "Time: " + Math.Round(timer);

        if (timer <= 0.0f)
        {
            // gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
