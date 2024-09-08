
using UnityEngine;

public class ClickedData
{
    public int ID { get; private set; }
    
    public PieceOwner Owner { get; private set; }
    public int Row { get;private set; }
    public int Column { get;private set; }
    public Vector2Int[] Directions { get;private set; }

    public ClickedData(int id, PieceOwner owner, int row, int column, Vector2Int[] directions)
    {
        ID = id;
        Owner = owner;
        Row = row;
        Column = column;
        Directions = directions;
    }
}
