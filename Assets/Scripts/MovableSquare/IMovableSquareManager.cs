using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

public interface IMovableSquareManager
{
    public Observable<Vector2Int> ClickMovableSquare { get; }
    public void SetUp();
    
    public void ShowMovableSquares(ClickedData clickedData);
    
    public void HideMovableSquares();
}
