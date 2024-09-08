using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using VContainer;

public class PieceGenerator : IPieceGenerator
{
    private List<PieceView> m_PieceViews = new List<PieceView>();

    private List<IPieceView> m_InstancedPieces = new List<IPieceView>();
    
    private Transform m_Parent;
    private PieceView m_PieceViewPrefab;
    
    [Inject]
    public PieceGenerator(PieceView pieceview, Transform parent)
    {
        m_PieceViewPrefab = pieceview;
        m_Parent = parent;
    }

    public void SetUp()
    {
        for (int i = 0; i < Enum.GetValues(typeof(PieceType)).Length; i++)
        {
            if (i == 0) continue; //HACK:PieceType 0番目はNoneのため飛ばす
            PieceView pieceViewInstanced =
                GameObject.Instantiate(m_PieceViewPrefab, Vector3.zero, Quaternion.identity, m_Parent);
            pieceViewInstanced.GetComponent<Image>().sprite = Resources.Load<Sprite>(Consts.PieceImagePaths[i]);
            string name = Enum.GetName(typeof(PieceType),(PieceType)i);
            if (name != null) pieceViewInstanced.gameObject.name = name;
            pieceViewInstanced.SetType((PieceType)i);
            pieceViewInstanced.gameObject.SetActive(false);
            m_PieceViews.Add(pieceViewInstanced);
        }
    }

    public (IPieceView,IPiece) GeneratePiece(PieceType type,PieceOwner owner,Transform parent)
    {
        PieceView pieceView = FindPieceViewByType(type);
        PieceView instancedPieceView = GameObject.Instantiate(pieceView,Vector3.zero,Quaternion.identity,parent);
        if(owner == PieceOwner.Player2) instancedPieceView.transform.rotation = Quaternion.Euler(0, 0, 180);
        instancedPieceView.gameObject.SetActive(true);
        IPieceView instancedView = instancedPieceView;
        m_InstancedPieces.Add(instancedView);
        int id = m_InstancedPieces.Count;
        IPiece pieceModel = null;
        
        switch (type)
        {
            case PieceType.Chick:
            {
                pieceModel = new Chick(id,PieceOwner.None,Vector2Int.zero);
                break;
            }
            case PieceType.Chicken:
            {
                pieceModel = new Chicken(id,PieceOwner.None,Vector2Int.zero);
                break;
            }
            case PieceType.Elephant:
            {
                pieceModel = new Elephant(id,PieceOwner.None,Vector2Int.zero);
                break;
            }
            case PieceType.Giraffe:
            {
                pieceModel = new Giraffe(id, PieceOwner.None, Vector2Int.zero);
                break;
            }
            case PieceType.Lion:
            {
                pieceModel = new Lion(id, PieceOwner.None, Vector2Int.zero);
                break;
            }
        }
        
        instancedView.Initialize(id);
        return (instancedView,pieceModel);
    }

    private PieceView FindPieceViewByType(PieceType pieceType)
    {
        return m_PieceViews.Select(p => p).First(p => p.Type == pieceType);
    }
    
}
