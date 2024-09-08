using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundClicked : MonoBehaviour,IPointerClickHandler,IBackgroundClicked
{
    public Observable<Unit> OnClick => m_OnClick;
    private Subject<Unit> m_OnClick = new Subject<Unit>();
    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnClick.OnNext(Unit.Default);
    }
}
