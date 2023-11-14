using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyAssignment.Board.Interface;
using ToyAssignment.Toy;
using ToyAssignment.Toy.Interface;

namespace ToyAssignmentTests
{
    public class TestToyRobot
    {
        private Mock<IToyRobot> _toyRobot;

        [SetUp]
        public void TestInitialize()
        {
            this._toyRobot = new Mock<IToyRobot>();

        }
        /// <summary>
        /// Test toy turn left
        /// </summary>
        [Test]
        public void TestValidToyTurnLeft()
        {
            // arrange
            Position pos = new Position(2, 2);
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.South);
            _toyRobot.Setup(x => x.RotateLeft());

            // act
            _toyRobot.Object.RotateLeft();

            // assert
            Assert.AreEqual(Direction.South, _toyRobot.Object.Direction);
        }

        /// <summary>
        /// Test toy turn right
        /// </summary>
        [Test]
        public void TestValidToyTurnRight()
        {
            // arrange
            Position pos = new Position(2, 2);
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.North);
            _toyRobot.Setup(x => x.RotateLeft());

            // act
            _toyRobot.Object.RotateRight();

            // assert
            Assert.AreEqual(Direction.North, _toyRobot.Object.Direction);
        }
        /// <summary>
        /// Test move
        /// </summary>
        [Test]
        public void TestValidToyMove()
        {
            // arrange
            Position pos = new Position(2, 2);
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.East);
            _toyRobot.Setup(x => x.RotateLeft());
            pos = new Position(3, 2);
            _toyRobot.Setup(x => x.GetNextPosition()).Returns(pos);

            // act
            var nextPosition = _toyRobot.Object.GetNextPosition();

            // assert
            Assert.AreEqual(3, nextPosition.X);
            Assert.AreEqual(2, nextPosition.Y);
        }
        /// <summary>
        /// Test set toy position and direction
        /// </summary>
        [Test]
        public void TestValidToyPositionAndDirection()
        {
            // arrange
            Position pos = new Position(3, 3);
            _toyRobot.Setup(x => x.Position).Returns(pos);
            _toyRobot.Setup(x => x.Direction).Returns(Direction.North);


            // act
            _toyRobot.Object.Place(pos, Direction.North);

            // assert
            Assert.AreEqual(3, _toyRobot.Object.Position.X);
            Assert.AreEqual(3, _toyRobot.Object.Position.Y);
            Assert.AreEqual(Direction.North, _toyRobot.Object.Direction);
        }
    }
}
