using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text userText;
    [SerializeField] TMP_Text ldUsername, ldScore;

    private void Start()
    {
        string username = PlayerPrefs.GetString("nombreJugador");
        userText.text += $"\n{username}";
    }

    public void UpdateLeaderboard()
    {
        ldUsername.text = PlayerPrefs.GetString("nombreJugador");
        ldScore.text = ScoreCounter.Instance.counterPoints.ToString();
    }
}
