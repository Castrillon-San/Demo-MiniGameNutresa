using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text userText;
    [SerializeField] TMP_Text ldUsername, ldScore;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] List<AudioClip> clipList;
    [SerializeField] private int victoryCounter = 0;
    [SerializeField] GameObject victoryCanva;
    [SerializeField] GameObject parentSlots;
    public static GameManager Instance { get; private set; }
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
    }
    private void Start()
    {
        TimeCounter.Instance.StartTimer();
        victoryCounter = parentSlots.transform.childCount;
        string username = PlayerPrefs.GetString("nombreJugador");
        userText.text += $"\n{username}";
    }

    public void UpdateLeaderboard()
    {
        ldUsername.text = PlayerPrefs.GetString("nombreJugador");
        ldScore.text = ScoreCounter.Instance.counterPoints.ToString();
    }

    public void SoundEffect(int audioIndex)
    {
        audioSrc.clip = clipList[audioIndex];
        audioSrc.Play();
    }

    public void VictoryCounter(int value)
    {
        victoryCounter += value;
        if(victoryCounter == 0)
        {
            Win();
        }
    }


    public void Win()
    {
        Leaderboard.Instance.SetLeaderboardEntry(PlayerPrefs.GetString("nombreJugador"), (int)TimeCounter.Instance.timeRunning * -1);
        SoundEffect(2);
        victoryCanva.SetActive(true);
        TimeCounter.Instance.EndTimer();
    }

}
