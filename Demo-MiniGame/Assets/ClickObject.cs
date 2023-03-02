using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] Transform gondolaPos;

    private void OnMouseDown()
    {
        transform.DOMove(gondolaPos.position, 1f);
        ScoreCounter.Instance.UpdateScore();
    }
}
