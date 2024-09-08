
using R3;
using UnityEngine;

public interface IMovableSquareView
{
    Observable<Vector2Int> OnClick { get; }
    
    public bool IsVisible { get; }
    public void Show(Vector2Int position,Vector2Int direction);
    public void Hide();
}
