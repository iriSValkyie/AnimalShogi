using System.Collections.Generic;
using R3;
using UnityEngine;

public interface IPieceView
{
    public void Initialize(int id);
    public Observable<int> OnClickPiece { get; }

    public PieceType Type { get; }

    public int ID { get; }

    public void SetPosition(Vector2Int position);

    public void Promotion(Sprite sprite);
}
