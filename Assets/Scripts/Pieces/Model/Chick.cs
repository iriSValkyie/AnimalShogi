
using UnityEngine;

public class Chick : BasePiece
{
    private static Vector2Int[] DIRECTIONS = { PieceDirection.up };
    
    public Chick(int id,PieceOwner owner,Vector2Int position) : base(id,owner,DIRECTIONS,position)
    {
        
    }

    public override IPiece Promote()
    {
        return new Chicken(m_ID,m_PieceOwner, m_Position);
    }
}
