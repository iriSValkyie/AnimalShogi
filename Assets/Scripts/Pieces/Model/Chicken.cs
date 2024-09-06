
using UnityEngine;

public class Chicken : BasePiece
{
    private static Vector2Int[] DIRECTIONS =
    {
        PieceDirection.up,PieceDirection.down,PieceDirection.left,PieceDirection.right,
        PieceDirection.upleft,PieceDirection.upright
    };
    
    public Chicken(int id,PieceOwner owner,Vector2Int position) : base(id,owner, DIRECTIONS, position)
    {
        
    }
   
}


