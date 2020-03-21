using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }
    public bool IsReadyToReverse { get; private set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public void Ready() {
        foreach (var direction in (Direction[])Enum.GetValues(typeof(Direction))) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
        }
    }

    public void ResetState() {
        IsReadyToReverse = false;
    }

    public bool Excute() {
        if (!IsReadyToReverse) return false;
        if (Color == PieceColor.black) Color = PieceColor.white;
        else if (Color == PieceColor.white) Color = PieceColor.black;
        return true;
    }

    void CheckReversible(PieceColor color, Direction direction) {
        if (color.IsSame(Color)) {
            var nextPiece = GetNextPiece(direction.Reverse());
            if (nextPiece == null) return;
            nextPiece.PrepareReverse(color, direction.Reverse());
        } else if (color.IsOpposite(Color)) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) return;
            nextPiece.CheckReversible(color, direction);
        }
    }

    void PrepareReverse(PieceColor color, Direction direction) {
        if (!color.IsOpposite(Color)) return;
        IsReadyToReverse = true;
        var nextPiece = GetNextPiece(direction);
        if (nextPiece == null) return;
        nextPiece.PrepareReverse(color, direction);
    }

    Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        return board.GetPiece(nextCell);
    }
}