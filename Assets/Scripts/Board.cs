using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board {
    List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public Board() {
        pieces.Add(new Piece(this, PieceColor.black, Cell.d5));
        pieces.Add(new Piece(this, PieceColor.black, Cell.e4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.d4));
        pieces.Add(new Piece(this, PieceColor.white, Cell.e5));
    }

    #region Color
    public PieceColor GetColor(Cell? cell) {
        if (cell == null) return PieceColor.none;

        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }

    public bool IsBlack(Cell? cell) {
        return GetColor(cell) == PieceColor.black;
    }

    public bool IsWhite(Cell? cell) {
        return GetColor(cell) == PieceColor.white;
    }

    public bool IsNone(Cell? cell) {
        return GetColor(cell) == PieceColor.none;
    }
    #endregion

    public Piece GetPiece(Cell? cell) {
        if (cell == null) return null;

        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    public void PutPiece(params Cell[] cells) {
        foreach (var cell in cells)
            PutPiece(cell);
    }

    public bool PutPiece(Cell cell) {
        if (GetPiece(cell) != null) return false;
        var newPiece = new Piece(this, ColorInTurn, cell);
        pieces.Add(newPiece);
        newPiece.Work();

        if (Reverse()) return true;

        pieces.Remove(newPiece);
        return false;
    }

    public bool Check(Cell[] blackCells, Cell[] whiteCells) {
        return false;
    }

    bool Reverse() {
        var result = false;
        foreach (var piece in pieces)
            if (piece.Reverse()) result = true;
        if (result) ChangeTurn();
        return result;
    }

    void ChangeTurn() {
        if (ColorInTurn == PieceColor.black) ColorInTurn = PieceColor.white;
        else if (ColorInTurn == PieceColor.white) ColorInTurn = PieceColor.black;
    }
}