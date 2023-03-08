using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ClickObject2 : MonoBehaviour
{
    [SerializeField] RectTransform referencePos;
    private Button thisButton;
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(MoveOnClick);
    }

    void MoveOnClick()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = referencePos.anchoredPosition;
        //gameObject.GetComponent<RectTransform>().anchoredPosition.
    }
}
