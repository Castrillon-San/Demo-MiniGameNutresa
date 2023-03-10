using Dan.Main;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class GetLeaderboard : MonoBehaviour
{
    [SerializeField] private string publicLeaderboardKey = "";
    [SerializeField] private List<TextMeshProUGUI> names1, names2, winners;
    [SerializeField] private List<TextMeshProUGUI> scores1, scores2, winnersScores;

    void Update()
    {
        GetMyLeaderboard();
    }

    public void GetMyLeaderboard()
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

            if (loopLength <= 3)
            {
                TextLoopLeaderboard(0, loopLength, winners, winnersScores);
            }
            else if (loopLength <= 6)
            {
                TextLoopLeaderboard(0, 3, winners, winnersScores);
                TextLoopLeaderboard(3, loopLength, names1, scores1);
            }
            else if (loopLength <= 9)
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
}
