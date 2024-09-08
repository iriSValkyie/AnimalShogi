using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;
using VContainer;

public class MovableSquareManager : IMovableSquareManager
{
    public Observable<Vector2Int> ClickMovableSquare => m_OnClickMovableSquare;
    private Subject<Vector2Int> m_OnClickMovableSquare = new Subject<Vector2Int>();
    
    private MovableSquareView m_MovableSquareView;
    private Transform m_PoolParent;
    
    List<IMovableSquareView> m_Pools = new List<IMovableSquareView>();
    
    List<IDisposable> m_Disposables = new List<IDisposable>();
    
    [Inject]
    public MovableSquareManager(MovableSquareView movableSquareView,Transform poolParent)
    {
        m_MovableSquareView = movableSquareView;
        m_PoolParent = poolParent;
    }

    

    public void SetUp()
    {
        for (int i = 0; i < Consts.MaxDirectionCount; i++)
        {
            MovableSquareView movableSquareView = GameObject.Instantiate(m_MovableSquareView, Vector3.zero, Quaternion.identity, m_PoolParent);
            movableSquareView.gameObject.SetActive(false);
            m_Pools.Add(movableSquareView);
        }
    }

    public void ShowMovableSquares(ClickedData clickedData)
    {
        Vector2Int[] directions = clickedData.Directions;
        for (int i = 0; i < directions.Length; i++)
        {
            Vector2Int direction = directions[i];

            if (clickedData.Owner == PieceOwner.Player2)
            {
                direction.x *= -1;
                direction.y *= -1;
            }
            
            if (clickedData.Column + direction.x > Consts.ColumnCount - 1 ||
                clickedData.Row - direction.y > Consts.RowCount - 1 || 
                clickedData.Row < 0 ||
                clickedData.Column < 0)
            {
                continue;
            }
            
            Vector2Int position 
                = new Vector2Int(Consts.ColumnPositions[clickedData.Column + direction.x],
                    Consts.RowPositions[clickedData.Row - direction.y]);
            
            IMovableSquareView movableSquareView = FindShowableMovableSquare();
            movableSquareView.Show(position,direction);
            IDisposable disposable = movableSquareView.OnClick.Subscribe(OnClickMovableSquareView);
            m_Disposables.Add(disposable);
        }
    }

    private void OnClickMovableSquareView(Vector2Int direction)
    {
        m_OnClickMovableSquare.OnNext(direction);
    }

    private IMovableSquareView FindShowableMovableSquare()
    {
        for (int i = 0; i < m_Pools.Count; i++)
        {
            if(m_Pools[i].IsVisible) return m_Pools[i];
        }
        return null;
    }
    
    public void HideMovableSquares()
    {
        foreach (var pool in m_Pools)
        {
            pool.Hide();
        }
        
        for (int i = 0; i < m_Disposables.Count; i++)
        {
            m_Disposables[i].Dispose();
        }
        m_Disposables.Clear();
    }
    
    
    
}
