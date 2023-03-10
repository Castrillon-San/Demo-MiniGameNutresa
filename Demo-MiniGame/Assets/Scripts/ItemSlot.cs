using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string checkTag = "";
    [NonSerialized] public CanvasGroup canvaGroup;
    private void Awake()
    {
        canvaGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragDrop>().isPlaced = true;
            eventData.pointerDrag.GetComponent<DragDrop>().ReceiveItemSlot(this);
            GameManager.Instance.SoundEffect(1);
            canvaGroup.blocksRaycasts = false;
            if (eventData.pointerDrag.gameObject.CompareTag(checkTag))
            {
                    gameObject.GetComponent<Image>().color = Color.green;
                GameManager.Instance.VictoryCounter(-1);
                eventData.pointerDrag.GetComponent<DragDrop>().wasCorrectAnswer = true;
            }
        }

    }
}
