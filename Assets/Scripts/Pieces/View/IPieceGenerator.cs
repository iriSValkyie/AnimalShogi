

using UnityEngine;

public interface IPieceGenerator
{
    public (IPieceView,IPiece) GeneratePiece(PieceType type,PieceOwner owner,Transform parent);

    public void SetUp();
}
