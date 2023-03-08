using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickButtonEvent : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text counterText;
    private int counter;
    void Start()
    {
        counter = 0;
        counterText.text = "0";
    }

    public void onClickButtonEvent()
    {
        counter++;
        counterText.text = counter.ToString();
    }
}
