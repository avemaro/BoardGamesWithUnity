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

    Piece GetPiece(Cell? cell) {
        if (cell == null) return null;

        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    public bool PutPiece(Cell cell) {
        if (GetPiece(cell) != null) return false;

        ReversePieces(cell);

        pieces.Add(new Piece(this, ColorInTurn, cell));

        ChangeTurn();
        return true;
    }

    void ReversePieces(Cell nextMove) {
        var pinchedPieces = GetPinchedPieces(nextMove); //打った石と自分の石とで挟んだ相手の石をリストアップする

        foreach (var piece in pinchedPieces) //それらの石を裏返す。
            piece.Reverse();
    }

    List<Piece> GetPinchedPieces(Cell nextMove) {
        var pinchedPieces = new List<Piece>();
        foreach (var direction in Enum.GetValues(typeof(Direction)))
            pinchedPieces.AddRange(GetPinchedPieces(nextMove, (Direction)direction));
        return pinchedPieces;
    }

    List<Piece> GetPinchedPieces(Cell nextMove, Direction direction) {
        var reversiblePieces = new List<Piece>();

        var nextCell = nextMove.Next(direction);   //指定方向の隣のセルを得る
        var nextPiece = GetPiece(nextCell);   //隣の石を得る
        var nextCell2 = nextMove.Next(direction, 2);   //隣の隣のセルを得る
        var nextPiece2 = GetPiece(nextCell2);   //隣の隣の石を得る

        if (nextPiece == null || nextPiece2 == null) return reversiblePieces;

        if (nextPiece.IsOpposite(ColorInTurn)   //隣の石が手番の色と逆で、
            && nextPiece2.IsSame(ColorInTurn)) {   //隣の隣の色が同じなら
            reversiblePieces.Add(nextPiece);  //隣の駒をリストに加える
        }
        return reversiblePieces;
    }

    void ChangeTurn() {
        ColorInTurn = ColorInTurn.ReversedColor();
    }
}

public class Piece {
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public void Reverse() {
        Color = Color.ReversedColor();
    }

    public bool IsSame(PieceColor pieceColor) {
        return pieceColor == Color;
    }

    public bool IsOpposite(PieceColor pieceColor) {
        if (pieceColor == PieceColor.none) return false;
        return pieceColor == Color.ReversedColor();
    }
}