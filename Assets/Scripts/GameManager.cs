using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameManager : IStartable
{
    private IPiecesPresenter m_PiecesPresenter;
    private IPieceGenerator m_PieceGenerator;
    private IMovableSquareManager m_MovableSquareManager;
    
    [Inject]
    public GameManager(IPieceGenerator generator, IPiecesPresenter piecePresenter,IMovableSquareManager movableSquareManager)
    {
        m_PieceGenerator = generator;
        m_PiecesPresenter = piecePresenter;
        m_MovableSquareManager = movableSquareManager;
    }

    public void Start()
    {
        m_PieceGenerator.SetUp();
        m_PiecesPresenter.SetUpBoard();
        m_MovableSquareManager.SetUp();

        m_PiecesPresenter.RequestMovableSquares.Subscribe(RequestMovableSquares);
        m_PiecesPresenter.CancelPieceClick.Subscribe(CancelPieceClick);
    }

    private void RequestMovableSquares(ClickedData clickedData)
    {
        m_MovableSquareManager.ShowMovableSquares(clickedData);
    }

    private void CancelPieceClick(Unit unit)
    {
        m_MovableSquareManager.HideMovableSquares();
    }
    
}
