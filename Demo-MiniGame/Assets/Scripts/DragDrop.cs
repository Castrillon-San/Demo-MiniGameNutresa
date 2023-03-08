using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    [NonSerialized] public Vector2 initPosition;
    [NonSerialized] public bool isPlaced = false, wasCorrectAnswer = false;
    private CanvasGroup canvasGroup;
    private ItemSlot refItemSlot;
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").gameObject.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPosition = rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced == true && refItemSlot != null) CorrectMatch(); 
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        isPlaced = false;
        GameManager.Instance.SoundEffect(0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (isPlaced == false)
        { 
            rectTransform.anchoredPosition = initPosition;
            if(refItemSlot != null)
            {
                CorrectMatch();
                refItemSlot = null;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void CorrectMatch()
    {
        refItemSlot.canvaGroup.blocksRaycasts = true;
        if (wasCorrectAnswer == true)
        {
            refItemSlot.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            GameManager.Instance.VictoryCounter(1);
            wasCorrectAnswer = false;
        }
    }


    public void ReceiveItemSlot(ItemSlot currentItemSlot)
    {
        refItemSlot = currentItemSlot;
    }
}
