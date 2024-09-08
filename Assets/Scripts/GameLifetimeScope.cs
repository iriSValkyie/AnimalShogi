using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private PieceView m_PieceView;
    [SerializeField] private MovableSquareView m_MovableSquareView;
    [SerializeField] private Transform m_PiecePoolParent;
    [SerializeField] private Transform m_MovablePoolParent;
    [SerializeField] private Transform m_PieceParent;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<IBackgroundClicked>();
        builder.Register<IPieceGenerator,PieceGenerator>(Lifetime.Singleton).WithParameter(m_PieceView).WithParameter(m_PieceParent);
        builder.Register<IPiecesPresenter,PiecesPresenter>(Lifetime.Singleton).WithParameter(typeof(IPieceGenerator)).WithParameter(m_PieceParent);
        builder.Register<IMovableSquareManager,MovableSquareManager>(Lifetime.Singleton).WithParameter(m_MovableSquareView).WithParameter(m_MovablePoolParent).WithParameter(m_PieceParent);
        builder.RegisterEntryPoint<GameManager>(Lifetime.Singleton).WithParameter(typeof(IPieceGenerator)).WithParameter(typeof(IPiecesPresenter)).WithParameter(typeof(IMovableSquareManager));
        
    }
}
