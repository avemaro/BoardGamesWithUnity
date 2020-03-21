using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class ReverseTests {
        [Test]
        public void Test1BoardHasInitialized() {
            var board = new Board();
            Assert.AreEqual(board.GetColor(Cell.d5), PieceColor.black);
            Assert.AreEqual(board.GetColor(Cell.e4), PieceColor.black);
            Assert.AreEqual(board.GetColor(Cell.d4), PieceColor.white);
            Assert.AreEqual(board.GetColor(Cell.e5), PieceColor.white);
        }

        [Test]
        public void Test2PutPieceAlternately() {
            var board = new Board();
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(board.ColorInTurn, PieceColor.white);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
        }

        [Test]
        public void Test3PutPieceOnVacantCell() {
            var board = new Board();
            Assert.False(board.PutPiece(Cell.d4));
            Assert.True(board.PutPiece(Cell.d3));
            Assert.AreEqual(PieceColor.black, board.GetColor(Cell.d3));
            Assert.False(board.PutPiece(Cell.e4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.AreEqual(PieceColor.white, board.GetColor(Cell.c5));
        }

        [Test]
        public void Test4APieceHasReveresed() {
            var board = new Board();
            Assert.True(board.PutPiece(Cell.d3));
            Assert.True(board.IsBlack(Cell.d3));
            Assert.True(board.IsBlack(Cell.d4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.True(board.IsWhite(Cell.c5));
            Assert.True(board.IsWhite(Cell.d5));
        }
    }
}
