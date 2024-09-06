
using UnityEngine;

public interface IPiece
{
    public int ID { get; }
    
    public PieceOwner PieceOwner { get; }
    public Vector2Int[] Directions { get; }
    public Vector2Int SetPosition(Vector2Int position);
    public Vector2Int Position { get; }
    public PieceOwner SetOwner(PieceOwner owner);
    public IPiece Promote();
}
