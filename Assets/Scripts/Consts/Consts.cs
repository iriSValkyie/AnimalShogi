using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consts
{
    public static int MaxDirectionCount = 8;
    
    public static int ColumnCount = 3;
    public static int RowCount = 4;

    public static int[] ColumnPositions = new [] { -211, -4, 205 };
    public static int[] RowPositions = new[] { 313,105,-105,-313 };

    public static string[] PieceImagePaths = new[]
    {
        "",
        "Designs/rion",
        "Designs/chick",
        "Designs/elephant",
        "Designs/giraffe",
        "Designs/chicken"
    };
    
    public static PieceType[,] DEFAULT_BOARD = new PieceType[,] {
        { PieceType.Giraffe, PieceType.Lion, PieceType.Elephant},
        { PieceType.None, PieceType.Chick, PieceType.None },
        { PieceType.None, PieceType.Chick, PieceType.None },
        { PieceType.Elephant, PieceType.Lion, PieceType.Giraffe }
    };
}
