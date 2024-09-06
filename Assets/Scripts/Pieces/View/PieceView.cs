using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;

public class PieceView : MonoBehaviour, IPieceView,IPointerClickHandler
{
    public int ID => m_ID;
    public PieceType Type => m_Type;
    public Observable<int> OnClickPiece => m_OnClickPiece;

    private Subject<int> m_OnClickPiece = new Subject<int>();
    private int m_ID;
    private RectTransform m_RectTransform;
    [SerializeField] private Image m_Image;
    private PieceType m_Type = PieceType.None;
    
    
    public void Initialize(int id)
    {
        m_ID = id;
        m_RectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    public void SetType(PieceType type)
    {
        m_Type = type;
    }
    
    public void SetPosition(Vector2Int position)
    {
        m_RectTransform.anchoredPosition = position;
    }

    public void Promotion(Sprite sprite)
    {
        m_Image.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnClickPiece.OnNext(m_ID);
    }
}
