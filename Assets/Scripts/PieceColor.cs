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

    public static bool IsSame(this PieceColor pieceColor, PieceColor other) {
        if (pieceColor == PieceColor.none) return false;
        return pieceColor == other;
    }

    public static bool IsOpposite(this PieceColor pieceColor, PieceColor other) {
        switch (pieceColor) {
            case PieceColor.black: return other == PieceColor.white;
            case PieceColor.white: return other == PieceColor.black;
        }
        return false;
    }

    public static string GetString(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return "B";
            case PieceColor.white: return "W";
        }
        return "*";
    }
}