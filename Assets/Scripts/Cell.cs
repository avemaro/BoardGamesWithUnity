using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cell {
    a1, b1, c1, d1, e1, f1, g1, h1,
    a2, b2, c2, d2, e2, f2, g2, h2,
    a3, b3, c3, d3, e3, f3, g3, h3,
    a4, b4, c4, d4, e4, f4, g4, h4,
    a5, b5, c5, d5, e5, f5, g5, h5,
    a6, b6, c6, d6, e6, f6, g6, h6,
    a7, b7, c7, d7, e7, f7, g7, h7,
    a8, b8, c8, d8, e8, f8, g8, h8
}

public static class CellExtend {
    public static Cell[] AllCases = (Cell[])Enum.GetValues(typeof(Cell));

    public static Cell? Next(this Cell cell, Direction direction) {
        if (cell.GetFile() == File.a && direction.Pos().x == -1) { return null; }
        if (cell.GetFile() == File.h && direction.Pos().x == 1) { return null; }
        if (cell.GetRank() == Rank.one && direction.Pos().y == 1) { return null; }
        if (cell.GetRank() == Rank.eight && direction.Pos().y == -1) { return null; }
        int nextIndex = (int)cell + (int)direction;
        return (Cell)AllCases.GetValue(nextIndex);
    }

    public static Cell? Next(this Cell cell, Direction direction, int distance) {
        Cell? nextCell = cell;
        for (var i = 0; i < distance; i++) {
            if (nextCell == null) return null;
            nextCell = ((Cell)nextCell).Next(direction);
        }
        return nextCell;
    }

    public enum File { a, b, c, d, e, f, g, h }
    public static File[] fileArray = new File[]
        { File.a, File.b, File.c, File.d, File.e, File.f, File.g, File.h };
    public static File GetFile(this Cell cell) {
        var div = (int)cell % 8;
        return fileArray[div];
    }
    public enum Rank { one, two, three, four, five, six, seven, eight }
    public static Rank[] rankArray = new Rank[]
        {Rank.one, Rank.two, Rank.three, Rank.four, Rank.five, Rank.six, Rank.seven, Rank.eight};
    public static Rank GetRank(this Cell cell) {
        var mod = (int)cell / 8;
        return rankArray[mod];
    }
}