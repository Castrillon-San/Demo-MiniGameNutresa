using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Numerics;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    [NonSerialized] public UnityEngine.Vector2 initPosition;
    [NonSerialized] public bool isPlaced = false, wasCorrectAnswer = false;
    private CanvasGroup canvasGroup;
    private ItemSlot refItemSlot;
    UnityEngine.Vector3 myScale, scaledSize, myVector;
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").gameObject.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform.localScale += new UnityEngine.Vector3(0.3f,0.3f);
        initPosition = rectTransform.anchoredPosition;
        myScale = rectTransform.localScale;
        myVector = new UnityEngine.Vector3(0.3f, 0.3f, 0);
        scaledSize = rectTransform.localScale - myVector;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.gondolaLevel)
        {
            gameObject.transform.parent = GameManager.Instance.interactablesParent.transform; 
            GameManager.Instance.positionedParent.SetActive(false);
            GameManager.Instance.writeZone.text = gameObject.name;
        }
       
        if (isPlaced == true && refItemSlot != null)
        {
            CorrectMatch();
            refItemSlot.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        isPlaced = false;
        rectTransform.localScale = scaledSize;
        GameManager.Instance.SoundEffect(0);

        if (!GameManager.Instance.gondolaLevel) return;
        foreach(RectTransform _object in GameManager.Instance.gondolaExpandibles)
        {
            _object.localScale += new UnityEngine.Vector3(0.5f, 0.5f);
            _object.localPosition += new UnityEngine.Vector3(0, -100f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameManager.Instance.positionedParent.SetActive(true);
        GameManager.Instance.writeZone.text = "";
        if (wasCorrectAnswer == false) rectTransform.localScale = myScale;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (isPlaced == false)
        {
            if (GameManager.Instance.gondolaLevel) gameObject.transform.parent = GameManager.Instance.interactablesParent.transform;
            rectTransform.anchoredPosition = initPosition;
            if(refItemSlot != null)
            {
                CorrectMatch();
                refItemSlot = null;
            }
        }
        if(isPlaced == true)
        {
            rectTransform.localScale = scaledSize;
            if (GameManager.Instance.gondolaLevel) gameObject.transform.parent = GameManager.Instance.positionedParent.transform;
        }
        if (!GameManager.Instance.gondolaLevel) return;
        foreach (RectTransform _object in GameManager.Instance.gondolaExpandibles)
        {
            _object.localScale -= new UnityEngine.Vector3(0.5f, 0.5f);
            _object.localPosition += new UnityEngine.Vector3(0, 100f);
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
            GameManager.Instance.VictoryCounter(1);
            wasCorrectAnswer = false;
        }
    }


    public void ReceiveItemSlot(ItemSlot currentItemSlot)
    {
        refItemSlot = currentItemSlot;
    }
}
