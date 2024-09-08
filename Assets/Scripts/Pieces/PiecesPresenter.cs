using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using R3;
public class PiecesPresenter : IPiecesPresenter
{
    
    public Observable<ClickedData> RequestMovableSquares => m_RequestMovableSquares;
    public Observable<Unit> CancelPieceClick => m_CancelPieceClick;
    
    private Subject<ClickedData> m_RequestMovableSquares = new Subject<ClickedData>();
    private Subject<Unit> m_CancelPieceClick = new Subject<Unit>();
    
    private List<List<IPieceView>> m_ViewBoard = new List<List<IPieceView>>();
    private List<List<IPiece>> m_Board = new List<List<IPiece>>();
    
    private IPieceGenerator m_Generator;
    private IMovableSquareManager m_MovableSquareManager;
    private IDisposable m_ClickEventDisposable;
    private Transform m_Parent;
    
    private int m_SelectedPieceID;
    private ClickedData m_SelectedClickData;
    [Inject]
    public PiecesPresenter(IPieceGenerator pieceGenerator, IMovableSquareManager movableSquareManager,Transform parent)
    {
        m_Generator = pieceGenerator;
        m_MovableSquareManager = movableSquareManager;
        m_Parent = parent;
        
    }

    

    public void SetUpBoard()
    {
        for (int i = 0; i < Consts.DEFAULT_BOARD.GetLength(0); i++)
        {
            m_ViewBoard.Add(new List<IPieceView>());
            m_Board.Add(new List<IPiece>());
            PieceOwner owner = PieceOwner.None; 
            if (i < 2)
            {
                owner = PieceOwner.Player2;
            }
            else
            {
                owner = PieceOwner.Player1;
            }

            for (int j = 0; j < Consts.DEFAULT_BOARD.GetLength(1); j++)
            {
                PieceType type = Consts.DEFAULT_BOARD[i, j];
                if (type == PieceType.None)
                {
                    m_ViewBoard[i].Add(null);
                    m_Board[i].Add(null);
                    continue;
                };
                (IPieceView view,IPiece model) = m_Generator.GeneratePiece(type,owner,m_Parent);
                model.SetOwner(owner);
                view.SetPosition(new Vector2Int(Consts.ColumnPositions[j],Consts.RowPositions[i]));
                view.OnClickPiece.Subscribe(OnClickPiece);
                model.SetPosition(new Vector2Int(Consts.ColumnPositions[j],Consts.RowPositions[i]));

                m_ViewBoard[i].Add(view);
                m_Board[i].Add(model);
            }
        }
    }

    private void OnClickPiece(int id)
    {
        if (m_SelectedClickData != null)
        {
            Debug.Log($"Click Canceled piece {id}");
            m_CancelPieceClick.OnNext(Unit.Default);
            m_SelectedClickData = null;
            return;
        }
        Debug.Log($"Clicked piece {id}");
       IPiece clickedPieceView = FindPieceById(id);
       (int row, int column) = GetPieceViewBoardIndex(clickedPieceView);
       if (row == -1 || column == -1) return;
       
       m_SelectedClickData = new ClickedData(id,clickedPieceView.PieceOwner,row, column, clickedPieceView.Directions);
       
       m_RequestMovableSquares.OnNext(m_SelectedClickData);
       m_ClickEventDisposable = m_MovableSquareManager.ClickMovableSquare.Subscribe(OnClickMovePosition);
    }

    private void OnClickMovePosition(Vector2Int direction)
    {
        Debug.Log($"Move piece {direction}");
        if(m_ClickEventDisposable != null) m_ClickEventDisposable.Dispose();
        IPiece piece = FindPieceById(m_SelectedClickData.ID);
        IPieceView pieceView = FindPieceViewById(m_SelectedClickData.ID);
        if(piece == null || pieceView == null) return;
        Vector2Int position 
            = new Vector2Int(Consts.ColumnPositions[m_SelectedClickData.Column + direction.x],
                Consts.RowPositions[m_SelectedClickData.Row - direction.y]);
        piece.SetPosition(position);
        pieceView.SetPosition(position);

        m_SelectedClickData = null;
    }

    private IPiece FindPieceById(int id)
    {
        foreach (var boardRow in m_Board)
        {
            foreach (var boardColumn in boardRow)
            {
                if(boardColumn == null) continue;
                if (boardColumn.ID == id)
                {
                    return boardColumn;
                }
            }
        }

        return null;
    }
    
    private IPieceView FindPieceViewById(int id)
    {
        foreach (var boardRow in m_ViewBoard)
        {
            foreach (var boardColumn in boardRow)
            {
                if(boardColumn == null) continue;
                if (boardColumn.ID == id)
                {
                    return boardColumn;
                }
            }
        }

        return null;
    }

    
    private (int,int) GetPieceViewBoardIndex(IPiece piece)
    {
        int row = 0;
        int column = 0;
        for (int i = 0; i < m_Board.Count; i++)
        {
            row = i;
            for (int j = 0; j < m_Board[i].Count; j++)
            {
                column = j;
                if(m_Board[i][j] == null) continue;
                if(m_Board[i][j].ID == piece.ID) return (row,column);
            }
        }

        return (-1,-1);
    }
}
