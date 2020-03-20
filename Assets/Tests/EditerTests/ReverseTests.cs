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
            Assert.AreEqual(board.colorInTurn, PieceColor.black);
            board.PutPiece(Cell.d3);
            Assert.AreEqual(board.colorInTurn, PieceColor.white);
            board.PutPiece(Cell.c5);
            Assert.AreEqual(board.colorInTurn, PieceColor.black);
        }
    }
}
