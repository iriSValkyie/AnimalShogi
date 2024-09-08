
using R3;

public interface IPiecesPresenter
{
    public Observable<ClickedData> RequestMovableSquares { get; }
    public Observable<Unit> CancelPieceClick { get; }
    public void SetUpBoard();
}
