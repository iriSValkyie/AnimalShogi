using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovableSquareView : MonoBehaviour,IPointerClickHandler,IMovableSquareView
{
    public Observable<Vector2Int> OnClick => m_OnClick;
    
    public bool IsVisible => !gameObject.activeSelf;


    private Subject<Vector2Int> m_OnClick = new Subject<Vector2Int>();

    private RectTransform m_RectTransform;
    private Vector2Int m_Direction;



    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnClick.OnNext(m_Direction);
    }
    
    public void Show(Vector2Int position,Vector2Int direction)
    {
        if(m_RectTransform == null) m_RectTransform = gameObject.GetComponent<RectTransform>();
        m_RectTransform.anchoredPosition = position;
        m_Direction = direction;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
