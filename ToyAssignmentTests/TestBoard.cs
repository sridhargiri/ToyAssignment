using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.Board;
using ToyAssignment.Board.Interface;
using ToyAssignment.ConsoleChecker.Interface;
using ToyAssignment.Toy;
using ToyAssignment.Toy.Interface;

namespace ToyAssignmentTests
{
    internal class TestBoard
    {
        private Mock<IToyBoard> _toyBoard;

        [SetUp]
        public void TestInitialize()
        {
            this._toyBoard = new Mock<IToyBoard>();

        }
        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestInvalidBoardPosition()
        {

            _toyBoard.Object.Rows = 5;
            _toyBoard.Object.Columns = 5;
            Position position = new Position(6, 6);

            // act
            var result = _toyBoard.Object.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestValidBoardPosition()
        {

            _toyBoard.Object.Rows = 5;
            _toyBoard.Object.Columns = 5;
            Position position = new Position(1, 4);

            // act
            var result = _toyBoard.Object.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }

    }
}
