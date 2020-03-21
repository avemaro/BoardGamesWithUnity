using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor{
    black, white, none
}

public static class PieceColorExtend {
    public static PieceColor ReversedColor(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return PieceColor.white;
            case PieceColor.white: return PieceColor.black;
        }
        return PieceColor.none;
    }
}