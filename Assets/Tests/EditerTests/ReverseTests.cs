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
        public void TestBoardHasInitialized() {
            var board = new Board();
            Assert.AreEqual(board.GetColor(Cell.d5), PieceColor.black);
            Assert.AreEqual(board.GetColor(Cell.e4), PieceColor.black);
            Assert.AreEqual(board.GetColor(Cell.d4), PieceColor.white);
            Assert.AreEqual(board.GetColor(Cell.e5), PieceColor.white);
        }

        [Test]
        public void TestPutPieceAlternately() {
            var board = new Board();
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(board.ColorInTurn, PieceColor.white);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(board.ColorInTurn, PieceColor.black);
        }

        [Test]
        public void TestPutPieceOnVacantCell() {
            var board = new Board();
            Assert.False(board.PutPiece(Cell.d4));
            Assert.True(board.PutPiece(Cell.d3));
            Assert.AreEqual(board.GetColor(Cell.d3), PieceColor.black);
            Assert.False(board.PutPiece(Cell.e4));
            Assert.True(board.PutPiece(Cell.c5));
            Assert.AreEqual(board.GetColor(Cell.c5), PieceColor.white);
        }
    }
}
