using UnityEngine;

public class Elephant : BasePiece
{
    private static Vector2Int[] DIRECTIONS = 
    { 
        PieceDirection.upleft, PieceDirection.downleft, PieceDirection.upright, PieceDirection.downright
    };
    
    public Elephant(int id,PieceOwner owner,Vector2Int position) : base(id,owner,DIRECTIONS,position)
    {
        
    }
  
}
