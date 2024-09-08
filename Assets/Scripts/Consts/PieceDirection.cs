using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDirection
{
    public static Vector2Int up => new(0, 1);
    public static Vector2Int down => new(0, -1);
    public static Vector2Int left => new(-1, 0);
    public static Vector2Int right => new(1, 1);
    public static Vector2Int upleft => new(-1, 1);
    public static Vector2Int upright => new(1, 1);
    public static Vector2Int downleft => new(-1, -1);
    public static Vector2Int downright => new(1, -1);
    
}
