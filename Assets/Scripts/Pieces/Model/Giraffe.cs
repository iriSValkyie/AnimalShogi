
using UnityEngine;

public class Giraffe : BasePiece
{
    private static Vector2Int[] DIRECTIONS = 
    { 
        PieceDirection.up, PieceDirection.down, PieceDirection.left, PieceDirection.right,
    };
    
    public Giraffe(int id,PieceOwner owner,Vector2Int position) : base(id,owner,DIRECTIONS,position)
    {
        
    }
  
}
