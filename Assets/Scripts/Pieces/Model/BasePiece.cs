using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasePiece:IPiece
{
    protected Vector2Int m_Position;
    protected Vector2Int[] m_Directions;
    protected PieceOwner m_PieceOwner;
    protected int m_ID;
    
    public int ID => m_ID; 
    public Vector2Int Position => m_Position;
    public Vector2Int[] Directions => m_Directions;
    public PieceOwner PieceOwner => m_PieceOwner;
    
    public BasePiece(int id,PieceOwner owner,Vector2Int[] directions,Vector2Int position)
    {
        m_ID = id;
        m_PieceOwner = owner;
        m_Position = position;
        m_Directions = directions;
    }
    
    public Vector2Int SetPosition(Vector2Int position)
    {
        m_Position = position;
        return m_Position;
    }

    public PieceOwner SetOwner(PieceOwner owner)
    {
        m_PieceOwner = owner;
        return m_PieceOwner;
    }

    public virtual IPiece Promote()
    {
        return null;
    }
}
