using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text userText, victoryBannerUser, victoryBannerScore;
    //[SerializeField] TMP_Text ldUsername, ldScore;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] List<AudioClip> clipList;
    [SerializeField] private int victoryCounter = 0;
    [SerializeField] GameObject victoryCanva;
    [SerializeField] GameObject parentSlots;
    [SerializeField] GameObject victoryButton;
    [SerializeField] GameObject buttonNextLevel;
    private static bool doneLevel = false;

    CanvasGroup[] objectsInteractables; 
    public List<RectTransform> tranformsInteractables;
    public List<RectTransform> gondolaExpandibles;

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
        objectsInteractables = parentSlots.transform.GetComponentsInChildren<CanvasGroup>();
        TimeCounter.Instance.StartTimer();
        victoryCounter = parentSlots.transform.childCount;
        string username = PlayerPrefs.GetString("nombreJugador");
        userText.text = $"{username}";
    }

    //public void UpdateLeaderboard()
    //{
    //    ldUsername.text = PlayerPrefs.GetString("nombreJugador");
    //    ldScore.text = ScoreCounter.Instance.counterPoints.ToString();
    //}

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
        foreach (var item in objectsInteractables)
        {
            item.blocksRaycasts = false;
        }
        victoryBannerUser.text = PlayerPrefs.GetString("nombreJugador");
        victoryBannerScore.text = TimeCounter.Instance.scoreUser;
        Leaderboard.Instance.SetLeaderboardEntry(PlayerPrefs.GetString("nombreJugador"), (int)TimeCounter.Instance.timeRunning * -1);
        SoundEffect(2);
        victoryButton.SetActive(true);
        victoryCanva.SetActive(true);
        //if (doneLevel == false) buttonNextLevel.SetActive(true);
        doneLevel = true;
        TimeCounter.Instance.EndTimer();
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
