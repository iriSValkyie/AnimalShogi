using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : BasePiece
{
    private static Vector2Int[] DIRECTIONS = 
    { 
        PieceDirection.up, PieceDirection.down, PieceDirection.left, PieceDirection.right,
        PieceDirection.upleft, PieceDirection.downleft, PieceDirection.upright, PieceDirection.downright
    };
    
    public Lion(int id,PieceOwner owner,Vector2Int position) : base(id,owner,DIRECTIONS,position)
    {
        
    }
   
}
