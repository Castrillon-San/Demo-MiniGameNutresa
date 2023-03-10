using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.AI;
using System.Reflection;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string publicLeaderboardKey = "";
    [SerializeField] private List<TextMeshProUGUI> names1, names2, winners;
    [SerializeField] private List<TextMeshProUGUI> scores1, scores2, winnersScores;
    private int realListCount;
    public static Leaderboard Instance { get; private set; }
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
    public void Start()
    {
        realListCount = names1.Count + 7;
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
        void TextLoopLeaderboard(int initial, int index, List<TextMeshProUGUI> listUsers, List<TextMeshProUGUI> listScores)
            {
                int counter = 0;
                for (int i = initial; i < index; i++)
                {
                    listUsers[counter].text = msg[i].Username;
                    listScores[counter].text = TimeSpan.FromSeconds((msg[i].Score * -1)).ToString(@"mm\:ss");
                    counter++;
                }
                counter = 0;
            }
            int loopLength = (msg.Length < 9) ? msg.Length : 9;

            if(loopLength <= 3)
            {
                TextLoopLeaderboard(0, loopLength, winners, winnersScores);
            }
            else if(loopLength <= 6)
            {
                TextLoopLeaderboard(0, 3, winners, winnersScores);
                TextLoopLeaderboard(3, loopLength, names1, scores1);
            }
            else if(loopLength <= 9)
            {
                TextLoopLeaderboard(0, 3, winners, winnersScores);
                TextLoopLeaderboard(3, 6, names1, scores1);
                TextLoopLeaderboard(6, loopLength, names2, scores2);
            }
            else
            {
                return;
            }

        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            if (username == "") return;
            GetLeaderboard();
        }));
    }

}
