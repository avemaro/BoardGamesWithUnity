using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public PieceColor GetColor(Cell? cell) {
        if (cell == Cell.d4) return PieceColor.white;
        if (cell == Cell.e5) return PieceColor.white;
        return PieceColor.black;
    }
}