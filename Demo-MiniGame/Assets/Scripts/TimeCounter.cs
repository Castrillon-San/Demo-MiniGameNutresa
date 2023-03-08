using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    private TimeSpan timeSpan;
    [SerializeField] TMP_Text textTimer;
    private bool timerBool;
    private float timeRunning;
    private static string scoreUser;
    public static TimeCounter Instance { get; private set; }
    public static string ScoreUser { set => scoreUser = value; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        timerBool = false;
    }
    void Start()
    {
        
    }
    public void StartTimer()
    {
        timerBool = true;
        timeRunning = 0f;

        StartCoroutine(ActUpdate());
    }
    public void EndTimer()
    {
        timerBool = false;
    }

    private IEnumerator ActUpdate()
    {
        while (timerBool)
        {
            timeRunning += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(timeRunning);
            textTimer.text = timeSpan.ToString(@"mm\:ss");
            scoreUser = textTimer.text;
            yield return null;
        }

    }
}
