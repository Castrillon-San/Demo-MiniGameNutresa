using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;
    public int counterPoints = 0;

    public static ScoreCounter Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        //counterText = gameObject.GetComponent<TMP_Text>();
    }

    public void UpdateScore()
    {
        if (counterPoints == 21) return;
        counterPoints += 1;
        counterText.text = $"{counterPoints}";
    }
}
